using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent activateEvent;
    private bool isActivated;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.tag == "Player")
        {
            activateEvent.Invoke();
            isActivated = true;
        }
    }
}
