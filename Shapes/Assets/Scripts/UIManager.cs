using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class UIManager : MonoBehaviour
{
    //handles screen capture
    //https://www.youtube.com/watch?v=j3zGzbe9V1o


    public RecordManager recordManager;

    void Start()
    {
        //GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;
        //GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = false;
    }

    public void StartVid()
    {

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound              //not working?

        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false; //disable UI during record

        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = false;
        GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = true;

        foreach (string name in MovieRotate.movieArray)  //disable toolbar shapes
        {
            GameObject go = GameObject.Find(name);

            if (go)
            {
                if (MovieRotate.playArray[System.Array.IndexOf(MovieRotate.movieArray, go.name)] == false) //if "not in play"
                {
                    go.GetComponent<BoxCollider2D>().enabled = false;
                    go.GetComponent<SpriteRenderer>().enabled = false;
                }

            }
        }

        Global.Recording = true; //flag to stop shapes returning to invisiable toolbar during recording

        recordManager.StartRecord();
    }

    public void StopVid()
    {
         recordManager.StopRecord();

        Global.Recording = false; 

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound        //not working?

        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;
        GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = false;

        foreach (string name in MovieRotate.movieArray)  //enable toolbar shapes again
        {
            GameObject go = GameObject.Find(name);

            if (go)
            {
                go.GetComponent<BoxCollider2D>().enabled = true;
                go.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true; //re-enable UI after record
  
       
    }

}
