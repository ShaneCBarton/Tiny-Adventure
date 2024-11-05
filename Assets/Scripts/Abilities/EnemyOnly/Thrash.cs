using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Thrash : Ability
{
    public override void Use(Character user, Character target, TextMeshProUGUI text)
    {
        PlayerStats.Instance.SetHealth(-user.GetDamage());
        text.text = $"{user.GetName()} thrashed and dealt {user.GetDamage()} damage to {target.GetName()}!";
    }
}
