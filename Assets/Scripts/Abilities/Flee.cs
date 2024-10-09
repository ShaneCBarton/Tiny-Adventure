using UnityEngine;

public class Flee : Ability
{
    public override void Use(Character user, Character target)
    {
        Debug.Log($"{user.name} attempted to flee");
    }


}
