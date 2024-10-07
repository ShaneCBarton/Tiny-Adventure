using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    public float encounterRate = 0.1f;
    public float safetyPeriod = 5f;
    private bool inEncounter = false;
    private float lastEncounterTime = 0f;

    void Update()
    {
        if (!inEncounter && Time.time - lastEncounterTime > safetyPeriod)
        {
            if (IsPlayerOnWater() && Random.value < encounterRate)
            {
                StartEncounter();
            }
        }
    }

    bool IsPlayerOnWater()
    {
        Vector3 playerPosition = transform.position;
        Collider2D collider = Physics2D.OverlapPoint(playerPosition);
        if (collider != null && collider.gameObject.CompareTag("Water"))
        {
            return true;
        }
        return false;
    }

    void StartEncounter()
    {
        inEncounter = true;
        lastEncounterTime = Time.time;
        SceneManager.LoadScene("BattleScene");
    }

    public void EndEncounter()
    {
        inEncounter = false;
        SceneManager.UnloadSceneAsync("BattleScene");
    }
}
