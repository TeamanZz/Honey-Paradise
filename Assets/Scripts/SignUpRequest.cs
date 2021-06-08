using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SignUpRequest : MonoBehaviour
{
    public TMP_InputField LoginInput;
    public TMP_InputField PasswordInput;
    [SerializeField] private string url;

    [Header("Только для регистрации!")]
    [SerializeField] private bool IsRegistration;
    public TMP_InputField NicknameInput;

    private WWWForm form;
    private UnityWebRequest postWebRequest;

    public void SendInputFieldsData()
    {
        StartCoroutine(MakePostRequest());
    }

    IEnumerator MakePostRequest()
    {
        AddFieldsInForm();
        InitRequest();
        yield return postWebRequest.SendWebRequest();

        CheckOnRequestResult();
    }

    private void AddFieldsInForm()
    {
        form = new WWWForm();

        if (IsRegistration)
            form.AddField("nickname", NicknameInput.text);

        form.AddField("login", LoginInput.text);
        form.AddField("password", PasswordInput.text);
    }

    private void InitRequest()
    {
        postWebRequest = UnityWebRequest.Post(url, form);
    }

    private void CheckOnRequestResult()
    {
        if (postWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(postWebRequest.error);
            return;
        }

        if (postWebRequest.downloadHandler.text == "true")
            SceneLoader.Instance.OnLogged?.Invoke();
        else
            Notification.Instance.OnWrongEnteredData?.Invoke(postWebRequest.downloadHandler.text);
    }
}