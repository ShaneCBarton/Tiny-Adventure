
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
        Vector3 position = stats.GetPosition();
        positionX = position.x;
        positionY = position.y;
    }
}

public class SaveManager : Singleton<SaveManager>
{
    private string savePath;
    private const string SAVE_FILE_NAME = "player_save.json";

    protected override void Awake()
    {
        base.Awake();
        savePath = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
    }

    public void SaveGame()
    { 
        PlayerSaveData saveData = new PlayerSaveData(PlayerStats.Instance);

        string jsonData = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(savePath, jsonData);
        Debug.Log($"Game saved successfully at {savePath}");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);

            PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(jsonData);

            PlayerStats.Instance.SetHealth(saveData.health - PlayerStats.Instance.GetHealth());
            Vector3 newPosition = new Vector3(saveData.positionX, saveData.positionY, 0);
            PlayerStats.Instance.SetPlayerPosition(newPosition);

            Debug.Log("Game loaded successfully");
        }
        else
        {
            Debug.Log("No save file found");
        }
    }
}