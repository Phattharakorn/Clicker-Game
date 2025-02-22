using System;

[Serializable]
public class SaveData
{
    public string playerName;
    public int level;
    public int currentEXP;
    public int cash;
    public int credit;
    public int awayIncome;
    
    public SaveData()
    {
        playerName = "";
        level = 1;
        currentEXP = 0;
        cash = 0;
        credit = 0;
        awayIncome = 0;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }
}
