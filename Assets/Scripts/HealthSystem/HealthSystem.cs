using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Главный скрипт системы здоровья*/

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private PlayerController player;

    public HealthSystem(PlayerController playerController)
    {
        player = playerController;
    }

    public void TakeDamage(int damagePoints)
    {
        currentHealth -= damagePoints;

        if (currentHealth <= 0)
        {
            Destroy(gameObject, 1f);
            DeathAnimation();
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

    void DeathAnimation()
    {
        player.animator.StopPlayback();
        player.animator.CrossFade("death", 0.1f);
    }
}
