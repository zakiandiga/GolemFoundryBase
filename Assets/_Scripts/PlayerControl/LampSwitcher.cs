using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.Equipping;

public class LampSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject lamp;

    private void OnEnable()
    {
        CustomEquipper.OnEquipLamp += LampSwitch;
    }

    private void OnDisable()
    {
        CustomEquipper.OnEquipLamp -= LampSwitch;
    }

    private void LampSwitch(string mode)
    {
        switch (mode)
        {
            case "EquipLamp":
                lamp.SetActive(true);
                break;
            case "UnequipLamp":
                lamp.SetActive(false);
                break;
        }
    }
}
