﻿using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;
using Opsive.UltimateInventorySystem.Input;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //Add character visual game object as a children to the prefab
    //Required cinemachine brain on main camera

    #region InputActionReference
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpControl;
    [SerializeField] private InputActionReference crouchControl;
    [SerializeField] private InputActionReference interactControl;
    [SerializeField] private InputActionReference openMenu;
    [SerializeField] private InputActionReference indoorSwitch;
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

    #endregion

    #region CameraComponent
    private Transform cam;
    //private GameObject cinemachineLock;
    [SerializeField] private CinemachineVirtualCamera directObjCam;
    [SerializeField] private CinemachineVirtualCamera playerLockCam;
    [SerializeField] private CinemachineFreeLook playerFreeCam;
    [SerializeField] private CinemachineFreeLook playerIndoorCam;
    private CinemachineBrain cameraBrain;
    private CinemachineCollider cinemachineCollider;
    #endregion

    #region OtherRequiredComponent
    private CharacterController controller;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI interactSign; //TEMP

    #endregion

    #region ActionAnnouncer
    public static event Action<string> OnOpenMenu; 
    public static event Action<PlayerMovement> OnInteract;
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
        OnObject
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
    }

    private void OnEnable()
    {
        movementControl.action.Enable(); //Enable (and disable) these reference action
        jumpControl.action.Enable();     //Utilize this to activate/deactivate player control
        crouchControl.action.Enable();   //Instead of SetActive the component
        //openMenu.action.Enable();
        interactControl.action.Enable();
        indoorSwitch.action.Enable(); //Temporary indoor switch

        InRangeAnnouncer.OnPlayerInRange += ActivateMenu; //TEMP
        InRangeAnnouncer.OnPlayerOutRange += DeactivateMenu;
        UIS_CustomInput.OnClosingBuildMenu += EnableControl;
        //BuildGolemHandler.OnBuildPressed += EnableControl;
        //UIS_CustomInput.OnBuildTrigger += EnableControl;
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        crouchControl.action.Disable();
        openMenu.action.Disable();
        interactControl.action.Disable();
        indoorSwitch.action.Disable(); //Temporary indoor switch

        InRangeAnnouncer.OnPlayerInRange -= ActivateMenu; //TEMP
        InRangeAnnouncer.OnPlayerOutRange -= DeactivateMenu;
        UIS_CustomInput.OnClosingBuildMenu -= EnableControl;
        //UIS_CustomInput.OnBuildTrigger -= EnableControl;
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

        else
            StartCoroutine(EnableControlDelay());
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

    private void ActivateMenu(string announcer)
    {
        openMenu.action.Enable();
        if(announcer == "MaterialRefill")
        {
            interactSign.text = "[I] Refill material";
        }
        else if(announcer == "GolemPod")
        {
            interactSign.text = "[M] Open Build Menu";
        }
        interactSign.enabled = true;
        
    }

    private void DeactivateMenu(InRangeAnnouncer announcer)
    {
        openMenu.action.Disable();
        interactSign.enabled = false;
    }

    private void DisablingMovement()  //when opening UI
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        crouchControl.action.Disable();
        interactControl.action.Disable();

        openMenu.action.Disable();
    }

    private void EnablingMovement()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        crouchControl.action.Enable();
        interactControl.action.Enable();

        openMenu.action.Enable();
    }

    private void CameraStateSwitch()
    {
        switch(cameraMode)
        {
            case CameraMode.Free:
                playerLockCam.m_Priority = 0;
                directObjCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                playerFreeCam.m_Priority = 1;
                //Debug.Log("CameraMode = " + cameraMode);
                break;
            case CameraMode.LockOn:
                directObjCam.m_Priority = 0;
                playerFreeCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                playerLockCam.m_Priority = 1;
                //Debug.Log("CameraMode = " + cameraMode);
                break;
            case CameraMode.OnObject:
                playerLockCam.m_Priority = 0;
                playerFreeCam.m_Priority = 0;
                playerIndoorCam.m_Priority = 0;
                directObjCam.m_Priority = 1;
                //Debug.Log("CaemraMode = " + cameraMode);
                break;
            case CameraMode.Indoor:
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
        }
        else if(movementState != MovementState.OnMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;  //CURSOR MODE CHECK
            //Cursor.visible = false;
            EnablingMovement();
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
            if(cameraMode != CameraMode.LockOn && cameraMode != CameraMode.OnObject)
            {
                cameraMode = CameraMode.LockOn;
                anim.SetBool("walk", true);
                CameraStateSwitch();
            }               
        }
        else if(crouchControl.action.ReadValue<float>() == 0)
        {
            if(cameraMode != CameraMode.Free && cameraMode != CameraMode.OnObject && cameraMode != CameraMode.Indoor)
            {
                cameraMode = CameraMode.Free;
                anim.SetBool("walk", false);
                CameraStateSwitch();
            }            
        }
        #endregion

        #endregion

        if (openMenu.action.triggered)  //Build Menu Interaction
        {            
            OnOpenMenu?.Invoke("player");
            if(movementState != MovementState.OnMenu)
            {
                movementState = MovementState.OnMenu;

                //cameraMode = CameraMode.OnObject; //temp
                cameraMode = CameraMode.OnObject;

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

        if(interactControl.action.triggered)
        {
            OnInteract?.Invoke(this);
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
