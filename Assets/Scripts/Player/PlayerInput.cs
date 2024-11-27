using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float zoomInSize;
    [SerializeField] private float zoomOutSize;

    private PlayerControls playerControls;
    private bool isZoomedIn = false;
    private bool isPaused = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Input.ZoomOut.performed += _ => ZoomOut();
        playerControls.Input.Exit.performed += _ => ExitGame();
        playerControls.Input.Achievements.performed += _ => AchievementScreen();
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

    private void ExitGame()
    {
        PlayerStats.Instance.SetPlayerPosition(FindObjectOfType<Character>().transform.position);
        SaveManager.Instance.SaveGame();
        Application.Quit();
    }
    private void AchievementScreen()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            AchievementManager.Instance.HideScreen();
            isPaused = false;
        } 
        else if (!isPaused)
        {
            Time.timeScale = 0;
            AchievementManager.Instance.ShowScreen();
            isPaused = true;
        }
    }
}
