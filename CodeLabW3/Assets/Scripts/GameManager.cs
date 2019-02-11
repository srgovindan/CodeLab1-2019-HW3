using System.Collections;
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
            Debug.Log("Score was set to: " + value);
            score = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score = 7;
    }
 
}
