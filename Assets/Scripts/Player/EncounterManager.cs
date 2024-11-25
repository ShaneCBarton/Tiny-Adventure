using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : Singleton<EncounterManager>
{
    [SerializeField] private float encounterRate;
    [SerializeField] private float safetyPeriod;
    [SerializeField] private float stepDistance;

    private Vector3 lastPosition;
    private float lastEncounterTime = 0f;
    private bool inEncounter = false;
    private int numOfEncounters = 0;
    private GameObject player;

    public int EncounterNumber => numOfEncounters;

    private void Start()
    {
        player = GameObject.Find("Player");
        lastPosition = player.transform.position;
    }

    private void Update()
    {
        if (player != null && !inEncounter)
        {
            Vector3 currentPosition = GameObject.Find("Player").transform.position;
            float distanceMoved = Vector3.Distance(lastPosition, currentPosition);

            if (distanceMoved >= stepDistance && Time.time - lastEncounterTime > safetyPeriod)
            {
                if (IsPlayerOnWater() && Random.value < encounterRate)
                {
                    StartEncounter();
                }
                lastPosition = currentPosition;
            }
        } else if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    private bool IsPlayerOnWater()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
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
        PlayerStats.Instance.SetPlayerPosition(FindObjectOfType<PlayerMovement>().CurrentPosition);
        TransitionScene("BattleScene");
    }

    public void EndEncounter()
    {
        numOfEncounters++;
        inEncounter = false;
        lastEncounterTime = Time.time;

        TransitionScene("GameScene");
    }

    private void TransitionScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
