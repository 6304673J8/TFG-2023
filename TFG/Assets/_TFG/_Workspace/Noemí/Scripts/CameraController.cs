using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float minSize = 4.0f;
    public float maxSize = 8.0f;
    public float sizeSpeed = 5.0f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (target)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smoothedPosition;

            float distance = Vector3.Distance(transform.position, target.position);
            float targetSize = Mathf.Clamp(distance * 0.5f, minSize, maxSize);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, sizeSpeed * Time.deltaTime);
        }
    }
}