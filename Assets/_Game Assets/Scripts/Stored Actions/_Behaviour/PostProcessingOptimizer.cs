using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class PostProcessingOptimizer : MonoBehaviour
{
    PostProcessVolume m_postProcessVolume;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();

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
        m_postProcessVolume.enabled = qualityLevel > 0;
    }
}
