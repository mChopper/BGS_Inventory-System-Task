using UnityEngine;

public class Potion : IItem
{
    public string Name { get; set; }
    public Sprite Icon { get; set; }
    
    public void UseItem()
    {
        DrinkPotion();
    }

    private void DrinkPotion()
    {
        
    }
}
