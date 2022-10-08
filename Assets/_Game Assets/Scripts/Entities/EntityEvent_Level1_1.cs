using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_1 : EntityEvent
{
    [SerializeField] CutsceneCamera m_doorNoSwitchEvent_Camera;
    public void DoorNoSwitchEvent()
    {
        m_doorNoSwitchEvent_Camera.UseCamera(0);
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_DOORNOSWITCH))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { player.storedActions.Add(new StoredActionTurn(player, 90, false)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { m_doorNoSwitchEvent_Camera.UseCamera(1); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Mungkin bisa ketemu penghuninya kalau ikuti garis ini!"))));
        um.AddUIAction(() => { m_doorNoSwitchEvent_Camera.ReleaseCamera(); um.NextAction(); });
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_1_Camera;
    bool m_openDoorEvent_1_firstTime = true;
    public void OpenDoorEvent_1(EntityCharacterNPC2D1BitDoor door)
    {
        m_openDoorEvent_1_Camera.UseCamera(0);
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Zzz); um.NextAction(); });

        if (m_openDoorEvent_1_firstTime) {
            m_openDoorEvent_1_firstTime = false;
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... zzz...", door.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Selamat datang di... Havvatopia...", door.voicePack))));
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Sekarang jam 2 pagi dan saat ini di Havvatopia sedang tidak ada internet dan mati lampu...", door.voicePack)))); 
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Katanya sih Havvatopia lagi keadaan darurat... tapi... aku cuma mau tidur... zzz...", door.voicePack))));       
            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        }

        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... zzz... Adakah... yang bisa dibantu...", door.voicePack),
                new DialogueChoice[3] {
                    new DialogueChoice("Havva sedang dimana ya?", () => {
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... zzz...", door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Sebelum mati lampu Havva berada di Observatory, lantai paling atas...", door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Silahkan pergi bersama Elefataa ke sana...", door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => { m_openDoorEvent_1_Camera.UseCamera(2); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Elefataa... selalu ada di tengah lantai kok...", door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => { m_openDoorEvent_1_Camera.UseCamera(0); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice("Boleh lewat ga?", () => {
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "... Oiya ini... silahkan lewat...", door.voicePack))));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice("Enggak jadi.", () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_timing_1_Camera;
    bool m_openDoorEvent_Timing_1_firstTime = true;
    public void OpenDoorEvent_Timing_1(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        if (doorSwitch.hasAutoCloseEffect)
            return;

        int useSwitchTurn = 20;
        if (!m_openDoorEvent_Timing_1_firstTime)
        {
            doorSwitch.UseSwitch(useSwitchTurn);
            return;
        }

        m_openDoorEvent_timing_1_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Huaaaaaa, ini kenapa listrik sama wifi nya ga nyala-nyala!!!", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Udah dari kemarin siang mati lampu nih!!", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Padahal gua mau dengerin Havva main piano!!!", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "...", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Hah?", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Apaaaaa?", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Lu mau gua buka pintu sebelah sana?", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Tapi lari ya, pintunya bakalan ketutup automatis.", doorSwitch.voicePack))));
        um.AddUIAction(() => { doorSwitch.UseSwitch(useSwitchTurn); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.25f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_timing_1_Camera.ReleaseCamera(); m_openDoorEvent_Timing_1_firstTime = false; um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_1_Camera;
    public void OpenDoorEvent_Password_1(EntityCharacterNPC2D1BitDoor door)
    {
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_1";
        bool haveKey = door.CheckPasswordWithKey(key);
        LocalizationString passwordChoice = haveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_openDoorEvent_password_1_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "STOPPPPPP!!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "SAYA PENJAGA PINTU INI DAN ANDA TIDAK BOLEH LEWAT SINI!!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "KECUALI ANDA MEMPUNYAI PASSWORD!!!!!!!!!!", door.voicePack),
                new DialogueChoice[3] {
                    new DialogueChoice(passwordChoice, () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack), haveKey),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack), haveKey),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack), haveKey),
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Passwordnya benar, yeaaay!", door.voicePack))));
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "PASSWORDNYA SALAH!!!!", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Tapi karena saya baik, saya ga akan laporin kok!", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Silahkan cari lagi dan ingat ulang passwordnya ya!", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice("Kenapa butuh password?", () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Hmm... iya yah, kenapa ya...", door.voicePack)))); 
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Yang setel passwordnya juga bukan Havva...", door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "TAPI PEKERJAAN TETAPLAH PEKERJAAN!", door.voicePack))));
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "SAYA HARUS LOYAL KE SIAPAPUN YANG MEMBERIKAN PEKERJAAN INI!", door.voicePack))));  
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                })));
    }

    [SerializeField] CutsceneCamera m_passwordTriggerEvent_1_Camera;
    [SerializeField] EntityCharacterNPC3DBotHeadphone m_passwordTriggerEvent_1_3DBH_1;
    [SerializeField] EntityCharacterNPC3DBotHeadphone m_passwordTriggerEvent_1_3DBH_2;
    public void PasswordTriggerEvent_1()
    {
        int eventId = 1;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        m_passwordTriggerEvent_1_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); player.animator.SetInteger("expression", 2); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Kamu secara ga sengaja (apa sengaja ya?) dengerin apa yang mereka bicarakan."))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #1", "COY! LU UDAH SETEL PASSWORD DI PINTU SANA BELOM?", m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #2", "HAH??! APAAN GA KEDENGERAN!!!", m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #1", "HAH?? LU NGOMONG APAAN BARUSAN? PASSWORDNYA UDAH DI SETEL APA BELOM??", m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #2", "APAAN???!!! PASSWORDNYA 1 2 3!!!", m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #1", "LU SETEL 3 PASSWORD DI PINTUNYA?????", m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #2", "NGOMONG YANG KERAS!!! GA KEDENGERAN COY!!!", m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { em.memoryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[1]))));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_passwordTriggerEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_1()
    {
        int eventId = 1;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;


        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Yohohoo, ini diary gua.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gua saranin lu kumpulin diary gua selama main game.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Ntar bakalan gua kasih reward lho kalau kekumpul semuanya.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHEHEHE", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Adios!", em.genericEvent.voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    
}
