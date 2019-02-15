using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManager will track collected Onigiri 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    void Start()
    {
        //SINGLETON
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
        
    }
}
