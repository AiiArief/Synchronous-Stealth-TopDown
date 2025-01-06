using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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

        HandleSpecs();
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
            Debug.Log("Mute!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            QualitySettings.SetQualityLevel(0, true);
            Screen.SetResolution(960, 540, FullScreenMode.FullScreenWindow, 30);
            Debug.Log("Quality level 0");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            QualitySettings.SetQualityLevel(1, true);
            Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow, 60);
            Debug.Log("Quality level 1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            QualitySettings.SetQualityLevel(2, true);
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 60);
            Debug.Log("Quality level 2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            QualitySettings.SetQualityLevel(3, true);
            Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow, 60);
            Debug.Log("Quality level 3");
        }
    }

    private void OnApplicationQuit()
    {
        //Application.OpenURL("https://forms.gle/TaZ6Vkf4QSFH9WS2A");
    }

    private void HandleSpecs()
    {
        string cpu = SystemInfo.processorType;
        string ram = SystemInfo.systemMemorySize + " MB";
        string gpu = SystemInfo.graphicsDeviceName + " (" + SystemInfo.graphicsMemorySize + "MB)";

        // adjust quality here

        //Analytics.CustomEvent("hardware_specs", new Dictionary<string, object> { {"CPU", cpu}, {"RAM", ram}, {"GPU", gpu} });
    }
}
