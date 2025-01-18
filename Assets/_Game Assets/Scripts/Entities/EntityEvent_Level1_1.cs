using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_1 : EntityEvent
{
    [SerializeField] CutsceneCamera m_doorNoSwitchEvent_Camera;
    public void DoorNoSwitchEvent()
    {
        m_doorNoSwitchEvent_Camera.UseCamera(0);
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_DOORNOSWITCH))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { player.storedActions.Add(new StoredActionTurn(player, 90, false)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { m_doorNoSwitchEvent_Camera.UseCamera(1); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_NOSWITCH_0))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_NOSWITCH_1))));
        um.AddUIAction(() => { m_doorNoSwitchEvent_Camera.ReleaseCamera(); um.NextAction(); });
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_1_Camera;
    bool m_openDoorEvent_1_firstTime = true;
    public void OpenDoorEvent_1(EntityCharacterNPC2D1BitDoor door)
    {
        m_openDoorEvent_1_Camera.UseCamera(0);
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Zzz); um.NextAction(); });

        if (m_openDoorEvent_1_firstTime) {
            m_openDoorEvent_1_firstTime = false;
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_0, door.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_1, door.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_2, door.voicePack)))); 
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_3, door.voicePack))));       
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        }

        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_4, door.voicePack),
                new DialogueChoice[3] {
                    new DialogueChoice(LocalizationManager.L1_1_OPENDOOR_4_1, () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_4_1_0, door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_4_1_1, door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_4_1_2, door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => { m_openDoorEvent_1_Camera.UseCamera(2); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_4_1_3, door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => { m_openDoorEvent_1_Camera.UseCamera(0); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.L1_1_OPENDOOR_4_2, () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, LocalizationManager.L1_1_OPENDOOR_4_2_0, door.voicePack))));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.L1_1_OPENDOOR_4_3, () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_timing_1_Camera;
    bool m_openDoorEvent_Timing_1_firstTime = true;
    public void OpenDoorEvent_Timing_1(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        if (doorSwitch.hasAutoCloseEffect)
            return;

        int useSwitchTurn = 20;
        if (!m_openDoorEvent_Timing_1_firstTime)
        {
            doorSwitch.UseSwitch(useSwitchTurn);
            return;
        }

        m_openDoorEvent_timing_1_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_0, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_1, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_2, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_3, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_4, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_5, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_6, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORTIMING_7, doorSwitch.voicePack))));
        um.AddUIAction(() => { doorSwitch.UseSwitch(useSwitchTurn); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.25f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_timing_1_Camera.ReleaseCamera(); m_openDoorEvent_Timing_1_firstTime = false; um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_1_Camera;
    public void OpenDoorEvent_Password_1(EntityCharacterNPC2D1BitDoor door)
    {
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_1";
        bool haveKey = door.CheckPasswordWithKey(key);
        LocalizationString passwordChoice = haveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_openDoorEvent_password_1_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORPASS_0, door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_1_OPENDOORPASS_1, door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2, door.voicePack),
                new DialogueChoice[3] {
                    new DialogueChoice(passwordChoice, () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack), haveKey),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack), haveKey),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack), haveKey),
                        },
                        () => {
                            um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_1_T0, door.voicePack))));
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));                            
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_1_F0, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_1_F1, door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_1_F2, door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice(LocalizationManager.L1_1_OPENDOORPASS_2_2, () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_2_0, door.voicePack)))); 
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_2_1, door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_2_2, door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.L1_1_OPENDOORPASS_2_2_3, door.voicePack))));  
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] EntityCharacterNPC3DBotHeadphone m_passwordTriggerEvent_1_3DBH_1;
    [SerializeField] EntityCharacterNPC3DBotHeadphone m_passwordTriggerEvent_1_3DBH_2;
    public void PasswordTriggerEvent_1()
    {
        int eventId = 1;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(true); player.animator.SetInteger("expression", 2); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_PASSTRIGGER_0))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_PASSTRIGGER_1))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", true); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD + " #1", LocalizationManager.L1_1_PASSTRIGGER_2, m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", false); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD + " #2", LocalizationManager.L1_1_PASSTRIGGER_3, m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", true); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD + " #1", LocalizationManager.L1_1_PASSTRIGGER_4, m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", false); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD + " #2", LocalizationManager.L1_1_PASSTRIGGER_5, m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", true); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD + " #1", LocalizationManager.L1_1_PASSTRIGGER_6, m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", false); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD + " #2", LocalizationManager.L1_1_PASSTRIGGER_7, m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => { m_passwordTriggerEvent_1_3DBH_1.animator.SetBool("isTalking", false); m_passwordTriggerEvent_1_3DBH_2.animator.SetBool("isTalking", false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_PASSTRIGGER_8))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); StartCoroutine(GlobalGameManager.Instance.soundManager.PlayMusicEffect(GlobalGameManager.Instance.databaseManager.me_victory)); um.NextAction(); });
        um.AddUIAction(() => { em.memoryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => { player.animator.SetInteger("expression", 3); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[1]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_PASSTRIGGER_9))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(2.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_1()
    {
        int eventId = 1;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_1_DIARY_0, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_1_DIARY_1, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_1_DIARY_2, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_1_DIARY_3, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_1_DIARY_4, em.genericEvent.voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_1_DIARY_5))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }
}
