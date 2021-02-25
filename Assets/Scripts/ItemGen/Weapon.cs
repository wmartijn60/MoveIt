using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public enum Rarity { Common, Rare, Legendary }
    public Rarity rarity { get; set; }
    public Sprite sprite { get { return sprite; } set { sprite = value; } }
}
