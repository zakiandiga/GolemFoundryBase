using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Behaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;

    [SerializeField] private Transform targetDestinator;

    private int patrolPoint = 5;

    private bool isPerforming = false;
    private bool hasDestination = false;
    private Vector3 nextDestination;

    private GolemState golemState = GolemState.Greetings;
    public enum GolemState
    {
        Greetings,
        Patrol,        
        Rest,
        Hyper,
        Idle
    }
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //On initiate
        golemState = GolemState.Greetings;
        StartCoroutine(GreetingsBehaviour());

        player = GameObject.FindWithTag("Player");        
        Physics.IgnoreCollision(GetComponentInChildren<MeshCollider>(), player.GetComponent<CharacterController>());

    }

    IEnumerator GreetingsBehaviour()
    {
        //Debug.Log("start greeting");
        float delay = 2f;
        anim.SetTrigger("greetings");

        yield return new WaitForSeconds(delay);

        //Debug.Log("Exit to patrol");
        golemState = GolemState.Patrol;
        StartCoroutine(DestinationDelay());

    }

    IEnumerator DestinationDelay()
    {
        float targetX = Random.Range(-8, 8);
        float targetZ = Random.Range(-8, 8);        

        float delay = Random.Range(1.8f, 3f);
        yield return new WaitForSeconds(delay);

        nextDestination = new Vector3(targetX, targetDestinator.position.y, targetZ);
        golemState = GolemState.Patrol;
        
        SetDestination(nextDestination);
    }

    private void SetDestination(Vector3 destination)
    {
        //Debug.Log("SetDestination() executed");
        hasDestination = true;
        agent.SetDestination(destination);
        //Debug.Log("Set Destination destination to " + nextDestination);
        anim.SetBool("isWalking", true);

    }

    IEnumerator DecisionDelay()
    {        
        float delay = Random.Range(3, 6);
        yield return new WaitForSeconds(delay);
        PerformDecision();
    }

    private void PerformDecision()
    {        
        golemState = (GolemState)Random.Range(1, 3); //doesn't consider Greeting state anymore
        //Debug.Log("exit golemState to " + golemState);
        isPerforming = true;
    }
    
    private void RefreshPatrolPoints(int points)
    {
        patrolPoint += points;
        PerformDecision();
    }

    private void Update()
    {
        

        if (Vector3.Distance(nextDestination, transform.position) < 1f && golemState == GolemState.Patrol)
        {
            
            anim.SetBool("isWalking", false);
            golemState = GolemState.Idle;
            StartCoroutine(DestinationDelay());
        }

        /*
        switch (golemState)
        {
            case GolemState.Greetings:
                //do something
                if(isPerforming)
                {
                    Debug.Log("Play greetings animation");
                    anim.SetTrigger("greetings");
                    StartCoroutine(DecisionDelay());
                    isPerforming = false;
                }                
                break;
            case GolemState.Patrol:
                if(isPerforming)
                {
                    if (Vector3.Distance(nextDestination, transform.position) < 0.5f)
                    {
                        if (hasDestination)
                        {
                            isPerforming = false;
                            hasDestination = false;
                        }
                                                   
                            
                    }

                    if (!hasDestination && patrolPoint > 0)
                    {                        
                        StartCoroutine(DestinationDelay());
                        anim.SetBool("isWalking", false);
                        isPerforming = false;
                    }

                    if (patrolPoint <= 0)
                    {
                        RefreshPatrolPoints(Random.Range(3, 5));                        
                        StartCoroutine(DecisionDelay());
                        anim.SetBool("isWalking", false);
                        isPerforming = false;
                    }
                }
                if(!isPerforming)
                {
                    
                    
                }
                //do something
                break;
            case GolemState.Hyper:
                if(isPerforming)
                {
                    Debug.Log("Behaviour under development");
                    StartCoroutine(DecisionDelay());
                    isPerforming = false;
                }
           
                break;
            case GolemState.Rest:
                //Do something
                if (isPerforming)
                {
                    Debug.Log("Behaviour under development");
                    StartCoroutine(DecisionDelay());
                    isPerforming = false;
                }
                
                break;
        }
        */




    }



}
