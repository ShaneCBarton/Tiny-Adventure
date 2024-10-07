using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Vector3 PlayerPosition { get; private set; }
    [SerializeField] private GameObject player;

    public void UpdatePlayerPosition(Vector3 newPlayerPosition)
    {
        PlayerPosition = newPlayerPosition;
    }

    public void EndEncounterAndLoadScene(int index)
    {
        EncounterManager.Instance.EndEncounter();
        SceneManager.LoadScene(index);
    }
}
