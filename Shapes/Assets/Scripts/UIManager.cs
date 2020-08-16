using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder; 

public class UIManager : MonoBehaviour
{
    //handles screen capture
    //https://www.youtube.com/watch?v=j3zGzbe9V1o

    public RecordManager recordManager; 

    public void StartVid()
    {
        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        recordManager.StartRecord(); 
    }

    public void StopVid()
    {
        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        recordManager.StopRecord();
    }
}
