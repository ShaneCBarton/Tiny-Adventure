using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip[] battleMusic;
    [SerializeField] private float fadeSpeed = 1f;
    private float currentVolume;

    protected override void Awake()
    {
        base.Awake();
        currentVolume = musicSource.volume;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip targetClip;

        switch (scene.buildIndex)
        {
            case 0:
                targetClip = menuMusic;
                break;
            case 2:
                targetClip = battleMusic[Random.Range(0, battleMusic.Length)];
                break;
            default:
                targetClip = gameMusic;
                break;
        }

        StartCoroutine(FadeToNewClip(targetClip));
    }

    private IEnumerator FadeToNewClip(AudioClip newClip)
    {
        float fadeVolume = currentVolume;

        while (fadeVolume > 0)
        {
            fadeVolume -= Time.deltaTime * fadeSpeed;
            musicSource.volume = fadeVolume;
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.Play();

        while (fadeVolume < currentVolume)
        {
            fadeVolume += Time.deltaTime * fadeSpeed;
            musicSource.volume = fadeVolume;
            yield return null;
        }
    }
}