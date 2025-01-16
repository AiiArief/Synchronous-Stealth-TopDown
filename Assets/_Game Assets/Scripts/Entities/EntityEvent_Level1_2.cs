using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_2 : EntityEvent
{
    [SerializeField] CutsceneCamera m_closeDoorEvent_1_Camera;
    bool m_closeDoorEvent_1_firstTime = true;
    public void CloseDoorEvent_1(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        if (m_closeDoorEvent_1_firstTime)
        {
            m_closeDoorEvent_1_Camera.UseCamera();
            um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
            um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
            um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_2_CLOSEDOOR_0, doorSwitch.voicePack),
                    new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.L1_2_CLOSEDOOR_0_1, () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, LocalizationManager.L1_2_CLOSEDOOR_0_1_0, doorSwitch.voicePack))));
                        um.AddUIAction(() => { doorSwitch.UseSwitch(); m_closeDoorEvent_1_firstTime = false; um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_closeDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.L1_2_CLOSEDOOR_0_2, () => {
                        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_closeDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
            })));
        }
        else
        {
            doorSwitch.UseSwitch();
        }
    }

    public void DevlogDiaryTriggerEvent_2()
    {
        int eventId = 2;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_2_DIARY_0, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_2_DIARY_1, em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, LocalizationManager.L1_2_DIARY_2, em.genericEvent.voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L1_2_DIARY_3))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }
}
