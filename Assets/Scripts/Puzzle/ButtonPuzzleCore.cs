using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleCore : MonoBehaviour
{
    public GameObject[] ButtonVisual;
    public GameObject[] ButtonTrigger;
    public bool IsRandom;

    public int id;

    public int wrongButtonTries;

    public static ButtonPuzzleCore instance;
    private int CurrentButtonNumber;
    private int wrongButtons;

    private bool buttonsResetet;


    private void Start()
    {
        if (IsRandom) GenerateButtonOrder();
        ShowButtonOrder();
    }
    public void PressButton(GameObject Button)
    {
        if (!buttonsResetet) {
            if (Button == ButtonTrigger[CurrentButtonNumber])
            {
                ButtonVisual[CurrentButtonNumber].GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(0,1,0));
                if (CurrentButtonNumber != ButtonTrigger.Length - 1)
                {
                    CurrentButtonNumber++;
                } else
                {
                    GameEvents.puzzleButton.ButtonTriggerEnter(id);
                }
            }
            else
            {
                StartCoroutine(BlinkingSingleCoroutine(Button));
                Debug.Log("Wrong Button");
                wrongButtons++;
                if (wrongButtons >= wrongButtonTries)
                {
                    resetButtons();
                }
            }
        }
    }

    public void ShowButtonOrder()
    {
        StartCoroutine(BlinkingCoroutine());
    }

    IEnumerator BlinkingCoroutine()
    {
        // needs animation or something cool
        for (int n = 0; n <= ButtonVisual.Length - 1; n++)
        {
            if (buttonsResetet)
            {
                n = ButtonVisual.Length; 
                break;
            }
            GameObject showButton = ButtonVisual[n];
            showButton.GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(1, 0, 0));
            yield return new WaitForSeconds(2);
            showButton.GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(0, 0, 0));
        }
    }

    IEnumerator BlinkingSingleCoroutine(GameObject Button)
    {
        Button.GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(1, 0, 0));
        yield return new WaitForSeconds(2);
        Button.GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(0, 0, 0));
    }

    private void resetButtons()
    {
        buttonsResetet = true;
        wrongButtons = 0;
        CurrentButtonNumber = 0;
        StartCoroutine(BlinkingResetCoroutine());
    }

    IEnumerator BlinkingResetCoroutine()
    {
        for (int n = 0; n <= 5; n++)
        {
            foreach (GameObject showButton in ButtonVisual)
            {
                showButton.GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(1, 0, 0));
            }
            yield return new WaitForSeconds(0.5f);
            foreach (GameObject showButton in ButtonVisual)
            {
                showButton.GetComponent<Renderer>().material.SetVector("Vector3_b506aa2ca3f742a988d071bf89bf80d1", new Vector4(0, 0, 0));
            }
            yield return new WaitForSeconds(0.5f);
        }
        buttonsResetet = false;
        ShowButtonOrder();
    }

    private void GenerateButtonOrder()
    {
        if (ButtonTrigger.Length == ButtonVisual.Length) {
            for (int iterations = 0; iterations <= 4; iterations ++) {
                for (int n = 0; n <= ButtonVisual.Length - 1; n++)
                {
                    int r = Random.Range(1, n);
                    GameObject t = ButtonVisual[r];
                    GameObject s = ButtonTrigger[r];
                    ButtonTrigger[r] = ButtonTrigger[n];
                    ButtonVisual[r] = ButtonVisual[n];
                    ButtonTrigger[n] = s;
                    ButtonVisual[n] = t;
                }
            }
        }
        else
        {
            Debug.LogError("Button Array Diffrent Length");
        }
    }
}
