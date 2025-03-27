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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InventoryDataUpdate ()
    {        
        Debug.Log("F InventoryDATAUpdate");
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            
        }
        for (int i = 0; i < inventoryUISlots.Length; i++)
        {
            if (inventoryUISlots[i].transform.childCount != 0) {
                //GameObject item = Instantiate(inventoryUISlots[i]., inventoryUISlots[i].transform);
                GameObject go = inventoryUISlots[i].transform.GetChild(0).gameObject;
                Debug.Log(go.name);
                //go.GetComponent<CoreItemSO>().name;
                var path = "Prefabs/" + go.GetComponent<CoreItem>().data.prefabName;
                inventoryItems[i] = Resources.Load<GameObject>(path);
                //Debug.Log(inventoryItems[i].name);
                    //inventoryUISlots[i].transform.GetChild(0).gameObject;
                //item.GetComponent<Image>().sprite = inventoryItems[i].GetComponent<CoreItem>().data.icon;
                //item.GetComponent<Image>().enabled = true;
            }
            else
            {
                //inventoryItems[i] = null;
                //inventoryUISlots[i].GetComponent<Image>().sprite = null;
                //inventoryUISlots[i].GetComponent<Image>().enabled = false;
            }
        }
        Debug.Log("F InventoryDATAUpdate");
    }
    public void InventoryUIUpdate(bool isLoadingState)
    {
        Debug.Log("Star InventoryUIUpdate");
        for (int i = 0; i < inventoryUISlots.Length; i++)
        {
            int isItemInSlot = inventoryUISlots[i].transform.childCount;
            if (isItemInSlot > 0)
            {
                Destroy(inventoryUISlots[i].transform.GetChild(0).gameObject);
            }
        }

        //inventoryUISlots = new GameObject[9];
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] != null) {
                GameObject item = Instantiate(inventoryItems[i], inventoryUISlots[i].transform);
                if (item.transform.childCount != 0)
                {
                    item.transform.GetChild(0).gameObject.SetActive(true);
                }
                //item.GetComponent<Image>().sprite = inventoryItems[i].GetComponent<CoreItem>().data.icon;
                //item.GetComponent<Image>().enabled = true;
            }
            else
            {
                //inventoryUISlots[i].GetComponent<Image>().sprite = null;
                //inventoryUISlots[i].GetComponent<Image>().enabled = false;
            }
        }
        Debug.Log("F InventoryUIUpdate");
        if (!isLoadingState)
        {
            InventoryDataUpdate();
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
                //inventoryUISlots[i].GetComponent<Image>().sprite = item.GetComponent<CoreItem>().data.icon;
                //inventoryUISlots[i].GetComponent<Image>().enabled = true;
                itemPicked = true;
                Debug.Log("Picked item");
                InventoryUIUpdate(itemPicked);
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
