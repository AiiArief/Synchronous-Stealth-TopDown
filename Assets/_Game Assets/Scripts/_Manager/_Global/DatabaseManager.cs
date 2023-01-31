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

    [SerializeField] AudioClip m_me_victory;
    public AudioClip me_victory { get { return m_me_victory; } }

    [SerializeField] AudioClip m_sfx_passwordTrue;
    public AudioClip sfx_passwordTrue { get { return m_sfx_passwordTrue; } }

    [SerializeField] AudioClip m_sfx_passwordWrong;
    public AudioClip sfx_passwordWrong { get { return m_sfx_passwordWrong; } }

    [SerializeField] AudioClip m_sfx_tikTok;
    public AudioClip sfx_tikTok { get { return m_sfx_tikTok; } }

    [SerializeField] AudioClip m_sfx_computer;
    public AudioClip sfx_computer { get { return m_sfx_computer; } }

    [SerializeField] AudioClip m_sfx_pptTransition;
    public AudioClip sfx_pptTransition { get { return m_sfx_pptTransition; } }

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
