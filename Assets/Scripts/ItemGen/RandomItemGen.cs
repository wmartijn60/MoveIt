using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGen : MonoBehaviour
{
    public int legendaryMaxDamage;
    public int legendaryMinDamage;
    public int rareMaxDamage;
    public int rareMinDamage;
    public int commonMaxDamage;
    public int commonMinDamage;

    public int playerLevelMultiplier = 1;

    public List<Sprite> weaponSprites;
    public List<GameObject> weapons;
    public List<GameObject> cosmetics;

    //variables for random chance
    [SerializeField]private int rareRate;
    [SerializeField]private int legendaryRate;
    [SerializeField]private int maxRate;

    public List<string> weaponNames;
        

    private void Start()
    {        

    }

    public GameObject GenerateRandomItem()
    {
        GameObject nWeapon = Instantiate(weapons[Random.Range(0, weapons.Count)], transform.position, Quaternion.identity);

        int r = Random.Range(0,maxRate);
        if (r < legendaryRate)
        {     
            int d = Random.Range(legendaryMinDamage * playerLevelMultiplier, legendaryMaxDamage * playerLevelMultiplier);
            nWeapon.GetComponent<Weapon>().damage = d;
            nWeapon.GetComponent<Weapon>().rarity = Weapon.Rarity.Legendary;
            nWeapon.GetComponent<Weapon>().price = GeneratePrice(3, d);
            nWeapon.GetComponent<Weapon>().weaponName = weaponNames[Random.Range(0, weaponNames.Count)];
        }
        else if (r < rareRate)
        {
            int d = Random.Range(rareMinDamage * playerLevelMultiplier, rareMinDamage * playerLevelMultiplier);
            nWeapon.GetComponent<Weapon>().damage = d;
            nWeapon.GetComponent<Weapon>().rarity = Weapon.Rarity.Rare;
            nWeapon.GetComponent<Weapon>().price = GeneratePrice(2,d);
            nWeapon.GetComponent<Weapon>().weaponName = weaponNames[Random.Range(0, weaponNames.Count)];
        }
        else // if rarity rate doesn't match rare or legendary, it becomes a common
        {
            int d = Random.Range(commonMinDamage * playerLevelMultiplier, commonMaxDamage * playerLevelMultiplier);
            nWeapon.GetComponent<Weapon>().damage = d;
            nWeapon.GetComponent<Weapon>().rarity = Weapon.Rarity.Common;
            nWeapon.GetComponent<Weapon>().price = GeneratePrice(1, d);
            nWeapon.GetComponent<Weapon>().weaponName = weaponNames[Random.Range(0, weaponNames.Count)];
        }

        return nWeapon;
    }

    public GameObject GenerateRandomCosmetic()
    {
        GameObject nCosmetic = Instantiate(cosmetics[Random.Range(0, cosmetics.Count)], transform.position, Quaternion.identity);

        return nCosmetic;
    }

    private int GeneratePrice(int rarityMultiplier, int calDmg)
    {        

        int price = Mathf.RoundToInt(((rarityMultiplier + playerLevelMultiplier) * calDmg)/2);

        return price;
    }
    public Weapon GenerateRandomItem2()
    {
        //GameObject nWeapon = Instantiate(weapons[Random.Range(0, weapons.Count)], transform.position, Quaternion.identity);
        Weapon weapon = new Weapon();

        int r = Random.Range(0, maxRate);
        if (r < legendaryRate)
        {
            int d = Random.Range(legendaryMinDamage * playerLevelMultiplier, legendaryMaxDamage * playerLevelMultiplier);
            weapon.damage = d;
            weapon.rarity = Weapon.Rarity.Legendary;
            weapon.price = GeneratePrice(3, d);
            weapon.weaponName = weaponNames[Random.Range(0, weaponNames.Count)];
            weapon.sprite = weaponSprites[Random.Range(0, weaponSprites.Count)];
        }
        else if (r < rareRate)
        {
            int d = Random.Range(rareMinDamage * playerLevelMultiplier, rareMinDamage * playerLevelMultiplier);
            weapon.damage = d;
            weapon.rarity = Weapon.Rarity.Rare;
            weapon.price = GeneratePrice(2, d);
            weapon.weaponName = weaponNames[Random.Range(0, weaponNames.Count)];
            weapon.sprite = weaponSprites[Random.Range(0, weaponSprites.Count)];
        }
        else // if rarity rate doesn't match rare or legendary, it becomes a common
        {
            int d = Random.Range(commonMinDamage * playerLevelMultiplier, commonMaxDamage * playerLevelMultiplier);
            weapon.damage = d;
            weapon.rarity = Weapon.Rarity.Common;
            weapon.price = GeneratePrice(1, d);
            weapon.weaponName = weaponNames[Random.Range(0, weaponNames.Count)];
            weapon.sprite = weaponSprites[Random.Range(0, weaponSprites.Count)];
        }

        return weapon;
    }

}
