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

    [SerializeField]private GameObject weapon;

    //variables for random chance
    [SerializeField]private int rareRate;
    [SerializeField]private int legendaryRate;
    [SerializeField]private int maxRate;

    private void Start()
    {
        GenerateRandomItem();
        GenerateRandomItem();
        GenerateRandomItem();
    }

    private GameObject GenerateRandomItem()
    {
        GameObject nWeapon = Instantiate(weapon, transform.position, Quaternion.identity);

        int r = Random.Range(0,maxRate);
        if (r < legendaryRate)
        {     
            int d = Random.Range(legendaryMinDamage * playerLevelMultiplier, legendaryMaxDamage * playerLevelMultiplier);
            nWeapon.GetComponent<Weapon>().damage = d;
            nWeapon.GetComponent<Weapon>().rarity = Weapon.Rarity.Legendary;
        }
        else if (r < rareRate)
        {
            int d = Random.Range(rareMinDamage * playerLevelMultiplier, rareMinDamage * playerLevelMultiplier);
            nWeapon.GetComponent<Weapon>().damage = d;
            nWeapon.GetComponent<Weapon>().rarity = Weapon.Rarity.Rare;
        }
        else // if rarity rate doesn't match rare or legendary, it becomes a common
        {
            int d = Random.Range(commonMinDamage * playerLevelMultiplier, commonMaxDamage * playerLevelMultiplier);
            nWeapon.GetComponent<Weapon>().damage = d;
            nWeapon.GetComponent<Weapon>().rarity = Weapon.Rarity.Common;
        }

        return nWeapon;
    }
    
}
