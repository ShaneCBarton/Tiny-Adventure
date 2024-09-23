using UnityEngine;
using TMPro;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float upperBoundary;
    [SerializeField] private float lowerBoundary;

    private RectTransform rectTransform;
    private bool movingUp = true;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (movingUp)
        {
            rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
            if (rectTransform.anchoredPosition.y >= upperBoundary)
            {
                movingUp = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition += Vector2.down * speed * Time.deltaTime;
            if (rectTransform.anchoredPosition.y <= lowerBoundary)
            {
                movingUp = true;
            }
        }
    }
}
