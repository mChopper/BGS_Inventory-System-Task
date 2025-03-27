using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GameObject controls;
    public GameObject helpMessage;
    private bool isHelpOn;
    private bool isLoading;

    private void Start()
    {
        isHelpOn = false;   
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.DeleteAll();
        //playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();

        for (int i = 0; i < playerInventory.inventoryItems.Length; i++)
        {
            if (playerInventory.inventoryItems[i])
            {
                PlayerPrefs.SetString("Prefab" + i, playerInventory.inventoryItems[i].name);
                PlayerPrefs.SetInt("Slot" + i, i);
            }
        }
        Debug.Log("Game Saved");
    }
    public void LoadData()
    {
        isLoading = true;
        for (int i = 0; i < playerInventory.inventoryItems.Length; i++)
        {
            //GameObject go = playerInventory.inventoryUISlots[i].transform.GetChild(0).gameObject;
            //Destroy(go);
            string prefab = PlayerPrefs.GetString("Prefab" + i);
            playerInventory.inventoryItems[i] = Resources.Load<GameObject>("Prefabs/" + prefab);
        } 
        playerInventory.InventoryUIUpdate(isLoading);
        Debug.Log("Game Loaded");
    }

    public void DisplayControls()
    {
        controls.SetActive(!isHelpOn);
        helpMessage.SetActive(isHelpOn);
        isHelpOn = !isHelpOn;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
