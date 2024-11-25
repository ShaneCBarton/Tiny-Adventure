// Data structure to hold player stats
using System.IO;
using System;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public int health;
    public int damage;
    public string playerName;
    public float positionX;
    public float positionY;

    public PlayerSaveData(PlayerStats stats)
    {
        health = stats.GetHealth();
        damage = stats.GetDamage();
        playerName = stats.GetName();
        Vector2 position = stats.GetPosition();
        positionX = position.x;
        positionY = position.y;
    }
}

public class SaveManager : Singleton<SaveManager>
{
    private string savePath;
    private const string SAVE_FILE_NAME = "player_save.json";

    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
    }

    public void SaveGame()
    {
        try
        {
            PlayerSaveData saveData = new PlayerSaveData(PlayerStats.Instance);

            string jsonData = JsonUtility.ToJson(saveData, true);

            File.WriteAllText(savePath, jsonData);
            Debug.Log($"Game saved successfully at {savePath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving game: {e.Message}");
        }
    }

    public void LoadGame()
    {
        try
        {
            if (File.Exists(savePath))
            {
                string jsonData = File.ReadAllText(savePath);

                PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(jsonData);

                PlayerStats playerStats = PlayerStats.Instance;
                playerStats.SetHealth(saveData.health);
                Vector2 newPosition = new Vector2(saveData.positionX, saveData.positionY);
                playerStats.SetPlayerPosition(newPosition);

                Debug.Log("Game loaded successfully");
            }
            else
            {
                Debug.Log("No save file found");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error loading game: {e.Message}");
        }
    }
}