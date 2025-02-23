﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource m_musicSource;
    public AudioSource musicSource => m_musicSource;

    [SerializeField] AudioSource m_meSource;
    public AudioSource meSource => m_meSource;

    [SerializeField] AudioMixerGroup m_masterAudioMixer;
    public AudioMixerGroup MasterAudioMixer => m_masterAudioMixer;

    [SerializeField] AudioMixerGroup m_musicAudioMixer;
    public AudioMixerGroup musicAudioMixer => m_musicAudioMixer;

    [SerializeField] AudioMixerGroup m_sfxAudioMixer;
    public AudioMixerGroup SFXAudioMixer => m_sfxAudioMixer;

    public void PlayMusic(int music, bool stopSamePlayedMusic = true)
    {
        var library = new Dictionary<int, AudioClip>()
        {
            [0] = GlobalGameManager.Instance.databaseManager.music_FrostWaltz,
            [1] = GlobalGameManager.Instance.databaseManager.music_teddyBearWaltz,
            [2] = GlobalGameManager.Instance.databaseManager.music_spyGlass,
            [3] = GlobalGameManager.Instance.databaseManager.music_fireBrand,
        }; 
        
        if (m_musicSource.isPlaying && m_musicSource.clip == library[music] && !stopSamePlayedMusic)
            return;

        m_musicSource.clip = library[music];
        m_musicSource.Play();
    }

    public IEnumerator PlayMusicEffect(AudioClip audio, bool playMusicAgain = true)
    {
        StartCoroutine(FadeOutMusic(0.25f, false));
        yield return new WaitForSeconds(0.25f);

        m_meSource.PlayOneShot(audio);
        while (m_meSource.isPlaying)
            yield return null;

        if(playMusicAgain)
            StartCoroutine(FadeInMusic(1.0f));
    }

    public IEnumerator FadeOutMusic(float time, bool stopMusic = true)
    {
        while (m_musicSource.volume > 0)
        {
            musicSource.volume -= 1.0f * Time.deltaTime / time;

            yield return null;
        }

        if (stopMusic)
        {
            m_musicSource.Stop();
            m_musicSource.volume = 1.0f;
        }
    }

    public IEnumerator FadeInMusic(float time)
    {
        m_musicSource.volume = 0.0f;
        if (!m_musicSource.isPlaying)
            m_musicSource.Play();

        while (m_musicSource.volume < 1.0f)
        {
            musicSource.volume += 1.0f * Time.deltaTime / time;

            yield return null;
        }

    }
}
