using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : Singleton<EncounterManager>
{
    public float encounterRate;
    public float safetyPeriod;
    private float lastEncounterTime = 0f;
    private bool inEncounter = false;

    private void Update()
    {
        if (!inEncounter)
        {
            if (Time.time - lastEncounterTime > safetyPeriod)
            {
                if (IsPlayerOnWater() && Random.value < encounterRate)
                {
                    StartEncounter();
                }
            }
        }
    }

    private bool IsPlayerOnWater()
    {
        Vector3 playerPosition = FindObjectOfType<PlayerMovement>().CurrentPosition;
        Collider2D collider = Physics2D.OverlapPoint(playerPosition);
        if (collider != null && collider.gameObject.CompareTag("Water"))
        {
            return true;
        }
        return false;
    }

    private void StartEncounter()
    {
        inEncounter = true;
        GameManager.Instance.UpdatePlayerPosition(FindObjectOfType<PlayerMovement>().CurrentPosition);
        TransitionScene("BattleScene");
    }

    public void EndEncounter()
    {
        inEncounter = false;
        lastEncounterTime = Time.time;
        TransitionScene("GameScene");
    }

    private void TransitionScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
