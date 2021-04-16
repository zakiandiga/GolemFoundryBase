using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehaviour : MonoBehaviour
{
    public static event Action<string> OnDisappearDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void AppearDone(string panelName)
    {
        
    }

    private void DisappearDone(string panelName)
    {
        Debug.Log(panelName);
        OnDisappearDone?.Invoke(panelName);
    }
}
