using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance; // Singleton instance

    public AudioSource bgmSource; // BGM Audio Source
    public AudioSource[] sfxSources; // Array of SFX Audio Sources

    private bool isBGMEnabled;
    private bool isSFXEnabled;

    private void Awake()
    {

        LoadSettings();
    }

    private void LoadSettings()
    {
        isBGMEnabled = PlayerPrefs.GetInt("BGM", 1) == 1;
        isSFXEnabled = PlayerPrefs.GetInt("SFX", 1) == 1;
        ApplySettings();
    }

    private void ApplySettings()
    {
        if (bgmSource != null)
        {
            bgmSource.mute = !isBGMEnabled;
            if (isBGMEnabled && !bgmSource.isPlaying)
            {
                bgmSource.Play(); // Play BGM if enabled
            }
            else if (!isBGMEnabled && bgmSource.isPlaying)
            {
                bgmSource.Stop(); // Stop BGM if disabled
            }
        }

        foreach (AudioSource sfx in sfxSources)
        {
            if (sfx != null)
                sfx.mute = !isSFXEnabled;
        }
    }

    public void SetBGM(bool enabled)
    {
        isBGMEnabled = enabled;
        PlayerPrefs.SetInt("BGM", enabled ? 1 : 0);
        PlayerPrefs.Save();
        ApplySettings(); // Apply updated settings
    }

    public void SetSFX(bool enabled)
    {
        isSFXEnabled = enabled;
        PlayerPrefs.SetInt("SFX", enabled ? 1 : 0);
        PlayerPrefs.Save();
        ApplySettings(); // Apply updated settings
    }

    public void ReconnectToggles(Toggle bgmToggle, Toggle sfxToggle)
    {
        if (bgmToggle != null)
        {
            bgmToggle.isOn = isBGMEnabled;
            bgmToggle.onValueChanged.AddListener(SetBGM);
        }

        if (sfxToggle != null)
        {
            sfxToggle.isOn = isSFXEnabled;
            sfxToggle.onValueChanged.AddListener(SetSFX);
        }
    }
}
