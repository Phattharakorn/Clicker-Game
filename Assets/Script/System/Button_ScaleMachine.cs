using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1f); // Desired scale when hovered over
    private Vector3 originalSize;

    private void Start()
    {
        originalSize = transform.localScale; // Store the original size of the image
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hoverScale; // Scale up the image when hovered
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalSize; // Reset to original size when not hovered
    }
}
