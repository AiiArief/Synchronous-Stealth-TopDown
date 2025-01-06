using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class EntityEvent_VoidWorld : EntityEvent_Generic
{
    public override void EventOnLoadLevel()
    {
        _BasicOnLoadLevel();

        AddBasicStatusEffectOnStartingEvent();

        string currentScene = PlayerPrefs.GetString(ProfileManager.PLAYERPREFS_CURRENTSCENE, "Void World");

        #region End Game - Demo
        if (currentScene == "Havvatopia - Downtown") {
            _EndGameDemo();
            return;
        }
        #endregion

        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("logoSSV", 5.0f)));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));

        #region Mid Game
        if (currentScene != "Void World")
        {
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Agent Violet. Kerja oy, lu masih menjalankan misi infiltrasi Kerajaan Havva kan?", em.genericEvent.voicePack),
                    new DialogueChoice[3] {
                        new DialogueChoice("Eiya, punten. (Lanjutkan permainan)", () => _LoadGameButton(currentScene)),
                        new DialogueChoice("Hah? Engga kok, ngablu kali lu! (Ulang dari awal)", () => _ClearSaveGameButton(currentScene)),
                        new DialogueChoice("Engga ah, males kerja. (Keluar)", () => em.genericEvent.QuitButton(false))
                    })));
            return;
        }
        #endregion

        #region Start Game
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "63 68 6F 6F 73 65 20 79 6F 75 72 20 6C 61 6E 67 75 61 67 65", em.genericEvent.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice("Can you speak English? (English)", () => { 
                        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, (int)LocalizationLanguage.English); 
                    }),
                    new DialogueChoice("Gabesa basa Enggres... (Bahasa Indonesia)", () => { 
                        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, (int)LocalizationLanguage.Indonesia); 
                    })
                })));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "Ah, punten. Gua lupa ganti bahasanya wkwk.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "(Gua ga ngerti Bahasa Indonesia KBBI sih, bodo amet lah ya~)", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "Err... Anyway...", em.genericEvent.voicePack))));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "NYEHEHEHEHE!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "SELAMAT DATANG DI DUNIA YANG GUA BIKIN, PLAYER!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "KENALIN, GUA \"The Developer\"!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Err... mungkin lu pernah kenal gua dari masa depan atau dari masa lalu...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Tapi gapapa, kenalan lagi kalau udah kenal.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Nyehehehe...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Hehe.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "DI GAME INI, LU BAKALAN JADI SEORANG SPY!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "TUGAS LU SEKARANG ADALAH INFILTRASI KOTA HAVVATOPIA!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "SAAT INI KOTA HAVVATOPIA SEDANG DIBAJAK UNTUK MEMICU TERJADINYA PERANG DIMENSI!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "SELAMATKAN HAVVA YANG SEDANG DITAWAN DI SANA SERTA CEGAH TERJADINYA PERANG DIMENSI!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "TANPA.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "KETAHUAN.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "SAMA SEKALI!!!!!!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", em.genericEvent.voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { StartCoroutine(VCamSlowlyGlideUp()); StartCoroutine(um.AnimateTransition("fade", 5.0f)); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Udah siap memainkan game ini, Agent Violet?", em.genericEvent.voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice("Oke, siap. (Mulai game)", () => { 
                        _NewGameButton(); 
                    }),
                    new DialogueChoice("Engga ah, males. (Keluar)", () => {
                        em.genericEvent.QuitButton(); 
                    })
                })));
        #endregion
    }

    private void _NewGameButton()
    {
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sip!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua lagi siapin teleportase lu ke Hub World.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sampai disana, lu interaksi sama laptop gua yang ada di ujung Hub World biar lu teleport lagi ke Kota Havvatopia.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Dan juga, lu cuma bisa kontak gua disini doang.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Setelah teleportase dari sini, lu bakalan dipandu dengan catatan-catatan yang gua taruh di berbagai sisi di dunia ini.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sip! Sebelum mulai gamenya, ada pertanyaan ga?", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Ga ada?", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Welp, bukannya ga ada sih, gua emang ga ngasih pilihan buat pertanyaan, NYEHEHEHEHE.", em.genericEvent.voicePack), 
            new DialogueChoice[4]
            {
                new DialogueChoice("(Annoyed)", () => player.animator.SetInteger("expression", 1)),
                new DialogueChoice("(Smirk)", () => player.animator.SetInteger("expression", 3)),
                new DialogueChoice("(Surprised)", () => player.animator.SetInteger("expression", 4)),
                new DialogueChoice("...", () => player.animator.SetInteger("expression", 0)),
            }
            )));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(3.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sip, teleportase udah siap!", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Teleportase akan dilakukan dalam waktu ...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "3...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "2...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "1...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { em.triggerCheckpoints[0].teleportArea.gameObject.SetActive(true); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("flashbang")));
        um.AddUIAction(() => { player.animator.gameObject.SetActive(false); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(4.0f)));
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.sceneLevels[1]));
    }

    private void _LoadGameButton(string sceneName)
    {
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => _TeleportPlayerToScene(GlobalGameManager.Instance.databaseManager.GetSceneLevelFromSceneName(sceneName), false));
    }

    private void _ClearSaveGameButton(string currentScene)
    {
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Se-seriusan? Berarti selama ini cuma khayalan doang?", em.genericEvent.voicePack),
            new DialogueChoice[2] {
                new DialogueChoice("Emang mau dari awal lagi sih, dadah! (Hapus & ulang dari awal)", () => {
                    GlobalGameManager.Instance.profileManager.ClearProfile();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                }),
                new DialogueChoice("Gaddeeeeng! (Lanjutkan permainan)", () => { _LoadGameButton(currentScene); })
            })));
    }

    [SerializeField] CinemachineVirtualCamera m_startCamera;
    private IEnumerator VCamSlowlyGlideUp()
    {
        var trackedDolly = m_startCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        var currentPath = 0.0f;
        while(currentPath < trackedDolly.m_Path.MaxPos)
        {
            currentPath += Time.deltaTime / 5.0f;
            trackedDolly.m_PathPosition = currentPath;
            yield return new WaitForEndOfFrame();
        }
    }

    private void _EndGameDemo() {
        um.AddUIAction(() => { StartCoroutine(VCamSlowlyGlideUp()); StartCoroutine(um.AnimateTransition("fade", 5.0f)); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Halo lagi, Agent Violet.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua liat lu udah sampai di Pusat Kota Havvatopia bagian bawah.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua ucapkan selamat sudah sampai sana, tapi sayangnya untuk versi yang lu mainin saat ini cuma bisa main sampai sana wkwk.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Umm... Jadi gini...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Tadi kan gua sempet bilang levelnya belum selesai...", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Saat ini gua lagi ga bisa lanjutin pengembangan dari game ini karena sebenernya gua saat ini kekurangan budget buat bikin game ini.", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Jadi palingan game ini gua delay sampai entah kapan tau.", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Atau mungkin gua cancel aja pengembangannya.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "NYEHEHEHEHEHE.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Hehe...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Welp...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Saatnya roll the credit!!!", em.genericEvent.voicePack))));

        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(2); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Developed by Ai Nonymous"))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Powered by Unity Engine"))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Music :\nKevin Macleod - Frost Waltz, Teddy Bear Waltz, Spy Glass"))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Audio & Sound :\nRPG Maker MV\nMechvibes.com - jsfxr"))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue("", "Animation :\nMixamo"))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(1.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Anyway, gua pengen bilang sesuatu.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "TERIMA KASIH SUDAH MEMAINKAN GAME INI!", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Lu bisa bantu development game ini dengan beberapa cara.", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Bisa dengan share game ini ke temen-temen lu.", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Dan bisa juga dengan isi survey yang bakalan kebuka setelah lu keluar dari game ini.", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua berencana untuk melanjutkan pengembangan game ini kalau ternyata banyak yang support, yang isi survey banyak, dan tiba-tiba gua dapat dana untuk lanjutin game ini...", em.genericEvent.voicePack))));
        //um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua harapnya sih masih tetap ngelanjutin pengembangan game ini wkwk.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Tapi sayangnya... ", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua bakal lupa kalau lu pernah mainin game ini...", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sebenernya setiap lu mulai game dari awal gua bakalan lupa lu sih wkwk.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Jadi sebelum gua lupa, gua pengen bilang makasih banget udah mainin & support game ini.", em.genericEvent.voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Apa yang mau lu lakukan sekarang, Agent Violet?", em.genericEvent.voicePack),
        new DialogueChoice[2] {
                    new DialogueChoice("Mulai dari awal lagi (Ulang dari awal)", () => {
                        GlobalGameManager.Instance.profileManager.ClearProfile();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }),
                    new DialogueChoice("Dadah! (Keluar)", () => {
                        um.AddUIAction(() => Application.Quit());
                    })
        })));
    }
}
