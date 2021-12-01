using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    [SerializeField] float bounceAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                Debug.Log("Found player rigidbody");

                Vector3 bounceDirection = -playerRigidbody.velocity;

                playerRigidbody.AddForce(bounceDirection * bounceAmount);
            }
        }
    }

}
