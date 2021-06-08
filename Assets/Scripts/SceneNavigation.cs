using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigation : MonoBehaviour
{
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject signUpScreen;

    public void ShowSignUpScreen()
    {
        signUpScreen.SetActive(true);
        loginScreen.SetActive(false);
    }
}
