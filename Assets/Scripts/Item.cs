using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    private UIManager uiManager;
    private bool isInRange = false;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            uiManager.ShowPickupPrompt($"'E'");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            uiManager.HidePickupPrompt();
        }
    }
    
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupItem();
        }
    }
    
    private void PickupItem()
    {
        if (!FindObjectOfType<AchievementManager>().IsAchievementUnlocked("OPEN_CHEST"))
        {
            FindObjectOfType<AchievementManager>().UnlockAchievement("OPEN_CHEST");
        }
        Inventory.Instance.AddItem(itemData);
    
        uiManager.ShowItemDescription(itemData.itemName, itemData.description);
    
        Destroy(gameObject);
    }
}