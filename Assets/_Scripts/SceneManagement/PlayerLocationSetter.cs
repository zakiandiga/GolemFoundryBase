using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationSetter : MonoBehaviour
{
    private Transform targetTransform;
    private PlayerMovement playerMovement;

    private bool isRelocating = false;
    private bool isFailed = false;

    public static event Action<PlayerLocationSetter> OnPlayerRelocationSuccess;

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
    }

    private void TryInitialize()
    {
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }

    private void Update()
    {
        if(isRelocating)
        {
            if(transform.position != targetTransform.transform.position)
            {
                TryInitialize();
            }
            else
            {
                isRelocating = false;
                playerMovement.enabled = true;
                OnPlayerRelocationSuccess?.Invoke(this);
            }
        }
    }
}
