using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;

    public string Name
    {
        get { return abilityName; }
        set { abilityName = value; }
    }

    public abstract void Use(Character user, Character target);
}