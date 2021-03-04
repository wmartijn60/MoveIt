using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int baseDamage;
    public int currentHealth;
    private int maxHealth;
    private int health;
    private int damage;


    public void DealDamage(int incommingDamage)
    {
        health -= incommingDamage;
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    private int CalculateDamage(int weaponDamage)
    {
        return baseDamage + weaponDamage;
    }


}

