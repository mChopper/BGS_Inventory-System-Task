using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthOrb", menuName = "Inventory Items/HealthOrb")]
public class HealthOrb : ScriptableObject
{
    public String name;
    public Sprite icon;
    public float healPower;
    public float cooldown;
    
    public Potion potion;
    
    
    
}
