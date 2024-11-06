using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
        if (character.GetHealth() >= .5f * character.GetMaxHealth()) // Health above 50% just attack
        {
            return abilities[1];
        } 
        else if (character.GetHealth() <= .2f * character.GetMaxHealth()) // Health below 20%
        {
            // 5% chance to flee, otherwise super attack
            if (Random.Range(0f, 1f) <= 0.05f)
            {
                return abilities[2];
            }
            else
            {
                return abilities[3];
            }
        } 
        else
        {
            // 5% chance to use pass, otherwise attack
            if (Random.Range(0f, 1f) <= 0.05f)
            {
                return abilities[0];
            }
            else
            {
                return abilities[1];
            }
        }
    }
}
