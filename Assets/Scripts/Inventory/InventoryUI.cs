using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> slotItems;

    [SerializeField]private Inventory Inventory;

    [SerializeField]private TextMeshProUGUI itemName;
    [SerializeField]private TextMeshProUGUI itemRarity;
    [SerializeField]private TextMeshProUGUI itemPrice;

    public void SelectItem(string iName, int index)
    {
        if (Inventory.weapons[index] != null)
        {
            itemName.text = Inventory.weapons[index].GetComponent<Weapon>().weaponName;
            itemRarity.text = Inventory.weapons[index].GetComponent<Weapon>().rarity.ToString();
            itemPrice.text = "Price: " + Inventory.weapons[index].GetComponent<Weapon>().price;
        }
        
    }

    public void AddWeaponToSlot(int index)
    {
        slotItems[index].GetComponentsInChildren<Image>()[1].sprite = Inventory.weapons[index].GetComponent<Weapon>().itemSprite;
    }
}
