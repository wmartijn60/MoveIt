using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ShopManagerScriptableObject", order = 1)]
public class TempItem : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public int itemCost;
}
