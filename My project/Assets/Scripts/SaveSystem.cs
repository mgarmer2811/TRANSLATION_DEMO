using System.IO;
using UnityEngine;

public class GameData
{
    public string language = "english";
}

public class SaveSystem : MonoBehaviour
{
    public static void SaveGameData(GameData gd)
    {
        string path = Path.Combine(Application.persistentDataPath + "/Assets/Resources/Save System");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string filePath = Path.Combine(path, "GameData.json");
        string json = JsonUtility.ToJson(gd);

        File.WriteAllText(filePath, json);
    }

    public static GameData LoadGameData()
    {
        string path = Path.Combine(Application.persistentDataPath + "/Assets/Resources/Save System");
        string filePath = Path.Combine(path, "GameData.json");

        if(!Directory.Exists(path))
        {
            GameData newGd = new GameData();
            SaveGameData(newGd);
        }

        string json = File.ReadAllText(filePath);
        GameData gd = JsonUtility.FromJson<GameData>(json);
        return gd;
    }
}