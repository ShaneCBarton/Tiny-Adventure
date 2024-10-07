using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    public float encounterRate;
    public float safetyPeriod;
    private float lastEncounterTime = 0f;

    void Update()
    {
        if (Time.time - lastEncounterTime > safetyPeriod)
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
        lastEncounterTime = Time.time;
        SceneManager.LoadScene("BattleScene");
    }
}
