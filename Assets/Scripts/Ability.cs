using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;

    public string Name => abilityName;

    public abstract void Use(Character user, Character target);
}