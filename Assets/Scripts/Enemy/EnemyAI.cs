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
        float healthPercent = (float)character.GetHealth() / (float)character.GetMaxHealth();

        if (healthPercent <= .2f) // Check low health FIRST
        {
            // 5% chance to flee, otherwise super attack
            if (Random.Range(0f, 1f) <= 0.05f)
            {
                return abilities[2];  // Flee
            }
            else
            {
                return abilities[3];  // Super attack
            }
        }
        else if (healthPercent >= .5f) // Then check high health
        {
            return abilities[1];  // Attack
        }
        else // Between 20% and 50%
        {
            // 5% chance to use pass, otherwise attack
            if (Random.Range(0f, 1f) <= 0.05f)
            {
                return abilities[0];  // Pass
            }
            else
            {
                return abilities[1];  // Attack
            }
        }
    }
}
