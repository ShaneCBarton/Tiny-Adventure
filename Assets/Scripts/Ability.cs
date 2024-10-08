using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;
    private Button abilityButton;

    public string Name
    {
        get { return abilityName; }
        set { abilityName = value; }
    }

    public Button ButtonRef
    {
        get { return abilityButton; }
        set { abilityButton = value; }
    }

    public virtual void Use()
    {
        Debug.Log($"Used ability: {name}");
    }
}