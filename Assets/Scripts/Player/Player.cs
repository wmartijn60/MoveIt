using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 50;
    public int currentHealth;
    public int levelModifier = 1;

    public float attackDelay = 1;

    public bool ready;

    public Weapon weapon;
    public BossFight bossFight;
    public RandomItemGen randomItemGen;

    

    private float attackCooldown;

    void Start()
    {
        currentHealth = playerHealth * levelModifier;
        weapon = randomItemGen.GenerateRandomItem().GetComponent<Weapon>();
    }

    void Update()
    {
        if (ready && Time.time >= attackCooldown)
        {
            bossFight.DamageBoss(DealDamage());
            attackCooldown = Time.time + 1f * attackDelay;
        }

    }

    public void SetWeapon(Weapon wpn)
    {
        weapon = wpn;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    public int DealDamage()
    {
        return weapon.damage;
    }

    public void ActivateAblility()
    {
        bossFight.DamageBoss(DealDamage() * 2);
    }
}
