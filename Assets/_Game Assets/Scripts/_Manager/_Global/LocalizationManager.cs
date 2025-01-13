using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocalizationLanguage
{
    Game, English, Indonesia
}

public class LocalizationString
{
    public string[] translatedStrings;

    public LocalizationString(string english, string indonesia, string game = "")
    {
        translatedStrings = new string[] { game, english, indonesia };
    }
}

public class LocalizationManager : MonoBehaviour
{
    string _Translate(LocalizationString localizationString)
    {
        int languageId = PlayerPrefs.GetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, 1);
        return localizationString.translatedStrings[languageId];
    }

    public static string Translate(LocalizationString localizationString)
    {
        if (!GlobalGameManager.Instance || !GlobalGameManager.Instance.localizationManager)
            return "";

        return GlobalGameManager.Instance.localizationManager._Translate(localizationString);
    }

    #region Tutorial
    public static readonly LocalizationString TUTORIAL_MOVE = new LocalizationString("Press to move", "Tekan untuk bergerak");
    public static readonly LocalizationString TUTORIAL_INTERACT = new LocalizationString("Hit any object to interact", "Tabrak objek apapun untuk berinteraksi");
    public static readonly LocalizationString TUTORIAL_RUN = new LocalizationString("Hold + move to run", "Tahan + gerak untuk lari");
    public static readonly LocalizationString TUTORIAL_SKIP = new LocalizationString("Hold to skip turn", "Tahan untuk lewati giliran");
    public static readonly LocalizationString TUTORIAL_NEXT = new LocalizationString("Next", "Lanjut");
    public static readonly LocalizationString TUTORIAL_SELECT = new LocalizationString("Select", "Pilih");
    public static readonly LocalizationString TUTORIAL_CHECKPOINT = new LocalizationString("Checkpoint!", "Checkpoint!");
    public static readonly LocalizationString TUTORIAL_HUBWORLD = new LocalizationString("Hub World", "Hub World");
    public static readonly LocalizationString TUTORIAL_HAVVATOPIA_UPTOWN = new LocalizationString("Havvatopia - Uptown", "Havvatopia - Pusat Kota Bagian Atas");
    public static readonly LocalizationString TUTORIAL_HAVVATOPIA_OBSERVATORY = new LocalizationString("Havvatopia - Observatory", "Havvatopia - Observatorium");
    public static readonly LocalizationString TUTORIAL_HAVVATOPIA_DOWNTOWN = new LocalizationString("Havvatopia - Downtown...?", "Havvatopia - Pusat Kota Bagian Bawah...?");
    #endregion

    #region Character
    public static readonly LocalizationString CHARACTER_MYSTERIOUSVOICES = new LocalizationString(
        "???",
        "???",
        "3f 3f 3f"
    );

    public static readonly LocalizationString CHARACTER_THEDEVELOPER = new LocalizationString(
        "The Developer",
        "The Developer"
    );

    public static readonly LocalizationString CHARACTER_3DHEADPHONESPHEREROBOT_GUARD = new LocalizationString(
        "(3D Headphone Sphere Robot) Guard",
        "(3D Headphone Sphere Robot) Satpam"
    );

    public static readonly LocalizationString CHARACTER_DEVELOPERNOTE = new LocalizationString(
        "Developer Note",
        "Pesan Developer"
    );

    public static readonly LocalizationString CHARACTER_DEVELOPERLOGDIARY = new LocalizationString(
        "Developer Log Diary",
        "Developer Log Diary"
    );

    public static readonly LocalizationString CHARACTER_CRACKOFTIME = new LocalizationString(
        "Crack of Time",
        "Pecahan Waktu"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_DOOR = new LocalizationString(
        "(2D 1 Bit) Door",
        "(2D 1 Bit) Pintu"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_SWITCH = new LocalizationString(
        "(2D 1 Bit) Switch",
        "(2D 1 Bit) Saklar"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_DOORPASSWORD = new LocalizationString(
        "(2D 1 Bit) Door with Password",
        "(2D 1 Bit) Pintu dengan Password"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_RGBGAMINGDOOR = new LocalizationString(
        "(2D 1 Bit) RGB Gaming Door",
        "(2D 1 Bit) Pintu Gaming RGB"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_SIGNPOST = new LocalizationString(
        "(2D 1 Bit) Signpost",
        "(2D 1 Bit) Plang"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_ELEFATAA = new LocalizationString(
        "(2D 1 Bit) Elefataa",
        "(2D 1 Bit) Elefataa"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_FIREPLACE = new LocalizationString(
        "(2D 1 Bit) Fire Place",
        "(2D 1 Bit) Fire Place"
    );

    public static readonly LocalizationString CHARACTER_2DHUMANOID_HAVVA = new LocalizationString(
        "(2D humanoid) Havva",
        "(2D Humanoid) Havva"
    );

    #endregion

    #region Generic Dialogues
    public static readonly LocalizationString[] GENERIC_PAUSE_CHOICES = new LocalizationString[3]
    {
        new LocalizationString("... (Resume)", "... (Lanjutkan main)"),
        new LocalizationString("I want to time leap! (Restart from last checkpoint)", "Mau time leap! (Ulang dari checkpoint terakhir)"),
        new LocalizationString("I don't want to work anymore. (Quit)", "Udahan kerjanya ah. (Keluar dari game)"),
    };

    public static readonly LocalizationString GENERIC_CAPTURED = new LocalizationString(
        "HEY! WHO ARE YOU! ALERT! ALERT! ALERT!",
        "WOY! SAPA LU! ALERT! ALERT! ALERT!"
    );

    public static readonly LocalizationString GENERIC_QUIT = new LocalizationString(
        "-",
        "EHHH BENTAR BENTAR!"
    );

    public static readonly LocalizationString[] GENERIC_CAPTURED_CHOICES = new LocalizationString[2]
    {
        new LocalizationString("It's time to time leap! (Restart from last checkpoint)", "Saatnya time leap! (Ulang dari checkpoint terakhir)"),
        new LocalizationString("I'm out. (Quit)", "Au ah. (Keluar)"),
    };

    public static readonly LocalizationString GENERIC_DOORNOSWITCH = new LocalizationString(
        "There's no one in this door...",
        "Pintunya ga ada penghuninya..."
    );

    public static readonly LocalizationString[] GENERIC_PASSWORD_CHOICES = new LocalizationString[3]
    {
        new LocalizationString("Enter Password.", "Masukkan Password."),
        new LocalizationString("Enter Password (Already have the answers).", "Masukkan Password (Sudah punya jawabannya)."),
        new LocalizationString("Cancel.", "Gajadi.")
    };

    public static readonly LocalizationString[] GENERIC_PASSWORD_QUESTION = new LocalizationString[9]
    {
        new LocalizationString("Question #1", "Pertanyaan #1"),
        new LocalizationString("Question #2", "Pertanyaan #2"),
        new LocalizationString("Question #3", "Pertanyaan #3"),
        new LocalizationString("Question #4", "Pertanyaan #4"),
        new LocalizationString("Question #5", "Pertanyaan #5"),
        new LocalizationString("Question #6", "Pertanyaan #6"),
        new LocalizationString("Question #7", "Pertanyaan #7"),
        new LocalizationString("Question #8", "Pertanyaan #8"),
        new LocalizationString("Question #9", "Pertanyaan #9")
    };

    public static readonly LocalizationString[] GENERIC_PASSWORD_ANSWER = new LocalizationString[3]
    {
        new LocalizationString("1", "1"),
        new LocalizationString("2", "2"),
        new LocalizationString("3", "3")
    };

    public static readonly LocalizationString GENERIC_THE_ANSWER_IS = new LocalizationString(
        "The answer is ",
        "Jawabannya adalah "
    );

    public static readonly LocalizationString GENERIC_MEMORY_TRIGGERED = new LocalizationString(
        "There are many voices from the past heard through this crack of time...",
        "Ada banyak suara dari masa lalu terdengar di pecahan waktu ini..."
    );

    public static readonly LocalizationString[] GENERIC_MEMORY_REMEMBERED = new LocalizationString[2]
    {
        new LocalizationString("You magically remember all of the dialogues...", "Secara tiba-tiba hapal semua dialog barusan..."),
        new LocalizationString("Maybe those dialogues can be used as a password for a door!", "Mungkin dialog-dialog tersebut bisa dipakai untuk password di pintu tertentu!"),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_FAILED = new LocalizationString(
        "-",
        "M-Maaf, ada kesalahan teknis jadi tidak bisa kesana..."
    );

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_PASSWORD_CORRECT = new LocalizationString[2]
    {
        new LocalizationString("-", "Passwordnya benar!"),
        new LocalizationString("-", "Ayo kita ke sana!"),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_PASSWORD_WRONG = new LocalizationString(
        "-",
        "M-maaf, tapi passwordnya salah..."
    );

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_DOWNTOWN = new LocalizationString[2]
    {
        new LocalizationString("-", "T-tapi buat kesana kamu butuh password..."),
        new LocalizationString("-", "M-mungkin Havva mengetahui passwordnya..."),
    };

    public static readonly LocalizationString[][] GENERIC_ELEFATAAEVENT_DOWNTOWN_PASSWORD_ANSWERS = new LocalizationString[4][]
    {
        new LocalizationString[3] { new LocalizationString("E", "E"), new LocalizationString("D", "D"), new LocalizationString("B", "B") },
        new LocalizationString[3] { new LocalizationString("C", "C"), new LocalizationString("D", "D"), new LocalizationString("E", "E") },
        new LocalizationString[3] { new LocalizationString("E", "E"), new LocalizationString("F", "F"), new LocalizationString("D", "D")},
        new LocalizationString[3] { new LocalizationString("C E G", "C E G"), new LocalizationString("E F# G", "E F# G"), new LocalizationString("A G# G", "A G# G")}
    };

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_OBSERVATORY = new LocalizationString[2]
    {
        new LocalizationString("-", "M-maaf, kamu tidak bisa ke Observatory..."),
        new LocalizationString("-", "A-aslinya aku ga mau melakukan ini, t-tapi aku disuruh meminta password untuk siapapun yang ingin pergi ke Observatory agar tidak ada yang bisa menemui Havva..."),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_CHOICE = new LocalizationString(
        "-",
        "Passwordnya dapat dimana ya?"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_QUESTION = new LocalizationString(
        "-",
        "D-dan terakhir, tolong isi captcha ini :"
    );

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_ANSWER = new LocalizationString[3]
    {
        new LocalizationString("I'm not a employee.", "Saya bukan karyawan."),
        new LocalizationString("I'm not a robot.", "Saya bukan robot."),
        new LocalizationString("I'm not a spy.", "Saya bukan spy."),
    };

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_UPTOWN = new LocalizationString[4]
    {
        new LocalizationString("-", "Y-yang setel passwordnya sih tadi ke arah timur laut..."),
        new LocalizationString("-", "S-Semoga saja... passwordnya engga dititipin ke " + Translate(CHARACTER_2D1BIT_FIREPLACE) + "..."),
        new LocalizationString("-", "Soalnya siapapun yang mendatangi " + Translate(CHARACTER_2D1BIT_FIREPLACE) + " akan dibakar!!!"),
        new LocalizationString("-", "Dan aku ga mau ada yang dibakar huaaaaaaaaaa!!!"),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_NONUPTOWN = new LocalizationString(
        "-",
        "Y-yang setel passwordnya terakhir kulihat di Havvatopia bagian Uptown..."
    );

    #endregion

    #region Void World Dialogues
    #region End Game
    public static readonly LocalizationString VW_END_0 = new LocalizationString(
        "-",
        "Halo lagi, Agent Violet."
    );

    public static readonly LocalizationString VW_END_1 = new LocalizationString(
        "-",
        "Gua liat lu udah sampai di Pusat Kota Havvatopia bagian bawah."
    );

    public static readonly LocalizationString VW_END_2 = new LocalizationString(
        "-",
        "Gua ucapkan selamat sudah sampai sana, tapi sayangnya untuk versi yang lu mainin saat ini cuma bisa main sampai sana wkwk."
    );

    public static readonly LocalizationString VW_END_3 = new LocalizationString(
        "-",
        "..."
    );

    public static readonly LocalizationString VW_END_4 = new LocalizationString(
        "-",
        "Umm... Jadi gini..."
    );

    public static readonly LocalizationString VW_END_5 = new LocalizationString(
        "-",
        "Tadi kan gua sempet bilang levelnya belum selesai..."
    );

    public static readonly LocalizationString VW_END_6 = new LocalizationString(
        "-",
        "Itu karena..."
    );

    public static readonly LocalizationString VW_END_7 = new LocalizationString(
        "-",
        "GUA MALES LANJUTIN GAMENYA..."
    );

    public static readonly LocalizationString VW_END_8 = new LocalizationString(
        "-",
        "NYEHEHEHEHEHE."
    );

    public static readonly LocalizationString VW_END_9 = new LocalizationString(
        "-",
        "Hehe..."
    );

    public static readonly LocalizationString VW_END_10 = new LocalizationString(
        "-",
        "Welp..."
    );

    public static readonly LocalizationString VW_END_11 = new LocalizationString(
        "-",
        "Saatnya roll the credit!!!"
    );

    public static readonly LocalizationString VW_END_12 = new LocalizationString(
        "-",
        "Developed by Ai Nonymous"
    );

    public static readonly LocalizationString VW_END_13 = new LocalizationString(
        "-",
        "Powered by Unity Engine"
    );

    public static readonly LocalizationString VW_END_14 = new LocalizationString(
        "-",
        "Music :\nKevin Macleod - Frost Waltz, Teddy Bear Waltz, Spy Glass"
    );

    public static readonly LocalizationString VW_END_15 = new LocalizationString(
        "-",
        "Audio & Sound :\nRPG Maker MV\nMechvibes.com - jsfxr"
    );

    public static readonly LocalizationString VW_END_16 = new LocalizationString(
        "-",
        "Animation :\nMixamo"
    );

    public static readonly LocalizationString VW_END_17 = new LocalizationString(
        "-",
        "Anyway, gua pengen bilang sesuatu."
    );

    public static readonly LocalizationString VW_END_18 = new LocalizationString(
        "-",
        "TERIMA KASIH SUDAH MEMAINKAN GAME INI!"
    );

    public static readonly LocalizationString VW_END_19 = new LocalizationString(
        "-",
        "Gua sebenernya lagi kembangin game baru."
    );

    public static readonly LocalizationString VW_END_20 = new LocalizationString(
        "-",
        "Jadi lu bisa support gua dengan beberapa cara"
    );

    public static readonly LocalizationString VW_END_21 = new LocalizationString(
        "-",
        "1) Follow atau join discord channel gua"
    );

    public static readonly LocalizationString VW_END_22 = new LocalizationString(
        "-",
        "2) Taro review, kalo bingung tulis aja MAKASIH DEVELOPER NYEHEHEHE"
    );

    public static readonly LocalizationString VW_END_23 = new LocalizationString(
        "-",
        "..."
    );

    public static readonly LocalizationString VW_END_24 = new LocalizationString(
        "-",
        "Apa yang mau lu lakukan sekarang, Agent Violet?"
    );

    public static readonly LocalizationString VW_END_24_1 = new LocalizationString(
        "-",
        "Hapus ingatan developer (Ulang dari awal)"
    );

    public static readonly LocalizationString VW_END_24_2 = new LocalizationString(
        "-",
        "Dadah! (Keluar)"
    );
    #endregion

    #region Mid Game
    public static readonly LocalizationString VW_MIDGAME_0 = new LocalizationString(
        "-",
        "Agent Violet. Kerja oy, lu masih menjalankan misi ini kan?"
    );

    public static readonly LocalizationString VW_MIDGAME_0_1 = new LocalizationString(
        "-",
        "Eiya, punten. (Lanjutkan permainan)"
    );

    public static readonly LocalizationString VW_MIDGAME_0_2 = new LocalizationString(
        "-",
        "Hah? Engga kok, ngablu kali lu! (Ulang dari awal)"
    );

    public static readonly LocalizationString VW_MIDGAME_0_3 = new LocalizationString(
        "-",
        "Engga ah, males kerja. (Keluar)"
    );

    public static readonly LocalizationString VW_MIDGAME_NEW_0 = new LocalizationString(
        "-",
        "Se-seriusan? Berarti selama ini cuma khayalan doang?"
    );

    public static readonly LocalizationString VW_MIDGAME_NEW_0_1 = new LocalizationString(
        "-",
        "Emang mau dari awal lagi sih, dadah! (Hapus & ulang dari awal)"
    );

    public static readonly LocalizationString VW_MIDGAME_NEW_0_2 = new LocalizationString(
        "-",
        "Gaddeeeeng! (Lanjutkan permainan)"
    );
    #endregion

    #region Start Game
    static readonly string vw_onload_0 = "54 65 73 74 20 74 65 73 74 2E 20 48 61 6C 6F 20 41 67 65 6E 74 20 56 69 6F 6C 65 74";
    public static readonly LocalizationString VW_ONLOAD_0 = new LocalizationString(vw_onload_0, vw_onload_0, vw_onload_0);

    static readonly string vw_onload_0_1 = "Can you speak English? (English)";
    static readonly string vw_onload_0_2 = "Gabisa basa Enggres... (Bahasa Indonesia)";
    public static readonly LocalizationString VW_ONLOAD_0_1 = new LocalizationString(vw_onload_0_1, vw_onload_0_1, vw_onload_0_1);
    public static readonly LocalizationString VW_ONLOAD_0_2 = new LocalizationString(vw_onload_0_2, vw_onload_0_2, vw_onload_0_2);

    public static readonly LocalizationString VW_ONLOAD_1 = new LocalizationString(
        "Ah, excuse me. I forgot to change the language haha.",
        "Ah, punten. Gua lupa ganti bahasanya wkwk."
    );

    public static readonly LocalizationString VW_ONLOAD_2 = new LocalizationString(
        "(Darn, My English grammar sucks. Well who cares anyway~)",
        "(Gua ga ngerti Bahasa Indonesia KBBI sih, bodo amet lah ya~)"
    );

    public static readonly LocalizationString VW_ONLOAD_3 = new LocalizationString(
        "Err... Anyway...",
        "Err... Anyway..."
    );

    public static readonly LocalizationString VW_ONLOAD_4 = new LocalizationString(
        "NYEHEHEHEHE!",
        "NYEHEHEHEHE!"
    );

    public static readonly LocalizationString VW_ONLOAD_5 = new LocalizationString(
        "WELCOME TO THE WORLD THAT I MADE, PLAYER!",
        "SELAMAT DATANG DI DUNIA YANG GUA BIKIN, PLAYER!"
    );

    public static readonly LocalizationString VW_ONLOAD_6 = new LocalizationString(
        "I AM \"The Developer\"!",
        "KENALIN, GUA \"The Developer\"!"
    );

    public static readonly LocalizationString VW_ONLOAD_7 = new LocalizationString(
        "Uhh... maybe you know me from the future or from the past...",
        "Err... mungkin lu pernah kenal gua dari masa depan atau dari masa lalu..."
    );

    public static readonly LocalizationString VW_ONLOAD_8 = new LocalizationString(
        "But it's okay. Let me introduce myself again.",
        "Tapi gapapa, kenalan lagi kalau udah kenal."
    );

    public static readonly LocalizationString VW_ONLOAD_9 = new LocalizationString(
        "Nyehehehe...",
        "Nyehehehe..."
    );

    public static readonly LocalizationString VW_ONLOAD_10 = new LocalizationString(
        "Hehe.",
        "Hehe."
    );

    public static readonly LocalizationString VW_ONLOAD_11 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString VW_ONLOAD_12 = new LocalizationString(
        "IN THIS GAME, YOU ARE A SPY!",
        "DI GAME INI, LU BAKALAN JADI SEORANG SPY!"
    );

    public static readonly LocalizationString VW_ONLOAD_13 = new LocalizationString(
        "-",
        "TUGAS LU SEKARANG ADALAH INFILTRASI KOTA HAVVATOPIA!"
    );

    public static readonly LocalizationString VW_ONLOAD_14 = new LocalizationString(
        "-",
        "SAAT INI KOTA HAVVATOPIA SEDANG DIBAJAK UNTUK MEMICU TERJADINYA PERANG DIMENSI!"
    );

    public static readonly LocalizationString VW_ONLOAD_15 = new LocalizationString(
        "-",
        "SELAMATKAN HAVVA YANG SEDANG DITAWAN DI SANA SERTA CEGAH TERJADINYA PERANG DIMENSI!"
    );

    public static readonly LocalizationString VW_ONLOAD_16 = new LocalizationString(
        "-",
        "TANPA."
    );

    public static readonly LocalizationString VW_ONLOAD_17 = new LocalizationString(
        "-",
        "KETAHUAN."
    );

    public static readonly LocalizationString VW_ONLOAD_18 = new LocalizationString(
        "-",
        "SAMA SEKALI!!!!!!"
    );

    public static readonly LocalizationString VW_ONLOAD_19 = new LocalizationString(
        "-",
        "..."
    );

    public static readonly LocalizationString VW_ONLOAD_20 = new LocalizationString(
        "-",
        "Udah siap memainkan game ini, Agent Violet?"
    );

    public static readonly LocalizationString VW_ONLOAD_20_1 = new LocalizationString(
        "-",
        "Oke, siap. (Mulai game)"
    );

    public static readonly LocalizationString VW_ONLOAD_20_2 = new LocalizationString(
        "-",
        "Engga ah, males. (Keluar)"
    );

    public static readonly LocalizationString VW_ONLOAD_21 = new LocalizationString(
        "-",
        "Sip!"
    );

    public static readonly LocalizationString VW_ONLOAD_22 = new LocalizationString(
        "-",
        "Gua lagi siapin teleportase lu ke Hub World."
    );

    public static readonly LocalizationString VW_ONLOAD_23 = new LocalizationString(
        "-",
        "Sampai disana, lu interaksi sama laptop gua yang ada di ujung Hub World biar lu teleport lagi ke Kota Havvatopia."
    );

    public static readonly LocalizationString VW_ONLOAD_24 = new LocalizationString(
        "-",
        "Dan juga, lu cuma bisa kontak gua disini doang."
    );

    public static readonly LocalizationString VW_ONLOAD_25 = new LocalizationString(
        "-",
        "Setelah teleportase dari sini, lu bakalan dipandu dengan catatan-catatan yang gua taruh di berbagai sisi di dunia ini."
    );

    public static readonly LocalizationString VW_ONLOAD_26 = new LocalizationString(
        "-",
        "Sebelum mulai gamenya, ada pertanyaan ga?"
    );

    public static readonly LocalizationString VW_ONLOAD_27 = new LocalizationString(
        "-",
        "Ga ada?"
    );

    public static readonly LocalizationString VW_ONLOAD_28 = new LocalizationString(
        "-",
        "Welp, bukannya ga ada sih, gua emang ga ngasih pilihan buat pertanyaan, NYEHEHEHEHE."
    );

    public static readonly LocalizationString VW_ONLOAD_28_1 = new LocalizationString(
        "(Annoyed)",
        "-"
    );

    public static readonly LocalizationString VW_ONLOAD_28_2 = new LocalizationString(
        "(Smirk)",
        "-"
    );

    public static readonly LocalizationString VW_ONLOAD_28_3 = new LocalizationString(
        "(Surprised)",
        "-"
    );

    public static readonly LocalizationString VW_ONLOAD_28_4 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString VW_ONLOAD_29 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString VW_ONLOAD_30 = new LocalizationString(
        "-",
        "Sip, teleportase udah siap!"
    );

    public static readonly LocalizationString VW_ONLOAD_31 = new LocalizationString(
        "-",
        "Teleportase akan dilakukan dalam waktu ..."
    );

    public static readonly LocalizationString VW_ONLOAD_32 = new LocalizationString(
        "3...",
        "3..."
    );

    public static readonly LocalizationString VW_ONLOAD_33 = new LocalizationString(
        "2...",
        "2..."
    );

    public static readonly LocalizationString VW_ONLOAD_34 = new LocalizationString(
        "1...",
        "1..."
    );
    #endregion
    #endregion

    #region Hub World
    public static readonly LocalizationString HW_ONLOAD_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString HW_WIN_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString HW_WIN_1 = new LocalizationString(
        "?",
        "?"
    );

    public static readonly LocalizationString HW_WIN_2 = new LocalizationString(
        "-",
        "Ga terjadi apa-apa..."
    );

    public static readonly LocalizationString HW_WIN_3 = new LocalizationString(
        "-",
        "!"
    );

    #region 3DSR
    public static readonly LocalizationString HW_3DSR_0 = new LocalizationString(
        "-",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_3DSR_1 = new LocalizationString(
        "-",
        "Kenalkan, ini adalah salah satu sub-class NPC dari kelas 3D Sphere Robot, 3D Headphone Sphere Robot."
    );

    public static readonly LocalizationString HW_3DSR_2 = new LocalizationString(
        "-",
        "Mereka adalah salah satu kelas dominan dari penduduk Kota Havvatopia."
    );

    public static readonly LocalizationString HW_3DSR_3 = new LocalizationString(
        "-",
        "Namun saat ini mereka seperti kerasukan gitu, sehingga menempatkan mereka menjadi antagonis dari game ini."
    );

    public static readonly LocalizationString HW_3DSR_4 = new LocalizationString(
        "-",
        "Lu ga boleh dan ga bisa bunuh mereka, serta lu ga boleh ketauan oleh mereka."
    );

    public static readonly LocalizationString HW_3DSR_5 = new LocalizationString(
        "-",
        "Kalo lu ketauan oleh mereka, lu harus time leap."
    );

    public static readonly LocalizationString HW_3DSR_6 = new LocalizationString(
        "-",
        "Ntar lu balik ke checkpoint terakhir."
    );
    #endregion

    #region HAVVA
    public static readonly LocalizationString HW_HAVVA_0 = new LocalizationString(
        "-",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_HAVVA_1 = new LocalizationString(
        "-",
        "Ini adalah Kota Havvatopia."
    );

    public static readonly LocalizationString HW_HAVVA_2 = new LocalizationString(
        "-",
        "Sama seperti Kota lainnya, Kota ini terletak didalam 3D Titan Sphere Robot yang sudah mati."
    );

    public static readonly LocalizationString HW_HAVVA_3 = new LocalizationString(
        "-",
        "Kota ini dipimpin oleh Havva, dia yang memanggil lu kesana."
    );

    public static readonly LocalizationString HW_HAVVA_4 = new LocalizationString(
        "-",
        "Dia memanggil lu karena saat ini Kota Havvatopia sedang dalam keadaan darurat."
    );

    public static readonly LocalizationString HW_HAVVA_5 = new LocalizationString(
        "-",
        "Semua penduduk Havvatopia saat ini terjebak di kota ini."
    );

    public static readonly LocalizationString HW_HAVVA_6 = new LocalizationString(
        "-",
        "Nah, tugas lu yaitu ketemu dengan Havva dan investigasi apa yang terjadi di Havvatopia serta selamatkan penduduk Havvatopia yang saat ini sedang terjebak disana."
    );
    #endregion

    #region 3DH
    public static readonly LocalizationString HW_3DH_0 = new LocalizationString(
        "-",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_3DH_1 = new LocalizationString(
        "-",
        "Ini lu, Agent Violet."
    );

    public static readonly LocalizationString HW_3DH_2 = new LocalizationString(
        "-",
        "Lu berasal dari kelas 3D Humanoid."
    );

    public static readonly LocalizationString HW_3DH_3 = new LocalizationString(
        "-",
        "Lu adalah spy terbaik di game ini."
    );

    public static readonly LocalizationString HW_3DH_4 = new LocalizationString(
        "-",
        "Mungkin karena lu satu-satunya spy di game ini."
    );

    public static readonly LocalizationString HW_3DH_5 = new LocalizationString(
        "-",
        "NYEHEHEHEHE."
    );

    public static readonly LocalizationString HW_3DH_6 = new LocalizationString(
        "-",
        "Oh iya, karena banyak tester yang ga nyadar ini, jadi ada yang pengen gua kasih tau nih."
    );

    public static readonly LocalizationString HW_3DH_7 = new LocalizationString(
        "-",
        "Game ini adalah game synchronous, apa itu synchronous?"
    );

    public static readonly LocalizationString HW_3DH_8 = new LocalizationString(
        "-",
        "Ini game waktunya cuma jalan kalau lu jalan."
    );

    public static readonly LocalizationString HW_3DH_9 = new LocalizationString(
        "-",
        "Jadi, lu bisa pikirkan baik-baik sebelum lu jalan."
    );
    #endregion

    #region 2DH
    public static readonly LocalizationString HW_2DH_0 = new LocalizationString(
        "-",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_2DH_1 = new LocalizationString(
        "-",
        "Enggak, ini bukan laptop gua."
    );

    public static readonly LocalizationString HW_2DH_2 = new LocalizationString(
        "-",
        "Ini adalah interface berbentuk monitor dari NPC kelas 2D, salah satu penduduk Kota Havvatopia."
    );

    public static readonly LocalizationString HW_2DH_3 = new LocalizationString(
        "-",
        "Ada beberapa sub-class dari kelas 2D, seperti 2D Humanoid dan 2D 1 Bit."
    );

    public static readonly LocalizationString HW_2DH_4 = new LocalizationString(
        "-",
        "Mereka semua butuh interface karena mereka semua hidup di dimensi yang berbeda."
    );

    public static readonly LocalizationString HW_2DH_5 = new LocalizationString(
        "-",
        "Untuk pindah dari interface ke interface lain, mereka menggunakan internet."
    );

    public static readonly LocalizationString HW_2DH_6 = new LocalizationString(
        "-",
        "Jika listrik mati atau wifi mati, mereka akan terperangkap di interface tersebut sampai mereka berubah menjadi objek statis."
    );
    #endregion

    #endregion

    #region Level 1

    #endregion

    #region Level 2

    #endregion

    #region Level 3

    #endregion
}
