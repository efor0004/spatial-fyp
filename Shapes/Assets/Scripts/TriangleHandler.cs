using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TriangleHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the Triangle scene
    //*** SCENE NOT CURRENLTY IN USE, HANDLER SCRIPT MUST BE UPDATED (USE FARM AND MOUSE WORLDS AS REFERENCE) ***

   // delegate void PuzzleMethod();                                       //creates an empty method
   // List<PuzzleMethod> Puzzle = new List<PuzzleMethod>();               //creates a list of empty methods

   //// int PuzzlesPerLevel = 5;
   // Image Mask;
   // Text LevelText;


   // void CreateList()                                 
   // {
   //     //populates the list of empty methods with a function call for each puzzle
   //     //adapted from https://answers.unity.com/questions/873650/how-to-make-a-list-or-array-of-functions-with-type.html 

   //     Puzzle.Add(Puzzle1);
   // }

    
   // void Start()
   // {
   //     // Start is called before the first frame update

   //     Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened
   //     CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
   //     Mask = GameObject.Find("Mask").GetComponent<Image>();
   //     LevelText = GameObject.Find("LevelText").GetComponent<Text>();

   // }
   //     void Update()
   //     {
   //     //called each frame

   //         if (Global.piecesPlaced == Global.puzzlePieces)                    //puzzle completion 
   //             {
   //              Global.PuzzleComplete(); 
   //             }

   //     if (Global.NextPuzzleReady == true)
   //     {
   //         int n;
   //         n = (Global.TriangleLevel - 1) * 5 + Global.TrianglePuzzle;              //index of array = puzzle number -1
   //         Puzzle[n]();                                                       //calls the puzzle by indexing the array of function calls
   //     }

   // }

   // void Puzzle1()
   // {
   //     //puzzle 1 in the Triangle scene
   //     //the fish

   //     Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

   //     //record level and puzzle numbers
   //     Global.TriangleLevel = 1;
   //     Global.TrianglePuzzle = 1;

   //     Global.ProgressBar(Global.PuzzlesPerLevel, Global.TrianglePuzzle - 1, Mask, LevelText, Global.TriangleLevel); //updates the progress bar

   //     //set number of pieces in the puzzle
   //     Global.puzzlePieces = 5;

   //     //spawn anchor shape

   //     //spawn movable shapes   


   //     //spawn target image
   //     Global.RenderPuzzleImage("T1");  //has the touchrotate script attached --> run after all shapes are loaded

   // }

}
