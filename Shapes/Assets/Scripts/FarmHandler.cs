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
        Puzzle.Add(Puzzle2);
        Puzzle.Add(Puzzle3);
        Puzzle.Add(Puzzle4);
        Puzzle.Add(Puzzle5);

        Puzzle.Add(Puzzle6);
        Puzzle.Add(Puzzle7);
        Puzzle.Add(Puzzle8);
        Puzzle.Add(Puzzle9);
        Puzzle.Add(Puzzle10);

    }

    
    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();

       // CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        Puzzle10();

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

}
