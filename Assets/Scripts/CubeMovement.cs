using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Quaternion rotationOffset;
    private bool playerInRange;
    private bool objectAttacked;
    public GameObject player;
    private Transform startParent;
    private void Start()
    {
        GameEvents.interactionControl.onInteractionEnter += AttachCube;
        if (transform.parent != null)
        {
            startParent = transform.parent.gameObject.transform;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            playerInRange = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    private void AttachCube()
    {
        if (playerInRange && !objectAttacked)
        {
            transform.SetParent(player.transform.parent.GetChild(3));
            transform.localPosition = positionOffset;
            transform.localRotation = rotationOffset;
            GetComponent<BoxCollider>().size = new Vector3(0,0,0);
            GetComponent<Rigidbody>().isKinematic = true;
            objectAttacked = true;
            
        } else if (objectAttacked)
        {
            transform.SetParent(startParent);
            GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            GetComponent<Rigidbody>().isKinematic = false;
            objectAttacked = false;
        }
    }


}
