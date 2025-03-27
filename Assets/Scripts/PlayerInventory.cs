using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryUI;

    public GameObject[] inventoryItems = new GameObject[9];
    public GameObject[] inventoryUISlots = new GameObject[9];
    public GameObject[] equipmentItems = new GameObject[3];
    public GameObject[] equipmentUISlots = new GameObject[3];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InventoryUIUpdate()
    {
        //inventoryUISlots = new GameObject[9];
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] != null) {
                inventoryUISlots[i].GetComponent<Image>().sprite = inventoryItems[i].GetComponent<CoreItem>().data.icon;
                inventoryUISlots[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                inventoryUISlots[i].GetComponent<Image>().sprite = null;
                inventoryUISlots[i].GetComponent<Image>().enabled = false;
            }
        }
    }
    public bool AddItem(GameObject item)
    {
        SpriteRenderer spriteUI;
        bool itemPicked = false;
        
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i])
            {
            }
            else
            {
                inventoryItems[i] = item.GetComponent<CoreItem>().data.prefab;
                inventoryUISlots[i].GetComponent<Image>().sprite = item.GetComponent<CoreItem>().data.icon;
                inventoryUISlots[i].GetComponent<Image>().enabled = true;
                itemPicked = true;
                Debug.Log("Picked item");
                
                //Instantiate(inventoryItems[i], inventorySlots[i].transform.position, inventoryItems[i].transform.rotation);
                //Instantiate(inventoryItems[i], inventorySlots[i], Quaternion.identity);
                return itemPicked;
            }
        }
        if (!itemPicked)
            Debug.Log("No Room!");
        return itemPicked;
    }
    
    public void RemoveItem(GameObject item) {
        //itemsUI.Remove(item);
       // itemsSOs.Remove(item.GetComponent<ScriptableObject>());
    }
}
