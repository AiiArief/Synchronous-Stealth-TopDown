using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_6 : EntityEvent
{
    [SerializeField] CutsceneCamera m_trappedEvent_Camera;
    [SerializeField] EntityCharacterNPC2D1BitSwitch m_trap_doorSwitch;
    public void TrappedEvent(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_TRAPPED_0))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(3); um.NextAction(); });
        um.AddUIAction(() => { m_trappedEvent_Camera.UseCamera(); um.NextAction(); });
        um.AddUIAction(() => { m_trap_doorSwitch.SetCurrentIsOn(true); m_trap_doorSwitch.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { player.storedActions.Add(new StoredActionTurn(player, 90, false)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_1, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_2, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_3, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_4, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_5, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_6, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPED_7, doorSwitch.voicePack))));
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_TRAPPED_8))));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 1); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_TRAPPED_9))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_TRAPPED_10))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); m_trappedEvent_Camera.ReleaseCamera(); doorSwitch.SetExpression(Expression_2D1Bit.Dead); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void TrappedEvent_Win(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        int eventId = 3;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.UseSwitch(); m_trap_doorSwitch.SetCurrentIsOn(false); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { player.storedActions.Add(new StoredActionTurn(player, 90, false)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_0, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_1, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_2, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_3, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_TRAPPEDWIN_4))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); StartCoroutine(GlobalGameManager.Instance.soundManager.PlayMusicEffect(GlobalGameManager.Instance.databaseManager.me_victory, false)); um.NextAction(); });
        um.AddUIAction(() => { player.animator.SetInteger("expression", 3); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_TRAPPEDWIN_5))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_6, doorSwitch.voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_7, doorSwitch.voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_8, doorSwitch.voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_9, doorSwitch.voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE, LocalizationManager.L1_6_TRAPPEDWIN_10, doorSwitch.voicePack)))); 
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });

        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(2); um.NextAction(); });
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_2_Camera;
    public void OpenDoorEvent_Password_2(EntityCharacterNPC2D1BitDoor door)
    {
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_2";
        bool haveKey = door.CheckPasswordWithKey(key);
        LocalizationString passwordChoice = haveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_openDoorEvent_password_2_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_0, door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1, door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(passwordChoice, () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack), haveKey),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack), haveKey),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack), haveKey),
                        },
                        () => {
                            um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_T0, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_T1, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_T2, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_T3, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_T4, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_T5, door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_6_OPENDOORPASS2_1_1_F0, door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_3_Camera;
    public void OpenDoorEvent_Password_3(EntityCharacterNPC2D1BitDoor door)
    {
        m_openDoorEvent_password_3_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_0, door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_1, door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_2, door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[0], () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack)),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack)),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack)),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[3], door.voicePack)),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[4], door.voicePack)),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[5], door.voicePack)),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[6], door.voicePack)),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[7], door.voicePack)),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[8], door.voicePack)),
                        },
                        () => {
                            um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_2_1_T0, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_2_1_T1, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_2_1_T2, door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_2_1_F0, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_RGBGAMINGDOOR, LocalizationManager.L1_6_OPENDOORPASS3_2_1_F1, door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_elevatorEvent_Camera;
    public void ElevatorEvent(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        string observatoryKey = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + GlobalGameManager.Instance.databaseManager.sceneLevels[2].scenes[0] + "_3";
        string downTownKey = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + GlobalGameManager.Instance.databaseManager.sceneLevels[3].scenes[0] + "_1";
        bool observatoryHaveKey = doorSwitch.switchForDoors[0].CheckPasswordWithKey(observatoryKey);
        bool downTownHaveKey = doorSwitch.switchForDoors[0].CheckPasswordWithKey(downTownKey);
        LocalizationString observatoryPasswordChoice = observatoryHaveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];
        LocalizationString downTownPasswordChoice = downTownHaveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_elevatorEvent_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.L1_6_ELEVATOREVENT_0, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.L1_6_ELEVATOREVENT_1, doorSwitch.voicePack),
            new DialogueChoice[5] {
                new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAGOTOCHOICES_OBSERVATORY, () => {
                    em.genericEvent.ElefataaEvent_Generic_Observatory(this, doorSwitch, observatoryPasswordChoice, observatoryHaveKey, m_elevatorEvent_Camera, m_trappedEvent_Camera);
                }),
                new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAGOTOCHOICES_DOWNTOWN, () => {
                    em.genericEvent.ElefataaEvent_Generic_Downtown(this, doorSwitch, downTownPasswordChoice, downTownHaveKey, m_elevatorEvent_Camera);
                }),
                new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAGOTOCHOICES_ENGINE, () => {
                    em.genericEvent.ElefataaEvent_Generic_Failed(this, doorSwitch, m_elevatorEvent_Camera);
                }),
                new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAGOTOCHOICES_UNDERGROUND, () => {
                    em.genericEvent.ElefataaEvent_Generic_Failed(this, doorSwitch, m_elevatorEvent_Camera);
                }),
                new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAGOTOCHOICES_CANCEL, () => {
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
            })));
    }
    
    public void DevlogDiaryTriggerEvent_6()
    {
        int eventId = 6;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_6_DIARY_0, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_6_DIARY_1, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_6_DIARY_2, em.genericEvent.voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_6_DIARY_3))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }
}
