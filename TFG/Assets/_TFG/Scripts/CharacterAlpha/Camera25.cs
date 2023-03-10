using UnityEngine;

public class Camera25 : MonoBehaviour
{
    public Transform player;
    public float camDistance;
    public float camHeight;
    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x + camDistance, player.position.y + camHeight, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
