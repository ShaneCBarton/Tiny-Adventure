using UnityEngine;

public class Flee : Ability
{

    public override void Use(Character user, Character target)
    {
        EncounterManager.Instance.EndEncounter();
    }
}
