using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpriteToggle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image targetImage; // The Image component to change the sprite
    public Sprite defaultSprite; // The default sprite to show
    public Sprite clickedSprite; // The sprite to show when clicked

    private void Start()
    {
        // Ensure the target image starts with the default sprite
        if (targetImage != null)
        {
            targetImage.sprite = defaultSprite;
        }
    }

    // Method called when the pointer is pressed down
    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetImage != null)
        {
            targetImage.sprite = clickedSprite; // Change to the clicked sprite
        }
    }

    // Method called when the pointer is released
    public void OnPointerUp(PointerEventData eventData)
    {
        if (targetImage != null)
        {
            targetImage.sprite = defaultSprite; // Revert to the default sprite
        }
    }
}
