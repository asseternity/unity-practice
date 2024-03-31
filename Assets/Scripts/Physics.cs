using UnityEngine;

public class PhysicsBehavior : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)] float maxAcceleration = 10f;
    [SerializeField, Range(0f, 10f)] float jumpHeight = 2f;
    Vector3 velocity = Vector3.zero;
    Vector3 desiredVelocity = Vector3.zero;
    bool desiredJump = false;
    bool onGround = false;
    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        desiredVelocity = 
            new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

        desiredJump |= Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        velocity = body.velocity;

        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        velocity.x = 
            Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = 
            Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        if (desiredJump) {
            desiredJump = false;
            Jump();
        }

        body.velocity = velocity;
        
        onGround = false;
    }

    void Jump()
    {
        if (onGround)
        {
            float gravity = Physics.gravity.y;
            velocity.y += Mathf.Sqrt(-2f * gravity * jumpHeight);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }
    void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }
    void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }
}