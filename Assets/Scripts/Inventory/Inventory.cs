using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> weapons;
    public List<GameObject> cosmetics;

    [SerializeField]private InventoryUI InventoryUI;

    private int selectedSlot;

    void Start()
    {
        
    }

    public void AddWeapon(GameObject wpn)
    {
        weapons.Add(wpn);
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
        selectedSlot = i;
        InventoryUI.ShowItemName(weapons[i].GetComponent<Weapon>().weaponName);
    }

}
