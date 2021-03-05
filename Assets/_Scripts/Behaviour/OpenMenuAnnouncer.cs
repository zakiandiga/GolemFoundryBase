using System;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuAnnouncer : MonoBehaviour
{
    public static event Action<string> OnMenuInteracting;
    

    public void MenuInteracting(string menuName) //Set menu panel Unique Name in the inspector
    {
        OnMenuInteracting?.Invoke(menuName);
    }
}
