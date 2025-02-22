using UnityEngine;
using TMPro;

public class PlayerNameHandler : MonoBehaviour
{
    public TMP_InputField nameInputField; // Assign in Inspector
    private SaveData saveData; // Player data storage

    private void Start()
    {
        saveData = new SaveData();
        LoadPlayerData(); // Load previously saved name if it exists
    }

    public void OnSubmitName()
    {
        if (nameInputField != null)
        {
            string inputName = nameInputField.text.Trim(); // Get user input

            if (!string.IsNullOrEmpty(inputName))
            {
                saveData.SetPlayerName(inputName); // Update SaveData
                Debug.Log("Player Name Saved: " + saveData.playerName);

                SavePlayerData(); // Save to PlayerPrefs
            }
        }
    }

    private void SavePlayerData()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
    }

    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            string json = PlayerPrefs.GetString("SaveData");
            saveData = JsonUtility.FromJson<SaveData>(json);
            nameInputField.text = saveData.playerName; // Set input field text to saved name
        }
    }
}
