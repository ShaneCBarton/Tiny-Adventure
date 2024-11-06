using TMPro;
using UnityEngine;

public class Bait : Ability
{
    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        text.text = $"{user.GetName()} threw some bait!";
    }

}
