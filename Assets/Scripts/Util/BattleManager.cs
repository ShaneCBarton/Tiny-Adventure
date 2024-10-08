using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private Image enemyImage;

    private void Start()
    {
        InitializePlayer();
        PopulateAbilityButtons();
        SpawnRandomEnemy();
    }

    private void InitializePlayer()
    {
        player = new GameObject("Player").AddComponent<Character>();
        // Add abilities to the player (you can customize these)
        AddAbilityToPlayer("Attack");
        AddAbilityToPlayer("Defend");
        AddAbilityToPlayer("Heal");
        AddAbilityToPlayer("Flee");
    }

    private void AddAbilityToPlayer(string abilityName)
    {
        Ability newAbility = new GameObject(abilityName).AddComponent<Ability>();
        newAbility.Name = abilityName;
        player.AddAbility(newAbility);
    }

    private void PopulateAbilityButtons()
    {
        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Ability ability = player.Abilities[i];
            Button button = GameObject.Find($"AbilityButton{i + 1}").GetComponent<Button>();
            ability.ButtonRef = button;
            button.GetComponentInChildren<Text>().text = ability.Name;

            // Set up button click event
            int index = i; // Capture the index for the lambda
            button.onClick.AddListener(() => OnAbilityButtonClicked(index));
        }
    }

    private void OnAbilityButtonClicked(int index)
    {
        Ability ability = player.Abilities[index];
        ability.Use();

        if (ability.Name == "Flee")
        {
            SceneManager.LoadScene("GameScene"); // Replace with your game scene name
        }
        // Implement other ability-specific logic here
    }

    private void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];
            GameObject spawnedEnemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);

            // Update the enemy image in the UI
            SpriteRenderer enemySprite = spawnedEnemy.GetComponent<SpriteRenderer>();
            if (enemySprite != null && enemyImage != null)
            {
                enemyImage.sprite = enemySprite.sprite;
            }
        }
        else
        {
            Debug.LogError("No enemy prefabs assigned to the BattleManager!");
        }
    }
}