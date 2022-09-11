using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_VoidWorld : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        _BasicOnLoadLevel();
        AddBasicStatusEffectOnStartingEvent();

        um.AddUIAction(() => StartCoroutine(um.AnimateTransition("logoSSV", 5.0f)));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));

        string currentScene = PlayerPrefs.GetString(ProfileManager.PLAYERPREFS_CURRENTSCENE, "Void World");

        #region Tengah Game
        if (currentScene != "Void World")
        {
            um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Agent Violet. Kerja oy, lu masih menjalankan misi infiltrasi Kerajaan Havva kan?", m_voicePack),
                    new DialogueChoice[3] {
                        new DialogueChoice("Eiya, punten. (Lanjutkan permainan)", () => _LoadGameButton(currentScene)),
                        new DialogueChoice("Hah? Engga kok, ngablu kali lu! (Ulang dari awal)", () => _ClearSaveGameButton(currentScene)),
                        new DialogueChoice("Engga ah, males kerja. (Keluar)", () => _QuitButton(false))
                    })));
            return;
        }
        #endregion

        #region Start Game
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "63 68 6F 6F 73 65 20 79 6F 75 72 20 6C 61 6E 67 75 61 67 65", m_voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice("Can you speak English? (English)", () => { 
                        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, (int)LocalizationLanguage.English); 
                    }),
                    new DialogueChoice("Gabesa basa Enggres... (Bahasa Indonesia)", () => { 
                        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, (int)LocalizationLanguage.Indonesia); 
                    })
                })));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "Ah, punten. Gua lupa ganti bahasanya wkwk.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "(Gua ga ngerti Bahasa Indonesia KBBI sih, bodo amet lah ya~)", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "Err... Anyway...", m_voicePack))));
        um.AddUIAction(() => { GlobalGameManager.Instance.soundManager.PlayMusic(0); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "NYEHEHEHEHE!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_MYSTERIOUSVOICES, "SELAMAT DATANG DI DUNIA YANG GUA BIKIN, PLAYER!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "KENALIN, GUA \"The Developer\"!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Err... mungkin lu pernah kenal gua dari masa depan atau dari masa lalu...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Tapi gapapa, kenalan lagi kalau udah kenal.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Nyehehehe...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Hehe.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "DI GAME INI, LU BAKALAN JADI SEORANG SPY!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "TUGAS LU SEKARANG ADALAH INFILTRASI KERAJAAN HAVVA!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "SAAT INI KERAJAAN HAVVA SEDANG DIBAJAK UNTUK MEMICU TERJADINYA PERANG DIMENSI!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "SELAMATKAN HAVVA YANG SEDANG DITAWAN DI SANA SERTA CEGAH TERJADINYA PERANG DIMENSI!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "TANPA.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "KETAHUAN.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "SAMA SEKALI!!!!!!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", m_voicePack)))); 
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AnimateTransition()));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Udah siap memainkan game ini, Agent Violet?", m_voicePack),
                new DialogueChoice[2] {
                    new DialogueChoice("Oke, siap. (Mulai game)", () => { 
                        _NewGameButton(); 
                    }),
                    new DialogueChoice("Engga ah, males. (Keluar)", () => { 
                        _QuitButton(); 
                    })
                })));
        #endregion
    }

    private void _NewGameButton()
    {
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sip!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Gua lagi siapin teleportase lu ke Hub World.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sampai disana, lu interaksi sama laptop gua yang ada di ujung Hub World biar lu teleport lagi ke Kerajaan Havva.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Dan juga, lu cuma bisa kontak gua disini doang.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Setelah teleportase dari sini, lu bakalan dipandu dengan catatan-catatan yang gua taruh di berbagai sisi di dunia ini.", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sip! Sebelum mulai gamenya, ada pertanyaan ga?", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Ga ada?", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Welp, bukannya ga ada sih, gua emang ga ngasih pilihan buat pertanyaan, NYEHEHEHEHE.", m_voicePack), 
            new DialogueChoice[4]
            {
                new DialogueChoice("(Annoyed)", () => player.animator.SetInteger("expression", 1)),
                new DialogueChoice("(Smirk)", () => player.animator.SetInteger("expression", 3)),
                new DialogueChoice("(Surprised)", () => player.animator.SetInteger("expression", 4)),
                new DialogueChoice("...", () => player.animator.SetInteger("expression", 0)),
            }
            )));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => { player.animator.SetInteger("expression", 0); um.NextAction(); });
        um.AddUIAction(() => { StartCoroutine(GlobalGameManager.Instance.soundManager.FadeOutMusic(3.0f)); um.NextAction(); });
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(3.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Sip, teleportase udah siap!", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Teleportase akan dilakukan dalam waktu ...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "3...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "2...", m_voicePack))));
        um.AddUIAction(() => StartCoroutine(um.DelayNextAction(1.0f)));
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "1...", m_voicePack))));
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
        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(LocalizationManager.CHARACTER_THEDEVELOPER, "Se-seriusan? Berarti selama ini cuma khayalan doang?", m_voicePack),
            new DialogueChoice[2] {
                new DialogueChoice("Emang mau dari awal lagi sih, dadah! (Hapus & ulang dari awal)", () => {
                    GlobalGameManager.Instance.profileManager.ClearProfile();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                }),
                new DialogueChoice("Gaddeeeeng! (Lanjutkan permainan)", () => { _LoadGameButton(currentScene); })
            })));
    }
}
