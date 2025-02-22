using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public PlayerData playerData; // Reference to PlayerData
    public int upgradeCost; // Cost for the upgrade
    public int coinCost; // Coin cost for the upgrade
    public Sprite[] upgradeSprites; // Array for different upgrade sprites
    public GameObject spawnItemPrefab; // Prefab to spawn after upgrade
    public TextMeshProUGUI upgradeDescription; // Text for upgrade description
    private int currentUpgradeStage = 0; // Track the current upgrade stage

    private void Start()
    {
        UpdateUpgradeButton();
    }

    public void OnUpgradeButtonClick()
    {
        // Check if player has enough cash and coins for the upgrade
        if (playerData.cash >= upgradeCost && playerData.coins >= coinCost)
        {
            // Deduct the costs from player data
            playerData.cash -= upgradeCost;
            playerData.coins -= coinCost;

            // Perform upgrade logic
            currentUpgradeStage++;
            UpdateUpgradeButton();

            // Change the sprite based on upgrade stage
            if (currentUpgradeStage < upgradeSprites.Length)
            {
                // Change to the corresponding upgrade sprite
                // Assuming you have a reference to the image or game object that displays the sprite
                GetComponent<Image>().sprite = upgradeSprites[currentUpgradeStage];
            }

            // If it's the max stage, hide description
            if (currentUpgradeStage >= upgradeSprites.Length - 1)
            {
                upgradeDescription.gameObject.SetActive(false); // Hide description
            }

            // Perform any additional logic for the upgrade (e.g., spawn item)
            SpawnUpgradedItem();
        }
    }

    private void UpdateUpgradeButton()
    {
        // Update upgrade button visuals and text based on the current stage
        if (currentUpgradeStage >= upgradeSprites.Length)
        {
            // If max level reached, change button to "Max" or disable it
            GetComponentInChildren<TextMeshProUGUI>().text = "Max";
            // Optionally, disable the button
            GetComponent<Button>().interactable = false;
        }
        else
        {
            // Update the button with cost information
            GetComponentInChildren<TextMeshProUGUI>().text = $" (${upgradeCost})";
        }
    }

    private void SpawnUpgradedItem()
    {
        // Instantiate the item prefab and set its position based on your logic
        GameObject spawnedItem = Instantiate(spawnItemPrefab, transform.position, Quaternion.identity);
        // Additional setup for the spawned item if necessary
    }
}
