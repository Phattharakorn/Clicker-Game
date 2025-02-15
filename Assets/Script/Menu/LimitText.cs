using TMPro;
using UnityEngine;

public class LimitTMPInputField : MonoBehaviour
{
    public TMP_InputField tmpInputField;

    void Start()
    {
        tmpInputField.characterLimit = 20; 
    }
}
