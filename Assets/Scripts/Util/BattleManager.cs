using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private TextMeshProUGUI battleText;
    [SerializeField] private string battleEntryText;
    [SerializeField] private float enemyTurnDelay = 1f;

    public event EventHandler<int> OnPlayerTurnEnd;

    private Character enemy;
    private bool isPlayerTurn = true;

    private void Start()
    {
        PopulateAbilityButtons();
        SpawnRandomEnemy();
        battleText.text = battleEntryText + enemy.GetName();
        StartCoroutine(BattleLoop());
    }

    private void PopulateAbilityButtons()
    {
        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Ability ability = player.Abilities[i];
            Button button = GameObject.Find($"AbilityButton{i + 1}").GetComponent<Button>();
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = ability.GetName();
            button.onClick.AddListener(() => OnAbilityButtonClicked(ability));
        }
    }

    private void OnAbilityButtonClicked(Ability ability)
    {
        if (isPlayerTurn)
        {
            ability.Use(player, enemy, battleText);
            CheckBattleEnd();
            EndPlayerTurn();
        }
    }

    private void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];
            GameObject spawnedEnemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<Character>();
        }
        else
        {
            Debug.LogError("No enemy prefabs assigned to the BattleManager!");
        }
    }

    private void EndPlayerTurn()
    {
        isPlayerTurn = false;
        SetAbilityButtonsInteractable(false);
        OnPlayerTurnEnd?.Invoke(this, enemy.GetHealth());
        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(enemyTurnDelay);

        if (!isPlayerTurn)
        {
            Ability ability = enemy.GetComponent<EnemyAI>().GetAbility();
            ability.Use(enemy, player, battleText);
            CheckBattleEnd();
            isPlayerTurn = true;
        }
    }

    private void SetAbilityButtonsInteractable(bool interactable)
    {
        Button[] abilityButtons = GameObject.FindObjectsOfType<Button>();
        foreach (Button button in abilityButtons)
        {
            button.interactable = interactable;
        }
    }

    private IEnumerator BattleLoop()
    {
        while (true)
        {
            if (isPlayerTurn)
            {
                SetAbilityButtonsInteractable(true);
                battleText.text += "\nIt's your turn!";
                yield return new WaitUntil(() => !isPlayerTurn);
            }
            else
            {
                yield return StartCoroutine(EnemyTurn());
            }
        }
    }

    private void CheckBattleEnd()
    {
        if (PlayerStats.Instance.GetHealth() <= 0)
        {
            battleText.text = "You have been defeated!";
            StopAllCoroutines();
            EncounterManager.Instance.EndEncounter();
        }
        else if (enemy.GetHealth() <= 0)
        {
            battleText.text = "Enemy defeated!";
            if (!FindObjectOfType<AchievementManager>().IsAchievementUnlocked("WIN_BATTLE"))
            {
                FindObjectOfType<AchievementManager>().UnlockAchievement("WIN_BATTLE");
            }
            StopAllCoroutines();
            EncounterManager.Instance.EndEncounter();
        }
    }

    public string GetEnemyName()
    {
        return enemy.GetName();
    }

    public int GetEnemyStartHealth()
    {
        return enemy.GetHealth();
    }
}