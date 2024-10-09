using UnityEngine;

public class Bait : Ability
{
    public override void Use(Character user, Character target)
    {
        Debug.Log($"{user.name} threw Bait at {target.name}");
    }
}
