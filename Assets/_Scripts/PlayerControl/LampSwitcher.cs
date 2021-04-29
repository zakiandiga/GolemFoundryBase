using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.Equipping;

public class LampSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject lamp;

    public bool lampEquipped = false;
    public bool lampOn = false;

    private void OnEnable()
    {
        CustomEquipper.OnEquipLamp += LampSwitch;
    }

    private void OnDisable()
    {
        CustomEquipper.OnEquipLamp -= LampSwitch;
    }

    public void LampOn()
    {
        if (!lampOn && lampEquipped)
        {
            lampOn = true;
            lamp.SetActive(true);
        }
    }

    public void LampOff()
    {
        if(lampOn)
        {
            lampOn = false;
            lamp.SetActive(false);
        }
    }

    public void LampSwitch()
    {
        if (!lampOn)
        {
            if (lampEquipped)
            {
                lampOn = true;
                lamp.SetActive(true);
            }
        }

        else if (lampOn)
        {
            lamp.SetActive(false);
            lampOn = false;
        }
            
    }

    private void LampSwitch(string mode)
    {
        switch (mode)
        {
            case "EquipLamp":
                lampEquipped = true;
                LampSwitch();
                break;
            case "UnequipLamp":
                lampEquipped = false;
                LampSwitch();
                break;
        }
    }
}
