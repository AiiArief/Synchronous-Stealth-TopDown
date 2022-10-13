using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [HideInInspector]
    public AudioSource musicSource;

    public AudioMixer audioMixer;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void ToggleMute(bool isOn)
    {
        audioMixer.SetFloat("vol", (isOn) ? -80.0f : 0.0f);
    }

    public void PlayMusic(int music, bool stopSamePlayedMusic = true)
    {
        var library = new Dictionary<int, AudioClip>()
        {
            [0] = GlobalGameManager.Instance.databaseManager.music_FrostWaltz,
            [1] = GlobalGameManager.Instance.databaseManager.music_teddyBearWaltz,
            [2] = GlobalGameManager.Instance.databaseManager.music_spyGlass,
            [3] = GlobalGameManager.Instance.databaseManager.music_fireBrand,
            [4] = GlobalGameManager.Instance.databaseManager.music_waltz_havva,
        }; 
        
        if (musicSource.isPlaying && musicSource.clip == library[music] && !stopSamePlayedMusic)
            return;

        musicSource.clip = library[music];
        musicSource.Play();
    }

    public IEnumerator FadeOutMusic(float time)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / time;

            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
    }
}
