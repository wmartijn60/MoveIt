using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public int price;
    public string weaponName;
    public enum Rarity { Common, Rare, Legendary }
    public Rarity rarity;
    public Sprite itemSprite;
}
