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

        // this vector is used to position how far the camera will remain, and has a very cool feature of being edited in unity
        Vector3 desiredPosition = target.position + offset;

        // this allows the camera to move in way that doesnt feel like its teleporting from one spot to another
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime
        );

        // self exaplainatory right?
        transform.LookAt(target);
    }
}

