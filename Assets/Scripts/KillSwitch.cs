using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public Vector3 LastCheckpoint;

    private bool setCheckpoint;
    private void Start()
    {
        StartCoroutine(CheckpointCoroutine());
        GameEvents.killControl.onKillEnter += TeleportToCheckpoint;
    }
    private void Update()
    {
        if (setCheckpoint && Vector3.Distance(LastCheckpoint, transform.position) >= 5f)
        {
            StartCoroutine(CheckpointCoroutine());
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill")
        {
            GameEvents.killControl.KillEnter();
        }
    }

    IEnumerator CheckpointCoroutine()
    {
        setCheckpoint = false;
        LastCheckpoint = transform.position;
        yield return new WaitForSeconds(10);
        setCheckpoint = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            LastCheckpoint = other.gameObject.transform.position;
        } else if (other.tag == "Kill")
        {
            GameEvents.killControl.KillEnter();
        }
    }

    IEnumerator KillCoroutine()
    {
        yield return new WaitForSeconds(5);
        TeleportToCheckpoint();
    }

    public void TeleportToCheckpoint ()
    {
        transform.position = LastCheckpoint + new Vector3(0, 1, 0);
    }
}
