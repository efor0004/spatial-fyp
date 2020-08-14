using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieMaker : MonoBehaviour
{
    //the script that controls all of the puzzles in the Mouse Shapes scene

  
    int TotalPuzzles = 1;
    int n = 0;

    void Start()
    {
        Puzzle1();
    }
    void Update()
    {


    }


    void Puzzle1()
    {
        //puzzle 1 in the Movie Maker
        //a test

        Debug.Log("Puzzle 1 run"); //////

       // GameObject.Find("PreviousButton").GetComponent<Button>().interactable = false; //make previous button false on first puzzle

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //set number of pieces in the puzzle (those to be placed)
        Global.puzzlePieces = 1;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "TriangleI", new Vector3(0.1424218f, 0.4473302f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f), "Shape1", new Vector4(1f, 0f, 0.05237484f, 1f), false, 0, false);
        Global.RenderShapeVariable("Shape1", "Pentagon", new Vector3(0.04f, 3.84f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.531f, 0.531f, 0.531f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 1, false);

        //spawn target image
        // Global.RenderPuzzleImage("MS1");  //has the touchrotate script attached --> run after all shapes are loaded

    }


}
