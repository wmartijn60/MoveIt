using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int playerHealth = 50;
    public int currentHealth;
    public int levelModifier = 1;
    public int ablilityModifier = 1;
    public int ablilityDelay = 20;

    public float attackDelay = 1;

    public bool ready;

    public Weapon weapon;
    public BossFight bossFight;
    public RandomItemGen randomItemGen;

    public SpriteRenderer character;
    public Image abilityButton;
    public Animator animator;

    private float attackCooldown;
    private float abilityCooldown;
    private bool abilityActive;

    void Start()
    {
        currentHealth = playerHealth * levelModifier;
        weapon = randomItemGen.GenerateRandomItem().GetComponent<Weapon>();
        attackCooldown = Time.time + 1f * attackDelay;
    }

    void Update()
    {
        if (ready && Time.time >= attackCooldown)
        {
            PlayAttack();
            attackCooldown = Time.time + 1f * attackDelay;            
        }
        if (Time.time <= abilityCooldown)
        {
            abilityButton.GetComponent<Image>().color = Color.white;
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

    public void DealDamage()
    {
        if (abilityActive)
        {
            bossFight.DamageBoss(weapon.damage * ablilityModifier);
            abilityActive = false;
            abilityCooldown = Time.time + 1f * ablilityDelay;            
        }
        else
        {
            bossFight.DamageBoss(weapon.damage);
        }
        
    }

    public void PlayAttack()
    {
        animator.Play("Attack1");
    }

    public void SwitchSide()
    {
        if (!character.flipX)
        {
            character.flipX = true;
        }
        else
        {
            character.flipX = false;
        }
        
    }

    public void ActivateAblility()
    {
        if (Time.time >= abilityCooldown && !abilityActive)
        {
            abilityButton.GetComponent<Image>().color = Color.grey;
            abilityActive = true;
        }
        
    }
}
