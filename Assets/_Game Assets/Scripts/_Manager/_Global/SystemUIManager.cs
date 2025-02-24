using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SystemUIManager : MonoBehaviour
{
    static Resolution[] commonResolutions = new Resolution[]
    {
        new Resolution { width = 640, height = 360, refreshRate = 60 },
        new Resolution { width = 854, height = 480, refreshRate = 60 },
        new Resolution { width = 960, height = 540, refreshRate = 60 },
        new Resolution { width = 1024, height = 576, refreshRate = 60 },
        new Resolution { width = 1280, height = 720, refreshRate = 60 },
        new Resolution { width = 1366, height = 768, refreshRate = 60 },
        new Resolution { width = 1600, height = 900, refreshRate = 60 },
        new Resolution { width = 1920, height = 1080, refreshRate = 60 },
        new Resolution { width = 2560, height = 1440, refreshRate = 60 },
        new Resolution { width = 3200, height = 1800, refreshRate = 60 },
        new Resolution { width = 3840, height = 2160, refreshRate = 60 },
        new Resolution { width = 1280, height = 800, refreshRate = 60 },
        new Resolution { width = 1440, height = 900, refreshRate = 60 },
        new Resolution { width = 1680, height = 1050, refreshRate = 60 },
        new Resolution { width = 1920, height = 1200, refreshRate = 60 },
        new Resolution { width = 2560, height = 1600, refreshRate = 60 },
        new Resolution { width = 3840, height = 2400, refreshRate = 60 }
    };

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

    [SerializeField] Text m_applyText;

    float onOpenTimeScale = -1.0f;
    List<Resolution> availableScreenResolution = new List<Resolution>();
    Dictionary<FullScreenMode, string> availableScreenMode = new Dictionary<FullScreenMode, string>();

    Resolution appliedResolution = new Resolution();
    FullScreenMode appliedFullscreenMode = new FullScreenMode();

    GameObject tempSelectedGameObject;

    public int GenerateDefaultResolution()
    {
        var currentMonitorResolution = Screen.currentResolution;
        var commonResolutionsList = commonResolutions.ToList();
        var currentMonitorResolutionIndex = commonResolutionsList.FindIndex(x => x.width == currentMonitorResolution.width && x.height == currentMonitorResolution.height);
        if (currentMonitorResolutionIndex >= 0)
            return currentMonitorResolutionIndex;

        return commonResolutionsList.FindIndex(x => x.width == 1280 && x.height == 720);
    }

    public void LoadAndApplyFromProfileManager()
    {
        var profileMusicVolumeInDB = _ConvertVolume(PlayerPrefs.GetFloat(ProfileManager.PLAYERPREFS_MUSICVOLUME, 100.0f), false);
        GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.SetFloat("musicVolume", profileMusicVolumeInDB);

        var profileSFXVolumeInDB = _ConvertVolume(PlayerPrefs.GetFloat(ProfileManager.PLAYERPREFS_SFXVOLUME, 100.0f), false);
        GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.SetFloat("sfxVolume", profileSFXVolumeInDB);

        var res = _GetCurrentResolution();
        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode, res.refreshRate);
        //Application.targetFrameRate = 60;
    }

    public void ToggleSystemUI()
    {
        onOpenTimeScale = (onOpenTimeScale < 0.0f) ? Time.timeScale : onOpenTimeScale;
        Time.timeScale = onOpenTimeScale;

        gameObject.SetActive(!gameObject.activeSelf);
        if (!gameObject.activeSelf)
        {
            if (tempSelectedGameObject != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(tempSelectedGameObject);
            }

            return;
        }

        onOpenTimeScale = Time.timeScale;
        Time.timeScale = 0;

        appliedResolution = _GetCurrentResolution();
        appliedFullscreenMode = Screen.fullScreenMode;

        tempSelectedGameObject = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_applyText.transform.parent.gameObject);

        _Localize();
        _SetupScreenResolutions();
        _SetupAudio();
    }

    public void ApplyChange()
    {
        int appliedResolutionIndex = commonResolutions.ToList().IndexOf(appliedResolution);
        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_RESOLUTION, appliedResolutionIndex);

        Screen.SetResolution(appliedResolution.width, appliedResolution.height, appliedFullscreenMode, appliedResolution.refreshRate);
        ToggleSystemUI();
    }

    public void ChangeMusicVolume(bool isNext)
    {
        if (!GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.GetFloat("musicVolume", out float musicVolume))
            return;

        var currentVolume = _ConvertVolume(musicVolume);
        var nextVolume = (isNext) ? currentVolume + 10.0f : currentVolume - 10.0f;
        var nextVolumeInDB = _ConvertVolume(Mathf.Clamp(nextVolume, 0, 100.0f), false);
        GlobalGameManager.Instance.soundManager.musicAudioMixer.audioMixer.SetFloat("musicVolume", nextVolumeInDB);

        PlayerPrefs.SetFloat(ProfileManager.PLAYERPREFS_MUSICVOLUME, Mathf.Clamp(nextVolume, 0, 100.0f));

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

        PlayerPrefs.SetFloat(ProfileManager.PLAYERPREFS_SFXVOLUME, Mathf.Clamp(nextVolume, 0, 100.0f));

        _SetupAudio();
    }

    public void ChangeResolutionSettings(bool isNext)
    {
        if (availableScreenResolution.Count <= 0)
            return;

        int currentResolutionInt = availableScreenResolution.FindIndex((x) => x.Equals(appliedResolution));
        if (currentResolutionInt == -1)
            return;

        var nextResolution = availableScreenResolution[(int)Mathf.Repeat((isNext) ? currentResolutionInt + 1 : currentResolutionInt - 1, availableScreenResolution.Count)];
        appliedResolution = nextResolution;
        m_screenResolutionListText.text = $"{nextResolution.width}x{nextResolution.height}@{nextResolution.refreshRate}Hz";
    }

    public void ChangeScreenModeSettings(bool isNext)
    {
        if (availableScreenMode.Count <= 0)
            return;

        var availableScreenModeList = availableScreenMode.ToList();
        int currentModeInt = availableScreenModeList.FindIndex((x) => x.Key.Equals(appliedFullscreenMode));
        if (currentModeInt == -1)
            return;

        var nextMode = availableScreenModeList[(int)Mathf.Repeat((isNext) ? currentModeInt + 1 : currentModeInt - 1, availableScreenModeList.Count)].Key;
        appliedFullscreenMode = nextMode;

        string nextModeStr = availableScreenMode[nextMode];
        m_screenModeListText.text = $"{nextModeStr}";
    }

    public void ChangeQualitySettings(bool isNext)
    {
        int currentQuality = QualitySettings.GetQualityLevel();
        int nextQuality = (int)Mathf.Repeat((isNext) ? currentQuality + 1 : currentQuality - 1, QualitySettings.names.Length);
        QualitySettings.SetQualityLevel(nextQuality, true);

        OnQualityLevelChanged?.Invoke(nextQuality);

        _SetupScreenResolutions();
    }

    private void _Localize()
    {
        m_musicVolumeText.text = LocalizationManager.SYSTEM_MUSICVOLUME;
        m_sfxVolumeText.text = LocalizationManager.SYSTEM_SFXVOLUME;
        m_screenResolutionText.text = LocalizationManager.SYSTEM_SCREENRESOLUTIONS;
        m_screenModeText.text = LocalizationManager.SYSTEM_SCREENMODE;
        m_graphicPresetText.text = LocalizationManager.SYSTEM_GRAPHICPRESET;
        m_applyText.text = LocalizationManager.SYSTEM_APPLY;
    }

    private void _SetupScreenResolutions()
    {
        if (Screen.resolutions.Length <= 0)
            return;

        if (QualitySettings.names.Length <= 0)
            return;

        if (availableScreenResolution == null || availableScreenResolution.Count <= 0)
        {
            availableScreenResolution.AddRange(commonResolutions.Select(resolution => new Resolution
            {
                width = resolution.width,
                height = resolution.height,
                refreshRate = resolution.refreshRate
            }));
        }

        if (availableScreenResolution.Count <= 0)
            return;

        if (availableScreenMode == null || availableScreenMode.Count <= 0)
        {
            availableScreenMode.Add(FullScreenMode.ExclusiveFullScreen, "Exclusive Fullscreen");
            availableScreenMode.Add(FullScreenMode.FullScreenWindow, "Fullscreen Window");
            //availableScreenMode.Add(FullScreenMode.MaximizedWindow, "Maximized Window");
            availableScreenMode.Add(FullScreenMode.Windowed, "Windowed");
        }

        if (availableScreenMode.Count <= 0)
            return;

        var currentScreenResolution = _GetCurrentResolution();
        string currentFullscreenMode = availableScreenMode[Screen.fullScreenMode];
        string currentQualityName = QualitySettings.names[QualitySettings.GetQualityLevel()];

        m_screenResolutionListText.text = $"{currentScreenResolution.width}x{currentScreenResolution.height}@{currentScreenResolution.refreshRate}Hz";
        m_screenModeListText.text = $"{currentFullscreenMode}";
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

    private Resolution _GetCurrentResolution()
    {
        var currentResolutionIndex = PlayerPrefs.GetInt(ProfileManager.PLAYERPREFS_RESOLUTION, GenerateDefaultResolution());
        if (currentResolutionIndex < 0)
            currentResolutionIndex = GenerateDefaultResolution();

        var res = commonResolutions[currentResolutionIndex];
        return res;
    }
}