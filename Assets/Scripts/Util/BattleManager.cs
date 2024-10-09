using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        InitializePlayer();
        PopulateAbilityButtons();
        SpawnRandomEnemy();
    }

    private void InitializePlayer()
    {
        player.AddAbility(gameObject.AddComponent<Hook>());
        player.AddAbility(gameObject.AddComponent<Bait>());
        player.AddAbility(gameObject.AddComponent<Pass>());
        player.AddAbility(gameObject.AddComponent<Flee>());
    }

    private void PopulateAbilityButtons()
    {
        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Ability ability = player.Abilities[i];
            Button button = GameObject.Find($"AbilityButton{i + 1}").GetComponent<Button>();
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = ability.Name;
            int index = i;
            button.onClick.AddListener(() => OnAbilityButtonClicked(index));
        }
    }

    private void OnAbilityButtonClicked(int index)
    {
        Ability ability = player.Abilities[index];
        ability.Use(player, enemy);

        if (ability is Flee)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            // Handle enemy turn or other game logic
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

            // You can add abilities to the enemy here if needed
            // enemy.AddAbility(gameObject.AddComponent<SomeEnemyAbility>());
        }
        else
        {
            Debug.LogError("No enemy prefabs assigned to the BattleManager!");
        }
    }
}