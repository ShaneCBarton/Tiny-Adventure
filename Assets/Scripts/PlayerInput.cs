using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float zoomInSize;
    [SerializeField] private float zoomOutSize;

    private PlayerControls playerControls;
    private bool isZoomedIn = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Input.ZoomOut.performed += _ => ZoomOut();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void ZoomOut()
    {
        if (isZoomedIn)
        {
            Camera.main.orthographicSize = zoomOutSize;
            isZoomedIn = false;
        } else
        {
            Camera.main.orthographicSize = zoomInSize;
            isZoomedIn = true;
        }
    }
}
