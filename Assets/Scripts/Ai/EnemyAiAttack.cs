using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiAttack : MonoBehaviour
{
    [SerializeField] string IdleType;
    [SerializeField] int attackingExitDelay;
    [SerializeField] float viewAngle;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;

    [SerializeField] GameObject player;
    
    private bool playerInRange;
    private bool isFollowing;
    private NavMeshAgent agent;
    private GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;
        agent = parent.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
        //Debug.DrawRay(transform.position, transform.forward, Color.red);
        RaycastHit hit;
        Vector3 targetPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
        float angle = Vector3.Angle(transform.forward, targetPosition - enemyPosition);
        if (Physics.Raycast(enemyPosition, targetPosition - enemyPosition, out hit,maxDistance ,layerMask) && hit.transform.gameObject == player && angle < viewAngle)
        {
            StartFollowing();
            playerInRange = true;
        } else if (playerInRange)
        {
            StartCoroutine(DelayedExit());
        }
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
