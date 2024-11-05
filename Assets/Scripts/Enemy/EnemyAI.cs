using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private List<Ability> abilities = new List<Ability>();
    [SerializeField] private Transform abilitiesTransform;

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

    public void UseAbility()
    {
        if (abilities.Count > 0)
        {
            
        }
    }
}
