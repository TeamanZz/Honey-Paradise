using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class HoneyCounter : MonoBehaviour
{
    [SerializeField] private int honeyCount;
    [SerializeField] private int honeyPerClick;

    private Action<int> ChangeHoneyCountText;
    private Jar _jar;

    [Inject]
    private void Construct(HoneyCounterView honeyCounterView, Jar jar)
    {
        ChangeHoneyCountText = honeyCounterView.ChangeHoneyCountText;

        _jar = jar;
        _jar.OnJarClicked += IncreaseHoneyCount;
    }

    private void OnDestroy()
    {
        _jar.OnJarClicked -= IncreaseHoneyCount;
    }

    private void IncreaseHoneyCount()
    {
        honeyCount += honeyPerClick;
        ChangeHoneyCountText(honeyCount);
    }
}