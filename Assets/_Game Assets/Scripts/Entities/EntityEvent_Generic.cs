using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    new DialogueChoice(LocalizationManager.PAUSE_CHOICES[0], () => {
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.PAUSE_CHOICES[1], () => {
                        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
                        _RetryLastCheckpointButton();
                    }),
                    new DialogueChoice(LocalizationManager.PAUSE_CHOICES[2], () => {
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_3DHEADPHONESPHEREROBOT_GUARD, "WOY, SIAPA LU! ALERT! ALERT!", byWhom.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.CAPTURED_CHOICES[0], () => { _RetryLastCheckpointButton(); }),
                    new DialogueChoice(LocalizationManager.CAPTURED_CHOICES[1], () => { QuitButton(); })
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "M-Maaf, ada kesalahan teknis jadi tidak bisa kesana...", doorSwitch.voicePack))));
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "T-tapi buat kesana kamu butuh password...", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "M-mungkin Havva mengetahui passwordnya...", doorSwitch.voicePack),
        new DialogueChoice[2] {
            new DialogueChoice(passwordChoice, () => {
                doorSwitch.switchForDoors[0].EnterPassword(new PasswordChoice[] {
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], doorSwitch.voicePack), haveKey),
                },
                () => {
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Passwordnya benar!", doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Ayo kita ke bawah!", doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
                    um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    //um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[4));                                    
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(5.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "NYEHEHEHEHE LEVELNYA BELOM SELESAI", em.genericEvent.voicePack))));
                },
                () => {
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "M-maaf, tapi passwordnya salah...", doorSwitch.voicePack))));
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
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "M-maaf, kamu tidak bisa ke Observatory...", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "A-aslinya aku ga mau melakukan ini, t-tapi aku disuruh meminta password untuk siapapun yang ingin pergi ke Observatory agar tidak ada yang bisa menemui Havva...", doorSwitch.voicePack),
        new DialogueChoice[3] {
            new DialogueChoice(passwordChoice, () => {
                doorSwitch.switchForDoors[0].EnterPassword(new PasswordChoice[] {
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], doorSwitch.voicePack), haveKey),
                    new PasswordChoice(2, new LocalizationString[3] {
                        new LocalizationString("I'm not a employee.", "Saya bukan karyawan."),
                        new LocalizationString("I'm not a robot.", "Saya bukan robot."),
                        new LocalizationString("I'm not a spy.", "Saya bukan spy.") } ,
                        new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "D-dan terakhir, tolong isi captcha ini :", doorSwitch.voicePack), haveKey), 
                },
                () => {
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Passwordnya benar!", doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Ayo kita ke Observatory!", doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
                    um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[3], true));
                },
                () => {
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "M-maaf, tapi passwordnya salah...", doorSwitch.voicePack))));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                });
            }),
            new DialogueChoice("Passwordnya dapat dimana ya?", () => {
                if(m_trappedEvent_Camera)
                {
                    string passwordProtectorName = LocalizationManager.Translate(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR);

                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Y-yang setel passwordnya sih tadi ke arah timur laut...", doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => { m_trappedEvent_Camera.UseCamera(); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "S-Semoga saja... passwordnya engga dititipin ke " + passwordProtectorName + "...", doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Soalnya siapapun yang mendatangi " + passwordProtectorName + " akan dibakar!!!", doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Dan aku ga mau ada yang dibakar huaaaaaaaaaa!!!", doorSwitch.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => { m_trappedEvent_Camera.ReleaseCamera(); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                    um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                    um.AddUIAction(() => { levelEvent.RemoveBasicStatusEffectOnFinishEvent(); m_elevatorEvent_Camera.ReleaseCamera(); um.NextAction(); });
                } else
                {
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Y-yang setel passwordnya terakhir kulihat di Havvatopia bagian Uptown...", doorSwitch.voicePack))));
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "EHHH BENTAR BENTAR!", voicePack))));
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
