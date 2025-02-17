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

    #region GLOBAL GAME MANAGER
    public static string SYSTEM_SCREENRESOLUTIONS => Translate(new LocalizationString("Screen Resolutions", "Resolusi Layar", "Screen Resolutions"));
    public static string SYSTEM_SCREENMODE => Translate(new LocalizationString("Screen Mode", "Mode Layar", "Screen Mode"));
    public static string SYSTEM_GRAPHICPRESET => Translate(new LocalizationString("Graphic Preset", "Preset Grafis", "Graphic Preset"));
    public static string SYSTEM_MUSICVOLUME => Translate(new LocalizationString("Music Volume", "Volume Musik", "Music Volume"));
    public static string SYSTEM_SFXVOLUME => Translate(new LocalizationString("SFX Volume", "Volume SFX", "SFX Volume"));
    public static string SYSTEM_APPLY => Translate(new LocalizationString("Apply", "Terapkan", "Apply"));

    #endregion

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
        "WAIT WAIT WAIT",
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
        new LocalizationString("You magically remember all of those dialogues...", "Secara tiba-tiba hapal semua dialog barusan..."),
        new LocalizationString("Maybe those dialogues can be used as a password for a door!", "Mungkin dialog-dialog tersebut bisa dipakai untuk password di pintu tertentu!"),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_FAILED = new LocalizationString(
        "S-Sorry... there's a technical difficulty so you can't go there...",
        "M-Maaf, ada kesalahan teknis jadi tidak bisa kesana..."
    );

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_PASSWORD_CORRECT = new LocalizationString[2]
    {
        new LocalizationString("The password is correct", "Passwordnya benar!"),
        new LocalizationString("Let's go!!!", "Ayo kita ke sana!"),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_PASSWORD_WRONG = new LocalizationString(
        "S-Sorry... but the password is incorrect...",
        "M-maaf, tapi passwordnya salah..."
    );

    public static readonly LocalizationString[] GENERIC_ELEFATAAEVENT_DOWNTOWN = new LocalizationString[2]
    {
        new LocalizationString("B-but you need password to go there...", "T-tapi buat kesana kamu butuh password..."),
        new LocalizationString("M-maybe Havva know about it...", "M-mungkin Havva mengetahui passwordnya..."),
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
        new LocalizationString("I-I'm sorry, you can't go to the Observatory...", "M-maaf, kamu tidak bisa ke Observatory..."),
        new LocalizationString("I-I originally didn't want to do this, but I was told to ask for a password for anyone who wanted to go to the Observatory so that no one could meet Havva...", "A-aslinya aku ga mau melakukan ini, t-tapi aku disuruh meminta password untuk siapapun yang ingin pergi ke Observatory agar tidak ada yang bisa menemui Havva..."),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_CHOICE = new LocalizationString(
        "Where can I get the passsword?",
        "Passwordnya dapat dimana ya?"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORD_QUESTION = new LocalizationString(
        "A-And lastly, please fill this captcha :",
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
        new LocalizationString("T-the one who set the password goes to northeast...", "Y-yang setel passwordnya sih tadi ke arah timur laut..."),
        new LocalizationString("I-I hope... the password is not given to " + Translate(CHARACTER_2D1BIT_FIREPLACE) + "...", "S-Semoga saja... passwordnya engga dititipin ke " + Translate(CHARACTER_2D1BIT_FIREPLACE) + "..."),
        new LocalizationString("Because anyone who comes to " + Translate(CHARACTER_2D1BIT_FIREPLACE) + " will be burned!!!", "Soalnya siapapun yang mendatangi " + Translate(CHARACTER_2D1BIT_FIREPLACE) + " akan dibakar!!!"),
        new LocalizationString("And I don't want anyone to get burned huaaaaaaaa", "Dan aku ga mau siapapun dibakar huaaaaaaaaaa!!!"),
    };

    public static readonly LocalizationString GENERIC_ELEFATAAEVENT_OBSERVATORY_PASSWORDLOCATION_NONUPTOWN = new LocalizationString(
        "L-last time I saw the one who set the password was in Havvatopia Uptown...",
        "Y-yang setel passwordnya terakhir kulihat di Havvatopia bagian Uptown..."
    );

    public static readonly LocalizationString GENERIC_ELEFATAAGOTOCHOICES_OBSERVATORY = new LocalizationString(
        "Havvatopia - Observatorium",
        "Havvatopia - Observatorium"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAGOTOCHOICES_UPTOWN = new LocalizationString(
        "Havvatopia - Uptown",
        "Havvatopia - Uptown"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAGOTOCHOICES_DOWNTOWN = new LocalizationString(
        "Havvatopia - Downtown",
        "Havvatopia - Downtown"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAGOTOCHOICES_ENGINE = new LocalizationString(
        "Havvatopia - Engine Room",
        "Havvatopia - Engine Room"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAGOTOCHOICES_UNDERGROUND = new LocalizationString(
        "Havvatopia - Underground",
        "Havvatopia - Underground"
    );

    public static readonly LocalizationString GENERIC_ELEFATAAGOTOCHOICES_CANCEL = new LocalizationString(
        "Cancel",
        "Gajadi"
    );
    #endregion

    #region Void World Dialogues
    #region End Game
    public static readonly LocalizationString VW_END_0 = new LocalizationString(
        "Hello again, Agent Violet.",
        "Halo lagi, Agent Violet."
    );

    public static readonly LocalizationString VW_END_1 = new LocalizationString(
        "I see that you already reached Downtown Havvatopia.",
        "Gua liat lu udah sampai di Havvatopia bagian bawah."
    );

    public static readonly LocalizationString VW_END_2 = new LocalizationString(
        "I congrats you for reaching there, but unfortunately you met the limit what you can play in this version",
        "Gua ucapkan selamat sudah sampai sana, tapi sayangnya untuk versi yang lu mainin saat ini cuma bisa main sampai sana wkwk."
    );

    public static readonly LocalizationString VW_END_3 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString VW_END_4 = new LocalizationString(
        "Umm... Hear me out...",
        "Umm... Jadi gini..."
    );

    public static readonly LocalizationString VW_END_5 = new LocalizationString(
        "I said that the level is unfinished right...",
        "Tadi kan gua sempet bilang levelnya belum selesai..."
    );

    public static readonly LocalizationString VW_END_6 = new LocalizationString(
        "It because...",
        "Itu karena..."
    );

    public static readonly LocalizationString VW_END_7 = new LocalizationString(
        "I'M TOO LAZY TO CONTINUE THE DEVELOPMENT OF THE GAME!",
        "GUA MALES LANJUTIN PENGEMBANGAN GAMENYA!"
    );

    public static readonly LocalizationString VW_END_8 = new LocalizationString(
        "NYEHEHEHEHEHE.",
        "NYEHEHEHEHEHE."
    );

    public static readonly LocalizationString VW_END_9 = new LocalizationString(
        "Hehe...",
        "Hehe..."
    );

    public static readonly LocalizationString VW_END_10 = new LocalizationString(
        "Welp...",
        "Welp..."
    );

    public static readonly LocalizationString VW_END_11 = new LocalizationString(
        "Time to roll the credit!!!",
        "Saatnya roll the credit!!!"
    );

    public static readonly LocalizationString VW_END_12 = new LocalizationString(
        "Developed by Ai Nonymous",
        "Developed by Ai Nonymous"
    );

    public static readonly LocalizationString VW_END_13 = new LocalizationString(
        "Powered by Unity Engine",
        "Powered by Unity Engine"
    );

    public static readonly LocalizationString VW_END_14 = new LocalizationString(
        "Music :\nKevin Macleod - Frost Waltz, Teddy Bear Waltz, Spy Glass",
        "Music :\nKevin Macleod - Frost Waltz, Teddy Bear Waltz, Spy Glass"
    );

    public static readonly LocalizationString VW_END_15 = new LocalizationString(
        "Audio & Sound :\nRPG Maker MV\nMechvibes.com - jsfxr",
        "Audio & Sound :\nRPG Maker MV\nMechvibes.com - jsfxr"
    );

    public static readonly LocalizationString VW_END_16 = new LocalizationString(
        "Animation :\nMixamo",
        "Animation :\nMixamo"
    );

    public static readonly LocalizationString VW_END_17 = new LocalizationString(
        "Anyway, I want to say something.",
        "Anyway, gua pengen bilang sesuatu."
    );

    public static readonly LocalizationString VW_END_18 = new LocalizationString(
        "THANK YOU FOR PLAYING THIS GAME!",
        "TERIMA KASIH SUDAH MEMAINKAN GAME INI!"
    );

    public static readonly LocalizationString VW_END_19 = new LocalizationString(
        "I actually trying to develop a new game.",
        "Gua sebenernya lagi kembangin game baru."
    );

    public static readonly LocalizationString VW_END_20 = new LocalizationString(
        "So if you like this game, you can support me with some way",
        "Jadi kalau lu senang game ini, lu bisa support gua dengan beberapa cara"
    );

    public static readonly LocalizationString VW_END_21 = new LocalizationString(
        "1) Follow or join my discord channel",
        "1) Follow atau join discord channel gua"
    );

    public static readonly LocalizationString VW_END_22 = new LocalizationString(
        "2) Write some review & feedback for this game",
        "2) Taro review & feedback untuk game ini"
    );

    public static readonly LocalizationString VW_END_23 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString VW_END_24 = new LocalizationString(
        "So, what do you want to do now, Agent Violet?",
        "Apa yang mau lu lakukan sekarang, Agent Violet?"
    );

    public static readonly LocalizationString VW_END_24_1 = new LocalizationString(
        "Erase the developer's memory (Start over)",
        "Hapus ingatan developer (Ulang dari awal)"
    );

    public static readonly LocalizationString VW_END_24_2 = new LocalizationString(
        "Bye! (Quit)",
        "Dadah! (Keluar)"
    );
    #endregion

    #region Mid Game
    public static readonly LocalizationString VW_MIDGAME_0 = new LocalizationString(
        "Agent Violet. Wake up, you still working on this mission right?",
        "Agent Violet. Kerja oy, lu masih menjalankan misi ini kan?"
    );

    public static readonly LocalizationString VW_MIDGAME_0_1 = new LocalizationString(
        "Ah, I nearly forgor (Continue)",
        "Eiya, punten. (Lanjutkan permainan)"
    );

    public static readonly LocalizationString VW_MIDGAME_0_2 = new LocalizationString(
        "Huh? Of coourse not, are your head okay? (New game)",
        "Hah? Engga kok, ngablu kali lu! (Ulang dari awal)"
    );

    public static readonly LocalizationString VW_MIDGAME_0_3 = new LocalizationString(
        "Nah, too lazy to work. (Quit)",
        "Engga ah, males kerja. (Keluar)"
    );

    public static readonly LocalizationString VW_MIDGAME_NEW_0 = new LocalizationString(
        "A-are you sure? So all of this is just my illusion?",
        "Se-seriusan? Berarti selama ini cuma khayalan doang?"
    );

    public static readonly LocalizationString VW_MIDGAME_NEW_0_1 = new LocalizationString(
        "I actually want to start over, bye bye! (Erase save and start over)",
        "Emang mau dari awal lagi sih, dadah! (Hapus & ulang dari awal)"
    );

    public static readonly LocalizationString VW_MIDGAME_NEW_0_2 = new LocalizationString(
        "Just kiddinggggg! (Continue)",
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
        "YOUR MISSION RIGHT NOW IS TO INFILTRATE HAVVATOPIA CITY!",
        "TUGAS LU SEKARANG ADALAH INFILTRASI KOTA HAVVATOPIA!"
    );

    public static readonly LocalizationString VW_ONLOAD_14 = new LocalizationString(
        "RIGHT NOW HAVVATOPIA IS BEING HIJACKED TO TRIGGER A DIMENSIONAL WAR!",
        "SAAT INI KOTA HAVVATOPIA SEDANG DIBAJAK UNTUK MEMICU TERJADINYA PERANG DIMENSI!"
    );

    public static readonly LocalizationString VW_ONLOAD_15 = new LocalizationString(
        "SAVE HAVVA WHO IS BEING HELD CAPTIVE THERE AND PREVENT A DIMENSIONAL WAR!",
        "SELAMATKAN HAVVA YANG SEDANG DITAWAN DI SANA SERTA CEGAH TERJADINYA PERANG DIMENSI!"
    );

    public static readonly LocalizationString VW_ONLOAD_16 = new LocalizationString(
        "WITHOUT.",
        "TANPA."
    );

    public static readonly LocalizationString VW_ONLOAD_17 = new LocalizationString(
        "BEING DETECTED.",
        "KETAHUAN."
    );

    public static readonly LocalizationString VW_ONLOAD_18 = new LocalizationString(
        "AT ALL!!!!!",
        "SAMA SEKALI!!!!!!"
    );

    public static readonly LocalizationString VW_ONLOAD_19 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString VW_ONLOAD_20 = new LocalizationString(
        "Are you ready to play this game, Agent Violet?",
        "Udah siap memainkan game ini, Agent Violet?"
    );

    public static readonly LocalizationString VW_ONLOAD_20_1 = new LocalizationString(
        "Okay, ready. (New game)",
        "Oke, siap. (Mulai game)"
    );

    public static readonly LocalizationString VW_ONLOAD_20_2 = new LocalizationString(
        "Nah, too lazy (Quit)",
        "Engga ah, males. (Keluar)"
    );

    public static readonly LocalizationString VW_ONLOAD_21 = new LocalizationString(
        "Alright!",
        "Sip!"
    );

    public static readonly LocalizationString VW_ONLOAD_22 = new LocalizationString(
        "I'm preparing your teleportation to Hub World.",
        "Gua lagi siapin teleportase lu ke Hub World."
    );

    public static readonly LocalizationString VW_ONLOAD_23 = new LocalizationString(
        "Once there, you have to interact with my laptop at the end of the Hub World to teleport you again to Havvatopia.",
        "Sampai disana, lu interaksi sama laptop gua yang ada di ujung Hub World biar lu teleport lagi ke Kota Havvatopia."
    );

    public static readonly LocalizationString VW_ONLOAD_24 = new LocalizationString(
        "And also, you can only talk to me here.",
        "Dan juga, lu cuma bisa kontak gua disini doang."
    );

    public static readonly LocalizationString VW_ONLOAD_25 = new LocalizationString(
        "After that, you will be guided with notes that I put on corners of this world.",
        "Setelah teleportase dari sini, lu bakalan dipandu dengan catatan-catatan yang gua taruh di berbagai sisi di dunia ini."
    );

    public static readonly LocalizationString VW_ONLOAD_26 = new LocalizationString(
        "Alright, before you start the game, is there any question?",
        "Sebelum mulai gamenya, ada pertanyaan ga?"
    );

    public static readonly LocalizationString VW_ONLOAD_27 = new LocalizationString(
        "Nothing?",
        "Ga ada?"
    );

    public static readonly LocalizationString VW_ONLOAD_28 = new LocalizationString(
        "Welp, I actually don't give you any choice to ask a question, NYEHEHEHEHE",
        "Welp, bukannya ga ada sih, gua emang ga ngasih pilihan buat pertanyaan, NYEHEHEHEHE."
    );

    public static readonly LocalizationString VW_ONLOAD_28_1 = new LocalizationString(
        "(Annoyed)",
        "(Annoyed)"
    );

    public static readonly LocalizationString VW_ONLOAD_28_2 = new LocalizationString(
        "(Smirk)",
        "(Smirk)"
    );

    public static readonly LocalizationString VW_ONLOAD_28_3 = new LocalizationString(
        "(Surprised)",
        "(Surprised)"
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
        "Okay, the teleportation is ready!",
        "Sip, teleportase udah siap!"
    );

    public static readonly LocalizationString VW_ONLOAD_31 = new LocalizationString(
        "You will be teleported in ...",
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
        "Nothing happened...",
        "Ga terjadi apa-apa..."
    );

    public static readonly LocalizationString HW_WIN_3 = new LocalizationString(
        "!",
        "!"
    );

    #region 3DSR
    public static readonly LocalizationString HW_3DSR_0 = new LocalizationString(
        "Note from The Developer :",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_3DSR_1 = new LocalizationString(
        "Let me introduce you, this is one of the NPCs from the 3D Sphere Robot class, the 3D Headphone Sphere Robot.",
        "Kenalkan, ini adalah salah satu sub-class NPC dari kelas 3D Sphere Robot, 3D Headphone Sphere Robot."
    );

    public static readonly LocalizationString HW_3DSR_2 = new LocalizationString(
        "They are one of the dominant classes at Havvatopia.",
        "Mereka adalah salah satu kelas dominan dari penduduk Kota Havvatopia."
    );

    public static readonly LocalizationString HW_3DSR_3 = new LocalizationString(
        "But right now they got possessed, so they are the antagonist of this game.",
        "Namun saat ini mereka seperti kerasukan gitu, sehingga menempatkan mereka menjadi antagonis dari game ini."
    );

    public static readonly LocalizationString HW_3DSR_4 = new LocalizationString(
        "You shouldn't and couldn't kill them, and also you can be detected by them.",
        "Lu ga boleh dan ga bisa bunuh mereka, serta lu ga boleh ketauan oleh mereka."
    );

    public static readonly LocalizationString HW_3DSR_5 = new LocalizationString(
        "If you got detected by them, you have to do time leap.",
        "Kalo lu ketauan oleh mereka, lu harus time leap."
    );

    public static readonly LocalizationString HW_3DSR_6 = new LocalizationString(
        "Witht that, you will be teleported to the last checkpoint",
        "Ntar lu balik ke checkpoint terakhir."
    );
    #endregion

    #region HAVVA
    public static readonly LocalizationString HW_HAVVA_0 = new LocalizationString(
        "Note from The Developer :",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_HAVVA_1 = new LocalizationString(
        "This is Havvatopia City.",
        "Ini adalah Kota Havvatopia."
    );

    public static readonly LocalizationString HW_HAVVA_2 = new LocalizationString(
        "Just like any other city in this universe, This city is located inside 3D Titan Sphere Robot that's already dead.",
        "Sama seperti Kota lainnya di universe ini, Kota ini terletak didalam 3D Titan Sphere Robot yang sudah mati."
    );

    public static readonly LocalizationString HW_HAVVA_3 = new LocalizationString(
        "This city is lead by Havva, she is the one who summon you.",
        "Kota ini dipimpin oleh Havva, dia yang memanggil lu kesana."
    );

    public static readonly LocalizationString HW_HAVVA_4 = new LocalizationString(
        "She summon you because right now Havvatopia is on emergency.",
        "Dia memanggil lu karena saat ini Kota Havvatopia sedang dalam keadaan darurat."
    );

    public static readonly LocalizationString HW_HAVVA_5 = new LocalizationString(
        "Every Havvatopia citizen is trapped in this city.",
        "Semua penduduk Havvatopia saat ini terjebak di kota ini."
    );

    public static readonly LocalizationString HW_HAVVA_6 = new LocalizationString(
        "Your mission is meet Havva and investigate what happened at Havvatopia and also save Havvatopia citizen that trapped over there.",
        "Nah, tugas lu yaitu ketemu dengan Havva dan investigasi apa yang terjadi di Havvatopia serta selamatkan penduduk Havvatopia yang saat ini sedang terjebak disana."
    );
    #endregion

    #region 3DH
    public static readonly LocalizationString HW_3DH_0 = new LocalizationString(
        "Note from The Developer :",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_3DH_1 = new LocalizationString(
        "This is you, Agent Violet.",
        "Ini lu, Agent Violet."
    );

    public static readonly LocalizationString HW_3DH_2 = new LocalizationString(
        "You come from 3D Humanoid class.",
        "Lu berasal dari kelas 3D Humanoid."
    );

    public static readonly LocalizationString HW_3DH_3 = new LocalizationString(
        "You are the best spy in this game.",
        "Lu adalah spy terbaik di game ini."
    );

    public static readonly LocalizationString HW_3DH_4 = new LocalizationString(
        "Maybe because you're the only spy in this game.",
        "Mungkin karena lu satu-satunya spy di game ini."
    );

    public static readonly LocalizationString HW_3DH_5 = new LocalizationString(
        "NYEHEHEHEHE.",
        "NYEHEHEHEHE."
    );

    public static readonly LocalizationString HW_3DH_6 = new LocalizationString(
        "Oh and also, because lot of tester didn't realize this, I want to tell you something.",
        "Oh iya, karena banyak tester yang ga nyadar ini, jadi ada yang pengen gua kasih tau nih."
    );

    public static readonly LocalizationString HW_3DH_7 = new LocalizationString(
        "This game is synchronous, do you know synchronous?",
        "Game ini adalah game synchronous, apa itu synchronous?"
    );

    public static readonly LocalizationString HW_3DH_8 = new LocalizationString(
        "It means that the time only move if you move.",
        "Ini game waktunya cuma jalan kalau lu jalan."
    );

    public static readonly LocalizationString HW_3DH_9 = new LocalizationString(
        "So plan carefully before you move.",
        "Jadi, lu bisa pikirkan baik-baik sebelum lu jalan."
    );
    #endregion

    #region 2DH
    public static readonly LocalizationString HW_2DH_0 = new LocalizationString(
        "Note from The Developer :",
        "Pesan dari The Developer :"
    );

    public static readonly LocalizationString HW_2DH_1 = new LocalizationString(
        "Nope, this isn't my laptop.",
        "Enggak, ini bukan laptop gua."
    );

    public static readonly LocalizationString HW_2DH_2 = new LocalizationString(
        "This is interface for any 2D class NPC, which is also Havvatopia's citizen.",
        "Ini adalah interface berbentuk monitor dari NPC kelas 2D, salah satu penduduk Kota Havvatopia."
    );

    public static readonly LocalizationString HW_2DH_3 = new LocalizationString(
        "There are some sub-class derived from 2D class, such as 2D Humanoid and 2D 1 Bit.",
        "Ada beberapa sub-class dari kelas 2D, seperti 2D Humanoid dan 2D 1 Bit."
    );

    public static readonly LocalizationString HW_2DH_4 = new LocalizationString(
        "All of them need interface because they all live in other dimension.",
        "Mereka semua butuh interface karena mereka semua hidup di dimensi yang berbeda."
    );

    public static readonly LocalizationString HW_2DH_5 = new LocalizationString(
        "To move from an interface to other, they use internet.",
        "Untuk pindah dari interface ke interface lain, mereka menggunakan internet."
    );

    public static readonly LocalizationString HW_2DH_6 = new LocalizationString(
        "If there is a power outtage or no internet, they will trapped in that interface until they turned to static object.",
        "Jika listrik mati atau internet mati, mereka akan terperangkap di interface tersebut sampai mereka berubah menjadi objek statis."
    );
    #endregion

    #endregion

    #region Level 1
    public static readonly LocalizationString L1_ONLOAD_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_SIGNPOST_0 = new LocalizationString(
        "Right now Havvatopia is in emergency mode.",
        "Havvatopia saat ini sedang keadaan darurat."
    );

    public static readonly LocalizationString L1_SIGNPOST_1 = new LocalizationString(
        "Because of that, the emergency stair will be closed for a while.",
        "Oleh karena itu, tangga darurat saat ini ditutup sementara."
    );

    public static readonly LocalizationString L1_SIGNPOST_2 = new LocalizationString(
        "Please use elevator instead...",
        "Silahkan gunakan elevator saja..."
    );

    #region Level 1_1
    public static readonly LocalizationString L1_1_NOSWITCH_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_1_NOSWITCH_1 = new LocalizationString(
        "Maybe you can find the resident if you follow this line!",
        "Mungkin bisa ketemu penghuninya kalau ikuti garis ini!"
    );

    public static readonly LocalizationString L1_1_OPENDOOR_0 = new LocalizationString(
        "... zzz...",
        "... zzz..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_1 = new LocalizationString(
        "... Welcome to... Havvatopia...",
        "... Selamat datang di... Havvatopia..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_2 = new LocalizationString(
        "... It's 2AM now and Havvatopia is having power outage and no internet...",
        "... Sekarang jam 2 pagi dan saat ini di Havvatopia sedang tidak ada internet dan mati lampu..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_3 = new LocalizationString(
        "... They said Havvatopia is in emergency mode... but... I just want to sleep... zzz...",
        "... Katanya sih Havvatopia lagi keadaan darurat... tapi... aku cuma mau tidur... zzz..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4 = new LocalizationString(
        "... zzz... Is there... anything that I can help...",
        "... zzz... Adakah... yang bisa dibantu..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_1 = new LocalizationString(
        "Where is Havva right now?",
        "Havva sedang dimana ya?"
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_1_0 = new LocalizationString(
        "... zzz...",
        "... zzz..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_1_1 = new LocalizationString(
        "... Before power outage, Havva is at The Observatory, it's located in top floor...",
        "... Sebelum mati lampu Havva berada di Observatory, lantai paling atas..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_1_2 = new LocalizationString(
        "... Please use Elefataa to go to there...",
        "... Silahkan pergi bersama Elefataa ke sana..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_1_3 = new LocalizationString(
        "... Elefataa... is always in the center of any floor...",
        "... Elefataa... selalu ada di tengah lantai kok..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_2 = new LocalizationString(
        "Can I pass?",
        "Boleh lewat ga?"
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_2_0 = new LocalizationString(
        "... Oh sure... go ahead...",
        "... Oiya ini... silahkan lewat..."
    );

    public static readonly LocalizationString L1_1_OPENDOOR_4_3 = new LocalizationString(
        "Nevermind.",
        "Enggak jadi."
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_0 = new LocalizationString(
        "Aaaaaaa, why the electricity and the internet is still not working!!!!",
        "Huaaaaaa, ini kenapa listrik sama internet-nya masih ga nyala-nyala!!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_1 = new LocalizationString(
        "It's been like this since yesterday!!!",
        "Udah dari kemarin siang mati lampu nih!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_2 = new LocalizationString(
        "I just want to Havva playing piano!!!",
        "Padahal gua mau dengerin Havva main piano!!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_3 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_4 = new LocalizationString(
        "Huh?",
        "Hah?"
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_5 = new LocalizationString(
        "Whaaaaat?",
        "Apaaaaa?"
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_6 = new LocalizationString(
        "You want ME to open the door over there?",
        "Lu mau gua buka pintu sebelah sana?"
    );

    public static readonly LocalizationString L1_1_OPENDOORTIMING_7 = new LocalizationString(
        "Okay, but please run to it, because the door will be closed automatically.",
        "Tapi lari ya, pintunya bakalan ketutup automatis."
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_0 = new LocalizationString(
        "STOPPPPPP!!",
        "STOPPPPPP!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_1 = new LocalizationString(
        "I'M GUARDING THIS DOOR AND YOU CAN'T PASS HERE!!",
        "SAYA PENJAGA PINTU INI DAN ANDA TIDAK BOLEH LEWAT SINI!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2 = new LocalizationString(
        "UNLESS YOU HAVE THE PASSWORD!!!!!!!!!",
        "KECUALI ANDA MEMPUNYAI PASSWORD!!!!!!!!!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_1_T0 = new LocalizationString(
        "The password is correct, yeaaay!",
        "Passwordnya benar, yeaaay!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_1_F0 = new LocalizationString(
        "WRONG PASSWORD!!!!",
        "PASSWORDNYA SALAH!!!!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_1_F1 = new LocalizationString(
        "But I'm feeling kind today, I will not report this attempt!",
        "Tapi karena saya baik, saya ga akan laporin kok!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_1_F2 = new LocalizationString(
        "Please try again and remember the password!",
        "Silahkan cari lagi dan ingat ulang passwordnya ya!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_2 = new LocalizationString(
        "Why do you need a password?",
        "Kenapa butuh password?"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_2_0 = new LocalizationString(
        "Hmm... yeah, I wonder why...",
        "Hmm... iya yah, kenapa ya..."
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_2_1 = new LocalizationString(
        "The one who set the password is not even Havva...",
        "Yang setel passwordnya juga bukan Havva..."
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_2_2 = new LocalizationString(
        "BUT JOB IS JOB!",
        "TAPI PEKERJAAN TETAPLAH PEKERJAAN!"
    );

    public static readonly LocalizationString L1_1_OPENDOORPASS_2_2_3 = new LocalizationString(
        "I HAVE TO LOYAL TO WHOEVER GAVE ME THIS JOB!",
        "SAYA HARUS LOYAL KE SIAPAPUN YANG MEMBERIKAN PEKERJAAN INI!"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_0 = new LocalizationString(
        "You accidentally overheard (or maybe in purpose?) listened to what they're talking about.",
        "Kamu secara ga sengaja (apa sengaja ya?) dengerin apa yang mereka bicarakan."
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_1 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_2 = new LocalizationString(
        "HEY! HAVE YOU SET THE PASSWORD FOR DOOR OVER THERE?",
        "COY! LU UDAH SETEL PASSWORD DI PINTU SANA BELOM?"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_3 = new LocalizationString(
        "HUH??! I CAN'T HEAR YOU!!!!",
        "HAH??! APAAN GA KEDENGERAN!!!"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_4 = new LocalizationString(
        "HUH??? WHAT DID YOU SAID?? HAVE YOU SET THE PASSWORD???",
        "HAH?? LU NGOMONG APAAN BARUSAN? PASSWORDNYA UDAH DI SETEL APA BELOM??"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_5 = new LocalizationString(
        "WHAAAAT????! THE PASSWORD IS 1 2 3!!!",
        "APAAN???!!! PASSWORDNYA 1 2 3!!!"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_6 = new LocalizationString(
        "YOU SET 3 PASSWORD ON THE DOOR????",
        "LU SETEL 3 PASSWORD DI PINTUNYA?????"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_7 = new LocalizationString(
        "SAY LOUDER!!! I CAN'T HEAR YOU!!!!",
        "NGOMONG YANG KERAS!!! GA KEDENGERAN COY!!!"
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_8 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_1_PASSTRIGGER_9 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_1_DIARY_0 = new LocalizationString(
        "Yohohoo, this is my diary.",
        "Yohohoo, ini diary gua."
    );

    public static readonly LocalizationString L1_1_DIARY_1 = new LocalizationString(
        "I suggest you to collect all the diaries while you playing this game.",
        "Gua saranin lu kumpulin diary gua selama main game."
    );

    public static readonly LocalizationString L1_1_DIARY_2 = new LocalizationString(
        "I'll give you a reward if you collect everything.",
        "Ntar bakalan gua kasih reward lho kalau kekumpul semuanya."
    );

    public static readonly LocalizationString L1_1_DIARY_3 = new LocalizationString(
        "NYEHEHEHEHEHE",
        "NYEHEHEHEHEHE"
    );

    public static readonly LocalizationString L1_1_DIARY_4 = new LocalizationString(
        "Adios!",
        "Adios!"
    );

    public static readonly LocalizationString L1_1_DIARY_5 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_2
    public static readonly LocalizationString L1_2_CLOSEDOOR_0 = new LocalizationString(
        "Do you want me to close the door so they can't see you?",
        "Lu mau gua tutup pintunya biar mereka ga bisa liat lu?"
    );

    public static readonly LocalizationString L1_2_CLOSEDOOR_0_1 = new LocalizationString(
        "Sure.",
        "Boleh."
    );

    public static readonly LocalizationString L1_2_CLOSEDOOR_0_1_0 = new LocalizationString(
        "Welp, thank goodness they're all stoopid, they will not realize it lol.",
        "Untungnya mereka bego, jadi mereka ga bakalan nyadar wkwk."
    );

    public static readonly LocalizationString L1_2_CLOSEDOOR_0_2 = new LocalizationString(
        "Nah.",
        "Gausah deh."
    );

    public static readonly LocalizationString L1_2_DIARY_0 = new LocalizationString(
        "Do you know why you can't subdue any 3D Sphere Robot?",
        "Tau ga kenapa lu ga bisa bunuh 3D Sphere Robot manapun?"
    );

    public static readonly LocalizationString L1_2_DIARY_1 = new LocalizationString(
        "Because I haven't implemented that mechanic.",
        "Karena gua memang belum sempet implementasiin mekanik tersebut."
    );

    public static readonly LocalizationString L1_2_DIARY_2 = new LocalizationString(
        "NYEHEHEHEHE",
        "NYEHEHEHEHE"
    );

    public static readonly LocalizationString L1_2_DIARY_3 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_3
    public static readonly LocalizationString L1_3_DIARY_0 = new LocalizationString(
        "Do you know why all 3D Headphone Sphere Robot use noise cancelling headphone?",
        "Tau ga kenapa semua 3D Headphone Sphere Robot pakai headphone noise cancelling?"
    );

    public static readonly LocalizationString L1_3_DIARY_1 = new LocalizationString(
        "Because I'm too lazy to implemented listening mechanic for NPC.",
        "Karena gua males implementasi listening mechanic buat NPC."
    );

    public static readonly LocalizationString L1_3_DIARY_2 = new LocalizationString(
        "NYEHEHEHEHE",
        "NYEHEHEHEHE"
    );

    public static readonly LocalizationString L1_3_DIARY_3 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_4
    public static readonly LocalizationString L1_4_DIARY_0 = new LocalizationString(
        "Do you know why at start I said I suck at grammar?",
        "Tau ga kenapa gua bilang bahasanya ga sesuai KBBI"
    );

    public static readonly LocalizationString L1_4_DIARY_1 = new LocalizationString(
        "Because... I don't have money to hire localisator",
        "Karena... gua ga ada duit nyewa penerjemah"
    ); 

    public static readonly LocalizationString L1_4_DIARY_2 = new LocalizationString(
        "NYEHEHEHEHE",
        "NYEHEHEHEHE"
    );

    public static readonly LocalizationString L1_4_DIARY_3 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_5
    public static readonly LocalizationString L1_5_DIARY_0 = new LocalizationString(
        "Do you know why you're the best spy in this world?",
        "Tau ga kenapa lu spy terbaik di dunia ini?"
    );

    public static readonly LocalizationString L1_5_DIARY_1 = new LocalizationString(
        "Because you're the only spy in this game.",
        "Karena lu satu satunya spy di game ini."
    );

    public static readonly LocalizationString L1_5_DIARY_2 = new LocalizationString(
        "NYEHEHEHEHE",
        "NYEHEHEHEHE"
    );

    public static readonly LocalizationString L1_5_DIARY_3 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_6
    public static readonly LocalizationString L1_6_TRAPPED_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_6_TRAPPED_1 = new LocalizationString(
        "HAHAHAHAHAHA!",
        "HAHAHAHAHAHA!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_2 = new LocalizationString(
        "WELCOME TO FIRE TRAP THAT I MADE!",
        "SELAMAT DATANG DI PERANGKAP API YANG SAYA BUAT!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_3 = new LocalizationString(
        "TO ESCAPE FROM THIS TRAP, YOU HAVE TO SOLVE PUZZLE LABYRINTH IN THIS ROOM!",
        "UNTUK KABUR DARI PERANGKAP INI, ANDA HARUS MEMECAHKAN TEKA-TEKI LABIRIN DI RUANGAN INI!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_4 = new LocalizationString(
        "IF YOU MANAGED TO ESCAPE FROM THIS TRAP, I WILL GIVE YOU A REWARD!",
        "JIKA ANDA BERHASIL KABUR DARI PERANGKAP INI, ANDA AKAN SAYA BERI HADIAH!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_5 = new LocalizationString(
        "FOR SOME REASON THE REWARD IS PASSWORD TO THE OBSERVATORY!",
        "ENTAH KENAPA HADIAHNYA YAITU BERUPA PASSWORD UNTUK KE OBSERVATORY!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_6 = new LocalizationString(
        "BUT IF YOU FAILED, YOU WILL BURN ALIVE HERE!",
        "NAMUN JIKA ANDA GAGAL, ANDA AKAN TERBAKAR DISINI!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_7 = new LocalizationString(
        "HAHAHAHAHAHA, GOOD LUCK!",
        "HAHAHAHAHAHA, SELAMAT MENCOBA!"
    );

    public static readonly LocalizationString L1_6_TRAPPED_8 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_6_TRAPPED_9 = new LocalizationString(
        "Tbh the fire has no heat... ",
        "Apinya ga ada panas-panasnya..."
    );

    public static readonly LocalizationString L1_6_TRAPPED_10 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_0 = new LocalizationString(
        "CONGRATULATIONS, YOU FINALLY DEFEAT THIS CHALLENGE!",
        "SELAMAT, ANDA BERHASIL MELEWATI RINTANGAN INI!"
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_1 = new LocalizationString(
        "AS PROMISED, I WILL GIVE YOU PASSWORD TO THE OBSERVATORY!",
        "SESUAI JANJI, SAYA AKAN MEMBERIKAN PASSWORD UNTUK KE OBSERVATORY!"
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_2 = new LocalizationString(
        "THE PASSWORD IS 3 3 3!",
        "PASSWORDNYA ADALAH 3 3 3!"
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_3 = new LocalizationString(
        "AND ALSO, WRITE \"I'M NOT A SPY\" FOR THE CAPTCHA SO YOU WILL BE ALLOWED TO PASS BY ELEFATAA!",
        "SERTA, ISI \"SAYA BUKAN SPY\" UNTUK CAPTCHANYA AGAR DIIZINKAN LEWAT OLEH ELEFATAA!"
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_4 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_5 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_6 = new LocalizationString(
        "But, it's weird.",
        "Tapi aneh dah."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_7 = new LocalizationString(
        "Spy is only a myth, why do you bother to use captcha.",
        "Spy kan cuma mitos, kenapa repot-repot pakai captcha ya."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_8 = new LocalizationString(
        "The one who set the password is also weird, they like possesed.",
        "Yang nitip password disini juga aneh banget, dia kayak kesurupan gitu."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_9 = new LocalizationString(
        "I want to ask why, but unfortunately the one who set it was 3D Headphone Sphere Robot, it's hard to talk anyone from that class",
        "Tadinya mau Saya tanya kenapa, tapi sayangnya dia 3D Headphone Sphere Robot, ga bisa diajak ngobrol kan tuh kelas."
    );

    public static readonly LocalizationString L1_6_TRAPPEDWIN_10 = new LocalizationString(
        "So yeah, I just do my job as best I can.",
        "Jadi ya yaudahlah, saya hanya melakukan kerjaan saya sebaik mungkin."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_0 = new LocalizationString(
        "I WILL PROTECT ELEFATAA AT ALL COST!",
        "SAYA AKAN MELINDUNGI ELEFATAA DENGAN SEGALA HAL!!!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1 = new LocalizationString(
        "YOU WILL NEVER FIND THE PASSWORD AND YOU WILL NEVER PASS ME!",
        "ANDA TIDAK AKAN PERNAH MENEMUKAN PASSWORDNYA DAN ANDA TIDAK AKAN PERNAH MELEWATI JALAN INI!!!!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_T0 = new LocalizationString(
        "Oh, it's actually fine.",
        "Oh, ternyata tidak apa-apa."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_T1 = new LocalizationString(
        "You have proven you're not dangerous",
        "Anda terbukti bukan bahaya kok."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_T2 = new LocalizationString(
        "Go ahead!",
        "Silahkan lewat!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_T3 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_T4 = new LocalizationString(
        "Oh and also, the one who set this password relay me a message to anyone who know the password.",
        "Oiya, yang setel password ini nitip pesan ke saya untuk siapapun yang berhasil lewat sini."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_T5 = new LocalizationString(
        "Do not go to the Observatory, because that's the place where Havva is being held.",
        "Jangan ke lantai Observatory ya, karena itu tempat Havva ditawan."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS2_1_1_F0 = new LocalizationString(
        "NO ONE CAN PASS HERE!!!",
        "TIDAK AKAN ADA YANG BISA MELEWATI SAYA!!!!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_0 = new LocalizationString(
        "Do not go here, this way is only for Hardcore Gammerzzzzzz.",
        "Jangan lewat sini, karena ini jalan hanya untuk Hardcore Gamerzzzz."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_1 = new LocalizationString(
        "Please look other way, because this is shortcut to Havva.",
        "Silahkan cari jalan lain, karena jalan ini hanya shortcut ke Havva."
    );
    
    public static readonly LocalizationString L1_6_OPENDOORPASS3_2 = new LocalizationString(
        "And you only can find the password on the internet.",
        "Dan Anda hanya bisa menemukan passwordnya di internet."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_2_1_T0 = new LocalizationString(
        "GGWP Gamers!",
        "GGWP Gamers!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_2_1_T1 = new LocalizationString(
        "But, this is not over yet!",
        "Namun, ini belum selesai!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_2_1_T2 = new LocalizationString(
        "I hope you can get through next challenge!",
        "Semoga saja Anda bisa melewati challenge selanjutnya!"
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_2_1_F0 = new LocalizationString(
        "See, no way you can pass here.",
        "Tuhkan, tidak mungkin lewat sini."
    );

    public static readonly LocalizationString L1_6_OPENDOORPASS3_2_1_F1 = new LocalizationString(
        "Please use other way",
        "Silahkan cari jalan lain."
    );

    public static readonly LocalizationString L1_6_ELEVATOREVENT_0 = new LocalizationString(
        "Hello! Welcome to Uptown Havvatopia!",
        "Halo! Selamat datang di Havvatopia bagian Uptown!"
    );

    public static readonly LocalizationString L1_6_ELEVATOREVENT_1 = new LocalizationString(
        "Where do you want to ride me?",
        "Mau naikki aku ke mana?"
    );

    public static readonly LocalizationString L1_6_DIARY_0 = new LocalizationString(
        "You're in a shortcut just for hardcore gamerzzz, I congratulate you for getting here.",
        "Lu lagi berada di shortcut khusus untuk gamerz yang hardcore, gua ucapkan selamat bisa sampai disini."
    );

    public static readonly LocalizationString L1_6_DIARY_1 = new LocalizationString(
        "You're correct; the robot need to be lured and then you slip away.",
        "Bener jawabannya; robotnya dipancing dulu baru nanti nyelip."
    );

    public static readonly LocalizationString L1_6_DIARY_2 = new LocalizationString(
        "I was considering using this mechanic at the start of the game, but it's actually too difficult lol",
        "Tadinya mau pake mekanik kayak gitu di awal game, tapi pada kesusahan wkwk."
    );

    public static readonly LocalizationString L1_6_DIARY_3 = new LocalizationString(
        "...",
        "..."
    );

    #endregion

    #region Level 1_7
    public static readonly LocalizationString L1_7_DIARY_0 = new LocalizationString(
        "I told you that 3D Humanoid is rare",
        "Gua sempet bilang kalau kelas 3D Humanoid karakternya sedikit."
    );

    public static readonly LocalizationString L1_7_DIARY_1 = new LocalizationString(
        "It's actually not rare, but you're the only one who from 3d Humanoid",
        "Sebenernya bukan sedikit sih, tapi lu satu-satunya karakter yang dari kelas 3D Humanoid."
    );

    public static readonly LocalizationString L1_7_DIARY_2 = new LocalizationString(
        "NYEHEHEHEHE",
        "NYEHEHEHEHE"
    );

    public static readonly LocalizationString L1_7_DIARY_3 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_8
    public static readonly LocalizationString L1_8_DIARY_0 = new LocalizationString(
        "Do you know why 3D Humanoid is rare?",
        "Tau ga kenapa kelas 3D Humanoid karakternya sedikit?"
    );

    public static readonly LocalizationString L1_8_DIARY_1 = new LocalizationString(
        "Because it's expensive to make",
        "Karena budget buat bikinnya mahal."
    );

    public static readonly LocalizationString L1_8_DIARY_2 = new LocalizationString(
        "Especially the animation, that's why there's lot of clipping.",
        "Apalagi animasinya, makanya banyak yang clipping."
    );

    public static readonly LocalizationString L1_8_DIARY_3 = new LocalizationString(
        "NYEHEHEHEHEHE",
        "NYEHEHEHEHEHE"
    );

    public static readonly LocalizationString L1_8_DIARY_4 = new LocalizationString(
        "Sigh...",
        "Sigh..."
    );

    public static readonly LocalizationString L1_8_DIARY_5 = new LocalizationString(
        "I wish I have more money...",
        "Seandainya gua punya duit lebih..."
    );

    public static readonly LocalizationString L1_8_DIARY_6 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 1_9
    public static readonly LocalizationString L1_9_PASSTRIGGER_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_1 = new LocalizationString(
        "\"What happened??!\"",
        "\"Apa yang terjadi??!\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_2 = new LocalizationString(
        "\"Duddee, You won't believe this!!\"",
        "\"Coy, lu ga bakal percaya ini coooy!\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_3 = new LocalizationString(
        "\"Havvatopia suddenly moving!!\"",
        "\"Havvatopia tiba-tiba bergerak!!\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_4 = new LocalizationString(
        "\"It's time to include this in the news.\"",
        "\"Saatnya masukin berita!!!\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_5 = new LocalizationString(
        "\"Honey ~ I'm scared ...\"",
        "\"Sayang ~ aku takut ...\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_6 = new LocalizationString(
        "\"Helo scared, my name is Honey.\"",
        "\"Halo Takut, namaku Sayang.\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_7 = new LocalizationString(
        "\"I can't move, what's wrong with the internet?\"",
        "\"Gua ga bisa pindah, internet-nya kenapa??\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_8 = new LocalizationString(
        "\"The internet is down! Someone please call the provider!\"",
        "\"Internet-nya mati coy! Hadeh gimana sih providernya.\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_9 = new LocalizationString(
        "\"BZZZZT... BZZZZT...\"",
        "\"BZZZZT... BZZZZT...\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_10 = new LocalizationString(
        "\"BZZZZT... BZZZZT...\"",
        "\"BZZZZT... BZZZZT...\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_11 = new LocalizationString(
        "\"What's wrong with those 3D Sphere Robot, so suspicious.\"",
        "\"Dih, itu 3D Sphere Robot pada kenapa dah, aneh banget.\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_12 = new LocalizationString(
        "\"They just like... possesed?\"",
        "\"Dia kayak... kerasukan?\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_13 = new LocalizationString(
        "\"BZZZZT... BZZZZT...\"",
        "\"BZZZZT... BZZZZT...\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_14 = new LocalizationString(
        "\"MUST. SET. PASSWORD. NEAR ELEFATAA.\"",
        "\"HARUS. SETEL. PASSWORD. DI DEKAT ELEFATAA.\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_15 = new LocalizationString(
        "\"THE PASSWORD IS 2 1 3...\"",
        "\"PASSWORDNYA 2 1 3...\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_16 = new LocalizationString(
        "\"BZZZZT... BZZZZT...\"",
        "\"BZZZZT... BZZZZT...\""
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_17 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_9_PASSTRIGGER_18 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L1_9_DIARY_0 = new LocalizationString(
        "You're in balcony.",
        "Lu lagi di balkon."
    );

    public static readonly LocalizationString L1_9_DIARY_1 = new LocalizationString(
        "And you can't open any windows.",
        "Dan lu ga bisa buka jendela."
    );

    public static readonly LocalizationString L1_9_DIARY_2 = new LocalizationString(
        "Because I'm too lazy to implement that mechanic.",
        "Karena emang gua males implementasiin mekanik kayak gitu."
    );

    public static readonly LocalizationString L1_9_DIARY_3 = new LocalizationString(
        "NYEHEHEHE.",
        "NYEHEHEHE."
    );

    public static readonly LocalizationString L1_9_DIARY_4 = new LocalizationString(
        "Welp, the story is those windows already turning into static object.",
        "Welp, ceritanya sih jendela tersebut udah jadi objek statis."
    );

    public static readonly LocalizationString L1_9_DIARY_5 = new LocalizationString(
        "This means that those windows were NPC before, but because they rarely got interacted they turned into static object now.",
        "Ini berarti tadinya jendela itu NPC, terus karena jarang di interact akhirnya mereka jadi objek statis."
    );

    public static readonly LocalizationString L1_9_DIARY_6 = new LocalizationString(
        "Booom, NPC lore drop.",
        "Beuh, NPC Lore."
    );

    public static readonly LocalizationString L1_9_DIARY_7 = new LocalizationString(
        "...",
        "..."
    );
    #endregion
    #endregion

    #region Level 2
    public static readonly LocalizationString L2_ELEVATOR_0 = new LocalizationString(
        "Hello! Welcome to Observatorium Havvatopia!",
        "Halo! Selamat datang di Havvatopia bagian Observatorium!"
    );

    public static readonly LocalizationString L2_ELEVATOR_1 = new LocalizationString(
        "Where do you want to ride me?",
        "Mau naikki aku ke mana?"
    );

    public static readonly LocalizationString L2_TALK_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_1 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_2 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_3 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_4 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_4_1 = new LocalizationString(
        "(Annoyed)",
        "(Annoyed)"
    );

    public static readonly LocalizationString L2_TALK_4_2 = new LocalizationString(
        "(Smirk)",
        "(Smirk)"
    );

    public static readonly LocalizationString L2_TALK_4_3 = new LocalizationString(
        "(Surprised)",
        "(Surprised)"
    );

    public static readonly LocalizationString L2_TALK_4_4 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_5 = new LocalizationString(
        "Test test...",
        "Test test..."
    );

    public static readonly LocalizationString L2_TALK_6 = new LocalizationString(
        "Hello hello.",
        "Halo halo."
    );

    public static readonly LocalizationString L2_TALK_7 = new LocalizationString(
        "Err... You got a message from The Developer :",
        "Err... Ini ada pesan dari The Developer :"
    );

    public static readonly LocalizationString L2_TALK_8 = new LocalizationString(
        "\"This message only appeared if there's an error in Havva's 2D Humanoid interface.\"",
        "\"Pesan ini muncul jika terjadi error di program interface 2D Humanoid-nya Havva.\""
    );

    public static readonly LocalizationString L2_TALK_9 = new LocalizationString(
        "\"Because Havva can't explain on what happened, the spy will be guided by this message.\"",
        "\"Karena Havva berhalangan untuk menjelaskan apa yang terjadi, maka spy akan dipandu oleh pesan ini.\""
    );

    public static readonly LocalizationString L2_TALK_10 = new LocalizationString(
        "\"Go ahead and open a file with name \"presentation for spy FINAL FIX PLEASE COME TO MEEEEE AAAAA.potx\".\"",
        "\"Silahkan buka file bernama \"presentasi untuk spy FINAL FIX TOLONG TOLONG BENERAN DATENG DONG.potx\".\""
    );

    public static readonly LocalizationString L2_TALK_11 = new LocalizationString(
        "\"If you want to restart the program for Havva's interface go ahead, but it probably will error again.\"",
        "\"Kalau mau mencoba jalankan ulang program interface 2D Humanoid silahkan saja, tapi palingan error lagi.\""
    );

    public static readonly LocalizationString L2_TALK_12 = new LocalizationString(
        "\"As long as you don't open the homework folder.\"",
        "\"Asalkan jangan buka folder homework.\""
    );

    public static readonly LocalizationString L2_TALK_13 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_13_1 = new LocalizationString(
        "Open file \"presentation for spy FINAL FIX PLEASE COME TO MEEEEE AAAAA.potx\"",
        "Buka file \"presentasi untuk spy FINAL FIX TOLONG BENERAN DATENG DONG.potx\""
    );

    public static readonly LocalizationString L2_TALK_13_1_0 = new LocalizationString(
        "Opening file \"presentation for spy FINAL FIX PLEASE COME TO MEEEEE AAAAA.potx\"...",
        "Membuka file \"presentasi untuk spy FINAL FIX TOLONG BENERAN DATENG DONG.potx\"..."
    );

    public static readonly LocalizationString L2_TALK_13_1_1 = new LocalizationString(
        "\"Let me introduce you, the one who got error was Havva, she is Havvatopia's mayor.\"",
        "\"Perkenalkan, yang barusan kena error adalah Havva, walikota dari Havvatopia.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_2 = new LocalizationString(
        "\"Havva didn't realize that the rumor by playing that song can actually summon a spy.\"",
        "\"Havva tidak mengira kalau rumor memainkan lagu yang dia mainkan barusan beneran bisa memanggil Spy.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_3 = new LocalizationString(
        "\"Her laptop is already in low battery and she will be turned into static object soon.\"",
        "\"Baterai laptopnya Havva sudah sekarat dan sebentar lagi Havva berubah jadi objek statis.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_4 = new LocalizationString(
        "\"Therefore, Havva was very grateful to Agent Violet for coming just in time.\"",
        "\"Oleh karena itu, Havva sangat berterima kasih kepada Agent Violet karena sudah datang tepat pada waktunya.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_5 = new LocalizationString(
        "\"Havva was playing piano and manage Havvatopia from the Observatory like always.\"",
        "\"Havva awalnya lagi bermain piano dan mengatur Havvatopia di observatory seperti biasa.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_6 = new LocalizationString(
        "\"Suddenly, 3D Titan Sphere Robot that is being lived by Havvatopia citizen for so long, is live again and moving.\"",
        "\"Tiba-tiba, 3D Titan Sphere Robot yang ditinggali oleh penduduk Havvatopia sejak lama ini, hidup lagi dan bergerak.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_7 = new LocalizationString(
        "\"And also, all of internet in Havvatopia is down and right now Havvatopia is using emergency power.\"",
        "\"Dan juga, seluruh internet di Havvatopia mati dan saat ini Havvatopia sedang menggunakan listrik darurat.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_8 = new LocalizationString(
        "\"She needs your help.\"",
        "\"Nah, Havva butuh bantuan Agent Violet nih.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_9 = new LocalizationString(
        "\"You need to investigate what happened at Havvatopia and find out where Havvatopia is going\"",
        "\"Bantuannya yaitu investigasi apa yang terjadi di Havvatopia dan cari tahu Havvatopia sedang bergerak menuju kearah mana.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_10 = new LocalizationString(
        "\"And also Havva need your help to turn on the power and internet at Havvatopia so she can control this 3D Titan Sphere.\"",
        "\"Lalu juga Havva membutuhkan bantuan Violet untuk menyalakan kembali listrik dan internet di Havvatopia agar bisa mengontrol kembali 3D Titan Sphere ini.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_11 = new LocalizationString(
        "\"This is a photo of Havvatopia's structure.\"",
        "\"Ini adalah foto kerangka Havvatopia.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_12 = new LocalizationString(
        "\"To turn on the power and internet at Havvatopia, you need to go to engine room.\"",
        "\"Untuk menyalakan listrik dan internet di Havvatopia, Agent Violet harus ke engine room.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_13 = new LocalizationString(
        "\"But, right now you can't access the engine room with Elefataa because there's damage between Downtown and Engine Room.\"",
        "\"Namun, saat ini Agent Violet tidak bisa mengakses ke engine room menggunakan Elefataa karena ada kerusakan antara Downtown dan Engine Room.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_14 = new LocalizationString(
        "\"So, you must go to Downtown with Elefataa, and then use Elefatwo or Elefatri to the underground.\"",
        "\"Sehingga, Agent Violet harus turun ke Downtown menggunakan Elefataa, kemudian pindah menggunakan Elefatwo atau Elefatri ke Underground.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_15 = new LocalizationString(
        "\"I hope one of them is still working.\"",
        "\"Semoga saja salah satu dari mereka layanannya masih jalan.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_16 = new LocalizationString(
        "\"From the underground, you can get to engine room using Elefataa's emergency stairs.\"",
        "\"Dari Underground, Agent Violet bisa ke engine room menggunakan tangga darurat Elefataa.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_17 = new LocalizationString(
        "\"There are 1000 step in that stairs, she hope that you don't get tired.\"",
        "\"Ada 1000 anak tangga di tangga darurat tersebut, Havva berharap semoga Agent Violet tidak capek.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_18 = new LocalizationString(
        "\"That's all her presentation.\"",
        "\"Sekian presentasinya Havva.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_19 = new LocalizationString(
        "\"To go to the Downtown, the password is already written here.\"",
        "\"Untuk pergi ke Downtown, passwordnya sudah tertera disini.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_20 = new LocalizationString(
        "\"Once again, she really said thank you because you already come here.\"",
        "\"Sekali lagi, Havva berterima kasih karena Agent Violet sudah datang.\""
    );

    public static readonly LocalizationString L2_TALK_13_1_21 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_13_2 = new LocalizationString(
        "Restart the program for 2D Humanoid interface",
        "Jalankan ulang program interface 2D Humanoid"
    );

    public static readonly LocalizationString L2_TALK_13_2_0 = new LocalizationString(
        "Booting program for 2D Humanoid interface...",
        "Menjalankan program interface 2D Humanoid..."
    );

    public static readonly LocalizationString L2_TALK_13_2_1 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_13_3 = new LocalizationString(
        "Open folder 120GB of \"Homework\"",
        "Buka folder \"Homework\" berukuran 120Gb"
    );

    public static readonly LocalizationString L2_TALK_13_3_0 = new LocalizationString(
        "Opening \"Homework\" folder...",
        "Membuka folder \"Homework\"..."
    );

    public static readonly LocalizationString L2_TALK_13_3_1 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L2_TALK_13_3_1_1 = new LocalizationString(
        "(Annoyed)",
        "(Annoyed)"
    );

    public static readonly LocalizationString L2_TALK_13_3_1_2 = new LocalizationString(
        "(Smirk)",
        "(Smirk)"
    );

    public static readonly LocalizationString L2_TALK_13_3_1_3 = new LocalizationString(
        "(Surprised)",
        "(Surprised)"
    );

    public static readonly LocalizationString L2_TALK_13_3_1_4 = new LocalizationString(
        "...",
        "..."
    );
    #endregion

    #region Level 3
    public static readonly LocalizationString L3_ONLOAD_0 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L3_ONLOAD_1 = new LocalizationString(
        "NYEHEHEHEHE.",
        "NYEHEHEHEHE."
    );

    public static readonly LocalizationString L3_ONLOAD_2 = new LocalizationString(
        "THIS LEVEL HAS NOT FINISHED YET!!!",
        "LEVELNYA BELUM SELESAI DIBUAT!!!"
    );

    public static readonly LocalizationString L3_ONLOAD_3 = new LocalizationString(
        "...",
        "..."
    );

    public static readonly LocalizationString L3_ONLOAD_4 = new LocalizationString(
        "I'm going to kidnap you for a while.",
        "Bentar, lu gua culik dulu."
    );
    #endregion
}
