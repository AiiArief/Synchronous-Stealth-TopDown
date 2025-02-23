﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class EntityEvent_VoidWorld : EntityEvent_Generic
{
    public override void EventOnLoadLevel()
    {
        _BasicOnLoadLevel();

        AddBasicStatusEffectOnStartingEvent();

        string currentScene = PlayerPrefs.GetString(ProfileManager.PLAYERPREFS_CURRENTSCENE, "Void World");

        #region End Game - Demo
        if (currentScene == "Havvatopia - Downtown") {
            _EndGameDemo();
            return;
        }
        #endregion

        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("logoSSV", 5.0f)));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));

        #region Mid Game
        if (currentScene != "Void World")
        {
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_MIDGAME_0, em.genericEvent.voicePack),
                    new DialogueChoice[3] {
                        new DialogueChoice(LocalizationManager.VW_MIDGAME_0_1, () => _LoadGameButton(currentScene)),
                        new DialogueChoice(LocalizationManager.VW_MIDGAME_0_2, () => _ClearSaveGameButton(currentScene)),
                        new DialogueChoice(LocalizationManager.VW_MIDGAME_0_3, () => em.genericEvent.QuitButton(false))
                    })));
            return;
        }
        #endregion

        #region Start Game
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, LocalizationManager.VW_ONLOAD_0, em.genericEvent.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.VW_ONLOAD_0_1, () => { 
                        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, (int)LocalizationLanguage.English); 
                    }),
                    new DialogueChoice(LocalizationManager.VW_ONLOAD_0_2, () => { 
                        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, (int)LocalizationLanguage.Indonesia); 
                    })
                })));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, LocalizationManager.VW_ONLOAD_1, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, LocalizationManager.VW_ONLOAD_2, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, LocalizationManager.VW_ONLOAD_3, em.genericEvent.voicePack))));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, LocalizationManager.VW_ONLOAD_4, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, LocalizationManager.VW_ONLOAD_5, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_6, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_7, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_8, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_9, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_10, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_11, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_12, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_13, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_14, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_15, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_16, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_17, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_18, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_19, em.genericEvent.voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { StartCoroutine(VCamSlowlyGlideUp()); StartCoroutine(um.AnimateTransition("fade", 5.0f)); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_20, em.genericEvent.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.VW_ONLOAD_20_1, () => { 
                        _NewGameButton(); 
                    }),
                    new DialogueChoice(LocalizationManager.VW_ONLOAD_20_2, () => {
                        em.genericEvent.QuitButton(); 
                    })
                })));
        #endregion
    }

    private void _NewGameButton()
    {
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_21, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_22, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_23, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_24, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_25, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_26, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_27, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_28, em.genericEvent.voicePack), 
            new DialogueChoice[4]
            {
                new DialogueChoice(LocalizationManager.VW_ONLOAD_28_1, () => player.animator.SetInteger("expression", 1)),
                new DialogueChoice(LocalizationManager.VW_ONLOAD_28_2, () => player.animator.SetInteger("expression", 3)),
                new DialogueChoice(LocalizationManager.VW_ONLOAD_28_3, () => player.animator.SetInteger("expression", 4)),
                new DialogueChoice(LocalizationManager.VW_ONLOAD_28_4, () => player.animator.SetInteger("expression", 0)),
            }
            )));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_29, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(3.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_30, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_31, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_32, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_33, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_ONLOAD_34, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { em.triggerCheckpoints[0].teleportArea.gameObject.SetActive(true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("flashbang")));
        um.AddUIAction(() => { player.animator.gameObject.SetActive(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(4.0f)));
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[1]));
    }

    private void _LoadGameButton(string sceneName)
    {
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.GetSceneLevelFromSceneName(sceneName), false));
    }

    private void _ClearSaveGameButton(string currentScene)
    {
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_MIDGAME_NEW_0, em.genericEvent.voicePack),
            new DialogueChoice[2] {
                new DialogueChoice(LocalizationManager.VW_MIDGAME_NEW_0_1, () => {
                    GlobalGameManager.Instance.profileManager.ClearProfile();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                }),
                new DialogueChoice(LocalizationManager.VW_MIDGAME_NEW_0_2, () => { _LoadGameButton(currentScene); })
            })));
    }

    [SerializeField] CinemachineVirtualCamera m_startCamera;
    private IEnumerator VCamSlowlyGlideUp()
    {
        var trackedDolly = m_startCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        var currentPath = 0.0f;
        while(currentPath < trackedDolly.m_Path.MaxPos)
        {
            currentPath += Time.deltaTime / 5.0f;
            trackedDolly.m_PathPosition = currentPath;
            yield return new WaitForEndOfFrame();
        }
    }

    private void _EndGameDemo() {
        um.AddUIAction(() => { StartCoroutine(VCamSlowlyGlideUp()); StartCoroutine(um.AnimateTransition("fade", 5.0f)); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_0, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_1, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_2, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_3, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_4, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_5, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_6, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_7, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_8, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_9, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_10, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_11, em.genericEvent.voicePack))));

        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(2); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.VW_END_12))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.VW_END_13))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.VW_END_14))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.VW_END_15))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.VW_END_16))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_17, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_18, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_19, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_20, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_21, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_22, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_23, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.VW_END_24, em.genericEvent.voicePack),
        new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.VW_END_24_1, () => {
                        GlobalGameManager.Instance.profileManager.ClearProfile();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }),
                    new DialogueChoice(LocalizationManager.VW_END_24_2, () => {
                        um.AddUIAction(() => Application.Quit());
                    })
        })));
    }
}
