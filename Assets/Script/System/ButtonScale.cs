using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f); // Scale when hovered
    private Vector3 originalScale;

    private bool isHovered = false;

    private void Start()
    {
        originalScale = transform.localScale; // Store the default scale
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        transform.localScale = hoverScale; // Scale up when hovered
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        transform.localScale = originalScale; // Reset to original size
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.localScale = originalScale; // Reset to default size
        if (isHovered)
        {
            transform.localScale = hoverScale; // Rescale if the cursor is still on it
        }
    }
}
