using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    private GameObject creditsUI;

    private void Awake()
    {
        creditsUI = GameObject.FindWithTag("CreditUI");
    }

    public void OpenCredits(bool openMenu)
    {
        creditsUI.SetActive(openMenu);
    }
}
