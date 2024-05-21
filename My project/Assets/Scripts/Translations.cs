using TMPro;
using UnityEngine;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class Translations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        Translate();
    }

    private void Translate()
    {
        string languageData = LanguageSystem.GetTranslations();
        TranslateElements(languageData);
    }

    private void TranslateElements(string languageData)
    {
        JObject jsonTranslations = JObject.Parse(languageData);
        JObject translations = (JObject) jsonTranslations["app"];

        text.text = translations["title"].ToString();
    }

    public void SetLanguage(string language)
    {
        GameData gd = SaveSystem.LoadGameData();
        gd.language = language;

        SaveSystem.SaveGameData(gd);
        Translate();
    }
}