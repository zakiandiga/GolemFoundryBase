using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.UI.CompoundElements;
using PixelCrushers;

public class SaveLoadManual : MonoBehaviour
{
    public ActionButton saveButton;
    public ActionButton loadButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveGame()
    {        
        SaveSystem.SaveToSlot(2);
        Debug.Log("Manual save performed!");
    }

    public void LoadGame()
    {
        SaveSystem.LoadFromSlot(2);
        Debug.Log("Manual load performed!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
