using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode back = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode openInventory = KeyCode.Tab;
    [SerializeField] private KeyCode saveGame = KeyCode.F5;
    [SerializeField] private KeyCode loadGame = KeyCode.F7;
    [SerializeField] private KeyCode quitGame = KeyCode.Escape;
    [SerializeField] private KeyCode resetGame = KeyCode.T;
    
    [Header("---")]
    [SerializeField]
    public GameManager gameManager;
    public PlayerMovement playerMovement;
    public PlayerInteractions playerInteractions;
    
    
    public void HandleInput()
    {
        playerMovement.Movement();  
        
        if (Input.GetKeyDown(openInventory))
        {
            playerInteractions.OpenInventoryUI();
        }

        if (Input.GetKeyDown(saveGame))
        {
            gameManager.SaveData();
        }  
        
        if (Input.GetKeyDown(loadGame))
        {
            gameManager.LoadData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
