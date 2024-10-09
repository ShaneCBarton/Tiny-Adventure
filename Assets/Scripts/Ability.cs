using TMPro;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;
    [SerializeField] private string actionText;

    public string Name => abilityName;

    public abstract void Use(Character user, Character target);

    public void PrintToText(TextMeshProUGUI text)
    {
        text.text = actionText;
    }
}