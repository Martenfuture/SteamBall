using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public GameObject LastCheckpoint;

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
            LastCheckpoint = other.gameObject;
        } else if (other.tag == "Kill")
        {
            TeleportToCheckpoint();
        }
    }

    void TeleportToCheckpoint ()
    {
        transform.position = LastCheckpoint.transform.position + new Vector3 (0,1,0);
    }
}
