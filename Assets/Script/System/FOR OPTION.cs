using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Toggle bgmToggle;
    public Toggle sfxToggle;

    private void Start()
    {
        if (GameSettings.Instance != null)
        {
            GameSettings.Instance.ReconnectToggles(bgmToggle, sfxToggle);
        }
    }
}
