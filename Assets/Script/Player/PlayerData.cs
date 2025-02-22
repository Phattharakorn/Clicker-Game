using System.Diagnostics;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance; // Singleton instance

    public int level;
    public int currentExp;
    public int nextLevelExp;
    public int cash;
    public int coins;

    public int carlevel;
    public int foodlevel;
    public string foodname;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize(1, 0, 100, 0, 0);

            // Ensure car level starts from 1
            if (carlevel < 1)
            {
                carlevel = 1;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Initialize(int startLevel, int startExp, int reqExp, int startCash, int startCoins)
    {
        level = startLevel;
        currentExp = startExp;
        nextLevelExp = reqExp;
        cash = startCash;
        coins = startCoins;

        
    }
    public void upgrade(string fname, int flvl, int startcar)
    {
        foodname = fname;
        foodlevel = flvl;
        carlevel = startcar;
    }
    public void food()
    {
        if (foodlevel == 2)
        {
            foodname = "shrimp";
        }
        else if (foodlevel == 3)
        {
            foodname = "fish";
        }
    }

    public void car()
    {
        if(carlevel == 2)
        {

        }
    }
    public void UpgradeCar(int level)
    {
        carlevel = Mathf.Max(1, level); // Ensure level is always 1 or higher

        // Update the car image in the UI
        CarImageManager carImageManager = FindObjectOfType<CarImageManager>();
        if (carImageManager != null)
        {
            carImageManager.UpdateCarImage();
        }
    }
    public void ResetData()
    {
        Initialize(1, 0, 100, 0, 0); // Reset player data to initial values
        upgrade("Chicken", 1, 1);
    }

    public void AddExperience(int amount)
    {
        currentExp += amount;
        // Check for level up if needed
        if (currentExp >= nextLevelExp)
        {
            LevelUp(); // Call a method to handle leveling up
        }
    }

    public void AddCash(int amount)
    {
        cash += amount;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    private void LevelUp()
    {
        level++;
        currentExp -= nextLevelExp; // Reset currentExp after leveling up
        nextLevelExp = CalculateNextLevelExp(); // Update next level experience
        coins += 5;
    }

    private int CalculateNextLevelExp()
    {
        // Example formula for next level experience
        return level * 100; // Adjust as needed
    }
}
