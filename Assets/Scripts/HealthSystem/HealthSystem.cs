using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*������� ������ ������� ��������*/

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
