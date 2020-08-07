using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //handles the background music persisting between scenes
    // adapted from https://www.youtube.com/watch?v=OeZuwgG6HJM

    static Music instance = null; 
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject); 
        }  
    }
}
