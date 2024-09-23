using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        Application.Quit();
    }
}
