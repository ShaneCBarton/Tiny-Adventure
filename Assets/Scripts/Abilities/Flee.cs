using TMPro;
using UnityEngine;

public class Flee : Ability
{

    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        text.text = $"{user.GetName()} is fleeing the battle!";
        EncounterManager.Instance.EndEncounter();
    }
}
