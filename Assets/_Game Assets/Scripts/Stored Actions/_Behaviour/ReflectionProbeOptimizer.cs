﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ReflectionProbeOptimizer : MonoBehaviour
{
    ReflectionProbe m_probe;
    EntityCharacterPlayer m_mainPlayer;

    [SerializeField] bool m_debug = false;

    private void Awake()
    {
        m_probe = GetComponent<ReflectionProbe>();

        StartCoroutine(_ReflectionAPIHandler());
        OnQualityLevelChanged(QualitySettings.GetQualityLevel());
    }

    private void OnEnable()
    {
        SystemUIManager.OnQualityLevelChanged += OnQualityLevelChanged;
    }

    private void OnDisable()
    {
        SystemUIManager.OnQualityLevelChanged -= OnQualityLevelChanged;
    }

    /// <summary>
    /// 0 = potato
    /// 1 = recommended
    /// 2 = brute force
    /// </summary>
    /// <param name="qualityLevel"></param>
    private void OnQualityLevelChanged(int qualityLevel)
    {
        m_probe.enabled = false;
        m_probe.resolution = 32 * (int)Mathf.Pow(2, qualityLevel);
        if (qualityLevel < 1)
            return;

        var refreshModeBefore = m_probe.refreshMode;
        m_probe.refreshMode = ReflectionProbeRefreshMode.EveryFrame;
        m_probe.enabled = true;
        m_probe.refreshMode = refreshModeBefore;
    }

    private IEnumerator _ReflectionAPIHandler()
    {
        if (m_probe.refreshMode != ReflectionProbeRefreshMode.ViaScripting)
            yield break;

        _InitRenderProbe();

        while (true)
        {
            yield return new WaitForEndOfFrame();

            int qualityLevel = QualitySettings.GetQualityLevel();
            if(qualityLevel < 1)
                continue;

            if (!m_mainPlayer)
                m_mainPlayer = GameManager.Instance.playerManager.GetMainPlayer();

            if (m_mainPlayer)
            {
                int playerCloseEnough = _CheckPlayerIsCloseEnough();

                bool isClose = playerCloseEnough == 2;
                m_probe.timeSlicingMode = (isClose) ? ReflectionProbeTimeSlicingMode.NoTimeSlicing : ReflectionProbeTimeSlicingMode.AllFacesAtOnce;

                bool renderNow = (qualityLevel >= 2) ? playerCloseEnough > 0 : playerCloseEnough == 2;

                if (renderNow)
                {
                    m_probe.RenderProbe();

                    //if (m_debug) Debug.Log("Rendered : " + gameObject.name);
                    
                    yield return new WaitForSeconds((1.0f / 60) * 5 * ((qualityLevel == 2) ? 2 : 8));
                }
            }
        }
    }

    private void _InitRenderProbe()
    {
        if (!m_probe.enabled)
            return;

        m_probe.timeSlicingMode = ReflectionProbeTimeSlicingMode.NoTimeSlicing;
        m_probe.RenderProbe();
        m_probe.timeSlicingMode = ReflectionProbeTimeSlicingMode.AllFacesAtOnce;
    }

    /**
     * Out : 
     * 2 = player is inside
     * 1 = player outside but camera can look
     * 0 = player outside & camera can't look
     **/
    private int _CheckPlayerIsCloseEnough()
    {
        float viewDistance = Mathf.Max(m_probe.size.x, m_probe.size.z);
        float cameraRadius = 20.0f / 2; // temporary, size camera / 2 palingan
        float distance = Vector3.Distance(m_mainPlayer.transform.position, transform.position);

        float totalDistance = distance - viewDistance - cameraRadius;
        return (totalDistance <= 0.0f) ? (totalDistance <= -viewDistance) ? 2 : 1 : 0;
    }
}
