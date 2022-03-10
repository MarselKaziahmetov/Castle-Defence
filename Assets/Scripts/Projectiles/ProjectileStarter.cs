using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStarter : MonoBehaviour
{
    public float moveSpeed;
    public float timeToDestroy;

    void Start()
    {
        Invoke("DestroyProjectile", timeToDestroy);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed/100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
