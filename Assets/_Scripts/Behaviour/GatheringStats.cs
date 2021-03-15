using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.DropsAndPickups;

public class GatheringStats : RandomInventoryPickup
{     
    public void Gathering()
    {
        //trigger gathering animation on player
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public override void Deactivate()
    {
        Debug.Log("Gathering Iron ore");
        //gameObject.SetActive(false);
        
        //OnDeselect();
        
        ObjectPooler.Instance.ReturnToPool(this.gameObject);
        m_Interactable.SetIsInteractable(false);


    }
    
}
