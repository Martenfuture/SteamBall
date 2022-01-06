using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPuzzleTrigger : MonoBehaviour
{
    public int Number;
    public bool Reset;
    public bool Check;

    private void OnTriggerEnter(Collider other)
    {
        if (Reset)
        {
            gameObject.GetComponentInParent<NumberPuzzleCore>().ResetNumber();
        } else if (Check)
        {
            gameObject.GetComponentInParent<NumberPuzzleCore>().CheckNumber();
        } else
        {
            gameObject.GetComponentInParent<NumberPuzzleCore>().PressButton(Number);
        }
        
    }
}
