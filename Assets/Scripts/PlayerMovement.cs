using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody my_rigidbody;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            Vector3 movement = Vector3.left * Time.deltaTime * moveSpeed;
            my_rigidbody.MovePosition(transform.position + movement);
        }   
        if (Input.GetKey("right"))
        {
            Vector3 movement = Vector3.right * Time.deltaTime * moveSpeed;
            my_rigidbody.MovePosition(transform.position + movement);        
        }        
        if (Input.GetKey("up"))
        {
            Vector3 movement = Vector3.forward * Time.deltaTime * moveSpeed;
            my_rigidbody.MovePosition(transform.position + movement);        
        }        
        if (Input.GetKey("down"))
        {
            Vector3 movement = -Vector3.forward * Time.deltaTime * moveSpeed;
            my_rigidbody.MovePosition(transform.position + movement);        
        }                
        if (Input.GetKey("space"))
        {
            Vector3 movement = Vector3.up * Time.deltaTime * moveSpeed;
            my_rigidbody.MovePosition(transform.position + movement);        
        }        
    }
}
