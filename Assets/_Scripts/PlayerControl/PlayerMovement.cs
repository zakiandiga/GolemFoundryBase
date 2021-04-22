using Cinemachine;
using Opsive.UltimateInventorySystem.Input;
using Opsive.UltimateInventorySystem.Interactions; //TEST
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(InventoryInteractor))]
public class PlayerMovement : MonoBehaviour //only use Interact() from InventoryInput
{
    //Add character visual game object as a children to the prefab
    //Required cinemachine brain on main camera
    #region CameraComponent
    private Transform cam;
    //private GameObject cinemachineLock;
    [SerializeField] private CinemachineVirtualCamera titleScreenCam;
    [SerializeField] private CinemachineVirtualCamera directObjCam;
    [SerializeField] private CinemachineVirtualCamera playerLockCam;
    [SerializeField] private CinemachineFreeLook playerFreeCam;
    [SerializeField] private CinemachineFreeLook playerIndoorCam;
    private CinemachineBrain cameraBrain;
    private CinemachineCollider cinemachineCollider;
    #endregion

    #region InputActionReference
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpControl;
    [SerializeField] private InputActionReference attackControl;
    [SerializeField] private InputActionReference crouchControl;
    [SerializeField] private InputActionReference interactControl;
    [SerializeField] private InputActionReference openMenu;
    [SerializeField] private InputActionReference indoorSwitch;
    //private InputActionReference lookAxis;
    #endregion

    #region MovementVariables
    public Transform groundChecker;
    public float groundCheckerRadius = 0.4f;
    public LayerMask groundMask;
    private bool groundedPlayer;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -100f;
    [SerializeField] private float rotationSpeed = 4f;
    private float jumpConst = -3.0f;
    private Vector3 playerVelocity;
    private Vector2 movement;
    private Transform spawnTransform;

    #endregion

    #region ActionProperties
    private bool canAttack = true;
    private float attackDelay = 1.2f; //modified from PlayerStat component
    #endregion

    #region OtherRequiredComponent
    private CharacterController controller;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI interactSign; //TEMP
    private GameObject currentInteractable;
    [SerializeField] private InventoryInteractor inventoryInteractor; //Manual InventoryInteractor input

    #endregion

    #region ActionAnnouncer
    public static event Action<string> OnOpenMenuFromInteract; //Might not needed later
    public static event Action<string> OnOpenInventoryMenu;
    public static event Action<GameObject> OnInteract;
    public static event Action<PlayerMovement> OnAttack;
    #endregion

    #region PlayerState
    private MovementState movementState = MovementState.Idle;
    public enum MovementState 
    {
        Move,
        Crouch,
        Idle,
        Jump,
        OnMenu,
        OnCutscene
    }    
    #endregion

    #region CameraMode
    private CameraMode cameraMode = CameraMode.Free;
    public enum CameraMode
    {
        Free,
        LockOn,
        Cutscene,
        Indoor,
        OnObject,
        TitleScreen,
    }
    #endregion

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;
        cinemachineCollider = playerFreeCam.GetComponent<CinemachineCollider>();
        cameraBrain = cam.GetComponent<CinemachineBrain>();

        //InventoryUI.OnAssembling += AssemblingControl;
        //Cursor.lockState = CursorLockMode.Locked;  //CURSOR MODE CHECK
        //Cursor.visible = false;
        interactSign.enabled = false; //TEMP

        controller.enabled = false; //Set CC false on start menu
        movementState = MovementState.OnMenu; //(Start menu)
        cameraMode = CameraMode.TitleScreen;
        //CameraStateSwitch();
        
    }

    private void OnEnable()
    {
        //SceneHandler.OnGameLoaded += GameLoadControlEnable;
        InRangeAnnouncer.OnPlayerInRange += RegisterInteractable; //TEMP
        InRangeAnnouncer.OnPlayerOutRange += DeactivateMenu;

        OpenMenuAnnouncer.OnMenuInteracting += OpenMenuFromInteract;

        PlayerLocationSetter.OnPlayerRelocationSuccess += EnableControl;

        UIS_CustomInput.OnClosingMenu += EnableControl; //REMOVE LATER
        MenuControl.OnClosingMenuNEW += EnableControl;

        //PlayerSpawner.OnPlayerReadyToMove += SetPlayerSpawn;
        //BuildGolemHandler.OnBuildPressed += EnableControl;
        //UIS_CustomInput.OnBuildTrigger += EnableControl;
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        attackControl.action.Disable();
        crouchControl.action.Disable();
        openMenu.action.Disable();
        interactControl.action.Disable();
        indoorSwitch.action.Disable(); //Temporary indoor switch
        playerFreeCam.GetComponent<CinemachineInputProvider>().XYAxis.action.Disable();

        //SceneHandler.OnGameLoaded -= GameLoadControlEnable;

        InRangeAnnouncer.OnPlayerInRange -= RegisterInteractable; //TEMP
        InRangeAnnouncer.OnPlayerOutRange -= DeactivateMenu;

        OpenMenuAnnouncer.OnMenuInteracting -= OpenMenuFromInteract;

        PlayerLocationSetter.OnPlayerRelocationSuccess -= EnableControl;

        UIS_CustomInput.OnClosingMenu -= EnableControl; //REMOVE LATER
        MenuControl.OnClosingMenuNEW -= EnableControl;

    }


    private void GameLoadControlEnable(SceneHandler s)
    {
        controller.enabled = true;

        EnableControl("TitleScreen");
        Debug.Log("GameLoadControlEnable() called here");
    }

    private void EnableControl(string announcer)
    {
        if(announcer == "BlueprintOption")
        {
            movementState = MovementState.Idle;
            cameraMode = CameraMode.Free;
            CameraStateSwitch();
            MenuControlSwitch("BlueprintMenu");
        }

        if(announcer == "InventoryMenu")
        {
            movementState = MovementState.Idle;
            MenuControlSwitch("InventoryMenu");
        }

        if(announcer == "CraftingMenu")
        {
            movementState = MovementState.Idle;
            MenuControlSwitch("CraftingMenu");
        }
        
        if (announcer == "TitleScreen")
        {
            movementState = MovementState.Idle;
            MenuControlSwitch("TitleScreen");
        }
        
        if(announcer == "PlayerRelocationSetter")
        {
            if(cameraMode == CameraMode.TitleScreen)
            {
                cameraMode = CameraMode.Free;
                CameraStateSwitch();
            }

            if(controller.enabled == false)
            {
                controller.enabled = true;
            }
            EnablingMovement();
        }

        /*
        else
            StartCoroutine(EnableControlDelay());
        */
    }

    IEnumerator EnableControlDelay()
    {
        float delay = 1.2f;
        yield return new WaitForSeconds(delay);

        movementState = MovementState.Idle;
        cameraMode = CameraMode.Free;

        CameraStateSwitch();

        MenuControlSwitch("nonPlayer");
    }

    private void RegisterInteractable(GameObject announcer) //this should be binded to the target instead of player
    {
        
        currentInteractable = announcer;
        //Debug.Log("Can interact with " + currentInteractable.name);

    }

    private void DeactivateMenu(GameObject announcer)  //this should be binded to the target instead of player
    {
        if(currentInteractable == announcer)
        {
            currentInteractable = null;
        }
        //Debug.Log("current interactable object is " + currentInteractable.name);
    }

    private void DisablingMovement()  //when opening UI
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        attackControl.action.Disable();
        crouchControl.action.Disable();
        interactControl.action.Disable();
        indoorSwitch.action.Disable(); //Temporary indoor switch

        openMenu.action.Disable();
        playerFreeCam.GetComponent<CinemachineInputProvider>().XYAxis.action.Disable(); //Not working
    }

    private void EnablingMovement()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        attackControl.action.Enable();
        crouchControl.action.Enable();
        interactControl.action.Enable();
        indoorSwitch.action.Enable(); //Temporary indoor switch

        openMenu.action.Enable();
        playerFreeCam.GetComponent<CinemachineInputProvider>().XYAxis.action.Enable();
    }

    private void CameraStateSwitch()
    {
        switch(cameraMode)
        {
            case CameraMode.TitleScreen:                
                playerLockCam.m_Priority = 0;
                directObjCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                playerFreeCam.m_Priority = 0;
                titleScreenCam.m_Priority = 1;
                break;
            case CameraMode.Free:
                titleScreenCam.m_Priority = 0;
                playerLockCam.m_Priority = 0;
                directObjCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                playerFreeCam.m_Priority = 1;                
                //Debug.Log("CameraMode = " + cameraMode);
                break;
            case CameraMode.LockOn:
                titleScreenCam.m_Priority = 0;
                directObjCam.m_Priority = 0;
                playerFreeCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                playerLockCam.m_Priority = 1;
                //Debug.Log("CameraMode = " + cameraMode);
                break;
            case CameraMode.OnObject:
                titleScreenCam.m_Priority = 0;
                playerLockCam.m_Priority = 0;
                playerFreeCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                directObjCam.m_Priority = 1;
                //Debug.Log("CaemraMode = " + cameraMode);
                break;
            case CameraMode.Indoor:
                titleScreenCam.m_Priority = 0;
                playerFreeCam.m_Priority = 0;
                playerLockCam.m_Priority = 0;
                directObjCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 1;
                //Debug.Log("CameraMode = " + cameraMode);
                break;
        }        
    }

    private void MenuControlSwitch(string source)
    {
        if(movementState == MovementState.OnMenu)
        {
            Cursor.lockState = CursorLockMode.Confined;  //CURSOR MODE CHECK
            //Cursor.visible = true;
            DisablingMovement();
            Debug.Log("PlayerControl Disabled: " + movementState);
        }
        else if(movementState != MovementState.OnMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;  //CURSOR MODE CHECK
            //Cursor.visible = false;
            EnablingMovement();
            Debug.Log("PlayerControl Enabled: " + movementState);
        }
    }

    /*
    private void AssemblingControl(InventoryUI ui)
    {
        if (cameraMode == CameraMode.OnObject)
        {
            cameraMode = CameraMode.Free;
        }
        else
        {
            cameraMode = CameraMode.OnObject;
        }
        CameraStateSwitch();       
    }
    */

    private void OpenMenuFromInteract(string menu)
    {
        if(menu == "TitleScreen")
        {
            if(movementState != MovementState.OnMenu)
            {
                movementState = MovementState.OnMenu;

                //directObjCam.transform = 
                cameraMode = CameraMode.TitleScreen;
            }
        }

        if(menu == "BuildingMenu")
        {
            OnOpenMenuFromInteract?.Invoke("BuildingMenu");
            if (movementState != MovementState.OnMenu)
            {
                movementState = MovementState.OnMenu;

                cameraMode = CameraMode.OnObject; //Temp, camera should define what object to lookAt
            }
            else
            {

                if (cameraMode == CameraMode.OnObject)
                {
                    cameraMode = CameraMode.Free;
                }
                movementState = MovementState.Idle;
            }

            CameraStateSwitch();

            MenuControlSwitch("player");
        }

        if(menu == "CraftingMenu")
        {
            OnOpenMenuFromInteract?.Invoke("CraftingMenu");
            if(movementState != MovementState.OnMenu)
            {
                movementState = MovementState.OnMenu;

                //set camera state later!
            }
            else
            {
                //camera mode if handler (see "BuildingMenu")
                movementState = MovementState.Idle;
            }

            //CameraStateSwitch(); //COMMENT THIS OUT AFTER THE MENU ESTABLISHED
            MenuControlSwitch("player");
        }
    }

    private void AttackAction()
    {
        //Set attack animation based on equipment state
        StartCoroutine(AttackDelay());
        inventoryInteractor.Interact();
        OnAttack?.Invoke(this); //Might be used for mining pickup interactable
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    void Update()
    {
        #region Movement

        //groundedPlayer = controller.isGrounded;
        groundedPlayer = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, groundMask);

        if (groundedPlayer && playerVelocity.y < 0)
        {            
            playerVelocity.y = -2;
            //anim.SetFloat("vSpeed", 0);
            //anim.SetBool("jump", false);
        }

        movement = movementControl.action.ReadValue<Vector2>();
                
        #region MovementState
        //MovementStateHandler
        if (movement != Vector2.zero)
        {
            if (movementState != MovementState.Move)
            {
                movementState = MovementState.Move;
                anim.SetBool("run", true);
                anim.SetFloat("forward", movement.y);
                anim.SetFloat("right", movement.x);
            }
        }
        if(movement == Vector2.zero && movementState != MovementState.OnMenu)
        {
            if(movementState != MovementState.Idle)
            {
                movementState = MovementState.Idle;
                anim.SetBool("run", false);                
            }            
        }
        #endregion

        Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
        moveDirection = cam.forward * moveDirection.z + cam.right * moveDirection.x;                    
        moveDirection.y = 0f;
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);
        
        // Changes the height position of the player.
        if (jumpControl.action.triggered && groundedPlayer)
        {            
            playerVelocity.y += Mathf.Sqrt(jumpHeight * jumpConst * gravityValue);
            //groundedPlayer = controller.isGrounded;
            //anim.SetBool("jump", true);
            movementState = MovementState.Jump;
        }

        //Default gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        //anim.SetFloat("vSpeed", playerVelocity.y);
        controller.Move(playerVelocity * Time.deltaTime);

        #region Attack
        if(attackControl.action.ReadValue<float>() !=0)
        {
            if(canAttack)
            {                
                AttackAction();
                canAttack = false;
            }
        }
        #endregion

        #region FaceDirection        
        if (movementState == MovementState.Move) 
        {
            float targetAngle = 0f;
            if (cameraMode == CameraMode.Free || cameraMode == CameraMode.Indoor)
            {
                targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }
            else if (cameraMode == CameraMode.LockOn)
            {
                targetAngle = cam.eulerAngles.y;
            }

            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        } 
        #endregion

        #region LockOn/Crouch
        if (crouchControl.action.ReadValue<float>() != 0)
        {
            if(cameraMode != CameraMode.LockOn && cameraMode != CameraMode.OnObject && cameraMode != CameraMode.TitleScreen)
            {
                cameraMode = CameraMode.LockOn;
                anim.SetBool("walk", true);
                CameraStateSwitch();
            }               
        }
        else if(crouchControl.action.ReadValue<float>() == 0)
        {
            if(cameraMode != CameraMode.Free && cameraMode != CameraMode.OnObject && cameraMode != CameraMode.Indoor && cameraMode != CameraMode.TitleScreen)
            {
                cameraMode = CameraMode.Free;
                anim.SetBool("walk", false);
                CameraStateSwitch();
            }            
        }
        #endregion

        #endregion



        if(openMenu.action.triggered)
        {
            if(movementState != MovementState.OnMenu)
            {
                movementState = MovementState.OnMenu;
                OnOpenInventoryMenu?.Invoke("player");
                MenuControlSwitch("Inventory Menu");
            }            
        }

        if(interactControl.action.triggered)
        {
            inventoryInteractor.Interact();
        }

        //Temporary camera switch
        if (indoorSwitch.action.triggered)
        {
            if(cameraMode != CameraMode.Indoor)
            {
                cameraMode = CameraMode.Indoor;
                CameraStateSwitch();
                
            }

            else
            {
                cameraMode = CameraMode.Free;
                CameraStateSwitch();
            }

        }        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
