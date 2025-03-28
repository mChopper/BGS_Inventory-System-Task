using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableUIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Transform inventory; 
    public Transform afterDrag;
    public Transform itemContainer;
    public Transform currentSlot;
    
    public void Start()
    {
        itemContainer = transform.parent;
        currentSlot = transform.parent.transform.parent;
        inventory = itemContainer.parent.transform.parent.transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        afterDrag = transform.parent;
        transform.SetParent(inventory);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemContainer.transform.position = Input.mousePosition;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemContainer.transform.SetParent(afterDrag);
        transform.SetParent(itemContainer);
        itemContainer.transform.position = afterDrag.position;
        currentSlot = transform.parent.transform.parent;
        itemContainer.transform.localPosition = Vector3.zero; 
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        image.raycastTarget = true;
    }
}
