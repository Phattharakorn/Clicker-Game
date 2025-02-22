using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    public void ExitGame()
    {
        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Quit the application
#endif
    }
}
