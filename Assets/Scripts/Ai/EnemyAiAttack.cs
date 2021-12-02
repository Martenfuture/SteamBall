using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiAttack : MonoBehaviour
{
    [SerializeField] string IdleType;
    [SerializeField] int attackingExitDelay;
    
    private bool playerInRange;
    private bool isFollowing;
    private NavMeshAgent agent;
    private GameObject parent;
    private GameObject player;

    private void Start()
    {
        parent = transform.parent.gameObject;
        agent = parent.GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            StartFollowing();
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(DelayedExit());
    }

    private void Follow()
    {
        agent.SetDestination(player.transform.position);
    }

    private void StartFollowing()
    {
        isFollowing = true;
        switch (IdleType)
        {
            case "random":
                parent.GetComponent<EnemyAiRandom>().isPatroling = false;
                StartCoroutine(FollowCoroutine());
                break;
            case "point":
                parent.GetComponent<EnemyAiPoint>().isPatroling = false;
                StartCoroutine(FollowCoroutine());
                break;
            default:
                Debug.LogError("Ai No Idle Type");
                break;
        }
    }

    private void StartIdle()
    {
        isFollowing = false;
        switch (IdleType)
        {
            case "random":
                parent.GetComponent<EnemyAiRandom>().StartPatroling();
                break;
            case "point":
                parent.GetComponent<EnemyAiPoint>().StartParoling();
                break;
            default:
                Debug.LogError("Ai No Idle Type");
                break;
        }
        
    }

    IEnumerator FollowCoroutine()
    {
        while (isFollowing)
        {
            Follow();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator DelayedExit()
    {
        playerInRange = false;
        yield return new WaitForSeconds(attackingExitDelay);
        if (!playerInRange)
        {
            StartIdle();
        }
    }
}
