using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EntityEvent_Level0 : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        AddBasicStatusEffectOnStartingEvent();
        player.animator.gameObject.SetActive(false);

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_HUBWORLD), 3.0f); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => { em.triggerCheckpoints[0].teleportArea.gameObject.SetActive(true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("flashbang")));
        um.AddUIAction(() => { player.animator.gameObject.SetActive(true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(4.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(1); um.NextAction(); });
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.Move, LocalizationManager.TUTORIAL_MOVE), 3.0f); um.NextAction(); });

        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void InteractTutorialEvent()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_INTERACT), 10.0f); um.NextAction(); });
    }

    public void RunTutorialEvent()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.MoveMod, LocalizationManager.TUTORIAL_RUN), 5.0f); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_cutsceneCamera1;
    public void WinCheckpointEvent()
    {
        m_cutsceneCamera1.UseCamera(0);

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(3.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "?"))));
        um.AddUIAction(() =>
        {
            m_cutsceneCamera1.UseCamera(1);
            player.animator.SetInteger("expression", 1);
            um.NextAction();
        });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Ga terjadi apa-apa..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() =>
        {
            player.animator.SetInteger("expression", 4);
            um.NextAction();
        });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "!"))));
        um.AddUIAction(() => { em.triggerCheckpoints[1].teleportArea.gameObject.SetActive(true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("flashbang")));
        um.AddUIAction(() =>
        {
            m_cutsceneCamera1.ReleaseCamera();
            player.animator.gameObject.SetActive(false);
            um.NextAction();
        });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(4.0f)));
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[2]));
    }

    [SerializeField] CutsceneCamera m_cutsceneCamera_note3DSphereRobot;
    public void DetailEvent_3DSphereRobot()
    {
        m_cutsceneCamera_note3DSphereRobot.UseCamera();

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Pesan dari The Developer :", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ini salah satu NPC dari kelas 3D Sphere Robot, 3D Headphone Sphere Robot.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Semua NPC dari kelas 3D Sphere Robot adalah antagonis di game ini.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Lu ga boleh dan ga bisa bunuh mereka, serta lu ga boleh ketauan sama mereka.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Kalo lu ketauan sama mereka, lu harus time leap.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ntar lu balik ke checkpoint terakhir.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_cutsceneCamera_note3DSphereRobot.ReleaseCamera(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_cutsceneCamera_noteHavvaKingdom;
    public void DetailEvent_HavvaKingdom()
    {
        m_cutsceneCamera_noteHavvaKingdom.UseCamera();

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Pesan dari The Developer :", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ini adalah Kerajaan Havva.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Sama kayak kerajaan lainnya, kerajaan ini terletak didalam 3D Titan Sphere Robot.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Penghasilan utama kerajaan ini yaitu bisnis warnetnya.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Saat ini 3D Titan Sphere Robot-nya Kerajaan Havva di hijack oleh (Main Antagonist) agar bisa menjadi tawanan untuk dimensional war.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Nah, tugas lu yaitu menyelamatkan Havva yang sedang ditawan oleh (Main Antagonist) dan mencegah terjadinya dimensional war.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_cutsceneCamera_noteHavvaKingdom.ReleaseCamera(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_cutsceneCamera_note3DHumanoid;
    public void DetailEvent_3DHumanoid(EntityCharacterNPCGodDeveloperNote agentVioletNote)
    {
        m_cutsceneCamera_note3DHumanoid.UseCamera();

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Pesan dari The Developer :", em.genericEvent.voicePack))));
        um.AddUIAction(() => { agentVioletNote.animator.SetInteger("expression", 3); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ini lu, Agent Violet.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Lu berasal dari kelas 3D Humanoid.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Lu adalah spy terbaik di game ini.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Mungkin karena lu satu-satunya spy di game ini.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "NYEHEHEHEHE.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Oh iya, karena banyak tester yang ga nyadar ini, jadi ada yang pengen gua kasih tau nih.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Game ini adalah game synchronous, apa itu synchronous?", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ini game turn base tapi musuh dan player bergerak bersama.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Jadi gunakan turn mu sebijak mungkin.", em.genericEvent.voicePack))));
        um.AddUIAction(() => { agentVioletNote.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_cutsceneCamera_note3DHumanoid.ReleaseCamera(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_cutsceneCamera_note2DHumanoid;
    public void DetailEvent_2DHumanoid()
    {
        m_cutsceneCamera_note2DHumanoid.UseCamera();

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Pesan dari The Developer :", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Enggak, ini bukan laptop gua.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ini adalah interface berbentuk monitor dari NPC kelas 2D.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Ada beberapa sub-class dari kelas 2D, seperti 2D Humanoid dan 2D 1 Bit.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Mereka semua butuh interface karena mereka semua hidup di dimensi yang berbeda.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Untuk pindah dari interface ke interface lain, mereka menggunakan internet.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Jika listrik mati atau wifi mati, mereka akan terperangkap di interface tersebut sampai mereka berubah menjadi objek statis.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_cutsceneCamera_note2DHumanoid.ReleaseCamera(); um.NextAction(); });
    }
}
