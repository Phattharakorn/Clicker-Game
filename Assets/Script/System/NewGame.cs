using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    private PlayerData playerData;

    private void Start()
    {
        // Initialize player data if it doesn't already exist
        if (PlayerData.Instance == null)
        {
            playerData = gameObject.AddComponent<PlayerData>(); // Ensure PlayerData exists
            playerData.Initialize(1, 0, 100, 0, 0); // Set initial values
        }
        else
        {
            playerData = PlayerData.Instance; // Reference the existing instance
        }
    }

    public void ResetPlayerData()
    {
        playerData.ResetData(); // Reset player data
        // Optionally, update the UI after resetting
        FindObjectOfType<UIManager>().UpdateUI(); // Ensure UI reflects the reset data
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game"); // Replace with your actual game scene name
    }
}
