using System;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private int startHealth;
    [SerializeField] private int startDamage;
    [SerializeField] private string playerName;

    public event EventHandler OnPlayerHealthChanged;

    private int currentHealth;
    private int currentDamage;

    private void Start()
    {
        currentHealth = startHealth;
        currentDamage = startDamage;
    }

    public int GetHealth() { return currentHealth; }
    public int GetDamage() { return currentDamage; }
    public string GetName() { return playerName; }

    public void SetHealth(int amount)
    {
        currentHealth += amount;
        OnPlayerHealthChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Current health: " + currentHealth);
    }
}
