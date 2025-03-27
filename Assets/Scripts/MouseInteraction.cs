using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    [Header("Mouse Functions")]
    public GameObject itemOnMouseCursor;
    public GameObject inventorySlotOnMouseCursor;
    public GameObject equipmentSlotOnMouseCursor;
    public GameObject grabbedItem;
    public bool isHovering;
    public bool isClicking;
    public bool isDragging;
    void Start()
    {
        isDragging = false;
        isHovering = false;
        isClicking = false;
    }
}
