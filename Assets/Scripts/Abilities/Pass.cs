using TMPro;
using UnityEngine;

public class Pass : Ability
{
    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        text.text = $"{user.GetName()} passed the turn!";
    }

}
