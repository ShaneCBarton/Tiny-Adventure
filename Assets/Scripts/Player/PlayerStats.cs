using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private int startHealth;
    [SerializeField] private int startDamage;
    [SerializeField] private string playerName;

    public event EventHandler OnPlayerHealthChanged;

    private int currentHealth;
    private int currentDamage;
    private Vector3 playerPosition;

    private void Start()
    {
        currentHealth = startHealth;
        currentDamage = startDamage;
    }

    public int GetHealth() { return currentHealth; }
    public int GetDamage() { return currentDamage; }
    public string GetName() { return playerName; }
    public Vector3 GetPosition() { return playerPosition; }

    public void SetPlayerPosition(Vector3 newPosition) { playerPosition = newPosition; }

    public void SetHealth(int amount)
    {
        currentHealth += amount;
        OnPlayerHealthChanged?.Invoke(this, EventArgs.Empty);
        if (IsPlayerDead())
        {
            currentHealth = startHealth;
            playerPosition = new Vector3(0, 0, 0);
            SaveManager.Instance.SaveGame();
            SaveManager.Instance.LoadGame();
            SceneManager.LoadScene(1);
        }
    }

    private bool IsPlayerDead()
    {
        return currentHealth <= 0;
    }
}
