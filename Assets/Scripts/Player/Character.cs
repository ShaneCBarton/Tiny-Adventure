using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<Ability> characterAbilities = new List<Ability>();
    [SerializeField] private string characterName;
    [SerializeField] private int characterMaxHealth;
    [SerializeField] private int characterDamage;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = characterMaxHealth;
    }

    public int GetDamage() { return characterDamage; }
    public int GetHealth() { return currentHealth; }
    public int GetMaxHealth() {  return characterMaxHealth; }
    public string GetName() { return characterName; }

    public IReadOnlyList<Ability> Abilities
    {
        get { return characterAbilities.AsReadOnly(); }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}