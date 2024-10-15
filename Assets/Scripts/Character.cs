using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<Ability> characterAbilities = new List<Ability>();
    [SerializeField] private string characterName;

    public string Name { get { return characterName; } }

    public IReadOnlyList<Ability> Abilities
    {
        get { return characterAbilities.AsReadOnly(); }
    }
}