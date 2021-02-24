using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private int portalNumber;

    public static event Action<Transform> OnSceneLoaded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        OnSceneLoaded?.Invoke(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
