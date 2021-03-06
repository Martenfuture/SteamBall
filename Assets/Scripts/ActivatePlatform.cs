using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{
    public int PlatformId;
    private void Start()
    {
        GameEvents.puzzleButton.onButtonTriggerEnter += OnPlatformActivate;
    }

    private void OnPlatformActivate(int id)
    {
        if (id == PlatformId)
        {
            if (gameObject.GetComponent<SimplePlatformTutorial>().speed == 0)
            {
                gameObject.GetComponent<SimplePlatformTutorial>().speed = 3;
            } else
            {
                gameObject.GetComponent<SimplePlatformTutorial>().speed = 0;
            }
            
        }
    }
}
