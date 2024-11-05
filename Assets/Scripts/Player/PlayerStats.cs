using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private int startHealth;
    [SerializeField] private int startDamage;

    private int currentHealth;
    private int currentDamage;

    private void Start()
    {
        currentHealth = startHealth;
        currentDamage = startDamage;
    }

    public int GetHealth() { return currentHealth; }
    public int GetDamage() { return currentDamage; }

    public void SetHealth(int amount)
    {
        currentHealth += amount;
        Debug.Log("Current health: " + currentHealth);
    }
}
