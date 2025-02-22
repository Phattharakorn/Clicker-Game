using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text playerLevelText;           // TextMeshPro Text for displaying player level
    public Slider experienceSlider;             // Slider UI for displaying current experience
    public TMP_Text cashText;                   // TextMeshPro Text for displaying cash
    public TMP_Text coinsText;
    public TMP_Text cashshopText;                   // TextMeshPro Text for displaying cash
    public TMP_Text coinsshopText;  // TextMeshPro Text for displaying coins
    public TMP_Text expText;                    // TextMeshPro Text for displaying current and required experience
    public PlayerData playerData;               // Reference to PlayerData script

    private void Start()
    {
        // Initialize UI at the start
        UpdateUI();
    }

    private void Update()
    {
        // Update UI periodically (or use events for better performance)
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (playerData != null)
        {
            // Update the UI elements with player data
            playerLevelText.text = "LV :" + playerData.level;
            // Ensure slider updates properly
            experienceSlider.maxValue = playerData.nextLevelExp; // Set the maximum value
            experienceSlider.value = playerData.currentExp;      // Set the current value
            cashText.text = "" + Mathf.FloorToInt(playerData.cash); // Display cash as an integer
            coinsText.text = "" + playerData.coins; // Display coins as an integer
            cashshopText.text = "" + Mathf.FloorToInt(playerData.cash); // Display cash as an integer
            coinsshopText.text = "" + playerData.coins; // Display coins as an integer

            // Update experience display (e.g., "500/3500")
            expText.text = $"{playerData.currentExp}/{playerData.nextLevelExp}";
        }
    }
}
