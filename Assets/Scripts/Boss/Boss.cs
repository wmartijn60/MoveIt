using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


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

    public Animator animator;

    private float attackCooldown;

    [SerializeField] private SceneSwitcher sceneSwitcher;

    void Start()
    {
        currentHealth = bossHealth * levelModifier;
        attackCooldown = Time.time + 1f * attackDelay;
    }

    void Update()
    {
        if (ready && Time.time >= attackCooldown)
        {            
            attackCooldown = Time.time + 1f * attackDelay;
            PlayAttack();
        }

    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            animator.Play("Death");
            bossFight.SetFightStage(false);
           sceneSwitcher.Invoke("Switchscene", 1f);
        }
    }

    public void DealDamage()
    {
        bossFight.DamagePlayer(Random.Range(minDamage, maxDamage) * levelModifier);
    }

    public void PlayAttack()
    {
        animator.Play("Attack1");
    }

}
