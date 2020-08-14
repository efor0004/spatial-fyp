using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieMaker : MonoBehaviour
{
    //the script that controls all of the puzzles in the Mouse Shapes scene

    delegate void PuzzleMethod();                                       //creates an empty method
    List<PuzzleMethod> Puzzle = new List<PuzzleMethod>();               //creates a list of empty methods

    // int PuzzlesPerLevel = 5;
   // Image Mask;
    //Text LevelText;
  
    int TotalPuzzles = 1;
    int n = 0;

    //void CreateList()
    //{
    //    //populates the list of empty methods with a function call for each puzzle
    //    //adapted from https://answers.unity.com/questions/873650/how-to-make-a-list-or-array-of-functions-with-type.html 

    //    Puzzle.Add(Puzzle1);

    //}


    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened        
       // Mask = GameObject.Find("Mask").GetComponent<Image>();
       // LevelText = GameObject.Find("LevelText").GetComponent<Text>();

        //CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        Puzzle1();
    }
    void Update()
    {
        ////called each frame
        //if (Global.piecesPlaced == Global.puzzlePieces)                    //puzzle completion 
        //{
        //    if (n + 1 == TotalPuzzles)
        //    {                                                            //if this is the last puzzle in the world
        //        Global.WorldComplete();
        //    }

        //    else if (Global.MousePuzzle == 5)
        //    {                                                            //if this is the last puzzle in the level
        //        Global.LevelComplete();
        //    }

        //    else
        //    {
        //        Global.PuzzleComplete();
        //    }
        //}

        //if (Global.NextPuzzleReady == true)
        //{
        //    if (n + 1 == TotalPuzzles) //if there are no more games
        //    {
        //        Global.MouseComplete = 1;
        //        SceneManager.LoadScene("Worlds"); //go to main menu
        //    }
        //    else
        //    {
        //        n = (Global.MouseLevel - 1) * 5 + Global.MousePuzzle;              //index of array = puzzle number -1
        //        Puzzle[n]();                                                       //calls the puzzle by indexing the array of function calls
        //    }
        //}

    }


    void Puzzle1()
    {
        //puzzle 1 in the Movie Maker
        //a test

        Debug.Log("Puzzle 1 run"); //////

        GameObject.Find("PreviousButton").GetComponent<Button>().interactable = false; //make previous button false on first puzzle

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 1;

       // Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle (those to be placed)
        Global.puzzlePieces = 1;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "TriangleI", new Vector3(0.1424218f, 0.4473302f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f), "Shape1", new Vector4(1f, 0f, 0.05237484f, 1f), false, 0, false);
        Global.RenderShapeVariable("Shape1", "Pentagon", new Vector3(0.04f, 3.84f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.531f, 0.531f, 0.531f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 1, false);


        //spawn target image
         Global.RenderPuzzleImage("MS1");  //has the touchrotate script attached --> run after all shapes are loaded

    }


}
