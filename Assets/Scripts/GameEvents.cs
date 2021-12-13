using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents puzzleButton;
    private void Awake()
    {
        puzzleButton = this;
    }

    public event Action<int> onButtonTriggerEnter;
    public void ButtonTriggerEnter(int id)
    {
        if (onButtonTriggerEnter != null)
        {
            onButtonTriggerEnter(id);
        }
    }
}
