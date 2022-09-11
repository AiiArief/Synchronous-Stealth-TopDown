using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager Instance = null;

    public ProfileManager profileManager;
    public SoundManager soundManager;
    public DatabaseManager databaseManager;
    public LocalizationManager localizationManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            Transform graphy = transform.Find("[Graphy]");
            if (graphy)
                graphy.gameObject.SetActive(!graphy.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            soundManager.musicSource.mute = !soundManager.musicSource.mute;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            QualitySettings.SetQualityLevel(0, true);
            Screen.SetResolution(960, 540, FullScreenMode.FullScreenWindow, 30);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            QualitySettings.SetQualityLevel(1, true);
            Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow, 60);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            QualitySettings.SetQualityLevel(2, true);
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 60);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            QualitySettings.SetQualityLevel(3, true);
            Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow, 60);
        }
    }
}
