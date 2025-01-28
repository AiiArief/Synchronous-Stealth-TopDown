using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SystemUIManager : MonoBehaviour
{
    public static Action<int> OnQualityLevelChanged;

    [SerializeField] Text m_musicVolumeText;
    [SerializeField] Slider m_musicVolumeSlider;

    [SerializeField] Text m_sfxVolumeText;
    [SerializeField] Slider m_sfxVolumeSlider;

    [SerializeField] Text m_screenResolutionText;
    [SerializeField] Text m_screenResolutionListText;

    [SerializeField] Text m_screenModeText;
    [SerializeField] Text m_screenModeListText;

    [SerializeField] Text m_graphicPresetText;
    [SerializeField] Text m_graphicPresetListText;

    float onOpenTimeScale = -1.0f;
    List<Resolution> availableScreenResolution = new List<Resolution>();
    List<FullScreenMode> availableScreenMode = new List<FullScreenMode>();

    public void ToggleSystemUI()
    {
        onOpenTimeScale = (onOpenTimeScale < 0.0f) ? Time.timeScale : onOpenTimeScale;
        Time.timeScale = onOpenTimeScale;

        gameObject.SetActive(!gameObject.activeSelf);
        if (!gameObject.activeSelf)
            return;

        onOpenTimeScale = Time.timeScale;
        Time.timeScale = 0;

        _Localize();
        _SetupScreenResolutions();
        _SetupAudio();
    }

    public void ChangeMusicVolume(bool isNext)
    {
        if (!GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.GetFloat("musicVolume", out float musicVolume))
            return;

        var currentVolume = _ConvertVolume(musicVolume);
        var nextVolume = (isNext) ? currentVolume + 10.0f : currentVolume - 10.0f;
        var nextVolumeInDB = _ConvertVolume(Mathf.Clamp(nextVolume, 0, 100.0f), false);
        GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.SetFloat("musicVolume", nextVolumeInDB);

        _SetupAudio();
    }

    public void ChangeSFXVolume(bool isNext)
    {
        if (!GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.GetFloat("sfxVolume", out float sfxVolume))
            return;

        var currentVolume = _ConvertVolume(sfxVolume);
        var nextVolume = (isNext) ? currentVolume + 10.0f : currentVolume - 10.0f;
        var nextVolumeInDB = _ConvertVolume(Mathf.Clamp(nextVolume, 0, 100.0f), false);
        GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.SetFloat("sfxVolume", nextVolumeInDB);

        _SetupAudio();
    }

    public void ChangeResolutionSettings(bool isNext)
    {
        if (availableScreenResolution.Count <= 0)
            return;

        var currentResolution = Screen.currentResolution;
        var currentFullscreenMode = Screen.fullScreenMode;

        int currentResolutionInt = availableScreenResolution.FindIndex((x) => x.Equals(currentResolution));
        if (currentResolutionInt == -1)
            return;

        var nextResolution = availableScreenResolution[(int)Mathf.Repeat((isNext) ? currentResolutionInt + 1 : currentResolutionInt - 1, availableScreenResolution.Count)];
        //Debug.Log($"{currentResolutionInt} / {availableScreenResolution.Count} - {nextResolution}");
        Screen.SetResolution(nextResolution.width, nextResolution.height, currentFullscreenMode);

        _SetupScreenResolutions();
    }

    public void ChangeScreenModeSettings(bool isNext)
    {
        if (availableScreenMode.Count <= 0)
            return;

        var currentResolution = Screen.currentResolution;
        var currentFullscreenMode = Screen.fullScreenMode;

        int currentModeInt = availableScreenMode.FindIndex((x) => x.Equals(currentFullscreenMode));
        if (currentModeInt == -1)
            return;

        var nextMode = availableScreenMode[(int)Mathf.Repeat((isNext) ? currentModeInt + 1 : currentModeInt - 1, availableScreenMode.Count)];
        Screen.SetResolution(currentResolution.width, currentResolution.height, nextMode);

        _SetupScreenResolutions();
    }

    public void ChangeQualitySettings(bool isNext)
    {
        int currentQuality = QualitySettings.GetQualityLevel();
        int nextQuality = (int)Mathf.Repeat((isNext) ? currentQuality + 1 : currentQuality - 1, QualitySettings.names.Length);
        QualitySettings.SetQualityLevel(nextQuality, true);

        OnQualityLevelChanged?.Invoke(nextQuality);

        // jangan lupa saving

        _SetupScreenResolutions();
    }

    private void _Localize()
    {
        m_musicVolumeText.text = LocalizationManager.SYSTEM_MUSICVOLUME;
        m_sfxVolumeText.text = LocalizationManager.SYSTEM_SFXVOLUME;
        m_screenResolutionText.text = LocalizationManager.SYSTEM_SCREENRESOLUTIONS;
        m_screenModeText.text = LocalizationManager.SYSTEM_SCREENMODE;
        m_graphicPresetText.text = LocalizationManager.SYSTEM_GRAPHICPRESET;
    }

    private void _SetupScreenResolutions()
    {
        if (Screen.resolutions.Length <= 0)
            return;

        if (QualitySettings.names.Length <= 0)
            return;

        if (availableScreenResolution == null || availableScreenResolution.Count <= 0)
        {
            availableScreenResolution = Screen.resolutions.ToList();
            //Debug.Log(string.Join(". ", availableScreenResolution));
            // filter list screen resolution dsiini 
        }

        if (availableScreenResolution.Count <= 0)
            return;

        if (availableScreenMode == null || availableScreenMode.Count <= 0)
        {
            availableScreenMode.Add(FullScreenMode.ExclusiveFullScreen);
            availableScreenMode.Add(FullScreenMode.FullScreenWindow);
            availableScreenMode.Add(FullScreenMode.Windowed);
        }

        if (availableScreenMode.Count <= 0)
            return;

        var currentScreenResolution = Screen.currentResolution;
        string currentFullscreenMode = Screen.fullScreenMode.ToString();
        string currentQualityName = QualitySettings.names[QualitySettings.GetQualityLevel()];

        m_screenResolutionListText.text = $"{currentScreenResolution.width}x{currentScreenResolution.height}";
        m_screenModeText.text = $"{currentFullscreenMode}";
        m_graphicPresetListText.text = $"{currentQualityName}";
    }

    private void _SetupAudio()
    {
        if (!GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.GetFloat("musicVolume", out float musicVolume))
            return;

        if (!GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.GetFloat("sfxVolume", out float sfxVolume))
            return;

        m_musicVolumeSlider.value = _ConvertVolume(musicVolume);
        m_sfxVolumeSlider.value = _ConvertVolume(sfxVolume);
    }

    private float _ConvertVolume(float val, bool isDbToPercentage = true) 
    {
        if (!isDbToPercentage)
            return (val / 100.0f * 80.0f) - 80.0f;

        return (val + 80.0f) / 80.0f * 100.0f; 
    }
}