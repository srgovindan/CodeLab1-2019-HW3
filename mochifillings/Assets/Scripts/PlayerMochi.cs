using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerMochi : MonoBehaviour
{
    // Key Codes 
    public KeyCode JumpKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode DiveKey;

    private Rigidbody2D mochiRB;

    private bool isWallCling;
    private bool isMidair;
    private bool isGrounded;
    private float rayDistance = .2f;

    private float groundVelocity = 2f;
    private float jumpVelocity = 5f;
    private float diveVelocity = 5f;

    private LayerMask layerMask;
    
    void Start()
    {
        mochiRB = GetComponent<Rigidbody2D>();  
        // setting up layer mask to only raycast on terrain layer
        layerMask = 1 << 9;
    }

    void Update()
    {
        Move();
        WallCling();

        //Reload scene on 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        //Debug.Log("Is Grounded: " + isGrounded);
    }

    void WallCling()
    {
        //LEFT
        if (Physics2D.Raycast(transform.position,Vector2.left,rayDistance,layerMask))
        {
         Debug.Log("Hit LEFT wall");   
        }
        //RIGHT
        if (Physics2D.Raycast(transform.position,Vector2.right,rayDistance,layerMask))
        {
            Debug.Log("Hit RIGHT wall");   
        }     
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
            mochiRB.AddForce(Vector2.up * 300);
        }
        
        // set new Mochi velocity 
        mochiRB.velocity = newMochiVelocity;
        
        // raycasting to check if grounded
        if(Physics2D.Raycast(transform.position,Vector2.down, rayDistance,layerMask))
        {
            //Debug.Log("Setting is grounded to true");
            isGrounded = true;
        }
        else
        {
            //Debug.Log("Setting is grounded to false");
            isGrounded = false;
        }
    }
}
