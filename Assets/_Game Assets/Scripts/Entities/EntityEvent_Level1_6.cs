﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_6 : EntityEvent
{
    // ceritanya dikasih challenge melewati labirin kebakaran
    // butuh fungsi abis trigger trap
    // kalo berhasil melewati labirin bakalan dikasih password buat naik ke observatory
    public void TrappedEvent()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Selamat, anda kejebak.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Goodluck kabur dari sini.\""))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }


    [SerializeField] CutsceneCamera m_trappedEvent_win_Camera;
    public void TrappedEvent_Win(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        int eventId = 3;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        m_trappedEvent_win_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); player.animator.SetInteger("expression", 2); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_TRIGGERED))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Sayang~ Aku hamil.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Bodo.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Ya abis gimana, disini kan ga ada cuti buat cewek hamil.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Untung ga kena phk kayak cewek dari departement sebelah gegara hamil.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Mentang-mentang Boba Kotak kelasnya 2D Humanoid yang ga bisa hamil, tapi ya ga gini juga sih...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"OEEEEE... OEEEEEE....\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Permisi atasan, bayi saya nangis dan butuh susu.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Saya izin untuk menyusui bayi saya sebentar ya?\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"ALERT ALERT!\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"PEKERJA TIDAK BOLEH MENINGGALKAN KERJAANNYA!\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"PERSENTASE PRIA WANITA DAN NEUTRAL DI PERUSAHAAN UBIVISION YAITU 60%, 10%, DAN 30%.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"ITULAH SEBABNYA WANITA TIDAK BERHAK ISTIRAHAT UNTUK MENYUSUI KETIKA KERJA.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Ya-yaudah menyusui disini deh...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Eh, tinggi dan beratnya Boba Kotak berapaan sih?\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Lu nanya gituan buat apaan?\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Oh buat referensi gambar ya.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Kadang gua lupa kalo kita kerja di departement Artist wkwk.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Tinggi Pak Boba Kotak 169Cm beratnya 69kg.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Tapi anjirlah Pak Boba Kotak.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Masa artist di perusahaan ini engga di cantumin namanya di game, ckck.\""))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { em.memoryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[1]))));
        um.AddUIAction(() => { doorSwitch.UseSwitch(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_trappedEvent_win_Camera.ReleaseCamera(); um.NextAction(); });
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
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_1";
        bool haveKey = doorSwitch.switchForDoors[0].CheckPasswordWithKey(key);
        LocalizationString passwordChoice = haveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_elevatorEvent_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_ELEFATAA, "Halo! Selamat datang di area bangsawan!", doorSwitch.voicePack))));
        em.genericEvent.ElefataaEvent_Generic(doorSwitch, passwordChoice, m_elevatorEvent_Camera);
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