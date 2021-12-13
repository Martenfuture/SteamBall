using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleCore : MonoBehaviour
{
    public GameObject[] ButtonVisual;
    public GameObject[] ButtonTrigger;

    private int CurrentButtonNumber;

    private void Start()
    {
        GenerateButtonOrder();
        ShowButtonOrder();
    }
    public void PressButton(GameObject Button)
    {
        if (Button == ButtonTrigger[CurrentButtonNumber])
        {
            ButtonVisual[CurrentButtonNumber].SetActive(false);
            if (CurrentButtonNumber != ButtonTrigger.Length - 1)
            {
                CurrentButtonNumber++;
            }
        }
        else
        {
            Debug.Log("Wrong Button");
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
            GameObject showButton = ButtonVisual[n];
            showButton.transform.position += new Vector3(0, 2, 0);
            yield return new WaitForSeconds(2);
            showButton.transform.position += new Vector3(0, -2, 0);
        }
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
