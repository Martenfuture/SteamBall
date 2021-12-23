using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePuzzleCore : MonoBehaviour
{
    [SerializeField] GameObject[] PlateTrigger;
    public int id;

    private bool allTriggert;
    public void PlateTriggert()
    {
        allTriggert = true;
        foreach (GameObject plate in PlateTrigger)
        {
            if (plate.GetComponent<PlatePuzzleTrigger>().TriggerCollider <= 0)
            {
                allTriggert = false;
            } 
        }

        if (allTriggert)
        {
            GameEvents.puzzleButton.ButtonTriggerEnter(id);
        }
    }
}
