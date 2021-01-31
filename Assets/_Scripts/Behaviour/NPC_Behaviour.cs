using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Behaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    private int actionPoint = 5;

    private bool isPerforming = false;

    private GolemState golemState = GolemState.Greetings;
    public enum GolemState
    {
        Greetings,
        Patrol1,
        Patrol2,
        Rest,
        Hyper
    }
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void PerformSwitch()
    {
        golemState = (GolemState)Random.Range(0, 5);

    }

    private void Update()
    {
        if(!isPerforming)
        {
            actionPoint += Random.Range(3, 5);
            isPerforming = true;
            
            PerformSwitch();
        }

        if(actionPoint < 0)
        {
            isPerforming = false;
        }
        



    }



}
