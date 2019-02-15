using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager will track collected Onigiri 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject OnigiriContainer;

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
//        if (OnigiriContainer.GetComponentInChildren<GameObject>().Equals(null))
//        {
//            SceneManager.LoadScene(1);
//        }
    }
    
}
