using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents puzzleButton;
    public static GameEvents interactionControl;
    public static GameEvents killControl;
    private void Awake()
    {
        puzzleButton = this;
        interactionControl = this;
        killControl = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            InteractionEnter();
        }
    }

    public event Action<int> onButtonTriggerEnter;
    public event Action<bool> onToggleControls;
    public event Action onInteractionEnter;
    public event Action onKillEnter;
    public void ButtonTriggerEnter(int id)
    {
        if (onButtonTriggerEnter != null)
        {
            onButtonTriggerEnter(id);
        }
    }

    public void ToggleControls(bool state)
    {
        if (onButtonTriggerEnter != null)
        {
            onToggleControls(state);
        }
    }

    public void InteractionEnter()
    {
        if (onInteractionEnter != null)
        {
            onInteractionEnter();
        }
    }

    public void KillEnter()
    {
        if (onKillEnter != null)
        {
            onKillEnter();
        }
    }

}
