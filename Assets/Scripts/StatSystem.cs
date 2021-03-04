using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public int baseDamage = 5;
    public int currentHealth = 20;
    public int maxHealth = 20;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void DealDamage(int incommingDamage)
    {
        currentHealth -= incommingDamage;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public virtual int CalculateDamage()
    {
        return baseDamage;
    }


}

