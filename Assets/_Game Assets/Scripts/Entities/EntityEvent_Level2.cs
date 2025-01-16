using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level2 : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_HAVVATOPIA_OBSERVATORY), 5.0f); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_elevatorEvent_Camera;
    public void ElevatorEvent(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        string downTownKey = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + GlobalGameManager.Instance.databaseManager.sceneLevels[3].scenes[0] + "_1";
        bool downTownHaveKey = doorSwitch.switchForDoors[0].CheckPasswordWithKey(downTownKey);
        LocalizationString downTownPasswordChoice = downTownHaveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_elevatorEvent_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.L2_ELEVATOR_0, doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_ELEFATAA, LocalizationManager.L2_ELEVATOR_1, doorSwitch.voicePack),
            new DialogueChoice[5] {
                new DialogueChoice(LocalizationManager.GENERIC_ELEFATAAGOTOCHOICES_UPTOWN, () => {
                    em.genericEvent.ElefataaEvent_Generic_Uptown(this, doorSwitch);
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

    [SerializeField] CutsceneCamera m_talkEvent_Camera;
    bool m_firstTime = true;
    public void TalkEvent(EntityCharacterNPC2DHumanoidLaptop havva)
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        
        if(m_firstTime)
        {
            m_firstTime = false;
            um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(0); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2DHUMANOID_HAVVA, LocalizationManager.L2_TALK_0))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(1); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2DHUMANOID_HAVVA, LocalizationManager.L2_TALK_1))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { havva.animator.SetInteger("cg", 1); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(_FadeOutHavvaMusic(havva, 3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2DHUMANOID_HAVVA, LocalizationManager.L2_TALK_2))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { havva.animator.SetInteger("cg", 2); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2DHUMANOID_HAVVA, LocalizationManager.L2_TALK_3))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { havva.animator.SetInteger("cg", 3); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_passwordWrong); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_4),
                new DialogueChoice[4]
                {
                new DialogueChoice(LocalizationManager.L2_TALK_4_1, () => player.animator.SetInteger("expression", 1)),
                new DialogueChoice(LocalizationManager.L2_TALK_4_2, () => player.animator.SetInteger("expression", 3)),
                new DialogueChoice(LocalizationManager.L2_TALK_4_3, () => player.animator.SetInteger("expression", 4)),
                new DialogueChoice(LocalizationManager.L2_TALK_4_4, () => player.animator.SetInteger("expression", 0)),
                }
                )));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_5, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_6, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_7, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_8, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_9, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_10, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_11, em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_12, em.genericEvent.voicePack))));
        }
        
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13),
            new DialogueChoice[3] {
                new DialogueChoice(LocalizationManager.L2_TALK_13_1, () => {
                    int eventId = 1;
                    string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => { player.animator.SetTrigger("interact"); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_computer); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13_1_0))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));

                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 4); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_pptTransition); um.NextAction(); });
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(1); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_1, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_2, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_3, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_4, em.genericEvent.voicePack))));
                    
                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 5); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_pptTransition); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_5, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_6, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_7, em.genericEvent.voicePack))));
                    
                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 6); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_pptTransition); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_8, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_9, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_10, em.genericEvent.voicePack))));

                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 7); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_pptTransition); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_11, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_12, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_13, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_14, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_15, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_16, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_17, em.genericEvent.voicePack))));

                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 8); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_pptTransition); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_18, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_19, em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, LocalizationManager.L2_TALK_13_1_20, em.genericEvent.voicePack))));

                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); StartCoroutine(GlobalGameManager.Instance.soundManager.PlayMusicEffect(GlobalGameManager.Instance.databaseManager.me_victory)); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13_1_21))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_talkEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
                new DialogueChoice(LocalizationManager.L2_TALK_13_2, () => {
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => { player.animator.SetTrigger("interact"); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_computer); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13_2_0))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 3); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_passwordWrong); um.NextAction(); });
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(1); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13_2_1))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_talkEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
                new DialogueChoice(LocalizationManager.L2_TALK_13_3, () => {
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => { player.animator.SetTrigger("interact"); havva.audioSource.PlayOneShot(GlobalGameManager.Instance.databaseManager.sfx_computer); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13_3_0))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.L2_TALK_13_3_1),
                        new DialogueChoice[4]
                        {
                            new DialogueChoice(LocalizationManager.L2_TALK_13_3_1_1, () => player.animator.SetInteger("expression", 1)),
                            new DialogueChoice(LocalizationManager.L2_TALK_13_3_1_2, () => player.animator.SetInteger("expression", 3)),
                            new DialogueChoice(LocalizationManager.L2_TALK_13_3_1_3, () => player.animator.SetInteger("expression", 4)),
                            new DialogueChoice(LocalizationManager.L2_TALK_13_3_1_4, () => player.animator.SetInteger("expression", 0)),
                        }
                        )));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_talkEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
        })));
    }

    private IEnumerator _FadeOutHavvaMusic(EntityCharacterNPC2DHumanoidLaptop havva, float fadeOutTime)
    {
        while(havva.audioSource.volume > 0.0f)
        {
            havva.audioSource.volume = Mathf.Max(havva.audioSource.volume - (1.0f / fadeOutTime) * Time.deltaTime, 0.0f);
            yield return null;
        }

        havva.audioSource.Stop();
        havva.audioSource.volume = 1.0f;

        um.NextAction();
    }
}
