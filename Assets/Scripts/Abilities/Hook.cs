using TMPro;
using UnityEngine;

public class Hook : Ability
{
    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        target.TakeDamage(user.GetDamage());
        text.text = $"{user.GetName()} dealt {user.GetDamage()} damage to {target.GetName()}!";
    }
}
