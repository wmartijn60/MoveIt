using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> slotItems;
    public Image cosmeticPreview;
    public Sprite emptySlot;

    [SerializeField]private Inventory Inventory;

    [SerializeField]private TextMeshProUGUI itemName;
    [SerializeField]private TextMeshProUGUI itemRarity;
    [SerializeField]private TextMeshProUGUI itemPrice;

    public void SelectWeapon(string iName, int index)
    {
        if (Inventory.weapons[index] != null)
        {
            itemName.text = Inventory.weapons[index].GetComponent<Weapon>().weaponName;
            itemRarity.text = Inventory.weapons[index].GetComponent<Weapon>().rarity.ToString();
            itemPrice.text = "Price: " + Inventory.weapons[index].GetComponent<Weapon>().price;
        }
        
    }

    public void SelectCosmetic(string iName, int index)
    {
        if (Inventory.cosmetics[index] != null)
        {
            itemName.text = Inventory.cosmetics[index].GetComponent<Cosmetic>().cosmeticName;
            itemRarity.text = Inventory.cosmetics[index].GetComponent<Cosmetic>().rarity.ToString();
            cosmeticPreview.sprite = Inventory.cosmetics[index].GetComponent<Cosmetic>().itemSprite;
        }

    }

    public void AddWeaponToSlot(int index)
    {
        slotItems[index].GetComponentsInChildren<Image>()[1].sprite = Inventory.weapons[index].GetComponent<Weapon>().sprite;
    }

    public void AddCosmeticToSlot(int index)
    {
        slotItems[index].GetComponentsInChildren<Image>()[1].sprite = Inventory.cosmetics[index].GetComponent<Cosmetic>().itemSprite;
    }

    public void ResetWeaponSlotImages()
    {
        for (int i = 0; i < Inventory.weapons.Count; i++)
        {
            slotItems[i].GetComponentsInChildren<Image>()[1].sprite = emptySlot;
        }
    }

}
