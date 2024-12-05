using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    [SerializeField] private GameObject creditsUI;

    public void OpenCredits(bool openMenu)
    {
        creditsUI.SetActive(openMenu);
    }
}
