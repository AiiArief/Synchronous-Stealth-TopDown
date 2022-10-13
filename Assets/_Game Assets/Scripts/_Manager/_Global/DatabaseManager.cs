using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneLevel
{
    [SerializeField] string m_sceneName;
    public string sceneName { get { return m_sceneName; } }

    [SerializeField] string[] m_scenes;
    public string[] scenes { get { return m_scenes; } }

    [SerializeField] LocalPhysicsMode[] m_physicsModes;
    public LocalPhysicsMode[] physicsModes { get { return m_physicsModes; } }
}

public class DatabaseManager : MonoBehaviour
{
    // character list --> suara list, kalo pintu password list
    // level list --> dapetin nama-nama scene
    [SerializeField] AudioClip m_music_frostWaltz;
    public AudioClip music_FrostWaltz { get { return m_music_frostWaltz; } }

    [SerializeField] AudioClip m_music_teddyBearWaltz;
    public AudioClip music_teddyBearWaltz { get { return m_music_teddyBearWaltz; } }

    [SerializeField] AudioClip m_music_spyGlass;
    public AudioClip music_spyGlass { get { return m_music_spyGlass; } }

    [SerializeField] AudioClip m_music_fireBrand;
    public AudioClip music_fireBrand { get { return m_music_fireBrand; } }

    [SerializeField] AudioClip m_music_waltz_havva;
    public AudioClip music_waltz_havva { get { return m_music_waltz_havva; } }

    [SerializeField] AudioClip m_passwordTrue;
    public AudioClip passwordTrue { get { return m_passwordTrue; } }

    [SerializeField] AudioClip m_passwordWrong;
    public AudioClip passwordWrong { get { return m_passwordWrong; } }

    [SerializeField] AudioClip m_tikTok;
    public AudioClip tikTok { get { return m_tikTok; } }

    [SerializeField] SceneLevel[] m_sceneLevels;
    public SceneLevel[] sceneLevels { get { return m_sceneLevels; } }

    public SceneLevel GetSceneLevelFromScenes(string scenes = "")
    {
        string searchedScene = scenes;
        if (scenes == "") searchedScene = SceneManager.GetActiveScene().name;

        for (int i=0; i<sceneLevels.Length; i++)
        {
            if (searchedScene == sceneLevels[i].scenes[0])
                return sceneLevels[i];
        }

        Debug.LogError("Scenes Not Found : " + searchedScene);
        return null;
    }

    public SceneLevel GetSceneLevelFromSceneName(string sceneName)
    {
        for(int i=0; i<sceneLevels.Length; i++)
        {
            if (sceneName == sceneLevels[i].sceneName)
                return sceneLevels[i];
        }

        Debug.LogError("Scene Name Not Found : " + sceneName);
        return null;
    }
}
