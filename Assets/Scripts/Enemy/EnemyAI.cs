using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private List<Ability> abilities = new List<Ability>();
    [SerializeField] private Transform abilitiesTransform;
    [SerializeField] private Character character;

    private void Start()
    {
        if (abilitiesTransform != null)
        {
            Ability[] abilityComponents = abilitiesTransform.GetComponentsInChildren<Ability>();
            foreach (Ability ability in abilityComponents)
            {
                abilities.Add(ability);
            }
        }
    }

    public Ability GetAbility()
    {
        if (character.GetHealth() >= .75f * character.GetMaxHealth())
        {
            return abilities[1];
        } else
        {
            return abilities[0];
        }
    }
}
