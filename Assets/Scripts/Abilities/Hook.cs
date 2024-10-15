using TMPro;
using UnityEngine;

public class Hook : Ability
{
    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        target.TakeDamage(user.Damage);
        text.text = $"{user.Name} dealt {user.Damage} damage to {target.Name}!";
    }
}
