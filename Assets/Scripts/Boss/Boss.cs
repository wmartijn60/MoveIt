using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealth = 100;
    public int currentHealth;
    public int levelModifier = 1;
    public int maxDamage = 5;
    public int minDamage = 1;

    public float attackDelay = 1;

    public bool ready;

    public BossFight bossFight;

    

    private float attackCooldown;

    void Start()
    {
        currentHealth = bossHealth * levelModifier;
    }

    void Update()
    {
        if (ready && Time.time >= attackCooldown)
        {
            bossFight.DamagePlayer(DealDamage());
            attackCooldown = Time.time + 1f * attackDelay;
        }

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
