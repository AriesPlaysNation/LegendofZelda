using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDesc;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
}
