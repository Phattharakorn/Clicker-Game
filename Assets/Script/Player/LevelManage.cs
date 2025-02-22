using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const int baseExperience = 100; // Base experience for level 1
    private const float experienceGrowthRate = 0.10f; // 10% increase per level

    private void Start()
    {
        // Initialize player data if needed
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.Initialize(1, 0, baseExperience, 0, 0);
        }
    }

    public void AddExperience(int amount)
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.AddExperience(amount);

            // Check if the player has leveled up
            while (PlayerData.Instance.currentExp >= PlayerData.Instance.nextLevelExp)
            {
                LevelUp();
            }
        }
    }

    private void LevelUp()
    {
        PlayerData.Instance.level++;
        PlayerData.Instance.currentExp -= PlayerData.Instance.nextLevelExp; // Reset currentExp after leveling up
        PlayerData.Instance.nextLevelExp = CalculateNextLevelExp(); // Update next level experience
    }

    private int CalculateNextLevelExp()
    {
        return Mathf.FloorToInt(baseExperience * Mathf.Pow(1 + experienceGrowthRate, PlayerData.Instance.level - 1));
    }
}
