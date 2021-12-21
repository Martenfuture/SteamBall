using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePuzzleTrigger : MonoBehaviour
{
    public int TriggerCollider;
    // Needs Juice
    private void OnTriggerEnter(Collider other)
    {
        TriggerCollider++;
        transform.parent.GetComponent<PlatePuzzleCore>().PlateTriggert();
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerCollider--;
    }
}
