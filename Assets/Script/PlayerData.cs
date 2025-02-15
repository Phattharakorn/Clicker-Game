using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public int currentEXP;
    public int cash;
    public int credit;
    public int awayIncome;
}

public class SaveManager : MonoBehaviour
{
    private string savePath;
    public PlayerData data = new PlayerData();

    void Awake()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
        LoadGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved: " + savePath);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game Loaded: " + savePath);
        }
        else
        {
            Debug.Log("No save file found, creating new data.");
            CreateNewSave();
        }
    }

    private void CreateNewSave()
    {
        data.playerName = "Player";
        data.level = 1;
        data.currentEXP = 0;
        data.cash = 0;
        data.credit = 0;
        data.awayIncome = 0;

        SaveGame();
    }
}
