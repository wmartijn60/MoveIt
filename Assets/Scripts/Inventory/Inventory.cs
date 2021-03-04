using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins;

    public List<GameObject> weapons;
    public List<GameObject> cosmetics;

    [SerializeField]private InventoryUI InventoryUI;
    [SerializeField]private RandomItemGen RandomItemGen;

    private int selectedSlot;

    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            AddWeapon(RandomItemGen.GenerateRandomItem());
        }
        
    }

    public void AddWeapon(GameObject wpn)
    {
        weapons.Add(wpn);
        int i = weapons.Count - 1;
        wpn.transform.parent = InventoryUI.slotItems[i].transform;
        InventoryUI.AddWeaponToSlot(i);
    }

    public GameObject GetWeapon(int index)
    {
        return weapons[index];
    }

    public void RemoveWeapons()
    {
        weapons.Clear();
    }

    public void AddCosmetic(GameObject cmtc)
    {
        cosmetics.Add(cmtc);
    }

    public GameObject GetCosmetic(int index)
    {
        return weapons[index];
    }

    public void SelectWeapon(int i)
    {
        if (i < weapons.Count)
        {
            selectedSlot = i;
            InventoryUI.SelectItem(weapons[i].GetComponent<Weapon>().weaponName, i);
        }        
    }

    public void SelectCosmetic(int i)//still needs cosmetic items to work, WIP
    {
        if (i < cosmetics.Count)
        {
            selectedSlot = i;
            InventoryUI.SelectItem(cosmetics[i].GetComponent<Weapon>().weaponName, i);
        }
    }

}
