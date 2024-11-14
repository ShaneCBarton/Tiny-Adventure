

using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private float delay = 0.1f;

    private string fullText;
    private string lastProcessedText;
    private bool isTyping = false;
    private Coroutine typeCoroutine;

    private void Start()
    {
        if (!string.IsNullOrEmpty(textMeshPro.text))
        {
            fullText = textMeshPro.text;
            lastProcessedText = fullText;
            textMeshPro.text = "";
            StartTypingEffect();
        }
    }

    private void Update()
    {
        if (!isTyping &&
            textMeshPro.text != lastProcessedText &&
            !string.IsNullOrEmpty(textMeshPro.text))
        {
            fullText = textMeshPro.text;
            lastProcessedText = fullText;
            StartTypingEffect();
        }
    }

    private void StartTypingEffect()
    {
        if (typeCoroutine != null)
        {
            StopCoroutine(typeCoroutine);
        }

        textMeshPro.text = "";
        typeCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        isTyping = true;

        foreach (char c in fullText)
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
        typeCoroutine = null;
    }

    private void OnDisable()
    {
        if (typeCoroutine != null)
        {
            StopCoroutine(typeCoroutine);
            typeCoroutine = null;
        }
        isTyping = false;
    }
}
