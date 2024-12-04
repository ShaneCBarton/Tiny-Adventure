using TMPro;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName;
    [SerializeField] protected AudioClip abilitySound;

    private AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    public string GetName() { return abilityName; }

    public abstract void Use(Character user, Character target, TextMeshProUGUI text);

    public void PlayAbilitySound()
    {
        audioSource.PlayOneShot(abilitySound);
    }

    public AudioClip GetClip()
    {
        return abilitySound;
    }
}