using UnityEngine;

public class Hook : Ability
{
    public override void Use(Character user, Character target)
    {
        Debug.Log($"{user.name} pulled the Hook on {target.name}");
    }
}
