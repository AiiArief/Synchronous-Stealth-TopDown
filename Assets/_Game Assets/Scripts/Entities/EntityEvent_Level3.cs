using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEvent_Level3 : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));

        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_HAVVATOPIA_DOWNTOWN), 5.0f); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "NYEHEHEHEHE.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "LEVELNYA BELUM SELESAI DIBUAT!!!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Bentar, lu gua culik dulu.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { em.triggerCheckpoints[0].teleportArea.gameObject.SetActive(true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("flashbang")));
        um.AddUIAction(() => { player.animator.gameObject.SetActive(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(4.0f)));
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[0], false));
    }
}
