using System.Collections.Generic;
using UnityEngine;
public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] 
    private BoxCollider2D boxCollider;
    [SerializeField] 
    private bool isTouching;
    public PlayerInventory playerInventory;
    public List<GameObject> itemsCollidedWith = new List<GameObject>();
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        isTouching = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouching = true;
        itemsCollidedWith.Add(collision.gameObject);
        Interact();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouching = false;
        itemsCollidedWith.Remove(collision.gameObject);
    }
    public void Interact()
    {
        for (int i = 0; i < itemsCollidedWith.Count; i++)
        {
            if (isTouching)
            {
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
