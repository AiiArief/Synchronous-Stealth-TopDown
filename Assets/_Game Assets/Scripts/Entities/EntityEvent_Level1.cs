using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1 : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        if (PlayerPrefs.GetInt(ProfileManager.PLAYERPREFS_CURRENTSCENECHECKPOINT) == 0)
        {
            AddBasicStatusEffectOnStartingEvent();
            player.animator.gameObject.SetActive(false);

            um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
            um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_HAVVASKINGDOM_NOBLEAREA), 3.0f); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { em.triggerCheckpoints[0].teleportArea.gameObject.SetActive(true); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AnimateTransition("flashbang")));
            um.AddUIAction(() => { player.animator.gameObject.SetActive(true); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(4.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
            um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(2); um.NextAction(); });

            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
            return;
        }

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_HAVVASKINGDOM_NOBLEAREA), 5.0f); um.NextAction(); });
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(2); um.NextAction(); });
    }
}
