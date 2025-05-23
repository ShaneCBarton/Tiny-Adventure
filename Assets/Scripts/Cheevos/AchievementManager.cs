using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public event Action<Achievement> OnAchievementUnlocked;

    [SerializeField] private List<Achievement> achievements = new List<Achievement>();
    [SerializeField] private GameObject pauseUI;
    

    private void Awake()
    {
        LoadAchievements();
    }

    private void LoadAchievements()
    {
        foreach (Achievement achievement in achievements)
        {
            achievement.isUnlocked = PlayerPrefs.GetInt(achievement.id, 0) == 1;
        }
    }

    public void UnlockAchievement(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;
            PlayerPrefs.SetInt(achievement.id, 1);
            PlayerPrefs.Save();
            OnAchievementUnlocked?.Invoke(achievement);
        }
    }

    public List<Achievement> GetAllAchievements()
    {
        return achievements;
    }

    public bool IsAchievementUnlocked(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        return achievement != null && achievement.isUnlocked;
    }

    public void ShowScreen()
    {
        if (!IsAchievementUnlocked("CHECK_ACHIEVEMENTS"))
        {
            UnlockAchievement("CHECK_ACHIEVEMENTS");
        }
        pauseUI.GetComponent<AchievementUI>().PopulateAchievements();
        pauseUI.SetActive(true);
    }
    
    public void HideScreen()
    {
        pauseUI.SetActive(false);
    }
}

