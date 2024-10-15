using TMPro;
using UnityEngine;

public class Flee : Ability
{

    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        EncounterManager.Instance.EndEncounter();
        text.text = actionText;
    }
}
