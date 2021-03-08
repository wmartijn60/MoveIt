using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int BossHealth = 100;
    public int levelModifier = 1;
    public int maxDamage = 5;
    public int minDamage = 1;
    public int attackDelay = 1;

    private int currentHealth;

    void Start()
    {
        currentHealth = BossHealth * levelModifier;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    public int DealDamage()
    {
        return Random.Range(minDamage,maxDamage) * levelModifier;
    }
}
