using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*������ �� �������, ������� ����� �������� ��*/

public class CollisionDamage : MonoBehaviour
{
    public int damagePoints;
    public string collisionTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            health.TakeDamage(damagePoints);
        }
    }
}
