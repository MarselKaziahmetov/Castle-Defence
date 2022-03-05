using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesSpanwer : MonoBehaviour
{
    public GameObject projectile;

    public float timeToReload;
    private float startTimeToReload;
    
    void FixedUpdate()
    {
        if (startTimeToReload <=0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, transform.position, transform.rotation);
                startTimeToReload = timeToReload;
            }
        }
        else
        {
            startTimeToReload -= Time.deltaTime;
        }
    }
}
