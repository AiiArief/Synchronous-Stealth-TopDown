using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_4 : EntityEvent
{
    public void DevlogDiaryTriggerEvent_4()
    {
        int eventId = 4;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Ini gua ngoding bego dah.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Semua yang interactable adalah NPC.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Makanya banyak pintu dan switch yang sekalian jadi NPC juga.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Makanya jadi ada kelas 2D 1 Bit.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gegara ngoding gua bego wkwkwk.", em.genericEvent.voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }
}
