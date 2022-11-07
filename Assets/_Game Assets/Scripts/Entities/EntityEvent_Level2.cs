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
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.None, LocalizationManager.TUTORIAL_HAVVASKINGDOM_OBSERVATORY), 5.0f); um.NextAction(); });
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(4); um.NextAction(); });
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Halo! Selamat datang di Havvatopia bagian Observatorium!", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Mau naikki aku ke mana?", doorSwitch.voicePack),
            new DialogueChoice[5] {
                new DialogueChoice("Havvatopia - Uptown", () => {
                    em.genericEvent.ElefataaEvent_Generic_Uptown(this, doorSwitch);
                }),
                new DialogueChoice("Havvatopia - Downtown", () => {
                    em.genericEvent.ElefataaEvent_Generic_Downtown(this, doorSwitch, downTownPasswordChoice, downTownHaveKey, m_elevatorEvent_Camera);
                }),
                new DialogueChoice("Havvatopia - Engine Room", () => {
                    em.genericEvent.ElefataaEvent_Generic_Failed(this, doorSwitch, m_elevatorEvent_Camera);
                }),
                new DialogueChoice("Havvatopia - Underground", () => {
                    em.genericEvent.ElefataaEvent_Generic_Failed(this, doorSwitch, m_elevatorEvent_Camera);
                }),
                new DialogueChoice("Gajadi", () => {
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
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(1); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { havva.animator.SetInteger("cg", 1); um.NextAction(); });
            um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { havva.animator.SetInteger("cg", 2); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { havva.animator.SetInteger("cg", 3); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."),
                new DialogueChoice[4]
                {
                new DialogueChoice("(Annoyed)", () => player.animator.SetInteger("expression", 1)),
                new DialogueChoice("(Smirk)", () => player.animator.SetInteger("expression", 3)),
                new DialogueChoice("(Surprised)", () => player.animator.SetInteger("expression", 4)),
                new DialogueChoice("...", () => player.animator.SetInteger("expression", 0)),
                }
                )));
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
            um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Test test...", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Halo halo.", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "Err... Ini ada pesan dari The Developer :", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Pesan ini muncul jika terjadi error di program interface 2D Humanoid-nya Havva.\"", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Karena Havva berhalangan untuk menjelaskan apa yang terjadi, maka spy akan dipandu oleh pesan ini.\"", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Silahkan buka file bernama \"presentasi untuk spy FINAL FIX TOLONG TOLONG BENERAN DATENG DONG.potx\".\"", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Kalau mau mencoba jalankan ulang program interface 2D Humanoid silahkan saja, tapi palingan error lagi.\"", em.genericEvent.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Asalkan jangan buka folder homework.\"", em.genericEvent.voicePack))));
        }
        
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."),
            new DialogueChoice[3] {
                new DialogueChoice("Buka file \"presentasi untuk spy FINAL FIX TOLONG BENERAN DATENG DONG.potx\"", () => {
                    int eventId = 1;
                    string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Membuka file \"presentasi untuk spy FINAL FIX TOLONG BENERAN DATENG DONG.potx\"..."))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));

                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 4); um.NextAction(); });
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(1); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Perkenalkan, yang barusan kena error adalah Havva, walikota dari Havvatopia.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Havva tidak mengira kalau rumor memainkan lagu yang dia mainkan barusan beneran bisa memanggil Spy.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Baterai laptopnya Havva sudah sekarat dan sebentar lagi Havva berubah jadi objek statis.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Oleh karena itu, Havva sangat berterima kasih kepada Agent Violet karena sudah datang tepat pada waktunya.\"", em.genericEvent.voicePack))));
                    
                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 5); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Havva awalnya lagi bermain piano dan mengatur Havvatopia di observatory seperti biasa.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Tiba-tiba, 3D Titan Sphere Robot yang ditinggali oleh penduduk Havvatopia sejak lama ini, hidup lagi dan bergerak.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Dan juga, seluruh wifi di Havvatopia mati dan saat ini Havvatopia sedang menggunakan listrik darurat.\"", em.genericEvent.voicePack))));
                    
                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 6); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Nah, Havva butuh bantuan Agent Violet nih.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Bantuannya yaitu investigasi apa yang terjadi di Havvatopia dan cari tahu Havvatopia sedang bergerak menuju kearah mana.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Lalu juga Havva membutuhkan bantuan Violet untuk menyalakan kembali listrik dan wifi di Havvatopia agar bisa mengontrol kembali 3D Titan Sphere ini.\"", em.genericEvent.voicePack))));

                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 7); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Ini adalah foto kerangka Havvatopia.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Untuk menyalakan listrik dan wifi di Havvatopia, Agent Violet harus ke engine room.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Namun, saat ini Agent Violet tidak bisa mengakses ke engine room menggunakan Elefataa karena ada kerusakan antara Downtown dan Engine Room.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Sehingga, Agent Violet harus turun ke Downtown menggunakan Elefataa, kemudian pindah menggunakan Elefatwo atau Elefatri ke Underground.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Semoga saja salah satu dari mereka layanannya masih jalan.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Dari Underground, Agent Violet bisa ke engine room menggunakan tangga darurat Elefataa.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Ada 1000 anak tangga di tangga darurat tersebut, Havva berharap semoga Agent Violet tidak capek.\"", em.genericEvent.voicePack))));

                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 8); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Sekian presentasinya Havva.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Untuk pergi ke Downtown, passwordnya sudah tertera disini.\"", em.genericEvent.voicePack))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERNOTE, "\"Sekali lagi, Havva berterima kasih karena Agent Violet sudah datang.\"", em.genericEvent.voicePack))));

                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_talkEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
                new DialogueChoice("Jalankan ulang program interface 2D Humanoid", () => {
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Menjalankan program interface 2D Humanoid..."))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => { havva.animator.SetInteger("cg", 3); um.NextAction(); });
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(1); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_talkEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
                new DialogueChoice("Buka folder \"Homework\" berukuran 120Gb", () => {
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Membuka folder \"Homework\"..."))));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."),
                        new DialogueChoice[4]
                        {
                            new DialogueChoice("(Annoyed)", () => player.animator.SetInteger("expression", 1)),
                            new DialogueChoice("(Smirk)", () => player.animator.SetInteger("expression", 3)),
                            new DialogueChoice("(Surprised)", () => player.animator.SetInteger("expression", 4)),
                            new DialogueChoice("...", () => player.animator.SetInteger("expression", 0)),
                        }
                        )));
                    um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
                    um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
                    um.AddUIAction(() => { m_talkEvent_Camera.UseCamera(2); um.NextAction(); });
                    um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_talkEvent_Camera.ReleaseCamera(); um.NextAction(); });
                }),
        })));
    }
}
