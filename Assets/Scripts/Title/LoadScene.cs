using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNewScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
