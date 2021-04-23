namespace Opsive.UltimateInventorySystem.Equipping
{
    using Opsive.Shared.Game;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using UnityEngine;
    using EventHandler = Opsive.Shared.Events.EventHandler;


    public class CustomEquipper : Equipper
    {
        private string lamp = "Lamp"; //Lamp Equipper

        public static event Action<string> OnEquipLamp;
        
        public override bool Equip(Item item)
        {
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].ItemObject != null) { continue; }
                if (m_Slots[i].Category != null && m_Slots[i].Category.InherentlyContains(item) == false) { continue; }

                if (item.name == lamp)
                {
                    OnEquipLamp?.Invoke("EquipLamp");
                }

                return Equip(item, i);
            }

            //Check for any slot (even used ones).
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].Category != null && m_Slots[i].Category.InherentlyContains(item) == false) { continue; }

                //lamp switch
                if (item.name == lamp)
                {
                    OnEquipLamp?.Invoke("EquipLamp");
                }

                return Equip(item, i);
            }

            return false;
        }

        public override void UnEquip(Item item)
        {
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].ItemObject == null || m_Slots[i].ItemObject.Item != item) { continue; }

                if(item.name == lamp)
                {
                    OnEquipLamp?.Invoke("UnequipLamp");
                }
                UnEquip(i);
                return;
            }

        }
    }
}


