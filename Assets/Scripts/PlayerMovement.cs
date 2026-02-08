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
       
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");     //this is using the legacy input manager, inputing WASD 
        float up = Input.GetAxis("Jump");
        // This here converts those inputs into direction
        Vector3 move = new Vector3(horizontal, up*3, vertical);

        // by using torque I was able to get the ball to move instead of just roll
        Vector3 torque = new Vector3(move.z, up*3, -move.x);

        // Apply torque to Rigidbody
        // this applies these values each frame to the call to apply force to it in the desired direction
        rb.AddTorque(torque * rollForce, ForceMode.Force);
    }
}


