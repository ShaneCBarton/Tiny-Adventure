using TMPro;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;
    [SerializeField] protected string actionText;

    public string Name => abilityName;

    public abstract void Use(Character user, Character target, TextMeshProUGUI text);

}