using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumberPuzzleCore : MonoBehaviour
{
    public GameObject VisualDisplay;
    public GameObject[] ButtonTrigger;
    public string SolutionNumber;


    public int id;

    public static ButtonPuzzleCore instance;
    private string CurrentButtonNumber = "";
    private TextMeshPro textMeshDisplay;
    private void Start()
    {
        textMeshDisplay = VisualDisplay.GetComponent<TextMeshPro>();
        textMeshDisplay.text = "";
        for (int n = 1; n <= SolutionNumber.Length; n++)
        {
            textMeshDisplay.text += "- ";
        }
    }
    public void PressButton(int ButtonNumber)
    {

        if (CurrentButtonNumber.Length >= (SolutionNumber.Length + 2))
        {
            StartCoroutine(BlinkingCoroutine(Color.red));
        }
        else
        {
            CurrentButtonNumber += ButtonNumber.ToString();
            textMeshDisplay.text = (CurrentButtonNumber);
        }
    }

    public void CheckNumber()
    {
        if (CurrentButtonNumber == SolutionNumber)
        {
            GameEvents.puzzleButton.ButtonTriggerEnter(id);
            textMeshDisplay.color = Color.green;
        }
    }

    public void ResetNumber()
    {
        CurrentButtonNumber = "";
        textMeshDisplay.text = (CurrentButtonNumber);
    }

    IEnumerator BlinkingCoroutine(Color textColor)
    {
        Color colorbefore = textMeshDisplay.color;
        for (int n = 0; n <= 2; n++)
        {
            textMeshDisplay.color = textColor;
            yield return new WaitForSeconds(0.5f);
            textMeshDisplay.color = colorbefore;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
