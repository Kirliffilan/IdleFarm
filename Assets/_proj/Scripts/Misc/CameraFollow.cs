using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector2 offset = Vector2.zero;

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 desiredPos = new(target.position.x + offset.x, 
            target.position.y + offset.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }
}
