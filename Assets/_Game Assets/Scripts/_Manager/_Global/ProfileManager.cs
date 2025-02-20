using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo : ubah ke jeson
public class ProfileManager : MonoBehaviour
{
    public const string PLAYERPREFS_ISFIRSTTIMESAVE = "isFirstTimeSave";
    public const string PLAYERPREFS_MUSICVOLUME = "musicVolume";
    public const string PLAYERPREFS_SFXVOLUME = "sfxVolume";
    public const string PLAYERPREFS_RESOLUTION = "resolution";
    public const string PLAYERPREFS_LANGUAGEID = "languageId";
    public const string PLAYERPREFS_CURRENTSCENE = "currentScene";
    public const string PLAYERPREFS_CURRENTSCENECHECKPOINT = "currentSceneCheckpoint";
    public const string PLAYERPREFS_HAVEPASSWORD = "havePassword";
    public const string PLAYERPREFS_HAVEDIARY = "haveDiary";

    public void ClearProfile()
    {
        PlayerPrefs.DeleteAll();
        SetupFirstTimeSave();
    }

    public void SetupFirstTimeSave()
    {
        if (PlayerPrefs.GetString(PLAYERPREFS_ISFIRSTTIMESAVE, true.ToString()) == true.ToString())
        {
            PlayerPrefs.SetString(PLAYERPREFS_ISFIRSTTIMESAVE, false.ToString());
            PlayerPrefs.SetFloat(PLAYERPREFS_MUSICVOLUME, 100.0f);
            PlayerPrefs.SetFloat(PLAYERPREFS_SFXVOLUME, 100.0f);
            PlayerPrefs.SetInt(PLAYERPREFS_RESOLUTION, GlobalGameManager.Instance.systemUIManager.GenerateDefaultResolution());
            PlayerPrefs.SetInt(PLAYERPREFS_LANGUAGEID, 0);
            PlayerPrefs.SetString(PLAYERPREFS_CURRENTSCENE, "Void World");
            PlayerPrefs.SetInt(PLAYERPREFS_CURRENTSCENECHECKPOINT, 0);
        }
    }
}
