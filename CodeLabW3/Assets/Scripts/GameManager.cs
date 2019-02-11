﻿using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (score > 10)
            {
                //Throw a party
                Debug.Log("AWESOME");
                score = 0;
            }
            Debug.Log("Score was set to: " + value);
        }
    }


//Health variable that only ranges from 0 to 100
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health > 100)
            {
                health = 100;
            }
            else if (health < 0)
            {
                health = 0;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score ++;
    }
 
}
