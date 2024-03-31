using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;
    Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector2 playerInput; // empty 2d coordinates
        playerInput.x = Input.GetAxis("Horizontal"); // returns a value between -1 and 1 based on the player's input (e.g., arrow keys or joystick).
        playerInput.y = Input.GetAxis("Vertical"); // returns a value between -1 and 1 based on the player's input (e.g., arrow keys or joystick).
        playerInput = Vector2.ClampMagnitude(playerInput, 1f); // pythagoras' theorem makes diagonal movement faster than purely in one direction. this makes sure that playerInput cannot be >1 regardless of direction

        Vector3 acceleration = 
            new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed; // just translates playerInput into 3D and saves it in "acceleration" var
        velocity += acceleration * Time.deltaTime; // before this, the velocity var was just empty 3d coordinates. 
            // this multiplies the direction of the joystick ("acceleration") by a very small amount (Time.deltaTime) so that the movement is fluid
            // but it adds this amount every frame so the movement speeds up
        Vector3 displacement = velocity * Time.deltaTime;
            // velocity basically = joystick direction * small amount of how much time has passed
            // every frame velocity adds up, becoming bigger and bigger
            // then its current value is used to position the object
            // We need to multiply by deltaTime again because the first time we multiplied by deltaTime - we didn't keep the value, instead, we are constantly adding it up!
        transform.localPosition += displacement;
    }    
}