using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    [SerializeField] private GameObject achievementPrefab;
    [SerializeField] private Transform achievementContainer;

    private void Start()
    {
        PopulateAchievements();
    }

    private void PopulateAchievements()
    {
        foreach (Transform child in achievementContainer)
        {
            Destroy(child.gameObject);
        }

        List<Achievement> achievements = AchievementManager.Instance.GetAllAchievements();
        foreach (Achievement achievement in achievements)
        {
            GameObject achievementObj = Instantiate(achievementPrefab, achievementContainer);
            AchievementUIElement uiElement = achievementObj.GetComponent<AchievementUIElement>();
            uiElement.SetAchievement(achievement);
        }
    }
}
