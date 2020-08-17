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
        GameObject.Find("StartButton").GetComponent<Button>().interactable = true;
        GameObject.Find("StopButton").GetComponent<Button>().interactable = false;
    }

    public void StartVid()
    {
        //if (Global.SoundEffects == true)
        //{
        //    FindObjectOfType<AudioManager>().Play("Button"); //plays button sound    //not working
        //    Debug.Log("true: SoundEffects: " + Global.SoundEffects);
        //    GameObject.Find("TimerText").GetComponent<Text>().text = "true";
        //}
        //else 
        //{
        //    Debug.Log("false: SoundEffects: " + Global.SoundEffects);
        //    GameObject.Find("TimerText").GetComponent<Text>().text = "false";
        //}

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound      //not working

        GameObject.Find("StartButton").GetComponent<Button>().interactable = false;
        GameObject.Find("StopButton").GetComponent<Button>().interactable = true;

        recordManager.StartRecord();
    }

    public void StopVid()
    {
        recordManager.StopRecord();

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound      //not working

        GameObject.Find("StartButton").GetComponent<Button>().interactable = true;
        GameObject.Find("StopButton").GetComponent<Button>().interactable = false;
    }

    //public void RecordButton()                
    //{                                                      //does NOT WORK
    //    //starts recording audio and screencapturing
    //    // triggered by pressing green button in movie-maker

    //    if (Global.SoundEffects == true)
    //        FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

    //    Global.Recording = !Global.Recording; //toggle value

    //    if (Global.Recording == false) //not recording -> start recording
    //    {
    //        GameObject.Find("RecordButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("start"); //green - not recording
    //        GameObject.Find("RecordText").GetComponent<Text>().text = "START";

    //        recordManager.StartRecord();

    //    }
    //    else   //recording -> stop recording
    //    {
    //        recordManager.StopRecord();

    //        GameObject.Find("RecordButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("stop"); //red - currently recording
    //        GameObject.Find("RecordText").GetComponent<Text>().text = "STOP";

           
    //    }

    //}

}
