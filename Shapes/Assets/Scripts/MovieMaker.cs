using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieMaker : MonoBehaviour
{
    //the script that controls all of the puzzles in the Mouse Shapes scene

    void Start()
    {
        Global.LeftArrowActiveMovie = true;                                              //instantiate buttons
        Global.RightArrowActiveMovie = true;
        // GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;
        // GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = false;

        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;
        GameObject.Find("StopRecordButton").GetComponent<Button>().interactable = false;

        PuzzleCharacters();
    }
    void Update()
    {


    }


    void PuzzleCharacters()
    {
        //loads farm and MouseShapes puzzles the Movie Maker

        //Farm World

        Global.RenderMovieVariable("F1", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 0);
        Global.RenderMovieVariable("F2", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 1);
        Global.RenderMovieVariable("F3", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 2);
        Global.RenderMovieVariable("F4", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 3);
        Global.RenderMovieVariable("F5", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 4);
        Global.RenderMovieVariable("F6", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 5);
        Global.RenderMovieVariable("F7", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 6);
        Global.RenderMovieVariable("F8", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 7);
        Global.RenderMovieVariable("F9", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 8);
        Global.RenderMovieVariable("F10", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 9);
      
        Global.RenderMovieVariable("F11", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 10);
        Global.RenderMovieVariable("F12", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 11);
        Global.RenderMovieVariable("F13", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 12);
        Global.RenderMovieVariable("F14", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 13);
        Global.RenderMovieVariable("F15", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 14);
        Global.RenderMovieVariable("F16", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 15);
        Global.RenderMovieVariable("F17", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 16);
        Global.RenderMovieVariable("F18", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 17);
        Global.RenderMovieVariable("F19", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 18);
        Global.RenderMovieVariable("F20", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 19);

        Global.RenderMovieVariable("F21", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 20);
        Global.RenderMovieVariable("F22", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 21);
        Global.RenderMovieVariable("F23", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 22);
        Global.RenderMovieVariable("F24", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 23);
        Global.RenderMovieVariable("F25", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 24);
        Global.RenderMovieVariable("F26", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 25);
        Global.RenderMovieVariable("F27", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 26);
        Global.RenderMovieVariable("F28", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 27);
        Global.RenderMovieVariable("F29", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 28);
        Global.RenderMovieVariable("F30", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 29);

        Global.RenderMovieVariable("F31", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 30);
        Global.RenderMovieVariable("F32", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 31);
        Global.RenderMovieVariable("F33", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 32);
        Global.RenderMovieVariable("F34", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 33);
        Global.RenderMovieVariable("F35", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 34);
        Global.RenderMovieVariable("F36", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 35);
        Global.RenderMovieVariable("F37", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 36);
        Global.RenderMovieVariable("F38", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 37);
        Global.RenderMovieVariable("F39", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 38);
        Global.RenderMovieVariable("F40", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 39);

        Global.RenderMovieVariable("F41", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 40);
        Global.RenderMovieVariable("F42", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 41);
        Global.RenderMovieVariable("F43", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 42);
        Global.RenderMovieVariable("F44", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 43);
        Global.RenderMovieVariable("F45", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 44);
        Global.RenderMovieVariable("F46", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 45);
        Global.RenderMovieVariable("F47", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 46);
        Global.RenderMovieVariable("F48", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 47);
        Global.RenderMovieVariable("F49", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 48);
        Global.RenderMovieVariable("F50", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 49);

        //MouseShapes

        Global.RenderMovieVariable("MS1", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 50);
        Global.RenderMovieVariable("MS2", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 51);
        Global.RenderMovieVariable("MS3", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 52);
        Global.RenderMovieVariable("MS4", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 53);
        Global.RenderMovieVariable("MS5", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 54);
        Global.RenderMovieVariable("MS6", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 55);
        Global.RenderMovieVariable("MS7", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 56);
        Global.RenderMovieVariable("MS8", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 57);
        Global.RenderMovieVariable("MS9", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 58);
        Global.RenderMovieVariable("MS10", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 59);

        Global.RenderMovieVariable("MS11", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 60);
        Global.RenderMovieVariable("MS12", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 61);
        Global.RenderMovieVariable("MS13", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 62);
        Global.RenderMovieVariable("MS14", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 63);
        Global.RenderMovieVariable("MS15", new Vector3(0.5f, 0.5f, 1.0f), "Shape2", 64);

    }


}
