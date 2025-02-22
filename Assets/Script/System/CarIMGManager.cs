using UnityEngine;
using UnityEngine.UI;

public class CarImageManager : MonoBehaviour
{
    public Image carImage; // UI Image that will change
    public Sprite[] carSprites; // Array of car sprites (index matches car levels)

    private void Start()
    {
        UpdateCarImage(); // Call on start to apply the correct image
    }

    public void UpdateCarImage()
    {
        if (PlayerData.Instance != null && carSprites.Length > 0)
        {
            int carLevel = Mathf.Max(1, PlayerData.Instance.carlevel); // Ensure level starts from 1

            if (carLevel - 1 < carSprites.Length) // Adjust index since array starts at 0
            {
                carImage.sprite = carSprites[carLevel - 1]; // Assign corresponding sprite
            }
        }
    }
}
