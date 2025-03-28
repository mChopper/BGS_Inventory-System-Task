using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public GameObject WeaponSlot;
    public GameObject OrbSlot;
    public GameObject KeySlot;
    public PlayerInventory playerInventory;

    public void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if ((gameObject.transform.name == "Slot_01") && (eventData.pointerDrag.gameObject.CompareTag("Weapon")))
            {
                Debug.Log("Weapon Slot");
                HandleDrop(eventData);
            }
            if ((gameObject.transform.name == "Slot_02") && (eventData.pointerDrag.gameObject.CompareTag("Orb")))
            {
                Debug.Log("Orb Slot");
                HandleDrop(eventData);
            }
            if ((gameObject.transform.name == "Slot_03") && (eventData.pointerDrag.gameObject.CompareTag("Key")))
            {
                Debug.Log("Key Slot");
                HandleDrop(eventData);
            }
            if (gameObject.CompareTag("InventorySlot"))
            {
                Debug.Log("Free Inv Slot");
                HandleDrop(eventData);
            }
        }
    }
    public void HandleDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableUIItem draggableUIItem = dropped.GetComponent<DraggableUIItem>();
        GameObject go = gameObject;
        draggableUIItem.afterDrag = transform;

        string futureSlotName = go.gameObject.transform.name;
        string oldSlot0Name = dropped.gameObject.GetComponent<DraggableUIItem>().currentSlot.gameObject.name;
        
        int futureSlot = GetIndex(futureSlotName);
        int oldSlot = GetIndex(oldSlot0Name);

        playerInventory.inventoryItems[oldSlot] = null;
        playerInventory.inventoryItems[futureSlot] = dropped;
    }
    public int GetIndex(String slotName)
    {
        slotName = slotName.Substring(5, 2);
        int slotNumber = Int32.Parse(slotName);
        Debug.Log(slotNumber);
        return slotNumber - 1;
    }
}