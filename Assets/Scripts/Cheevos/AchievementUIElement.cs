using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementUIElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject lockedOverlay;

    public void SetAchievement(Achievement achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;
        lockedOverlay.SetActive(!achievement.isUnlocked);
    }
}
