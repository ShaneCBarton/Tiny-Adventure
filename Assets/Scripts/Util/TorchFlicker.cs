using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchFlicker : MonoBehaviour
{
    [SerializeField] private Light2D torchLight;
    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;
    [SerializeField] private float flickerSpeed;

    private float flickerTime;

    private void Update()
    {
        if (Time.time > flickerTime)
        {
            torchLight.intensity = Random.Range(lowerLimit, upperLimit);
            flickerTime = Time.time + flickerSpeed;
        } 
    }
}
