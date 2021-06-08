using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class Jar : MonoBehaviour, IPointerClickHandler
{
    public static Jar Instance { get; private set; }

    public Action OnJarClicked;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnJarClicked?.Invoke();
    }
}