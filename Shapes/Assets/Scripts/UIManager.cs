using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class UIManager : MonoBehaviour
{
    //handles the prep work before and after screen capture
    //screen capture adapted from https://www.youtube.com/watch?v=j3zGzbe9V1o
    //api 21-26 inclusive 

    public RecordManager recordManager;
    void Start()
    {
        
    }

    public void StartVid()
    {

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;                             //disable UI during record

        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = false;
        GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = true;

        foreach (string name in MovieRotate.movieArray)                                                  //disable toolbar shapes
        {
            GameObject go = GameObject.Find(name);

            if (go)
            {
                if (MovieRotate.playArray[System.Array.IndexOf(MovieRotate.movieArray, go.name)] == false) //if "not in play" (in toolbar)
                {
                    go.GetComponent<CircleCollider2D>().enabled = false;
                    go.GetComponent<SpriteRenderer>().enabled = false;
                }

            }
        }

        Global.Recording = true;                                                                       //flag to stop shapes returning to invisiable toolbar during recording

        recordManager.StartRecord();                                                                  //starts recording (code from plug-in)
    }

    public void StopVid()
    {
        recordManager.StopRecord();                                                                 //stops recording (code from plug-in)

        Global.Recording = false; 

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button");  

        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;
        GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = false;

        foreach (string name in MovieRotate.movieArray)                                             //enable toolbar shapes again
        {
            GameObject go = GameObject.Find(name);

            if (go)
            {
                go.GetComponent<CircleCollider2D>().enabled = true;
                go.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;                           //re-enable UI after record
  
       
    }

}
