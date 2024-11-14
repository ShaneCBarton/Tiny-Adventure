using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;

    public string GetName() { return abilityName; }

    public abstract void Use(Character user, Character target, TextMeshProUGUI text);

}