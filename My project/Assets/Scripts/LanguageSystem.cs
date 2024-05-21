using System.IO;
using UnityEngine;

public class LanguageSystem : MonoBehaviour
{
    public static string GetTranslations()
    {
        GameData gd = SaveSystem.LoadGameData();
        return GetTranslationsJson(gd.language);
    }

    private static string GetTranslationsJson(string language)
    {
        string translations = "";

        switch (language)
        {
            case "spanish":
                translations = GetSpanish();
                break;
            case "english":
                translations = GetEnglish();
                break;
        }

        return translations;
    }

    private static string GetSpanish()
    {
        string filePath = "Assets/Translations/spanish.json";
        string jsonText = File.ReadAllText(filePath);
        return jsonText;
    }

    private static string GetEnglish()
    {
        string filePath = "Assets/Translations/english.json";
        string jsonText = File.ReadAllText(filePath);
        return jsonText;
    }
}