using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_6 : EntityEvent
{
    [SerializeField] CutsceneCamera m_trappedEvent_Camera;
    [SerializeField] EntityCharacterNPC2D1BitSwitch m_trap_doorSwitch;
    public void TrappedEvent(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(3); um.NextAction(); });
        um.AddUIAction(() => { m_trappedEvent_Camera.UseCamera(); um.NextAction(); });
        um.AddUIAction(() => { m_trap_doorSwitch.SetCurrentIsOn(true); m_trap_doorSwitch.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { player.storedActions.Add(new StoredActionTurn(player, 90, false)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "HAHAHAHAHAHA!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "SELAMAT DATANG DI PERANGKAP API YANG SAYA BUAT!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "UNTUK KABUR DARI PERANGKAP INI, ANDA HARUS MEMECAHKAN TEKA-TEKI LABIRIN DI RUANGAN INI!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "JIKA ANDA BERHASIL KABUR DARI PERANGKAP INI, ANDA AKAN SAYA BERI HADIAH!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "ENTAH KENAPA HADIAHNYA YAITU BERUPA PASSWORD UNTUK KE OBSERVATORY!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "NAMUN JIKA ANDA GAGAL, ANDA AKAN TERBAKAR DISINI!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "HAHAHAHAHAHA, SELAMAT MENCOBA!"))));
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Apinya ga ada panas-panasnya..."))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Dead); um.NextAction(); });
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_trappedEvent_Camera.ReleaseCamera(); um.NextAction(); });
    }

    public void TrappedEvent_Win(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        int eventId = 3;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        m_trappedEvent_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { player.storedActions.Add(new StoredActionTurn(player, 90, false)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { m_trap_doorSwitch.SetCurrentIsOn(false); m_trap_doorSwitch.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "SELAMAT, ANDA BERHASIL MELEWATI RINTANGAN INI!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "SESUAI JANJI, SAYA AKAN MEMBERIKAN PASSWORD UNTUK KE OBSERVATORY!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "PASSWORDNYA ADALAH 3 3 3!"))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "SERTA, ISI \"SAYA BUKAN SPY\" UNTUK CAPTCHANYA AGAR DIIZINKAN LEWAT OLEH ELEFATAA!"))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "Tapi aneh dah.")))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "Spy kan cuma mitos, kenapa repot-repot pakai captcha ya.")))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "Yang nitip password disini juga aneh banget, dia kayak kesurupan gitu.")))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "Tadinya mau Saya tanya kenapa, tapi sayangnya dia 3D Headphone Sphere Robot, ga bisa diajak ngobrol kan tuh kelas.")))); 
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_PASSWORDPROTECTOR, "Jadi ya yaudahlah, saya hanya melakukan kerjaan sebaik mungkin.")))); 
        um.AddUIAction(() => { m_trap_doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });

        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(2); um.NextAction(); });
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_trappedEvent_Camera.ReleaseCamera(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_2_Camera;
    public void OpenDoorEvent_Password_2(EntityCharacterNPC2D1BitDoor door)
    {
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_2";
        bool haveKey = door.CheckPasswordWithKey(key);
        LocalizationString passwordChoice = haveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_openDoorEvent_password_2_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "SAYA AKAN MELINDUNGI ELEFATAA DENGAN SEGALA HAL!!!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "ANDA TIDAK AKAN PERNAH MENEMUKAN PASSWORDNYA DAN ANDA TIDAK AKAN PERNAH MELEWATI JALAN INI!!!!", door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(passwordChoice, () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack), haveKey),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack), haveKey),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack), haveKey),
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Oh, ternyata tidak apa-apa.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Anda terbukti bukan bahaya kok.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Silahkan lewat!", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "...", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Oiya, yang setel password ini nitip pesan ke saya untuk siapapun yang berhasil lewat sini.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Jangan ke lantai Observatory ya, karena itu tempat Havva ditawan.", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "TIDAK AKAN ADA YANG BISA MELEWATI SAYA!!!!", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_3_Camera;
    public void OpenDoorEvent_Password_3(EntityCharacterNPC2D1BitDoor door)
    {
        m_openDoorEvent_password_3_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Jangan lewat sini, karena ini jalan hanya untuk Hardcore Gamerzzzz.", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Silahkan cari jalan lain, karena jalan ini hanya shortcut ke Havva.", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Dan Anda hanya bisa menemukan passwordnya di internet.", door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[0], () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack)),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack)),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack)),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[3], door.voicePack)),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[4], door.voicePack)),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[5], door.voicePack)),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[6], door.voicePack)),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[7], door.voicePack)),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER, new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, LocalizationManager.GENERIC_PASSWORD_QUESTION[8], door.voicePack)),
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "GGWP Gamers!", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Namun, ini belum selesai!", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Semoga saja Anda bisa melewati challenge selanjutnya!", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Tuhkan, tidak mungkin lewat sini.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Silahkan cari jalan lain.", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_elevatorEvent_Camera;
    public void ElevatorEvent(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        string observatoryKey = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + GlobalGameManager.Instance.databaseManager.sceneLevels[2].scenes[0] + "_3";
        string downTownKey = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + GlobalGameManager.Instance.databaseManager.sceneLevels[3].scenes[0] + "_1";
        bool observatoryHaveKey = doorSwitch.switchForDoors[0].CheckPasswordWithKey(observatoryKey);
        bool downTownHaveKey = doorSwitch.switchForDoors[0].CheckPasswordWithKey(downTownKey);
        LocalizationString observatoryPasswordChoice = observatoryHaveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];
        LocalizationString downTownPasswordChoice = downTownHaveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_elevatorEvent_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Halo! Selamat datang di Havvatopia bagian Uptown!", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Mau naikki aku ke mana?", doorSwitch.voicePack),
            new DialogueChoice[5] {
                new DialogueChoice("Havvatopia - Observatory", () => {
                    em.genericEvent.ElefataaEvent_Generic_Observatory(this, doorSwitch, observatoryPasswordChoice, observatoryHaveKey, m_elevatorEvent_Camera, m_trappedEvent_Camera);
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
    
    public void DevlogDiaryTriggerEvent_6()
    {
        int eventId = 6;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Lu lagi berada di shortcut khusus untuk gamerz yang hardcore.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gua ucapkan selamat bisa sampai disini.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Bener jawabannya; robotnya dipancing dulu baru nanti nyelip.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Tadinya mau pake mekanik kayak gitu di awal game, tapi pada kesusahan wkwk.", em.genericEvent.voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }
}
