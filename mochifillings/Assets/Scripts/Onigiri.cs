using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onigiri : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Entered collision.");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with player.");
            // play sound then dissappear 
            // maybe countdown UI 
            transform.position = other.transform.position + new Vector3(-.25f,0,0);
            transform.parent = other.transform;// child the onigiri to the player mochi
            //gameObject.AddComponent<Rigidbody2D>();
            //gameObject.AddComponent<PlayerMochi>();

            //Destroy(gameObject.GetComponent<Onigiri>());
        }
    }
}
