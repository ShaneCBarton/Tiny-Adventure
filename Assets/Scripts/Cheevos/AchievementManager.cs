using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField] private List<Achievement> achievements = new List<Achievement>();
    public event Action<Achievement> OnAchievementUnlocked;

    protected override void Awake()
    {
        base.Awake();
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
}

