using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrompt;
    [SerializeField] private TextMeshProUGUI pickupPromptText;
    [SerializeField] private GameObject itemDescription;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private float descriptionDisplayTime = 3f;

    private Coroutine descriptionCoroutine;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && itemDescription.activeInHierarchy)
        {
            HideItemDescription();
        }
    }

    public void ShowPickupPrompt(string message)
    {
        pickupPrompt.SetActive(true);
        pickupPromptText.text = message;
    }

    public void HidePickupPrompt()
    {
        pickupPrompt.SetActive(false);
    }

    public void ShowItemDescription(string itemName, string description)
    {
        if (descriptionCoroutine != null)
        {
            StopCoroutine(descriptionCoroutine);
        }

        itemDescription.SetActive(true);
        itemNameText.text = itemName;
        itemDescriptionText.text = description;

        descriptionCoroutine = StartCoroutine(HideDescriptionAfterDelay());
    }

    private IEnumerator HideDescriptionAfterDelay()
    {
        yield return new WaitForSeconds(descriptionDisplayTime);
        HideItemDescription();
    }

    public void HideItemDescription()
    {
        itemDescription.SetActive(false);
    }

}