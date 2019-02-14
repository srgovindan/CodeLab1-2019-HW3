using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // PROPERTIES: they work like wrappers on variables
    private int score = 0;
    public int Score
    {
        get
        {
            //Debug.Log("Someone got the score.");
            return score;
        }
        set
        {
            score = value;
            if (score > 10)
            {
                //Throw a party
                Debug.Log("AWESOME");
                score = 0;
            }
            //Debug.Log("Score was set to: " + value);
        }
    }

    public static GameManager instance;

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

    void Start()
    {
        // SINGLETON PATTERN
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Score ++;
        //print("Your current score is:" + Score);
    }
 
}
