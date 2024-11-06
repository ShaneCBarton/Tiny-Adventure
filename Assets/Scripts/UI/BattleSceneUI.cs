using System;
using TMPro;
using UnityEngine;

public class BattleSceneUI : MonoBehaviour
{
    [Header("Player UI")]
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI playerNameText;

    [Header("Enemy UI")]
    [SerializeField] private TextMeshProUGUI enemyHealthText;
    [SerializeField] private TextMeshProUGUI enemyNameText;

    private BattleManager battleManager;

    private void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
        PlayerStats.Instance.OnPlayerHealthChanged += PlayerStats_OnPlayerHealthChanged;
        battleManager.OnPlayerTurnEnd += BattleManager_OnPlayerTurnEnd;
        UpdatePlayerInfo();
        UpdateEnemyInfo(battleManager.GetEnemyStartHealth());
    }

    private void BattleManager_OnPlayerTurnEnd(object sender, int e)
    {
        UpdateEnemyInfo(e);
    }

    private void PlayerStats_OnPlayerHealthChanged(object sender, EventArgs e)
    {
        UpdatePlayerInfo();
    }

    private void UpdatePlayerInfo()
    {
        playerHealthText.text = $"HP: {PlayerStats.Instance.GetHealth().ToString()}";
        playerNameText.text = $"{ PlayerStats.Instance.GetName()}";
    }

    private void UpdateEnemyInfo(int health)
    {
        enemyNameText.text = $"{battleManager.GetEnemyName()}";
        enemyHealthText.text = $"HP: {health}";

    }
}
