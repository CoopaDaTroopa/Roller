using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;        // drag player here in Inspector
    public Vector3 offset = new Vector3(0f, 2f, -3f);
    public float smoothTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move camera
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime
        );

        // Always look at player
        transform.LookAt(target);
    }
}

