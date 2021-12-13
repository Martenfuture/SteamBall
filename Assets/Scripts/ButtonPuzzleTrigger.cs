using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<ButtonPuzzleCore>().PressButton(gameObject);
        }
    }
}
