using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI Credit
// Puzzle Stage & Settings GUI pack by CHOCOBALL (free on Unity Asset Store)

public class Menu : MonoBehaviour
{
    // Controls the Menu scene
    // Loads saved data and manages Settings
    // triggered when app is opened (menu scene runs)
                      
    void Start()
    {

        if (Global.StartUpMenu)              //if it is the first loading of this scene in a session
        {
            Save.LoadGame();                 //load saved data
            Global.StartUpMenu = false;

            if (Global.GenPopup == true)
            {
                Global.LoadParentalPopup(); 
            }
        }

    }

    void Update()
    {
  
        if (Global.Easy)                                                                  //update difficulty display in settings
        {
            Global.positionTolerance = Global.EasyPositionTolerance;
            Global.rotationTolerance = Global.EasyRotationTolerance;

            GameObject.Find("EasyButton").GetComponent<Image>().color = Color.white;
            GameObject.Find("MediumButton").GetComponent<Image>().color = Color.black;
            GameObject.Find("HardButton").GetComponent<Image>().color = Color.black;
        }
        else if (Global.Medium)
        {
            Global.positionTolerance = Global.MediumPositionTolerance;
            Global.rotationTolerance = Global.MediumRotationTolerance;

            GameObject.Find("EasyButton").GetComponent<Image>().color = Color.black;
            GameObject.Find("MediumButton").GetComponent<Image>().color = Color.white;
            GameObject.Find("HardButton").GetComponent<Image>().color = Color.black;

        }
        else if (Global.Hard)
        {
            Global.positionTolerance = Global.HardPositionTolerance;
            Global.rotationTolerance = Global.HardRotationTolerance;

            GameObject.Find("EasyButton").GetComponent<Image>().color = Color.black;
            GameObject.Find("MediumButton").GetComponent<Image>().color = Color.black;
            GameObject.Find("HardButton").GetComponent<Image>().color = Color.white;

        }
        else
        {
            Debug.Log("Error. neither easy nor medium nor hard is true");
        }

        
        if (Global.SoundEffects == true)                                            //update sound effects display in settings
        {
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
        }
        else
        {
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
        }


       
        if (Global.Music == true)                                                   //update music display in settings
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
        }
        else
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
        }

    }
}
