using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    public int DoorId;
    private bool isOpened;
    private void Start()
    {
        GameEvents.puzzleButton.onButtonTriggerEnter += OnPlatformActivate;
    }

    private void OnPlatformActivate(int id)
    {
        if (id == DoorId)
        {
            transform.parent.transform.RotateAround(transform.position, transform.up, -90f);
        }
    }
}
