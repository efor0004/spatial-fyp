﻿using System.Collections;
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
        Puzzle.Add(Puzzle2);
        Puzzle.Add(Puzzle3);
        Puzzle.Add(Puzzle4);
        Puzzle.Add(Puzzle5);

        Puzzle.Add(Puzzle6);
        Puzzle.Add(Puzzle7);
        Puzzle.Add(Puzzle8);
        Puzzle.Add(Puzzle9);
        Puzzle.Add(Puzzle10);

        Puzzle.Add(Puzzle11);
        Puzzle.Add(Puzzle12);
        Puzzle.Add(Puzzle13);
        Puzzle.Add(Puzzle14);
        Puzzle.Add(Puzzle15);

        Puzzle.Add(Puzzle16);
        Puzzle.Add(Puzzle17);
        Puzzle.Add(Puzzle18);
        Puzzle.Add(Puzzle19);
        Puzzle.Add(Puzzle20);

        Puzzle.Add(Puzzle21);
        Puzzle.Add(Puzzle22);
        Puzzle.Add(Puzzle23);
        Puzzle.Add(Puzzle24);
        Puzzle.Add(Puzzle25);

        Puzzle.Add(Puzzle26);
        Puzzle.Add(Puzzle27);
        Puzzle.Add(Puzzle28);
        Puzzle.Add(Puzzle29);
        Puzzle.Add(Puzzle30);
    }

    
    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();

       // CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        Puzzle30();

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
        //the round hay bale

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
        Global.RenderPuzzleImage("F1");  

    }

    void Puzzle2()
    {
        //puzzle 2 in the Farm scene
        //the triangle tree

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 1;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 1;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "TriangleI", new Vector3(-0.03f, -0.01f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.324098f, 0.609986f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(-0.013f, -1.9235f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1536004f, 0.2598308f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);

        //spawn target image
        Global.RenderPuzzleImage("F2"); 
    }


    void Puzzle3()
    {
        //puzzle 3 in the Farm scene
        //the circle tree

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 1;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 1;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(-0.005f, -1.566f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1134963f, 0.4317966f, 1f), "Shape1", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.014f, 0.232f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.403104f, 0.403104f, 0.403104f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 1, true);

        //spawn target image
        Global.RenderPuzzleImage("F3");
    }

    void Puzzle4()
    {
        //puzzle 4 in the Farm scene
        //the trough

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 1;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 1;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(0.011f, -0.544f, 0f), new Vector3(0f, 0f, 179.9374f), new Vector3(0.6953405f, 0.2912671f, 1.50282f), "Shape1", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(0f, -1.364f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4640758f, 0.08579277f, 1.514088f), "Shape2", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 1, false);

        //spawn target image
        Global.RenderPuzzleImage("F4");
    }

    void Puzzle5()
    {
        //puzzle 5 in the Farm scene
        //the tractor wagon

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 1;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 2;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(0.01f, -0.08f, 0f), new Vector3(0f, 0f, 180.3255f), new Vector3(0.443058f, 0.4217654f, 1f), "Shape1", new Vector4(1f, 0.3026949f, 0f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.036f, -1.714f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.32f, 0.32f, 0.32f), "Shape2", new Vector4(0f, 0f, 0f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(0.04f, -1.73f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.195f, 0.195f, 0.195f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), true, 2, true);


        //spawn target image
        Global.RenderPuzzleImage("F5");
    }

    void Puzzle6()
    {
        //puzzle 6 in the Farm scene
        //the nest

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 2;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 3;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -0.69f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.984f, 0.637f, 1f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.11f, -0.32f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.357885f, 0.2334883f, 1f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.69f, -0.94f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.357885f, 0.2334883f, 1f), "Shape3", new Vector4(0f, 0.7135715f, 1f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.87f, -0.95f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.357885f, 0.2334883f, 1f), "Shape4", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 3, false);

        //spawn target image
        Global.RenderPuzzleImage("F6");
    }

    void Puzzle7()
    {
        //puzzle 7 in the Farm scene
        //the house shaped tree

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 2;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 2;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.005f, -0.49f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4552859f, 0.300192f, 1f), "Shape1", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(0.003f, -1.85f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.125419f, 0.315972f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleI", new Vector3(0.006f, 0.619f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3661343f, 0.2032671f, 1f), "Shape3", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 2, false);

        //spawn target image
        Global.RenderPuzzleImage("F7");
    }

    void Puzzle8()
    {
        //puzzle 8 in the Farm scene
        //the square hay bale

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 2;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 2;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Parallelogram", new Vector3(0.083f, -0.897f, 0f), new Vector3(0f, 0f, 26.03632f), new Vector3(0.4677846f, 0.2173358f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Parallelogram", new Vector3(-0.293f, -0.126f, 0f), new Vector3(0f, 0f, 25.9614f), new Vector3(-0.4632128f, 0.1706752f, 1f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Parallelogram", new Vector3(-1.4613f, -1.2262f, 0f), new Vector3(0f, 0f, 339.3838f), new Vector3(-0.1891765f, 0.2731582f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 2, false);

        //spawn target image
        Global.RenderPuzzleImage("F8");
    }

    void Puzzle9()
    {
        //puzzle 9 in the Farm scene
        //the square red wagon

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 2;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 3;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-2.15f, -0.04f, 0f), new Vector3(0f, 0f, 310.6732f), new Vector3(0.5567303f, 0.03769343f, 1f), "Shape2", new Vector4(0f, 0f, 0f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(0.07f, -0.5f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.6682937f, 0.2391803f, 1f), "Shape1", new Vector4(1f, 0f, 0.05237484f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.62f, -1.3f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.175419f, 0.175419f, 0.175419f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.74f, -1.32f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.175419f, 0.175419f, 0.175419f), "Shape3", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), true, 3, true);

        //spawn target image
        Global.RenderPuzzleImage("F9");
    }

    void Puzzle10()
    {
        //puzzle 10 in the Farm scene
        //the square blue wheel barrow

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 2;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.01f, -0.71f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.457f, 0.331f, 1f), "Shape1", new Vector4(0f, 0.3845291f, 1f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "TriangleR", new Vector3(1.741f, -0.719f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3249949f, -0.3327077f, 1f), "Shape2", new Vector4(0f, 0.3845291f, 1f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleI", new Vector3(-0.73f, -1.74f, 0f), new Vector3(0f, 0f, 179.2627f), new Vector3(0.1038544f, 0.1471362f, 1f), "Shape5", new Vector4(0f, 0f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(1.06f, -1.49f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.278747f, 0.278747f, 0.278747f), "Shape4", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.48f, -0.75f, 0f), new Vector3(0f, 0f, 334.2581f), new Vector3(0.796f, -0.04065573f, 1f), "Shape5", new Vector4(0f, 0f, 0f, 1f), false, 4, false);


        //spawn target image
        Global.RenderPuzzleImage("F10");
    }

    void Puzzle11()
    {
        //puzzle 11 in the Farm scene
        //the two pronged tree

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 3;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.198f, -1.677f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.21866f, 0.4289213f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, false);

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(1.007f, -0.257f, 0f), new Vector3(0f, 0f, 53.03362f), new Vector3(0.3473177f, 0.08272378f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(-0.434f, -0.577f, 0f), new Vector3(0f, 0f, 314.2565f), new Vector3(0.2285819f, 0.1258446f, 1f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(1.818f, 0.745f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2558998f, 0.2558998f, 0.2558998f), "Shape5", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-1.289f, 0.282f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3483851f, 0.3483851f, 0.3483851f), "Shape4", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 4, true);

        //spawn target image
        Global.RenderPuzzleImage("F11");
    }

    void Puzzle12()
    {
        //puzzle 12 in the Farm scene
        //the straight fence

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 3;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.019f, -0.142f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.07232f, 0.065f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, false);
        Global.RenderShapeFixed("Shape1", "Square", new Vector3(0.021f, -1.136f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.07232f, 0.065f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);  //note: 2 anchor shapes toolbar shapes start 1 place over

        //spawn movable shapes   
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(-1.427f, -0.669f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132f, 0.408f, 1f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(0.02f, -0.67f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132f, 0.408f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(1.48f, -0.67f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132f, 0.408f, 1f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-1.427f, 0.502f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066068f, 0.1253439f, 1f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.022f, 0.506f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066068f, 0.1253439f, 1f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(1.481f, 0.504f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066068f, 0.1253439f, 1f), "Shape4", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F12");
    }

    void Puzzle13()
    {
        //puzzle 13 in the Farm scene
        //the angled fence

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 3;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.03f, -0.2f, 0f), new Vector3(0f, 0f, 17.39989f), new Vector3(1.07232f, 0.065f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, false);
        Global.RenderShapeFixed("Shape1", "Square", new Vector3(0.11f, -1.09f, 0f), new Vector3(0f, 0f, 17.39989f), new Vector3(1.07232f, 0.065f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(-1.48f, -1.11f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132f, 0.408f, 1f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(0.04f, -0.63f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132f, 0.408f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(1.54f, -0.18f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132f, 0.408f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-1.478f, 0.062f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066068f, 0.1253439f, 1f), "Shape4", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.04f, 0.541f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066068f, 0.1253439f, 1f), "Shape4", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(1.543f, 0.995f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066068f, 0.1253439f, 1f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F13");
    }

    void Puzzle14()
    {
        //puzzle 14 in the Farm scene
        //the beehive

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 3;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(0.02f, -2.006f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.40562f, 0.2116317f, 1f), "Shape1", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(-0.005f, -1.094f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.40562f, 0.2116317f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Trapezoid", new Vector3(0.001f, -0.172f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.40562f, 0.2116317f, 1f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(0f, 0.773f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4390411f, 0.217536f, 1f), "Shape4", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.01f, 0.694f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1066381f, 0.1066381f, 0.1066381f), "Shape5", new Vector4(0f, 0f, 0f, 1f), true, 4, true);

        //spawn target image
        Global.RenderPuzzleImage("F14");
    }

    void Puzzle15()
    {
        //puzzle 15 in the Farm scene
        //the apple tree

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 3;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.03f, -0.24f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1f, 0.666f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(0f, -2.24f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1216993f, 0.247758f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-1.641f, -0.25f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.158424f, 0.158424f, 0.158424f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.076f, -0.407f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1798775f, 0.1798775f, 0.1798775f), "Shape3", new Vector4(1f, 0f, 0.05237484f, 1f), true, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.704f, 0.686f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1206797f, 0.1206797f, 0.1206797f), "Shape4", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(1.186f, 0.493f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.112955f, 0.112955f, 0.112955f), "Shape4", new Vector4(0.7075472f, 0f, 0.5087439f, 1f), true, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(1.416f, -0.749f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.165416f, 0.1638593f, 0.1638593f), "Shape3", new Vector4(1f, 0f, 0.7190247f, 1f), true, 6, true);

        //spawn target image
        Global.RenderPuzzleImage("F15");
    }

    void Puzzle16()
    {
        //puzzle 16 in the Farm scene
        //the pink tulip

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 4;
        Global.FarmPuzzle = 1 ;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.003f, -1.479f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.01432002f, 0.4555461f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(0.009f, -0.254f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.26f, 0.2003434f, 0.26f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(0.677f, -1.315f, 0f), new Vector3(0f, 0f, 24.95188f), new Vector3(0.3102593f, 0.1589793f, 1f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.63f, -1.31f, 0f), new Vector3(0f, 0f, 332.8086f), new Vector3(0.2933749f, 0.1445005f, 1f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(0.583f, 0.507f, 0f), new Vector3(0f, 0f, 249.8091f), new Vector3(0.3248781f, 0.3263603f, 1f), "Shape3", new Vector4(1f, 0.4292453f, 0.839632f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(-0.584f, 0.494f, 0f), new Vector3(0f, 0f, 110.1442f), new Vector3(0.3178229f, 0.3247646f, 1f), "Shape3", new Vector4(1f, 0f, 0.7190247f, 1f), false, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F16");
    }

    void Puzzle17()
    {
        //puzzle 17 in the Farm scene
        //the sunflower

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 4;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.003f, -1.479f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.01432002f, 0.4555461f, 1f), "Shape1", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.677f, -1.315f, 0f), new Vector3(0f, 0f, 24.95188f), new Vector3(0.3102593f, 0.1589793f, 1f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.63f, -1.31f, 0f), new Vector3(0f, 0f, 332.8086f), new Vector3(0.2933749f, 0.1445005f, 1f), "Shape2", new Vector4(0.7818722f, 0.8018868f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Pentagon", new Vector3(0.013f, 0.4825f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4267566f, 0.4278826f, 1.126007f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.021f, 0.405f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.26391f, 0.26391f, 0.26391f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 4, true);

        //spawn target image
        Global.RenderPuzzleImage("F17");
    }

    void Puzzle18()
    {
        //puzzle 18 in the Farm scene
        //the blue scarecrow

        //note" glitchy placement of head tuft and mouth

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 4;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.05f, -1.23f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3109389f, 0.2500085f, 1.2531f), "Shape1", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(0.031f, -2.294f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.06287201f, 0.2345418f, 1f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(0.0111f, -0.4913f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5553608f, 0.09628849f, 0.9611799f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.003f, 0.317f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.273208f, 0.273208f, 0.273208f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Trapezoid", new Vector3(-0.01f, 1.129f, 0f), new Vector3(0f, 0f, 179.0659f), new Vector3(0.1165065f, 0.1041374f, 0.2558676f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(0.003f, 0.02f, 0f), new Vector3(0f, 0f, 179.5992f), new Vector3(0.1805402f, 0.1894247f, 1.418008f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F18");
    }

    void Puzzle19()
    {
        //puzzle 19 in the Farm scene
        //the orange scarecrow

        //note" glitchy placement of head tuft and mouth

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 4;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(0.05f, -1.23f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3109389f, 0.2500085f, 1.2531f), "Shape1", new Vector4(1f, 0.3766058f, 0f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(0.031f, -2.294f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.06287201f, 0.2345418f, 1f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(0.0111f, -0.4913f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5553608f, 0.09628849f, 0.9611799f), "Shape2", new Vector4(1f, 0.3766058f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.003f, 0.317f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.273208f, 0.273208f, 0.273208f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(0.003f, 0.02f, 0f), new Vector3(0f, 0f, 179.5992f), new Vector3(0.1805402f, 0.1894247f, 1.418008f), "Shape5", new Vector4(0f, 0f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(0.01f, 0.98f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.327278f, 0.171351f, 0.241f), "Shape4", new Vector4(0.7818722f, 0.8018868f, 0f, 1f), false, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F19");
    }

    void Puzzle20()
    {
        //puzzle 20 in the Farm scene
        //the lily pond

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 4;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.05f, -0.74f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.355833f, 0.7287205f, 1.232575f), "Shape1", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(1.974f, -0.937f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2366709f, 0.2366709f, 0.2366709f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(1.009f, -0.554f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2317931f, 0.2317931f, 0.2317931f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(1.02f, -1.576f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2329637f, 0.2329637f, 0.2329637f), "Shape2", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-2.41f, -1.57f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04631065f, 0.2486429f, 1.35f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-1.56f, -2.03f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04898283f, 0.2293878f, 1.233f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-1.54f, -1.06f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2119299f, 0.2119299f, 0.2119299f), "Shape4", new Vector4(0.9852834f, 1f, 0.4103774f, 1f), false, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(-2.41f, -0.64f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1745352f, 0.1745352f, 0.1745352f), "Shape5", new Vector4(0.7818722f, 0.8018868f, 0f, 1f), true, 7, true);

        //spawn target image
        Global.RenderPuzzleImage("F20");
    }

    void Puzzle21()
    {
        //puzzle 21 in the Farm scene
        //the duck

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.02f, -0.77f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.588294f, 0.588294f, 0.588294f), "Shape1", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.01f, 0.7f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.416556f, 0.3257468f, 0.416556f), "Shape2", new Vector4(0f, 0.4705882f, 0.3989398f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Parallelogram", new Vector3(0.056f, 0.244f, 0f), new Vector3(0f, 0f, 322.8435f), new Vector3(0.1236693f, 0.1431037f, 0.332f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.378f, 0.775f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0926929f, 0.0926929f, 0.0926929f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.415f, 0.803f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0926929f, 0.0926929f, 0.0926929f), "Shape4", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-0.578f, -2.079f, 0f), new Vector3(0f, 0f, 322.9961f), new Vector3(0.1684194f, 0.2103866f, 1.204947f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.633f, -2.099f, 0f), new Vector3(0f, 0f, 28.41183f), new Vector3(0.1714869f, 0.2077328f, 1.1941f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F21");
    }

    void Puzzle22()
    {
        //puzzle 22 in the Farm scene
        //the hen

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.01f, -1.22f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.847972f, 0.634f, 1f), "Shape1", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.01f, 0.17f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3422543f, 0.3422543f, 0.3422543f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Parallelogram", new Vector3(0.004f, -0.163f, 0f), new Vector3(0f, 0f, 53.54445f), new Vector3(0.0864291f, 0.09994827f, 0.655155f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(0.01f, 1.167f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1362367f, 0.1701122f, 0.916f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.01f, -1.04f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.107f, 0.209f, 1f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(-0.316f, 0.287f, 0f), new Vector3(0f, 0f, 206.1129f), new Vector3(0.1078746f, 0.1078746f, 0.1078746f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Semicircle", new Vector3(0.298f, 0.294f, 0f), new Vector3(0f, 0f, 152.9919f), new Vector3(0.1078746f, 0.1078746f, 0.1078746f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F22");
    }

    void Puzzle23()
    {
        //puzzle 23 in the Farm scene
        //the chick side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(-1.04f, -0.67f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5974934f, 0.5974934f, 0.5974934f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.59f, 0.51f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.329997f, 0.329997f, 0.329997f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(-0.83f, -0.97f, 0f), new Vector3(0f, 0f, 208.6882f), new Vector3(0.416292f, 0.416292f, 0.416292f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(1.73f, 0.46f, 0f), new Vector3(0f, 0f, 269.4442f), new Vector3(0.116586f, 0.214608f, 1f), "Shape4", new Vector4(1f, 0.4678748f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.88f, 0.66f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1031021f, 0.1031021f, 0.1031021f), "Shape5", new Vector4(0f, 0f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-1.05f, -2.35f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.06101832f, 0.1776372f, 0.514f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleR", new Vector3(-0.59f, -2.524f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.153341f, 0.09614398f, 1f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F23");
    }

    void Puzzle24()
    {
        //puzzle 24 in the Farm scene
        //the chick front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.05f, -0.662f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5060769f, 0.523456f, 0.5060769f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.007f, 0.8f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.329997f, 0.329997f, 0.329997f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.443f, 1f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.07938863f, 0.1173302f, 0.1031021f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.439f, 1.009f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.08177029f, 0.1196722f, 0.1031021f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(0.003f, -2.076f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.06323622f, 0.1314121f, 0.395266f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Parallelogram", new Vector3(0.007f, 0.446f, 0f), new Vector3(0f, 0f, 51.78432f), new Vector3(0.09743132f, 0.1088415f, 1.1689f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.005f, -2.504f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2012175f, 0.1210337f, 1f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F24");
    }

    void Puzzle25()
    {
        //puzzle 25 in the Farm scene
        //the duck in a pond

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.02f, -1.23f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.092f, 0.5795439f, 1f), "Shape1", new Vector4(0.3820755f, 0.6195526f, 1f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(-0.03f, -1.19f, 0f), new Vector3(0f, 0f, 179.0495f), new Vector3(0.6217577f, 0.5709299f, 0.469368f), "Shape2", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(1.45f, -0.25f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.275097f, 0.275097f, 0.275097f), "Shape3", new Vector4(0f, 0.4705882f, 0.3989398f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(-0.16f, -0.93f, 0f), new Vector3(0f, 0f, 163.2295f), new Vector3(0.385f, 0.385f, 0.385f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(1.56f, -0.06f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09824976f, 0.09824976f, 0.09824976f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(2.37f, -0.26f, 0f), new Vector3(0f, 0f, 270.2998f), new Vector3(0.1053322f, 0.3218185f, 1f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F25");
    }

    void Puzzle26()
    {
        //puzzle 26 in the Farm scene
        //the hen side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 6;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.21f, -1.4f, 0f), new Vector3(0f, 0f, 214.5233f), new Vector3(0.879383f, 0.879383f, 0.879383f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Pentagon", new Vector3(1.06f, 0.87f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.336105f, 0.300366f, 1f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(1.16f, 0.39f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.296676f, 0.296676f, 0.296676f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-1.94f, -1.55f, 0f), new Vector3(0f, 0f, 337.0754f), new Vector3(0.409944f, 0.2294915f, 1.102f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(2.19f, 0.45f, 0f), new Vector3(0f, 0f, 270.4231f), new Vector3(0.089866f, 0.203949f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(1.34f, -0.43f, 0f), new Vector3(0f, 0f, 20.85285f), new Vector3(0.1046704f, 0.165648f, 1f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(1.31f, 0.73f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.08405215f, 0.08405215f, 0.08405215f), "Shape4", new Vector4(0f, 0.3845291f, 1f, 1f), true, 6, true);

        //spawn target image
        Global.RenderPuzzleImage("F26");
    }

    void Puzzle27()
    {
        //puzzle 27 in the Farm scene
        //the rooster

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 6;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.056f, -1.346f, 0f), new Vector3(0f, 0f, 188.1675f), new Vector3(0.8134293f, 0.8415695f, 0.879383f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Pentagon", new Vector3(1.65f, 0.623f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.336105f, 0.300366f, 1f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(1.674f, 0.143f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.296676f, 0.296676f, 0.296676f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(-1.901f, 0.04f, 0f), new Vector3(0f, 0f, 9.460796f), new Vector3(0.5178179f, 0.6411142f, 1f), "Shape2", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(2.626f, -0.232f, 0f), new Vector3(0f, 0f, 252.9459f), new Vector3(0.089866f, 0.203949f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(1.768f, -0.763f, 0f), new Vector3(0f, 0f, 20.85285f), new Vector3(0.1046704f, 0.165648f, 1f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(1.9089f, 0.2641f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1097889f, 0.1097889f, 0.1097889f), "Shape4", new Vector4(0f, 0.4705882f, 0.3989398f, 1f), true, 6, true);

        //spawn target image
        Global.RenderPuzzleImage("F27");
    }

    void Puzzle28()
    {
        //puzzle 28 in the Farm scene
        //the tractor

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 6;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-0.322f, -0.248f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4579826f, 0.5771003f, 0.487f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(1.5f, -0.63f, 0f), new Vector3(0f, 0f, 269.9121f), new Vector3(0.277f, 0.371734f, 0.277f), "Shape2", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(-0.302f, 0.442f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3276496f, 0.1807653f, 1f), "Shape2", new Vector4(0.3820755f, 0.6195526f, 1f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-1.113f, -1.587f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4459338f, 0.4459338f, 0.4459338f), "Shape2", new Vector4(0f, 0f, 0f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(1.905f, -1.65f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2837227f, 0.2837227f, 0.2837227f), "Shape3", new Vector4(0f, 0f, 0f, 1f), false, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(-1.12f, -1.56f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2837227f, 0.2837227f, 0.2837227f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(1.93f, -1.61f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1713685f, 0.1713685f, 0.1713685f), "Shape4", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Square", new Vector3(1.48f, 0.64f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.05104677f, 0.2640191f, 1f), "Shape2", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F28");
    }

    void Puzzle29()
    {
        //puzzle 29 in the Farm scene
        //the tree with coloured fruits

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 6;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 12;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0f, -0.22f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.6009586f, 0.783289f, 0.677f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(-0.03f, -2.16f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.141245f, 0.268f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(-0.028f, -0.394f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04296885f, 0.6664533f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.5493f, 0.5002f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2208722f, -0.07628083f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleR", new Vector3(-0.5703f, 0.4969f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.2016866f, -0.07480234f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleR", new Vector3(0.6112f, -0.593f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2460683f, -0.07035697f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleR", new Vector3(-0.5956f, -0.5948f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.2135442f, -0.0659116f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 6, false);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(0.34f, 0.112f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09927668f, 0.1345628f, 1.3607f), "Shape3", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 7, false);
        Global.RenderShapeVariable("Shape8", "Circle", new Vector3(-0.3926f, 0.1154f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09719117f, 0.131736f, 1.332116f), "Shape3", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), true, 8, false);
        Global.RenderShapeVariable("Shape9", "Circle", new Vector3(0.881f, 0.295f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1008029f, 0.1366314f, 1.381618f), "Shape3", new Vector4(0.9750406f, 1f, 0f, 1f), true, 9, false);
        Global.RenderShapeVariable("Shape10", "Circle", new Vector3(-0.91f, 0.331f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09302851f, 0.1260938f, 1.275062f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), true, 10, false);
        Global.RenderShapeVariable("Shape11", "Circle", new Vector3(0.5853f, -0.9205f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1035182f, 0.140312f, 1.418836f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), true, 11, false);
        Global.RenderShapeVariable("Shape12", "Circle", new Vector3(-0.559f, -0.919f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09875373f, 0.133854f, 1.353532f), "Shape3", new Vector4(1f, 0f, 0.05237484f, 1f), true, 12, false);

        //spawn target image
        Global.RenderPuzzleImage("F29");
    }

    void Puzzle30()
    {
        //puzzle 30 in the Farm scene
        //the turkey

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 6;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Pentagon", new Vector3(-0.04f, -0.6f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.921024f, 0.921024f, 0.921024f), "Shape1", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.039f, -1.24f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3334219f, 0.447552f, 0.999f), "Shape2", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.052f, 0.229f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2286588f, 0.2286588f, 0.2286588f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(-0.05f, -2.359f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1879f, 0.1317169f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.044f, -0.618f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1231496f, 0.1681f, 1f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Parallelogram", new Vector3(-0.039f, -0.094f, 0f), new Vector3(0f, 0f, 233.9586f), new Vector3(0.08208603f, 0.09344608f, 1.134818f), "Shape5", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F30");
    }

}
