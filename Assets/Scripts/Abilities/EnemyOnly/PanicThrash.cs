using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanicThrash : Ability
{
    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        PlayerStats.Instance.SetHealth(-user.GetDamage() * 2);
        text.text = $"{user.GetName()} panicked and thrashed and dealt {user.GetDamage()} extra damage to {target.GetName()}!";
    }
}
