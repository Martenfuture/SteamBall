using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPuzzleCore : MonoBehaviour
{
    public GameObject VisualDisplay;
    public GameObject[] ButtonTrigger;
    public int SolutionNumber;

    public int id;

    public static ButtonPuzzleCore instance;
    private int CurrentButtonNumber;


    private void Start()
    {
    }
    public void PressButton(GameObject Button, int ButtonNumber)
    {
        if (CurrentButtonNumber.ToString().Length == 1)
        {

        }
    }
}
