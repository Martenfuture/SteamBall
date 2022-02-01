using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPoint : MonoBehaviour
{
    [SerializeField] GameObject[] positions;
    [SerializeField] int waitingTime;

    private NavMeshAgent agent;

    public bool isPatroling;
    private Vector3 walkPoint;
    private int walkPointIndex;
    private bool walkPointReached;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(PatroleCoroutine());
        isPatroling = true;
    }
    private void Update()
    {
        if (isPatroling)
        {
            if (Vector3.Distance(transform.position, walkPoint) < 2 && !walkPointReached)
            {
                walkPointReached = true;
                StartCoroutine(PatroleCoroutine());
            }
        }
    }

    IEnumerator PatroleCoroutine()
    {
        yield return new WaitForSeconds(waitingTime);

        walkPointIndex++;
        if (walkPointIndex == positions.Length)
        {
            walkPointIndex = 0;
        }
        walkPoint = positions[walkPointIndex].transform.position;
        Patrole();
        walkPointReached = false;
    }
    private void Patrole()
    {
        agent.SetDestination(walkPoint);
    }

    public void StartParoling()
    {
        isPatroling = true;
        Patrole();
    }
}
