using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformTutorial : MonoBehaviour
{

    public
    float speed;

    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float changeDirectionDelay;

    
    private Transform destinationTarget, departTarget;

    private float startTime;

    private float journeyLength;

    bool isWaiting;


    
    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;

        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
    }

   
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {


        if (!isWaiting)
        {
            if (speed != 0)
            {
                if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
                {
                    float distCovered = (Time.time - startTime) * speed;

                    float fractionOfJourney = distCovered / journeyLength;

                    transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
                }
                else
                {
                    isWaiting = true;
                    StartCoroutine(changeDelay());
                }
            } else
            {
                startTime = Time.time;
            }
        }


    }

    void ChangeDestination() //Platform moved zur?ck zum startPoint
    {

        if(departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint; 
        }

    }
    IEnumerator changeDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        ChangeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
    }




    void OnTriggerEnter(Collider other) //Spieler kann auf der Platform stehen      // BoxxCollider muss aktiviert sein //SpielerMUSS Player sein damit funkt
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SetParent(null);
        }
    }

}
