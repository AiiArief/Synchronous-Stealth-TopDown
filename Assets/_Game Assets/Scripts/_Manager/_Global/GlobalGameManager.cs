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
    public SystemUIManager systemUIManager;

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

        profileManager.SetupFirstTimeSave();
        systemUIManager.LoadAndApplyFromProfileManager();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            systemUIManager.ToggleSystemUI();
        }
    }
}