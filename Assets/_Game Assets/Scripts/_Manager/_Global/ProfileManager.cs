using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo : ubah ke jeson
public class ProfileManager : MonoBehaviour
{
    public const string PLAYERPREFS_ISFIRSTTIMESAVE = "isFirstTimeSave";
    public const string PLAYERPREFS_ISMUTE = "isMute";
    public const string PLAYERPREFS_LANGUAGEID = "languageId";
    public const string PLAYERPREFS_CURRENTSCENE = "currentScene";
    public const string PLAYERPREFS_CURRENTSCENECHECKPOINT = "currentSceneCheckpoint";
    public const string PLAYERPREFS_HAVEPASSWORD = "havePassword";
    public const string PLAYERPREFS_HAVEDIARY = "haveDiary";

    private void Awake()
    {
        _SetupFirstTimeSave();
    }

    public void ClearProfile()
    {
        PlayerPrefs.DeleteAll();
        _SetupFirstTimeSave();
    }

    private void _SetupFirstTimeSave()
    {
        if (PlayerPrefs.GetString(PLAYERPREFS_ISFIRSTTIMESAVE, true.ToString()) == true.ToString())
        {
            PlayerPrefs.SetString(PLAYERPREFS_ISFIRSTTIMESAVE, false.ToString());
            PlayerPrefs.SetString(PLAYERPREFS_ISMUTE, false.ToString());
            PlayerPrefs.SetInt(PLAYERPREFS_LANGUAGEID, 0);
            PlayerPrefs.SetString(PLAYERPREFS_CURRENTSCENE, "Void World");
            PlayerPrefs.SetInt(PLAYERPREFS_CURRENTSCENECHECKPOINT, 0);
        }
    }
}
