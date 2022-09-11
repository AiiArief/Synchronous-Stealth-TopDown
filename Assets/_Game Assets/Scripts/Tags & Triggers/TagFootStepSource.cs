using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagFootStepSource : MonoBehaviour
{
    [SerializeField] float m_autoDestroyTime = 0.0f;
    [SerializeField] float m_maxSize = 10.0f;
    [SerializeField] ParticleSystem m_particleDestroyWait;

    bool m_isRunning = false;

    public void SetupStepSource(bool isRunning = false)
    {
        m_isRunning = isRunning;

        var audioSource = GetComponent<AudioSource>();
        if(audioSource)
        {
            audioSource.pitch = Random.Range(0.5f, 1.5f);
            audioSource.volume = (isRunning) ? 1 : 0.1f;
        }

        if(m_autoDestroyTime > 0.0f)
        {
            Destroy(gameObject, m_autoDestroyTime);
            return;
        }

        if(m_particleDestroyWait)
        {
            if(isRunning)
            {
                ParticleSystem.MainModule @main = m_particleDestroyWait.main;
                @main.startSize = new ParticleSystem.MinMaxCurve(m_maxSize);
            }

            StartCoroutine(_HandleParticleDestroy());
        }
    }

    public float GenerateMaxSize()
    {
        return m_isRunning ? m_maxSize / 2 : 2.0f / 2;
    }

    private IEnumerator _HandleParticleDestroy()
    {
        while(!m_particleDestroyWait.isStopped)
        {
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
