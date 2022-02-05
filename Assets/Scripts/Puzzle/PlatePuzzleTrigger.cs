using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePuzzleTrigger : MonoBehaviour
{
    public int TriggerCollider;
    private int id;
    private bool isTriggert;
    private void Start()
    {
        id = transform.parent.GetComponent<PlatePuzzleCore>().id;
    }
    // Needs Juice
    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggert)
        {
            GameEvents.puzzleButton.ButtonTriggerEnter(id);
            isTriggert = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isTriggert)
        {
            GameEvents.puzzleButton.ButtonTriggerEnter(id);
            isTriggert = false;
        }
    }
}
