using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(5f, 2f, -10f);
    public float smoothTime = 0.25f;
    public float minimumX = -10f;
    public float maximumX = 10f;
    public float minimumY = -5f;
    public float maximumY = 5f;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minimumX, maximumX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minimumY, maximumY);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void LateUpdate()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minimumX, maximumX);
        float clampedY = Mathf.Clamp(transform.position.y, minimumY, maximumY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
