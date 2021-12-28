using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiRandom : MonoBehaviour
{
    public LayerMask whatIsGround;

    [SerializeField] float walkPointRange;

    public bool isPatroling;

    private NavMeshAgent agent;

    private bool walkPointSet;
    private bool walkPointReached;
    private Vector3 walkPoint;

    private Vector3 startPoint;





    void Start()
    {
        startPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(PatroleCoroutine());
    }

    private void Update()
    {
        if (isPatroling && walkPointReached)
        {
            StartCoroutine(PatroleCoroutine());
        }
    }

    private void Patrole()
    {
        while (!walkPointSet)
        {
            FindWalkPoint();
        }

        agent.SetDestination(walkPoint);
        walkPointSet = false;
    }

    IEnumerator PatroleCoroutine()
    {
        walkPointReached = false;
        Patrole();
        yield return new WaitForSeconds(Random.Range(5, 10));
        walkPointReached = true;
    }


    private void FindWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(startPoint.x + randomX, startPoint.y, startPoint.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))    walkPointSet = true;
    }

    public void StartPatroling()
    {
        isPatroling = true;
    }
}
