using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string actionPickaxe;

    public void GatheringPickaxe()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(actionPickaxe, gameObject);
    }

    public void Attack()
    {

    }

    public void Footsteps()
    {

    }
}
