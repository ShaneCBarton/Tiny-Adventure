using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform enemySpawnPoint;

    private Character enemy;

    private void Start()
    {
        PopulateAbilityButtons();
        SpawnRandomEnemy();
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
        ability.Use(player, enemy);
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
}