﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI Credit
// Puzzle Stage & Settings GUI pack by CHOCOBALL (free on Unity Asset Store)

public class Menu : MonoBehaviour
{
    // Controls the Menu scene
    // In particular loading Settings
                        


    void Start()
    {
        //Save.SavePopup(); 

        if (Global.StartUpMenu)
        {
            Save.LoadGame();             //load saved data
            Global.StartUpMenu = false;

            Debug.Log("GenPopup: " + Global.GenPopup); 

            if (Global.GenPopup == true)
            {
                Global.LoadParentalPopup(); 
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        //update difficulty display
        if (Global.Easy)
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

        //update sound effects display
        if (Global.SoundEffects == true)
        {
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
        }
        else
        {
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
        }


        //update music display
        if (Global.Music == true)
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
        }
        else
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
        }

    }
}
