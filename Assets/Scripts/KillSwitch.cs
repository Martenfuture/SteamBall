using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public Vector3 LastCheckpoint;
    private void Start()
    {
        LastCheckpoint = transform.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill")
        {
            TeleportToCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            LastCheckpoint = other.gameObject.transform.position;
        } else if (other.tag == "Kill")
        {
            TeleportToCheckpoint();
        }
    }

    void TeleportToCheckpoint ()
    {
        transform.position = LastCheckpoint + new Vector3(0, 1, 0);
    }
}
