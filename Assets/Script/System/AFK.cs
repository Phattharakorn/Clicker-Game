using UnityEngine;
using System;
using System.Collections;

public class AFKManager : MonoBehaviour
{
    public float cashPerMinute = 500f; // Cash added per minute
    private float maxAFKTime = 180f; // Maximum AFK time in minutes
    private DateTime lastQuitTime; // Time when the player quit
    private bool isCounting = false; // Track if counting is active

    private void Start()
    {
        // Optionally, you can check if the player was already AFK when the game starts
        if (PlayerPrefs.HasKey("LastQuitTime"))
        {
            long unixTime = Convert.ToInt64(PlayerPrefs.GetString("LastQuitTime"));
            lastQuitTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
            isCounting = true;
            StartCoroutine(AFKCashCoroutine());
        }
    }

    private void OnApplicationQuit()
    {
        // Store the current time when the player quits
        lastQuitTime = DateTime.Now;
        PlayerPrefs.SetString("LastQuitTime", ((DateTimeOffset)lastQuitTime).ToUnixTimeSeconds().ToString());
        PlayerPrefs.Save();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        // If the application gains focus, stop the counting
        if (hasFocus && isCounting)
        {
            isCounting = false;
            StopCoroutine(AFKCashCoroutine());
        }
        // If the application loses focus, restart counting
        else if (!hasFocus && !isCounting)
        {
            lastQuitTime = DateTime.Now;
            PlayerPrefs.SetString("LastQuitTime", ((DateTimeOffset)lastQuitTime).ToUnixTimeSeconds().ToString());
            PlayerPrefs.Save();
            isCounting = true;
            StartCoroutine(AFKCashCoroutine());
        }
    }

    private IEnumerator AFKCashCoroutine()
    {
        while (isCounting)
        {
            // Calculate the time difference from the last quit time
            float timeSpentAFK = (float)(DateTime.Now - lastQuitTime).TotalMinutes;

            if (timeSpentAFK >= maxAFKTime)
            {
                timeSpentAFK = maxAFKTime; // Cap the time to max AFK time
            }

            // Add cash based on the time spent AFK
            int cashToAdd = (int)((timeSpentAFK * cashPerMinute) / 60); // Cash per second
            PlayerData.Instance.AddCash(cashToAdd);

            yield return new WaitForSeconds(60f); // Wait for 1 minute before the next calculation
        }
    }
}
