using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    public Action OnLogged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnLogged += LoadGameSceneAsync;
    }

    private void OnDestroy()
    {
        OnLogged -= LoadGameSceneAsync;
    }

    private void LoadGameSceneAsync()
    {
        StartCoroutine(ILoadGameSceneAsync());
    }

    private IEnumerator ILoadGameSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
            yield return null;
    }
}