using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_Level1_9 : EntityEvent
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

    public void TutorialSkipTurn()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { um.AddTutorial(new Tutorial(TutorialType.MoveMod, LocalizationManager.TUTORIAL_SKIP), 5.0f); um.NextAction(); });
    }

    public void DoorNoSwitchEvent()
    {
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_DOORNOSWITCH))));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    #region Open Door Event
    [SerializeField] CutsceneCamera m_openDoorEvent_1_Camera;
    public void OpenDoorEvent_1(EntityCharacterNPC2D1BitDoor door)
    {
        m_openDoorEvent_1_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Halo dan hi!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Selamat datang di perushaan Ubivision!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Saat ini lagi mati lampu sih, makanya cuma sedikit yang kerja.", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Biasanya jam segini masih pada kerja lembur, hebat deh karyawan disini!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "...", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Kenapa?", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Anda mau menyingkirkan saya dan lewat sini?", door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice("Iya.", () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Cry); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOOR, "Ya-Yaudah deh!", door.voicePack))));
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice("Enggak.", () => {
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
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Dead); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Haddeeeh, males banget ngelembur yaampooon.", doorSwitch.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Malah ga dibayar uang lemburnya lagi.", doorSwitch.voicePack))));
        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Hah? Apaan? Lu mau gua buka pintu sebelah sana?", doorSwitch.voicePack))));
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Anda tidak bisa lewat sini, kecuali mempunyai password.", door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(passwordChoice, () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack), haveKey),
                            new PasswordChoice(1, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack), haveKey),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack), haveKey),
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Surprise); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Passwordnya... benar?", door.voicePack))));
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Pffft, passwordnya salah bodoh.", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_1_Camera.ReleaseCamera(); um.NextAction(); });
                        });
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "You're trying to listen to their conversation."))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #1", "HEY! DID YOU FORGET TO SET PASSWORD ON THE DOOR?", m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #2", "WHAT? I CAN'T HEAR YOU!", m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #1", "WHAT DID YOU SAY? YOUR HEADPHONE IS TOO LOUD! I SAID DID YOU FORGET TO SET PASSWORD ON THE DOOR???", m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #2", "WHAT? THE PASSWORD ON THE DOOR IS 1 2 3!!", m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #1", "YOU SET 3 PASSWORDS FOR THE DOOR???", m_passwordTriggerEvent_1_3DBH_1.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("(3D Headphone Sphere Robot) Guard #2", "SPEAK LOUDER! I CAN'T HEAR YOU!", m_passwordTriggerEvent_1_3DBH_2.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { em.memoryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[1]))));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_passwordTriggerEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_closeDoorEvent_1_Camera;
    bool m_closeDoorEvent_1_firstTime = true;
    public void CloseDoorEvent_1(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        if (m_closeDoorEvent_1_firstTime)
        {
            m_closeDoorEvent_1_Camera.UseCamera();
            um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
            um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
            um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Lu mau gua tutup pintunya biar robotnya ga bisa liat lu?", doorSwitch.voicePack),
                    new DialogueChoice[2] {
                    new DialogueChoice("Boleh.", () => {
                        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_SWITCH, "Untungnya mereka bego, jadi mereka ga bakalan nyadar wkwk.", doorSwitch.voicePack))));
                        um.AddUIAction(() => { doorSwitch.UseSwitch(); m_closeDoorEvent_1_firstTime = false; um.NextAction(); });
                        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_closeDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
                    new DialogueChoice("Gausah deh.", () => {
                        um.AddUIAction(() => { doorSwitch.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_closeDoorEvent_1_Camera.ReleaseCamera(); um.NextAction(); });
                    }),
            })));
        }
        else
        {
            doorSwitch.UseSwitch();
        }
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "ANDA TIDAK BOLEH MELEWATI JALAN KE GUDANG!!!", door.voicePack))));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Kecuali punya password.", door.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice(passwordChoice, () => {
                        door.EnterPassword(new PasswordChoice[] {
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[0], door.voicePack), haveKey),
                            new PasswordChoice(0, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[1], door.voicePack), haveKey),
                            new PasswordChoice(2, LocalizationManager.GENERIC_PASSWORD_ANSWER , new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, LocalizationManager.GENERIC_PASSWORD_QUESTION[2], door.voicePack), haveKey),
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.ThumbUp); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Benar!", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_2_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Salah!", door.voicePack))));
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

    [SerializeField] CutsceneCamera m_passwordTriggerEvent_2_Camera;
    public void PasswordTriggerEvent_2(EntityCharacterNPC2D1BitSwitch doorSwitch)
    {
        int eventId = 2;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        m_passwordTriggerEvent_2_Camera.UseCamera();
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
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_passwordTriggerEvent_2_Camera.ReleaseCamera(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_3_Camera;
    public void OpenDoorEvent_Password_3(EntityCharacterNPC2D1BitDoor door)
    {
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_3";
        bool haveKey = door.CheckPasswordWithKey(key);
        LocalizationString passwordChoice = haveKey ? LocalizationManager.GENERIC_PASSWORD_CHOICES[1] : LocalizationManager.GENERIC_PASSWORD_CHOICES[0];

        m_openDoorEvent_password_3_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Saya akan melindungi Elefataa dengan segala hal!!!", door.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Anda tidak akan pernah menemukan passwordnya dan anda tidak akan pernah melewati jalan ini!", door.voicePack),
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
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Anda terbukti bukan spy kok.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Silahkan lewat!", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Angry); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Asal jangan ke lantai paling atas ya, karena itu lantainya pemimpin kami yang maha hebat.", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_3_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_2D1BIT_DOORPASSWORD, "Tidak akan ada yang bisa melewati kami!", door.voicePack))));
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

    public void PasswordTriggerEvent_3()
    {
        int eventId = 3;
        string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + eventId;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); player.animator.SetInteger("expression", 2); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_TRIGGERED))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Akhirnya kerja di perusahaan Ubivision juga...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Susah banget masuk sini yak.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Padahal Pak Kotak alumni universitas yang sama kayak gua, walaupun dia drop out sih...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Tapi aneh dah, cowok gua yang nilainya dibawah gua kenapa lebih gampang masuk sini yak.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Apakah karena gua fresh grad cewek?\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Ah engga, jangan mikir yang gitu-gitu.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Baru aja mulai kerja wkwk.\""))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Gokil sih, ini perusahaan baru aja didiriin 4 tahun yang lalu, langsung bikin IP terkenal.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Tapi pelatihannya parah banget dah.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Masa kemaren gua nanya ke atasan soal game design gitu...\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Terus ga dibantuin karena gua cewek katanya.\""))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_CRACKOFTIME, "\"Ampuun dahh, ini perusahaan kenapa dah...\""))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { em.memoryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[0]))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", LocalizationManager.GENERIC_MEMORY_REMEMBERED[1]))));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    [SerializeField] CutsceneCamera m_openDoorEvent_password_4_Camera;
    public void OpenDoorEvent_Password_4(EntityCharacterNPC2D1BitDoor door)
    {
        m_openDoorEvent_password_4_Camera.UseCamera();
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Hello); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Enggak mungkin lu bisa lewatin gua, kecuali lu cari guide di internet atau baca readme.pdf haha!", door.voicePack),
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
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "GGWP!", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { door.SetDoorIsClosed(false); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.DelayNextAction(0.5f)));
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_4_Camera.ReleaseCamera(); um.NextAction(); });
                        },
                        () => {
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.Idk); um.NextAction(); });
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Tuhkan, ga mungkin lewatin gua.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Ini jalan cuma buat hardcore gammerrzzz.", door.voicePack))));
                            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_RGBGAMINGDOOR, "Cari jalan lain gih, ini jalan cuma shortcut.", door.voicePack))));
                            um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                            um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_4_Camera.ReleaseCamera(); um.NextAction(); });
                        });
                    }),
                    new DialogueChoice(LocalizationManager.GENERIC_PASSWORD_CHOICES[2], () => {
                        um.AddUIAction(() => { door.SetExpression(Expression_2D1Bit.None); um.NextAction(); });
                        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); m_openDoorEvent_password_4_Camera.ReleaseCamera(); um.NextAction(); });
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
        ElefataaEvent_Generic(doorSwitch, passwordChoice, m_elevatorEvent_Camera);
    }
    #endregion

    #region Devlog Event
    public void DevlogDiaryTriggerEvent_1()
    {
        int eventId = 1;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;


        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Yohohoo, ini diary gua.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gua saranin lu kumpulin diary gua selama main game.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Ntar bakalan gua kasih reward lho kalau kekumpul semuanya.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHEHEHE", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Adios!", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_2()
    {
        int eventId = 2;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Ini tempat awalnya gua pengen bikin kayak mansion tua gitu.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Tapi karena gua ga tau mansion isinya apaan...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Jadinya gua bikin jadi kantor aja.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHEHE", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_3()
    {
        int eventId = 3;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Tadinya tempat tidurnya 3D Sphere Robot kayak kasur gitu.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Masa iyak robot tidurnya di kasur, hadehhh.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Akhirnya gua buat kayak tabung di lab gitu deh buat tempat tidurnya.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHEHE", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_4()
    {
        int eventId = 4;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Lu lagi berada di shortcut khusus untuk gamerz yang hardcore.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gua ucapkan selamat bisa nembus disini.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Dasar no life, antara lu searching di internet, baca readme.pdf atau ga nyoba entah berapa banyak kemungkinannya.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Anyway, bener jawabannya; robotnya dipancing dulu baru nanti nyelip.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Tadinya mau pake mekanik kayak gitu di awal game, tapi pada kesusahan wkwk.", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_5()
    {
        int eventId = 5;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Aduh, gua gatau ruangan ini mau di isiin apaan.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gudang kali ya, au ah.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gua sering gatau mau isi furniture apaan wkwkwk.", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Ini gua ngoding bego dah.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Semua yang interactable adalah NPC.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Makanya banyak pintu dan switch yang sekalian jadi NPC juga.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Makanya jadi ada kelas 2D 1 Bit.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Gegara ngoding gua bego wkwkwk.", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_7()
    {
        int eventId = 7;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Devlog diary ini sengaja ditaro ditengah tengah sini biar lu panik.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Devlog diary emang sengaja didesain biar nyusahin wkwk.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Sok atuh spam click / space nya.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHEHHE", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_8()
    {
        int eventId = 8;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Boba Kotak itu gua ngeparodi dari orang beneran.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Perusahaan Ubivision juga ngeparodiin 2 perusahaan beneran.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Nama aslinya... adadehhhh.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHEHHE", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }

    public void DevlogDiaryTriggerEvent_9()
    {
        int eventId = 9;
        string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + eventId;
        if (PlayerPrefs.HasKey(key))
            return;

        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.AfterInput)));
        um.AddUIAction(() => { AddBasicStatusEffectOnStartingEvent(); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayUntilPhaseInput(PhaseEnum.WaitInput)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Lu lagi di balkon.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Dan lu ga bisa buka jendela.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Karena emang gua males implementasiin mekanik kayak gitu.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "NYEHEHEHE.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Welp, ceritanya sih jendela tersebut udah jadi objek statis.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Ini berarti tadinya jendela itu NPC, terus karena jarang di interact akhirnya mereka jadi objek statis.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_DEVELOPERLOGDIARY, "Beuh, NPC Lore.", m_voicePack))));

        um.AddUIAction(() => { PlayerPrefs.SetString(key, true.ToString()); um.NextAction(); });
        um.AddUIAction(() => { em.diaryTriggerEvents[eventId - 1].SetIsAvailable(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "..."))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { RemoveBasicStatusEffectOnFinishEvent(); um.NextAction(); });
    }
    #endregion
}
