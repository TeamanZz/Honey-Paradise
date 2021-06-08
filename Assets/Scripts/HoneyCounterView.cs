using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoneyCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI honeyCounterText;

    public void ChangeHoneyCountText(int newHoneyValue)
    {
        honeyCounterText.text = $"капли:  {newHoneyValue}";
    }
}
