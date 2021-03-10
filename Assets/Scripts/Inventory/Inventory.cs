using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins;

    public List<GameObject> weapons;
    public List<Weapon> weapons2;
    public List<GameObject> cosmetics;

    [SerializeField]private InventoryUI WeaponInventoryUI;
    [SerializeField]private InventoryUI CosmeticInventoryUI;
    [SerializeField]private RandomItemGen RandomItemGen;

    private int selectedSlot;
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Inventory");

        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        /*for (int i = 0; i < 9; i++)
        {
            AddWeapon(RandomItemGen.GenerateRandomItem());
        }
        RemoveWeapons();
        AddCosmetic(RandomItemGen.GenerateRandomCosmetic());*/
    }

    public void AddWeapon(GameObject wpn)
    {
        weapons.Add(wpn);
        int i = weapons.Count - 1;
        wpn.transform.parent = WeaponInventoryUI.slotItems[i].transform;
        WeaponInventoryUI.AddWeaponToSlot(i);
    }

    public void AddWeapon2(Weapon wpn) {
        weapons2.Add(wpn);
        int i = weapons2.Count - 1;
        //wpn.transform.parent = WeaponInventoryUI.slotItems[i].transform;
        //WeaponInventoryUI.AddWeaponToSlot(i);
    }

    public GameObject GetWeapon(int index)
    {
        return weapons[index];
    }

    public Weapon GetWeapon2(int index) {
        return weapons2[index];
    }

    public void RemoveWeapons()
    {
        WeaponInventoryUI.ResetWeaponSlotImages();
        weapons.Clear();
    }

    public void RemoveWeapons2() {
        WeaponInventoryUI.ResetWeaponSlotImages();
        weapons2.Clear();
    }

    public void AddCosmetic(GameObject cmtc)
    {
        cosmetics.Add(cmtc);
        int i = cosmetics.Count - 1;
        cmtc.transform.parent = CosmeticInventoryUI.slotItems[i].transform;
        CosmeticInventoryUI.AddCosmeticToSlot(i);
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
            WeaponInventoryUI.SelectWeapon(weapons[i].GetComponent<Weapon>().weaponName, i);
        }        
    }

    public void SelectCosmetic(int i)
    {
        if (i < cosmetics.Count)
        {
            selectedSlot = i;
            CosmeticInventoryUI.SelectCosmetic(cosmetics[i].GetComponent<Cosmetic>().cosmeticName, i);
        }
    }

}
