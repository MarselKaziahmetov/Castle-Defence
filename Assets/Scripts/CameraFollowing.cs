using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ���������� ������ �� ����������

public class CameraFollowing : MonoBehaviour
{
    public GameObject objectToFollowing;    //������, ������� ����� ��������������
    public Vector3 offset;
    public float cameraSpeed;

    public float zoomSpeed;
    public float maxZoom;
    public float minZoom;

    private float currentZoom = 1f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void FixedUpdate()
    {
        Vector3 newCameraPosition = objectToFollowing.transform.position + offset * currentZoom;
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraSpeed * Time.deltaTime);
    }
}
