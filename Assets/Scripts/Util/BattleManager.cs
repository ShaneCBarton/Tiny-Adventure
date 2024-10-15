using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private TextMeshProUGUI battleText;
    [SerializeField] private string battleEntryText;
    [SerializeField] private float enemyTurnDelay = 1f;

    private Character enemy;
    private bool isPlayerTurn = true;

    private void Start()
    {
        PopulateAbilityButtons();
        SpawnRandomEnemy();
        battleText.text = battleEntryText + enemy.Name;
        StartCoroutine(BattleLoop());
    }

    private void PopulateAbilityButtons()
    {
        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Ability ability = player.Abilities[i];
            Button button = GameObject.Find($"AbilityButton{i + 1}").GetComponent<Button>();
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = ability.Name;
            button.onClick.AddListener(() => OnAbilityButtonClicked(ability));
        }
    }

    private void OnAbilityButtonClicked(Ability ability)
    {
        if (isPlayerTurn)
        {
            ability.Use(player, enemy, battleText);
            EndPlayerTurn();
        }
    }

    private void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
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
        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(enemyTurnDelay);

        if (enemy.Abilities.Count > 0)
        {
            Ability randomAbility = enemy.Abilities[Random.Range(0, enemy.Abilities.Count)];
            randomAbility.Use(enemy, player, battleText);
        }

        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        isPlayerTurn = true;
        SetAbilityButtonsInteractable(true);
        battleText.text += "\nIt's your turn!";
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
                yield return new WaitUntil(() => !isPlayerTurn);
            }
            else
            {
                yield return StartCoroutine(EnemyTurn());
            }
        }
    }
}