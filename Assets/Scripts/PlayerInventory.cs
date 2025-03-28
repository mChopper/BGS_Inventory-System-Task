using System;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject itemPrefab;

    public GameObject[] inventoryItems = new GameObject[12];
    public GameObject[] inventoryUISlots = new GameObject[12];

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
        
    }
    public bool AddItem(GameObject item)
    {
        bool itemPicked = false;
        
        for (int i = 3; i < inventoryItems.Length; i++)
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
        Debug.Log(item);
        
        string slotName = item.gameObject.GetComponent<DraggableUIItem>().currentSlot.gameObject.name;
        slotName = slotName.Substring(5, 2);
        Debug.Log(slotName);
        int slotNumber = Int32.Parse(slotName);
        Debug.Log(slotNumber);
        
        Destroy(inventoryUISlots[slotNumber - 1].transform.GetChild(0).gameObject);
        inventoryItems[slotNumber - 1] = null;
        InventoryUIUpdate(true);
    }
}
