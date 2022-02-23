using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт следования камеры за персонажем

public class CameraFollowing : MonoBehaviour
{
    public GameObject objectToFollowing;    //объект, который будет преследоваться
    public Vector3 offset;
    public float cameraSpeed;

    void FixedUpdate()
    {
        Vector3 newCameraPosition = objectToFollowing.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraSpeed * Time.deltaTime);
    }
}
