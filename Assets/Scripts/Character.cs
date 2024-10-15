using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<Ability> characterAbilities = new List<Ability>();
    [SerializeField] private string characterName;
    [SerializeField] private int characterHealth;
    [SerializeField] private int characterDamage;

    public int Damage { get { return characterDamage; } }
    public int Health { get { return characterHealth; } }
    public string Name { get { return characterName; } }

    public IReadOnlyList<Ability> Abilities
    {
        get { return characterAbilities.AsReadOnly(); }
    }

    public void TakeDamage(int damage)
    {
        characterHealth -= damage;
    }
}