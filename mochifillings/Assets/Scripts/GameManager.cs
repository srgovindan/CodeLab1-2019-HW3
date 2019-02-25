using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager will track collected Onigiri 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject OnigiriContainer;


    private int maxLifes = 3;
    private int mochiLifes;
    public int MochiLifes
    {
        get
        {
            Debug.Log("Mochi Lifes was accessed");
            return mochiLifes;
        }
        set
        {
            if (mochiLifes <= 0)
            {
                // call restart level 
                mochiLifes = 3;
            }

            if (mochiLifes > maxLifes)
            {
                mochiLifes = maxLifes;
            }
            mochiLifes = value;
            Debug.Log("Mochi lifes was set to: " + value);
        }
    }

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
        
        //Set initial Mochi Lifes
        MochiLifes = maxLifes;
        
        //Find Onigiri Container
        OnigiriContainer = GameObject.Find("OnigiriContainer");
        Debug.Log(OnigiriContainer);
    }

    void Update()
    {
       LoadNextLevel();
    }

    void LoadNextLevel()
    {
        if (OnigiriContainer.transform.childCount < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    /// <summary>
    /// Increases the number of mochi lifes. 
    /// </summary>
    void _IncreaseLife()
    {
        mochiLifes +=1;
    }
    /// <summary>
    /// Increases the number of mochi lifes. 
    /// </summary>
    void _DecreaseLife()
    {
        mochiLifes -=1;
    }
    
    /// <summary>
    ///Reloads the current scene.
    /// </summary>
    void _ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Reloads the game to the 0 index scene.
    /// </summary>
    void _ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
