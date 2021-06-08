using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ColorifyText : MonoBehaviour
{
    private string originalWord;
    private string newWord = null;

    private void Start()
    {
    }

    private void ColorifyEverySecondLetter()
    {
        originalWord = GetComponent<TextMeshProUGUI>().text;
        for (int i = 0; i < originalWord.Length; i++)
        {
            string newLetter = Convert.ToString(originalWord[i]);
            if ((i + 1) % 2 == 0)
                newLetter = $"<color=#333333>{newLetter}</color>";
            newWord += newLetter;
        }
        GetComponent<TextMeshProUGUI>().text = newWord;
    }
}
