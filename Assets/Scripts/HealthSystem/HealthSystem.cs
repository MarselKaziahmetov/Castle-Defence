using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Главный скрипт системы здоровья*/

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public void TakeDamage(int damagePoints)
    {
        currentHealth -= damagePoints;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHeal(int healPoints)
    {
        currentHealth += healPoints;
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
