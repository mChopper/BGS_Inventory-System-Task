using System;
using NUnit.Framework.Constraints;
using UnityEngine;

[CreateAssetMenu(fileName = "CoreItem", menuName = "Inventory Items/Core Item")]
public class CoreItemSO : ScriptableObject
{
    public GameObject prefab;
    public String prefabName;
    public String name;
    public Sprite icon;
    public bool isPickable;
    public string description;
}