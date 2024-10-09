using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<Ability> characterAbilities = new List<Ability>();

    public IReadOnlyList<Ability> Abilities
    {
        get { return characterAbilities.AsReadOnly(); }
    }

    public void AddAbility(Ability ability)
    {
        characterAbilities.Add(ability);
    }
}