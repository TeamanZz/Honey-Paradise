using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Notification : MonoBehaviour
{
    public static Notification Instance { get; private set; }
    public Action<string> OnWrongEnteredData;

    [SerializeField] private TextMeshProUGUI wrongDataText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnWrongEnteredData += ShowErrorMessage;
    }

    private void OnDestroy()
    {
        OnWrongEnteredData -= ShowErrorMessage;
    }

    private void ShowErrorMessage(string errorMessage)
    {
        DetermineError(errorMessage);
        ShowWrongEnteredDataNotification();
    }

    private void DetermineError(string errorMessage)
    {
        Debug.Log(errorMessage);
        switch (errorMessage)
        {
            case "signupFalseResponse":
                wrongDataText.text = "Пользователь с таким логином уже существует!";
                break;
            case "false":
                wrongDataText.text = "Ошибка базы данных!";
                break;
            case "passwordNotVerify":
                wrongDataText.text = "Пароль не подходит!";
                break;
            case "emptyLogin":
                wrongDataText.text = "Логин пуст!";
                break;
        }
    }

    private void ShowWrongEnteredDataNotification()
    {
        StartCoroutine(IShowWrongEnteredDataNotification());
    }

    private IEnumerator IShowWrongEnteredDataNotification()
    {
        wrongDataText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        wrongDataText.gameObject.SetActive(false);
    }
}
