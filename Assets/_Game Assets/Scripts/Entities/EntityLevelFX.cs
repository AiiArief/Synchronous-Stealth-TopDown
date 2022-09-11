using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class EntityLevelFX : Entity
{
    [SerializeField] float m_skyboxSpeed = 0.0f;
    float m_currentSkyboxRotation = 0.0f;

    [Header("Wind Effect")]
    [SerializeField] bool m_hasWindEffect;
    [SerializeField] AudioSource m_windAmbienceSoundEffect;
    [SerializeField] GameObject m_playerSpringBoneParent; // belum disetting buat semua entity, probably berat lol
    VRMSpringBone[] m_playerSpringBones;

    public void FXOnLoadLevel()
    {
        m_playerSpringBones = m_playerSpringBoneParent.GetComponents<VRMSpringBone>();
        HandleSkyBox();
    }

    public override void WaitInput()
    {
        HandleFX(false);

        storedActions.Add(new StoredActionLevelFX(this));
    }

    public void HandleSkyBox()
    {
        if(m_skyboxSpeed > 0.0f)
        {
            m_currentSkyboxRotation = Mathf.Repeat(m_currentSkyboxRotation + Time.deltaTime * m_skyboxSpeed, 360);
            RenderSettings.skybox.SetFloat("_Rotation", m_currentSkyboxRotation);
        }
    }

    public void HandleWindEffect()
    {
        if(m_hasWindEffect)
        {
            foreach(VRMSpringBone springBone in m_playerSpringBones)
            {
                if (springBone.m_comment == "Bust")
                    continue;

                springBone.m_gravityDir = new Vector3(-1.0f, -1.0f, 0.0f);
                springBone.m_gravityPower = Mathf.PingPong(Time.time * 4, 0.5f);
            }
        }
    }

    public void HandleFX(bool play = true)
    {
        /*var pss = m_stepSoundParent.GetComponentsInChildren<ParticleSystem>(); // boros betulll, ambil dari level manager aja step sounds parentnya
        foreach(ParticleSystem ps in pss)
        {
            if (play && ps.isPaused)
                ps.Play();
            else
                ps.Pause();
        }
        */
    }

    public void ChangeWindEffect(bool hasWindEffect)
    {
        m_hasWindEffect = hasWindEffect;
        //StartCoroutine(_AmbiencePitchLerp(hasWindEffect));
        if (!m_hasWindEffect)
        {
            foreach (VRMSpringBone springBone in m_playerSpringBones)
            {
                springBone.m_gravityDir = new Vector3(0.0f, -1.0f, 0.0f);
                springBone.m_gravityPower = 0.0f;
            }
        }
    }

    /*private IEnumerator _AmbiencePitchLerp(bool windEffect)
    {
        if(windEffect)
        {
            while(m_windAmbienceSoundEffect.pitch < 0.3f)
            {
                m_windAmbienceSoundEffect.pitch += 0.2f * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        } else
        {
            while (m_windAmbienceSoundEffect.pitch > 0.1f)
            {
                m_windAmbienceSoundEffect.pitch -= 0.2f * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }*/
}
