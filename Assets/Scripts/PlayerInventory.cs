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
    public GameObject itemPrefab;

    public GameObject[] inventoryItems = new GameObject[9];
    public GameObject[] inventoryUISlots = new GameObject[9];
    public GameObject[] equipmentItems = new GameObject[3];
    public GameObject[] equipmentUISlots = new GameObject[3];

    public void InventoryDataUpdate ()
    { 
        for (int i = 0; i < inventoryUISlots.Length; i++)
        {
            if (inventoryUISlots[i].transform.childCount != 0) {

                GameObject go = inventoryUISlots[i].transform.GetChild(0).gameObject;

                var path = "Prefabs/" + go.GetComponent<CoreItem>().data.prefabName;
                inventoryItems[i] = Resources.Load<GameObject>(path);
            }
        }
    }
    public void InventoryUIUpdate(bool updateData)
    {
        for (int i = 0; i < inventoryUISlots.Length; i++)
        {
            int isItemInSlot = inventoryUISlots[i].transform.childCount;
            if (isItemInSlot > 0)
            {
                Destroy(inventoryUISlots[i].transform.GetChild(0).gameObject);
            }
        }

       
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] != null) {
                GameObject item = Instantiate(inventoryItems[i], inventoryUISlots[i].transform);
                if (item.transform.childCount != 0)
                {
                    item.transform.GetChild(0).gameObject.SetActive(true);
                }
      
            }
        }
        if (!updateData)
        {
            InventoryDataUpdate();
        }
        else
        {
        }
    }
    public bool AddItem(GameObject item)
    {
        bool itemPicked = false;
        
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i])
            {
            }
            else
            {
                inventoryItems[i] = item.GetComponent<CoreItem>().data.prefab;
                itemPicked = true;
                
                InventoryUIUpdate(itemPicked);
                return itemPicked;
            }
        }

        if (!itemPicked)
        {
            Debug.Log("No Room!");
        }
        return itemPicked;
    }
    
    public void UseItem(GameObject item)
    {
        Debug.Log("Using Item");
    }
    public void RemoveItem(GameObject item) {
        Debug.Log("Removing Item");
    }
}
