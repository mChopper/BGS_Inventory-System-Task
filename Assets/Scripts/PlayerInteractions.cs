using System.Collections.Generic;
using UnityEngine;
public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] 
    private BoxCollider2D boxCollider;
    [SerializeField] 
    private bool isTouching;
    public PlayerInventory playerInventory;
    //List<GameObject> itemsCollidedWith = new List <GameObject> ();
    public List<GameObject> itemsCollidedWith = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        isTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void InteractWithPlayer()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouching = true;
        Debug.Log("Enter" + collision.gameObject.name);
        itemsCollidedWith.Add(collision.gameObject);
        Interact();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouching = false;
        Debug.Log("Exit" + collision.gameObject.name);
        itemsCollidedWith.Remove(collision.gameObject);
    }

    public void Interact()
    {
        for (int i = 0; i < itemsCollidedWith.Count; i++)
        {
            Debug.Log(itemsCollidedWith[i]);
            if (isTouching)
            {
                Debug.Log(itemsCollidedWith);
                Debug.Log(itemsCollidedWith[i]);
                bool item = playerInventory.AddItem(itemsCollidedWith[i]);
                if (item)
                {
                    itemsCollidedWith[i].GetComponent<IItem>().PickItem();
                }
            }
        }
    }
    public void OpenInventoryUI()
    {
        if (playerInventory.inventoryUI.activeInHierarchy)
        {
            playerInventory.inventoryUI.SetActive(false);
        }
        else
        {
            playerInventory.inventoryUI.SetActive(true);
        }
    }
}
