using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float rollForce = 15f;

    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Read WASD input (Legacy Input Manager)
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S
        float up = Input.GetAxis("Jump");
        // Convert to movement direction
        Vector3 move = new Vector3(horizontal, up*3, vertical);

        // Convert movement into rolling torque
        Vector3 torque = new Vector3(move.z, up*3, -move.x);

        // Apply torque to Rigidbody
        rb.AddTorque(torque * rollForce, ForceMode.Force);
    }
}


