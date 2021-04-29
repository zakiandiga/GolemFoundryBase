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
        [SerializeField] private Item rustyPickaxe;

        public static event Action<string> OnEquipLamp;
        public static event Action<bool> OnToolChecked;

        private void OnEnable()
        {
            GatheringAnnouncer.OnCheckTool += CheckTool;
        }

        private void OnDisable()
        {
            GatheringAnnouncer.OnCheckTool -= CheckTool;
        }

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

                //lamp switch on
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

                //Lamp switch off
                if (item.name == lamp)
                {
                    OnEquipLamp?.Invoke("UnequipLamp");
                }
                UnEquip(i);
                return;
            }

        }

        public void CheckTool(Item item)
        {
            int itemFound = 0;

            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].ItemObject != null && m_Slots[i].ItemObject.Item.ItemDefinition == item.ItemDefinition)
                {
                    itemFound += 1;                   
                }
            }

            if(itemFound > 0)
            {
                Debug.Log("Pickaxe equipped");
                OnToolChecked?.Invoke(true);
            }
            else if (itemFound <= 0)
            {
                Debug.Log("Pickace not equipped!");
                OnToolChecked?.Invoke(false);
            }

        }
    }
}


