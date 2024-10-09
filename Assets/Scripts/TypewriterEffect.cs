using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private float delay = 0.1f;

    private string fullText;
    private string currentText;
    private bool isTyping = false;

    private void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = "";
        StartCoroutine(TypeText());
    }

    private void Update()
    {
        if (textMeshPro.text != currentText && !isTyping)
        {
            fullText = textMeshPro.text;
            textMeshPro.text = "";
            currentText = fullText;
            StartCoroutine(TypeText());
        }
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
    }
}
