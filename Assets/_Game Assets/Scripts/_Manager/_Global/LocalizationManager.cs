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
    public static string Translate(LocalizationString localizationString)
    {
        int languageId = PlayerPrefs.GetInt(ProfileManager.PLAYERPREFS_LANGUAGEID, 1);
        return localizationString.translatedStrings[languageId];
    }

    #region Tutorial
    public static readonly LocalizationString TUTORIAL_MOVE = new LocalizationString("Press to move", "Tekan untuk bergerak");
    public static readonly LocalizationString TUTORIAL_INTERACT = new LocalizationString("Hit any object to interact", "Tabrak objek apapun untuk berinteraksi");
    public static readonly LocalizationString TUTORIAL_RUN = new LocalizationString("Hold + move to run", "Tahan + gerak untuk lari");
    public static readonly LocalizationString TUTORIAL_SKIP = new LocalizationString("Rapidly tap to skip turn", "Tekan berkali-kali untuk lewati giliran");
    public static readonly LocalizationString TUTORIAL_NEXT = new LocalizationString("Next", "Lanjut");
    public static readonly LocalizationString TUTORIAL_SELECT = new LocalizationString("Select", "Pilih");
    public static readonly LocalizationString TUTORIAL_CHECKPOINT = new LocalizationString("Checkpoint!", "Checkpoint!");
    public static readonly LocalizationString TUTORIAL_HUBWORLD = new LocalizationString("Hub World", "Hub World");
    public static readonly LocalizationString TUTORIAL_HAVVASKINGDOM_NOBLEAREA = new LocalizationString("Havva's Kingdom Noble Area", "Area Bangsawan Kerajaan Havva");
    public static readonly LocalizationString TUTORIAL_HAVVASKINGDOM_OBSERVATORY = new LocalizationString("Havva's Kingdom Observatory", "Observatorium Kerajaan Havva");
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

    public static readonly LocalizationString CHARACTER_CRACKOFTIME = new LocalizationString(
        "Crack of Time",
        "Pecahan Waktu"
    );

    public static readonly LocalizationString CHARACTER_RGBGAMINGDOOR = new LocalizationString(
        "(2D 1 Bit) RGB Gaming Door",
        "(2D 1 Bit) Pintu Gaming RGB"
    );

    public static readonly LocalizationString CHARACTER_ELEFATAA = new LocalizationString(
        "(2D 1 Bit) Elefataa",
        "(2D 1 Bit) Elefataa"
    );

    public static readonly LocalizationString CHARACTER_2D1BIT_PASSWORDPROTECTOR = new LocalizationString(
        "(2D 1 Bit) Password Protector",
        "(2D 1 Bit) Penjaga Password"
    );

    #endregion

    #region Generic Dialogues
    public static readonly LocalizationString[] PAUSE_CHOICES = new LocalizationString[3]
    {
        new LocalizationString("... (Resume)", "... (Lanjutkan main)"),
        new LocalizationString("I want to time leap! (Restart from last checkpoint)", "Mau time leap! (Ulang dari checkpoint terakhir)"),
        new LocalizationString("I don't want to work anymore. (Quit)", "Udahan kerjanya ah. (Keluar dari game)"),
    };

    public static readonly LocalizationString[] CAPTURED_CHOICES = new LocalizationString[2]
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
    #endregion

    #region Void World Dialogues

    #region End Game

    #endregion

    #region Load Game

    #endregion

    #region Start Game

    #endregion
    #endregion

    #region Hub World


    #region 3DSR

    #endregion

    #region BD

    #endregion

    #region 3DH

    #endregion

    #region 2DH

    #endregion

    #endregion

    #region Level 1

    #endregion

    #region Level 2

    #endregion

}
