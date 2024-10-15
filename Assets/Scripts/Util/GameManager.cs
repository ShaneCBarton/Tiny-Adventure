using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Vector3 PlayerPosition { get; private set; }

    public void UpdatePlayerPosition(Vector3 newPlayerPosition)
    {
        PlayerPosition = newPlayerPosition;
    }

}
