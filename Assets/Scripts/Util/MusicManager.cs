using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
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
        AudioClip targetClip = scene.buildIndex == 0 ? menuMusic : gameMusic;
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