using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextInputHandler : MonoBehaviour
{
    public TMP_InputField tmpInputField;  // Reference to the TMP_InputField
    public Button buttonToShow;           // Reference to the Button that will be shown/hidden

    void Start()
    {
        // Initially hide the button
        buttonToShow.gameObject.SetActive(false);

        // Add listener to input field text change
        tmpInputField.onValueChanged.AddListener(OnTextChanged);
    }

    void OnTextChanged(string text)
    {
        // Check if the text length is at least 5 characters
        if (text.Length >= 5)
        {
            buttonToShow.gameObject.SetActive(true);  // Show the button
        }
        else
        {
            buttonToShow.gameObject.SetActive(false);  // Hide the button
        }
    }
}
