using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform groundChecker;
    public LayerMask groundMask;

    public Transform cameraPlace;

    public float walkSpeed = 3f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    private Vector3 velocity;
    private float groundDistance = 0.4f;
    private bool isGrounded = true;
    
    public void Move(float x, float z)
    {
        Vector3 movement = transform.right * x + transform.forward * z;
        characterController.Move(movement * walkSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}