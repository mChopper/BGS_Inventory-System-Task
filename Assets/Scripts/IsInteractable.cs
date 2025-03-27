using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IsInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject itemOnMouseCursor;
    public GameObject descriptionUI;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public PlayerInventory playerInventory;
    void Start()
    {
        descriptionUI = GameObject.FindWithTag("DescriptionUI");
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        itemIcon = descriptionUI.transform.GetChild(0).gameObject.GetComponent<Image>();
        itemName = descriptionUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        itemDescription = descriptionUI.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        
        itemIcon.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);
        itemDescription.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemOnMouseCursor = eventData.hovered[0];

        if (itemOnMouseCursor.transform.childCount != 0)
        {
            GameObject go = itemOnMouseCursor.transform.GetChild(0).gameObject;
        
            itemIcon.sprite = go.GetComponent<CoreItem>().data.icon;
            itemName.text = go.GetComponent<CoreItem>().data.name;
            itemDescription.text = go.GetComponent<CoreItem>().data.description;
        
            itemIcon.gameObject.SetActive(true);
            itemName.gameObject.SetActive(true);
            itemDescription.gameObject.SetActive(true);
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        itemName.text = "";
        itemDescription.text = "";
        
        itemIcon.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);
        itemDescription.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            playerInventory.RemoveItem(eventData.pointerCurrentRaycast.gameObject);
        }
    }
}
