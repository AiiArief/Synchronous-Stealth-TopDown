using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePack : MonoBehaviour
{
    AudioSource m_audioSource;

    [SerializeField] AudioClip[] m_voiceClips;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void TextToSpeech(char key)
    {
        int iKey = (int)key;
        int voiceLength = m_voiceClips.Length;
        int index = iKey % voiceLength;
        m_audioSource.PlayOneShot(m_voiceClips[index]);
    }
}
