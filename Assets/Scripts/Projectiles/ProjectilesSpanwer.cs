using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesSpanwer : MonoBehaviour
{
    public GameObject projectile;
    public GameObject parent;

    public float timeToReload;
    private float startTimeToReload;

    Vector3 worldPosition;
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            ObjectRotationInMouseDirection();
            if (startTimeToReload <= 0)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                startTimeToReload = timeToReload;
            }
            else
            {
                startTimeToReload -= Time.deltaTime;
            }
        }
        else
        {
            startTimeToReload -= Time.deltaTime;
        }
    }

    void ObjectRotationInMouseDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = new Vector3(hitData.point.x, parent.transform.position.y, hitData.point.z);
            parent.transform.LookAt(worldPosition);
        }
    }
}
