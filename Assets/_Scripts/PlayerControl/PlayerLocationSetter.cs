using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationSetter : MonoBehaviour
{
    private Transform targetTransform;
    private PlayerMovement playerMovement;

    private bool isRelocating = false;
    private bool isFailed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        PlayerSpawner.OnPlayerReadyToMove += SetPlayerSpawn;
    }

    private void OnDisable()
    {
        PlayerSpawner.OnPlayerReadyToMove -= SetPlayerSpawn;
    }

    private void SetPlayerSpawn(Transform spawnerTransform)
    {
        playerMovement.enabled = false;
        isRelocating = true;
        targetTransform = spawnerTransform;
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.localRotation;
        Debug.Log("player target transform = " + spawnerTransform.position);
        Debug.Log("Set player position to " + transform.position);
    }

    private void TryInitialize()
    {
        Debug.Log("Retry relocating!");
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }

    private IEnumerator ForceSpawnPlayer()
    {
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
        while (transform.position != targetTransform.position)
        {
            Debug.Log("Player relocation failed");
            yield return null;           

        }

        playerMovement.enabled = true;
    }

    private void Update()
    {
        if(isRelocating)
        {
            if(transform.position != targetTransform.transform.position)
            {
                Debug.Log("Player relocation failed");
                TryInitialize();
            }
            else
            {
                isRelocating = false;
                playerMovement.enabled = true;
                Debug.Log("Relocation finally success!");
            }
        }
    }
}
