using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*������ �� �������, ������� ����� ��������� ��*/

public class CollisionHeal : MonoBehaviour
{
    public int healPoints;
    public string collisionTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            health.TakeHeal(healPoints);
            Destroy(gameObject);
        }
    }
}
