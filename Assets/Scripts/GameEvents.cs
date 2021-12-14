using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents puzzleButton;
    public static GameEvents interactionControl;
    private void Awake()
    {
        puzzleButton = this;
        interactionControl = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            InteractionEnter();
        }
    }

    public event Action<int> onButtonTriggerEnter;
    public event Action onInteractionEnter;
    public void ButtonTriggerEnter(int id)
    {
        if (onButtonTriggerEnter != null)
        {
            onButtonTriggerEnter(id);
        }
    }

    public void InteractionEnter()
    {
        if (onButtonTriggerEnter != null)
        {
            onInteractionEnter();
        }
    }

}
