using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FarmHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the Farm scene

    delegate void PuzzleMethod();                                       //creates an empty method
    List<PuzzleMethod> Puzzle = new List<PuzzleMethod>();               //creates a list of empty methods

   // int PuzzlesPerLevel = 5;
    Image Mask;
    Text LevelText;
    int TotalPuzzles = 50;
    int n = 0;

    void CreateList()                                 
    {
        //populates the list of empty methods with a function call for each puzzle
        //adapted from https://answers.unity.com/questions/873650/how-to-make-a-list-or-array-of-functions-with-type.html 

        Puzzle.Add(Puzzle1);

    }

    
    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();

        CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        //Puzzle1();

    }
    void Update()
        {
        //called each frame
        if (Global.piecesPlaced == Global.puzzlePieces)                    //puzzle completion 
        {
            if (n + 1 == TotalPuzzles)
            {                                                            //if this is the last puzzle in the world
                Global.WorldComplete();
            }

            else if (Global.FarmPuzzle == 5)
            {                                                            //if this is the last puzzle in the level
                Global.LevelComplete();
            }

            else
            {
                Global.PuzzleComplete();
            }
        }

        if (Global.NextPuzzleReady == true)
        {
            if (n + 1 == TotalPuzzles) //if there are no more games
            {
                Global.FarmComplete = 1;
                SceneManager.LoadScene("Worlds"); //go to main menu
            }
            else
            {
                n = (Global.FarmLevel - 1) * 5 + Global.FarmPuzzle;              //index of array = puzzle number -1
                Puzzle[n]();                                                       //calls the puzzle by indexing the array of function calls
            }
        }

    }

    void Puzzle1()
    {
        //puzzle 1 in the Farm scene
        //the hay bale

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 1;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 2;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(0.228f, -0.776f, -3.31947E-10f), new Vector3(0.008076272f, 358.7235f, 270.0539f), new Vector3(0.356816f, 0.3529578f, 1f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.62f, -0.7746f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5103456f, 0.5074584f, 1.07212f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(1.208f, -0.774f, 0f), new Vector3(0f, 0f, 269.8332f), new Vector3(0.285349f, 0.1898621f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 2, false);


        //spawn target image
        Global.RenderPuzzleImage("F1");  //has the touchrotate script attached --> run after all shapes are loaded

    }

}
