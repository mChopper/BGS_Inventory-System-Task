using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableUIItem draggableUIItem = dropped.GetComponent<DraggableUIItem>();
            draggableUIItem.afterDrag = transform;
        }
        else
        {
            Debug.Log("Contains Item");
            GameObject dropped = eventData.pointerDrag;
            DraggableUIItem draggableUIItem = dropped.GetComponent<DraggableUIItem>();
            draggableUIItem.itemContainer.transform.localPosition = Vector3.zero; 
            draggableUIItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Debug.Log("Container" + draggableUIItem.itemContainer.transform.localPosition);
            Debug.Log("Draggable" + draggableUIItem.GetComponent<RectTransform>().anchoredPosition);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
