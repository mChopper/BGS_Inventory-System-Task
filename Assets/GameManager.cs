using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerInventory inventory;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        foreach (var go in inventory.inventoryItems)
        {
            PlayerPrefs.SetString("Item", go.GetComponent<CoreItemSO>().name);
            //PlayerPrefs.SetString("Slot", go.GetComponent<CoreItemSO>().slotPosition);
            PlayerPrefs.SetString("Prefab", go.GetComponent<CoreItemSO>().prefabName );
        }
    }
    public void LoadData()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < inventory.inventoryItems.Length; i++)
        {
            var slot = PlayerPrefs.GetInt("Slot");
            var prefab = PlayerPrefs.GetString("Prefab");
            
            GameObject obj = (GameObject)Resources.Load("Prefabs/" + prefab);
            
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            
            //inventory.inventoryUI = Instantiate(PlayerPrefs.GetString("Item"));
  
        }   
    }

    public void ResetGame()
    {
        //inventory.items.Clear();
    }
}
