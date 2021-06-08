using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class JarView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image jarFilledImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        DOTween.To((float val) => { jarFilledImage.fillAmount = val; }, jarFilledImage.fillAmount, jarFilledImage.fillAmount + 0.05f, 0.25f);
        transform.DOPunchScale(new Vector3(-0.01f, -0.01f, -0.01f), 0.25f, 10, 0.5f);

        if (jarFilledImage.fillAmount >= 0.98f)
        {
            transform.DOShakeRotation(1, 40, 9, 70, true);
            DOTween.To(() => transform.localScale, x => transform.localScale = x, new Vector3(1, 1, 1), 1);
            LeanTween.value(1f, 0, 1f).setOnUpdate((float val) => { jarFilledImage.fillAmount = val; Debug.Log(val); });
        }

    }
}
