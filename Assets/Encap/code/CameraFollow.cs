using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(1, 2, -10);
    public float smoothSpeed = 8f;
    private float initialX;
    public float minY = -2f; // Adjust based on your background
    public float maxY = 0f;  // Adjust based on your background

    void Start() {
        initialX = transform.position.x;
    }
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            targetPosition.x = initialX;
            // Clamp Y position to stay within the background
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}

