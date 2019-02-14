using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMochi : MonoBehaviour
{
    // Key Codes 
    public KeyCode JumpKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode DiveKey;

    private Rigidbody2D mochiRB;
    private bool isGrounded;
    private float distanceToGround = .5f;

    private float groundVelocity = 2f;
    private float jumpVelocity = 5f;
    private float diveVelocity = 5f;

    private LayerMask layerMask;
    
    void Start()
    {
        mochiRB = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        Move();
        Debug.Log("Is Grounded: " + isGrounded);
    }

    void Move()
    {
        Vector2 newMochiVelocity = new Vector2();
        if (Input.GetKey(LeftKey))
        {
            newMochiVelocity.x += -groundVelocity;
        }
        if (Input.GetKey(RightKey))
        {
            newMochiVelocity.x += groundVelocity;
        }
        if (Input.GetKey(DiveKey))
        {
                newMochiVelocity.y = +-diveVelocity;
        }
        else if (Input.GetKey(JumpKey) && isGrounded)
        {
            //newMochiVelocity.y += jumpVelocity;
            mochiRB.AddForce(Vector2.up * 500);
        }
        
        // set new Mochi velocity 
        mochiRB.velocity = newMochiVelocity;
  
        
        // setting up layer mask to only raycast on terrain layer
        layerMask = 1 << 9;
        // raycasting to check if grounded
        if(Physics2D.Raycast(transform.position,Vector2.down, distanceToGround,layerMask))
        {
            Debug.Log("Setting is grounded to true");
            isGrounded = true;
        }
        else
        {
            Debug.Log("Setting is grounded to false");
            isGrounded = false;
        }
    }
}
