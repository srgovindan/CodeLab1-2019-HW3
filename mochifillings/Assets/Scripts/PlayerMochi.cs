using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerMochi : MonoBehaviour
{
    // Key Codes 
    public KeyCode UpKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode DownKey;

    private Rigidbody2D mochiRB;

    private enum state
    {
        Grounded,
        Midair,
        WallCling,
    };
    private state mochiState;

    private bool isWallCling;
    private bool isMidair;
    private bool isGrounded;
    
    private float rayDistance = .2f;

    private float groundVelocity = 2f;
    private float airVelocity = 1f;
    private float diveVelocity = 5f;
    private float jumpForce = 300f;


    private LayerMask layerMask = 1 << 9; //layermask only hits terrain layer
    
    void Start()
    {
        mochiRB = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        Move();

        //Reload scene on 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        //Debug.Log("Is Grounded: " + isGrounded);
    }

    void Move()
    {
        // create empty velocity & force vectors
        Vector2 newMochiVelocity = new Vector2();
        Vector2 newMochiForce = new Vector2();
        
        // raycast to set state
        RaycastHit2D feet = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, layerMask);
        RaycastHit2D sideLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance, layerMask);
        RaycastHit2D sideRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, layerMask);
        
        if (feet)
        {
            mochiState = state.Grounded;
        }
        else
        {
            if (sideLeft || sideRight)
            {
                mochiState = state.WallCling;
            }
            else
            {
                mochiState = state.Midair;
            }
        }
        
        
        // switch case to allow different player movement
        switch (mochiState)
        {
            case state.Grounded:
                //grounded controls
                if (Input.GetKey(UpKey))
                {
                    newMochiForce += Vector2.up * jumpForce;
                }
                if (Input.GetKey(LeftKey))
                {
                    newMochiVelocity += Vector2.left * groundVelocity; 
                }
                if (Input.GetKey(RightKey))
                {
                    newMochiVelocity += Vector2.right * groundVelocity; 
                }
                break;
            case state.Midair:
                //midair controls
                
                break;
            case state.WallCling:
                //wall cling controls
                
                break;
        }
        //Debug.Log(mochiState);
        // set playerMochi forces & velocity
        mochiRB.velocity = newMochiVelocity;
        mochiRB.AddForce(newMochiForce);
    }
    
    
    
    
    
    
    void _Move()
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
        if (Input.GetKey(DownKey))
        {
                newMochiVelocity.y = +-diveVelocity;
        }
        else if (Input.GetKey(UpKey) && isGrounded)
        {
            isWallCling = false;
            isMidair = true;
            isGrounded = false;
            mochiRB.AddForce(Vector2.up * jumpForce);
        }
        // setting horizontal and dive movement velocities
        mochiRB.velocity = newMochiVelocity;
        
        // raycasting to check if grounded
        if (Physics2D.Raycast(transform.position, Vector2.down, rayDistance, layerMask))
        {
            if (isMidair)
            {
                //set velocity to zero when landing
                mochiRB.velocity = Vector2.zero;
            }
            isWallCling = false;
            isMidair = false;
            isGrounded = true;
        }
        
        // raycasting left & right to check for walls 
        if (Physics2D.Raycast(transform.position,Vector2.left,rayDistance,layerMask) || Physics2D.Raycast(transform.position,Vector2.right,rayDistance,layerMask))
        {
            //Debug.Log("Hit LEFT wall");
            isWallCling = true;
            isMidair = false;
            isGrounded = false;
            // set horizontal velocity to 0
            newMochiVelocity.x = 0;
            mochiRB.velocity = newMochiVelocity;
        }
    }
}
