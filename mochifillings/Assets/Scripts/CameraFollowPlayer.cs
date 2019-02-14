using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: attach script to the main camera and set the player character in the inspector 
// INTENT: main camera follows player character

public class CameraFollowPlayer : MonoBehaviour
{

    public GameObject Player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        //Debug.DrawLine(Player.transform.position,offset);
        transform.position = Player.transform.position + offset;
    }
}
