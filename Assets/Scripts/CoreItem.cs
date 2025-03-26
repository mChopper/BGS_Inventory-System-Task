using UnityEngine;

public class CoreItem : MonoBehaviour, IItem
{
    [SerializeField]
    public CoreItemSO data;
    public void UseItem()
    {
        
    }

    public void PickItem()
    {
        Debug.Log("Picked item");
        Destroy(gameObject);
    }
}
