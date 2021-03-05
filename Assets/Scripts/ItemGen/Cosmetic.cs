using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosmetic : MonoBehaviour
{
    public string cosmeticName;
    public enum Rarity { Common, Rare, Legendary }
    public Rarity rarity;
    public Sprite itemSprite;
}
