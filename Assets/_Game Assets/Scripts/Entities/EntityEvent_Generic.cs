using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEvent_Generic : EntityEvent
{
    public VoicePack voicePack { get; private set; }

    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();
        _TeleportPlayerToCheckpoint(em.currentcheckpoint);
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));

        foreach (Transform child in transform)
        {
            child.GetComponent<EntityEvent>().EventOnLoadLevel();
        }
    }

    public void CheckpointEvent()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_CHECKPOINT), 5.0f);
    }

    public void PlayerPause()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."),
                new DialogueChoice[3] {
                    new DialogueChoice(LocalizationManager.GENERIC_PAUSE_CHOICES[0], () => {
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PAUSE_CHOICES[1], () => {
                        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
                        _RetryLastCheckpointButton();
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PAUSE_CHOICES[2], () => {
                        QuitButton();
                    })
                })));
    }

    public void PlayerIsCapturedEvent(EntityCharacterNPC byWhom)
    {
        um.ClearUIAction();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        // seharusnya dapetin nama bywhom dulu
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD, LocalizationManager.GENERIC_CAPTURED, byWhom.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.GENERIC_CAPTURED_CHOICES[0], () => { _RetryLastCheckpointButton(); }),
                    new DialogueChoice(LocalizationManager.GENERIC_CAPTURED_CHOICES[1], () => { QuitButton(); })
                })));
    }


    public void DoorNoSwitchEvent_Generic()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_DOORNOSWITCH))));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void ElefataaEvent_Generic_Failed(EntityEvent levelEvent, EntityCharacterNPC2D1BitSwitch doorSwitch, CutsceneCamera m_elevatorEvent_Camera)
    {
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_FAILED, doorSwitch.voicePack))));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
        um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
    }

    public void ElefataaEvent_Generic_Uptown(EntityEvent levelEvent, EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
        um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[2], true, 11));
    }

    public void ElefataaEvent_Generic_Downtown(EntityEvent levelEvent, EntityCharacterNPC2D1BitSwitch doorSwitch, LocalizationString passwordChoice, bool haveKey, CutsceneCamera m_elevatorEvent_Camera)
    {
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_DOWNTOWN[0], doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_DOWNTOWN[1], doorSwitch.voicePack),
        new DialogueChoice[2] {
            new DialogueChoice(passwordChoice, () => {
                doorSwitch.switchForDoors[0].EnterPassword(new PasswordChoice[] {
                    new PasswordChoice(2, LocalizationManager.GENERIC_ELEFATAAEVENT_DOWNTOWN_PASSWORD_ANSWERS[0] , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(1, LocalizationManager.GENERIC_ELEFATAAEVENT_DOWNTOWN_PASSWORD_ANSWERS[1] , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(0, LocalizationManager.GENERIC_ELEFATAAEVENT_DOWNTOWN_PASSWORD_ANSWERS[2] , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(1, LocalizationManager.GENERIC_ELEFATAAEVENT_DOWNTOWN_PASSWORD_ANSWERS[3] , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], doorSwitch.voicePack), haveKey),
                },
                () => {
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_PASSWORD_CORRECT[0], doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_PASSWORD_CORRECT[1], doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
                    um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[4]));
                },
                () => {
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_PASSWORD_WRONG, doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                });
            }),
            new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
            }),
        })));
    }

    public void ElefataaEvent_Generic_Observatory(EntityEvent levelEvent, EntityCharacterNPC2D1BitSwitch doorSwitch, LocalizationString passwordChoice, bool haveKey, CutsceneCamera m_elevatorEvent_Camera, CutsceneCamera m_trappedEvent_Camera = null)
    {
        um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY[0], doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY[1], doorSwitch.voicePack),
        new DialogueChoice[3] {
            new DialogueChoice(passwordChoice, () => {
                doorSwitch.switchForDoors[0].EnterPassword(new PasswordChoice[] {
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(2, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_QUESTION, doorSwitch.voicePack), haveKey),
                },
                () => {
                    um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_PASSWORD_CORRECT[0], doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_PASSWORD_CORRECT[1], doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
                    um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[3], true));
                },
                () => {
                    um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_PASSWORD_WRONG, doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                });
            }),
            new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_CHOICE, () => {
                um.AddUIAction(() => { player.animator.SetTrigger("interact"); um.NextAction(); });
                um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                if(m_trappedEvent_Camera)
                {
                    string passwordProtectorName = LocalizationManager.Translate(LocalizationManager.CHARACTER_2D1BIT_FIREPLACE);

                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_UPTOWN[0], doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => { m_trappedEvent_Camera.UseCamera(); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_UPTOWN[1], doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_UPTOWN[2], doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_UPTOWN[3], doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => { m_trappedEvent_Camera.ReleaseCamera(); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                } else
                {
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_NONUPTOWN, doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }
            }),
            new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
            }),
        })));
    }

    public void QuitButton(bool fromGameplay = true)
    {
        if (fromGameplay) um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, LocalizationManager.GENERIC_QUIT, voicePack))));
        um.AddUIAction(() => Application.Quit());
    }

    protected override void _BasicOnLoadLevel()
    {
        base._BasicOnLoadLevel();
        voicePack = GetComponent<VoicePack>();
    }

    private void _RetryLastCheckpointButton()
    {
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.GetSceneLevelFromScenes(), false, em.currentcheckpoint));
    }
}
