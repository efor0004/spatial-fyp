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

        Puzzle.Add(Puzzle31);
        Puzzle.Add(Puzzle32);
        Puzzle.Add(Puzzle33);
        Puzzle.Add(Puzzle34);
        Puzzle.Add(Puzzle35);

        Puzzle.Add(Puzzle36);
        Puzzle.Add(Puzzle37);
        Puzzle.Add(Puzzle38);
        Puzzle.Add(Puzzle39);
        Puzzle.Add(Puzzle40);

        Puzzle.Add(Puzzle41);
        Puzzle.Add(Puzzle42);
        Puzzle.Add(Puzzle43);
        Puzzle.Add(Puzzle44);
        Puzzle.Add(Puzzle45);

        Puzzle.Add(Puzzle46);
        Puzzle.Add(Puzzle47);
        Puzzle.Add(Puzzle48);
        Puzzle.Add(Puzzle49);
        Puzzle.Add(Puzzle50);
    }

    
    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();

        Global.LeftArrowActive = true; //reset arrow flags to true
        Global.RightArrowActive = true;

       CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        //Puzzle11();

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

        GameObject.Find("PreviousButton").GetComponent<Button>().interactable = false; //make previous button false on first puzzle

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
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(1.208f, -0.774f, 0f), new Vector3(0f, 0f, 269.8332f), new Vector3(0.285349f, 0.1898621f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 2, false);


        //spawn target image
        Global.RenderPuzzleImage("F1");

        Global.InstructionPopup(); //run instruction pop-up for first puzzle

    }

    void Puzzle2()
    {
        //puzzle 2 in the Farm scene
        //the triangle tree

        GameObject.Find("PreviousButton").GetComponent<Button>().interactable = true; //make previous button true on second puzzle

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
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.11f, -0.32f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.357885f, 0.2334883f, 1f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.69f, -0.94f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.357885f, 0.2334883f, 1f), "Shape3", new Vector4(0f, 0.7135715f, 1f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.87f, -0.95f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.357885f, 0.2334883f, 1f), "Shape4", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), true, 3, false);

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
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.48f, -0.75f, 0f), new Vector3(0f, 0f, 334.2581f), new Vector3(0.796f, -0.04065573f, 1f), "Shape5", new Vector4(0f, 0f, 0f, 1f), false, 4, false); //


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
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(0f, -2.24f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1216993f, 0.247758f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 1, false);
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
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(0.009f, -0.254f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.26f, 0.2003434f, 0.26f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(0.677f, -1.315f, 0f), new Vector3(0f, 0f, 24.95188f), new Vector3(0.3102593f, 0.1589793f, 1f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.63f, -1.31f, 0f), new Vector3(0f, 0f, 332.8086f), new Vector3(0.2933749f, 0.1445005f, 1f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(0.583f, 0.507f, 0f), new Vector3(0f, 0f, 249.8091f), new Vector3(0.3248781f, 0.3263603f, 1f), "Shape3", new Vector4(1f, 0.4292453f, 0.839632f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(-0.584f, 0.494f, 0f), new Vector3(0f, 0f, 110.1442f), new Vector3(0.3178229f, 0.3247646f, 1f), "Shape3", new Vector4(1f, 0f, 0.7190247f, 1f), true, 5, false);

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
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.677f, -1.315f, 0f), new Vector3(0f, 0f, 24.95188f), new Vector3(0.3102593f, 0.1589793f, 1f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.63f, -1.31f, 0f), new Vector3(0f, 0f, 332.8086f), new Vector3(0.2933749f, 0.1445005f, 1f), "Shape2", new Vector4(0.7818722f, 0.8018868f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Pentagon", new Vector3(0.013f, 0.4825f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4267566f, 0.4278826f, 1.126007f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.021f, 0.405f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.26391f, 0.26391f, 0.26391f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 4, true);

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
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(0.01f, 0.98f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.327278f, 0.171351f, 0.241f), "Shape4", new Vector4(0.7818722f, 0.8018868f, 0f, 1f), true, 5, false);

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
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-2.41f, -1.57f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04631065f, 0.2486429f, 1.35f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-1.56f, -2.03f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04898283f, 0.2293878f, 1.233f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 5, false);
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
        Global.puzzlePieces = 8;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.01f, -0.86f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4787944f, 0.4733556f, 1f), "Shape1", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.01f, -0.41f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2752963f, 0.3482312f, 1f), "Shape2", new Vector4(0.4150943f, 0.3328587f, 0.2643289f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Square", new Vector3(0f, 0.62f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.126776f, 0.158769f, 1f), "Shape3", new Vector4(0.02870238f, 0.4056604f, 0.3491167f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.19f, 0.93f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2176354f, 0.2052727f, 1f), "Shape3", new Vector4(0.02870238f, 0.4056604f, 0.3491167f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Trapezoid", new Vector3(0.933f, 0.58f, 0f), new Vector3(0f, 0f, 246.6553f), new Vector3(0.04613106f, 0.1733201f, 1f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-0.302f, -2.139f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0430328f, 0.1608844f, 1f), "Shape2", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Square", new Vector3(0.3494f, -2.1f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04493695f, 0.1608844f, 1f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(-0.3f, -2.5f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.168364f, 0.081f, 1f), "Shape4", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 7, false);
        Global.RenderShapeVariable("Shape8", "TriangleI", new Vector3(0.34f, -2.5f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.168364f, 0.081f, 1f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), true, 8, false);

        //spawn target image
        Global.RenderPuzzleImage("F21");
    }

    void Puzzle22()
    {
        //puzzle 22 in the Farm scene
        //the nesting hen

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape

        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.013f, -1.41f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.8060359f, 0.539082f, 1f), "Shape1", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(-0.001f, 0.381f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.263f, 0.6140332f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleI", new Vector3(0.0061f, 1.184f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.121675f, 0.1577435f, 1f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Pentagon", new Vector3(-0.0069f, 0.1985f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1900875f, 0.2274384f, 1.0275f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Parallelogram", new Vector3(-0.004f, -0.022f, 0f), new Vector3(0f, 0f, 51.26485f), new Vector3(0.1019457f, 0.1237579f, 1.0505f), "Shape4", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(0.023f, -1.9f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3796188f, 0.3174821f, 1f), "Shape2", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), true, 5, false);

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
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(-0.605f, -0.743f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.6678144f, 0.5377721f, 1.152f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.78f, 0.06f, 0f), new Vector3(0f, 0f, 307.0678f), new Vector3(0.401166f, 0.4611303f, 1.173f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleR", new Vector3(1.99f, 0.19f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.153f, 0.153f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(-0.486f, -0.858f, 0f), new Vector3(0f, 0f, 206.8207f), new Vector3(0.486492f, 0.555953f, 1.142f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Parallelogram", new Vector3(-0.89f, -2.192f, 0f), new Vector3(0f, 0f, 18.50579f), new Vector3(-0.05114123f, 0.2289625f, 1f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleR", new Vector3(-0.188f, -2.46f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.27911f, 0.124f, 1f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), false, 5, false);

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
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.027f, -0.88f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5640027f, 0.5684251f, 1.152f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.043f, 0.38f, 0f), new Vector3(0f, 0f, 1.634199f), new Vector3(0.401166f, 0.4611303f, 1.173f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Parallelogram", new Vector3(-0.005f, 0.414f, 0f), new Vector3(0f, 0f, 325.905f), new Vector3(0.110546f, 0.1379576f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(-1.2599f, -0.5033f, 0f), new Vector3(0f, 0f, 70.53029f), new Vector3(0.302611f, 0.2917798f, 1f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(1.374f, -0.486f, 0f), new Vector3(0f, 0f, 286.1068f), new Vector3(0.302611f, 0.2917798f, 1f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Trapezoid", new Vector3(-0.025f, -2.204f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.101664f, 0.200978f, 1f), "Shape2", new Vector4(1f, 0.3766058f, 0f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(-0.02f, -2.51f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.256704f, 0.142524f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F24");
    }

    void Puzzle25()
    {
        //puzzle 25 in the Farm scene
        //the duck swimming (no pond)

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 5;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.54f, -1.13f, 0f), new Vector3(0f, 0f, 179.6777f), new Vector3(0.8234361f, 0.7812593f, 1.287f), "Shape1", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(0.922f, 0.14f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1730262f, 0.142772f, 1.3277f), "Shape2", new Vector4(0f, 0.4705882f, 0.3989398f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(1.118f, 0.813f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2649086f, 0.3285978f, 1.1977f), "Shape3", new Vector4(0f, 0.4705882f, 0.3989398f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Trapezoid", new Vector3(1.958f, 0.367f, 0f), new Vector3(0f, 0f, 239.5899f), new Vector3(0.03714421f, 0.1727612f, 1f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(-0.68f, -0.77f, 0f), new Vector3(0f, 0f, 158.2689f), new Vector3(0.414119f, 0.4496968f, 0.976f), "Shape2", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), false, 4, false);

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
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.171f, -0.95f, 0f), new Vector3(0f, 0f, 179.6449f), new Vector3(0.7373138f, 0.88974f, 1f), "Shape1", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(0.94f, 0.68f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.237585f, 0.594216f, 1f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Pentagon", new Vector3(1.131f, 1.014f, 0f), new Vector3(0f, 0f, 12.61283f), new Vector3(0.1253476f, 0.2282057f, 1f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(1.753f, 0.805f, 0f), new Vector3(0f, 0f, 271.576f), new Vector3(0.0703032f, 0.1607498f, 1f), "Shape5", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleR", new Vector3(-1.4623f, 0.4352f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1594495f, 0.1837932f, 1f), "Shape3", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Trapezoid", new Vector3(-0.12f, -2.18f, 0f), new Vector3(0f, 0f, 26.16989f), new Vector3(0.05897153f, 0.2077645f, 1f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleR", new Vector3(0.3986f, -2.4086f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2360714f, 0.1193104f, 1f), "Shape4", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), false, 6, false);

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
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.171f, -0.95f, 0f), new Vector3(0f, 0f, 179.6449f), new Vector3(0.7373138f, 0.88974f, 1f), "Shape1", new Vector4(0.01775544f, 0.0840873f, 0.5377358f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(0.94f, 0.68f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.237585f, 0.594216f, 1f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Pentagon", new Vector3(1.131f, 1.014f, 0f), new Vector3(0f, 0f, 12.61283f), new Vector3(0.1253476f, 0.2282057f, 1f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(1.753f, 0.805f, 0f), new Vector3(0f, 0f, 271.576f), new Vector3(0.0703032f, 0.1607498f, 1f), "Shape5", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(-1.778f, 0.696f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.400432f, 0.5913522f, 1f), "Shape3", new Vector4(0.02870238f, 0.4056604f, 0.3491167f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(-0.38f, -0.52f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.419279f, 0.249184f, 1f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Trapezoid", new Vector3(-0.12f, -2.18f, 0f), new Vector3(0f, 0f, 27.69507f), new Vector3(0.05897153f, 0.2077645f, 1f), "Shape3", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleR", new Vector3(0.3986f, -2.4086f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2360714f, 0.1193104f, 1f), "Shape4", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), false, 7, false);

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
        Global.RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.5493f, 0.5002f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2208722f, -0.07628083f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleR", new Vector3(-0.5703f, 0.4969f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.2016866f, -0.07480234f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleR", new Vector3(0.6112f, -0.593f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2460683f, -0.07035697f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleR", new Vector3(-0.5956f, -0.5948f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.2135442f, -0.0659116f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 6, false);
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
        Global.puzzlePieces = 7;

        //spawn anchor shape

        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(0.017f, 0.29f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.032343f, 1.153168f, 1f), "Shape1", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.02f, -0.45f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5270923f, 0.5935931f, 1f), "Shape2", new Vector4(0.4150943f, 0.3328587f, 0.2643289f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.01f, -1.22f, 0f), new Vector3(0f, 0f, 89.81538f), new Vector3(0.4495122f, 0.4084448f, 1f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Trapezoid", new Vector3(-0.014f, -2.462f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.05777565f, 0.1232492f, 1f), "Shape4", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(-0.011f, -2.618f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2354813f, 0.08741634f, 1f), "Shape5", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(0.013f, -0.701f, 0f), new Vector3(0f, 0f, 180.3527f), new Vector3(0.1198047f, 0.5745956f, 1f), "Shape4", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(0f, 0.01f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1550398f, 0.1586379f, 1f), "Shape5", new Vector4(0.5528213f, 0.8380989f, 0.9528302f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(-0.004f, -0.46f, 0f), new Vector3(0f, 0f, 179.8256f), new Vector3(0.07768118f, 0.1433826f, 1f), "Shape6", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F30");
    }

    void Puzzle31()
    {
        //puzzle 31 in the Farm scene
        //the sheep front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 7;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -0.76f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.495274f, 0.583305f, 1f), "Shape1", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.001f, 0.53f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.221259f, 0.3477088f, 1.126f), "Shape2", new Vector4(0f, 0f, 0f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(-0.71f, 1.21f, 0f), new Vector3(0f, 0f, 338.1617f), new Vector3(0.1734229f, 0.1509278f, 1.147f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(0.75f, 1.18f, 0f), new Vector3(0f, 0f, 15.84028f), new Vector3(0.1775053f, 0.1544806f, 1.174f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.435f, -2.161f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.065f, 0.241f, 1f), "Shape2", new Vector4(0f, 0f, 0f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(0.55f, -2.17f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.065f, 0.241f, 1f), "Shape2", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), false, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F31");
    }

    void Puzzle32()
    {
        //puzzle 32 in the Farm scene
        //the sheep side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 7;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.1f, -0.76f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.8217031f, 0.583305f, 1f), "Shape1", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-1.69f, -0.97f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.221259f, 0.3477088f, 1.126f), "Shape2", new Vector4(0f, 0f, 0f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(-2.41f, -0.26f, 0f), new Vector3(0f, 0f, 338.1617f), new Vector3(0.1734229f, 0.1509278f, 1.147f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(-0.95f, -0.22f, 0f), new Vector3(0f, 0f, 15.84028f), new Vector3(0.1775053f, 0.1544806f, 1.174f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.79f, -2.19f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.065f, 0.241f, 1f), "Shape2", new Vector4(0f, 0f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(0.82f, -2.2f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.065f, 0.241f, 1f), "Shape2", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(2.04f, -0.74f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.14656f, 0.14656f, 0.14656f), "Shape3", new Vector4(0f, 0f, 0f, 1f), false, 6, true);

        //spawn target image
        Global.RenderPuzzleImage("F32");
    }

    void Puzzle33()
    {
        //puzzle 33 in the Farm scene
        //the cow front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 7;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0f, -0.8f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5710837f, 0.583305f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.03f, 0.33f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.221259f, 0.3477088f, 1.126f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.671f, 0.942f, 0f), new Vector3(0f, 0f, 338.1617f), new Vector3(0.1603307f, 0.086056f, 1.147f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.74f, 0.93f, 0f), new Vector3(0f, 0f, 15.84028f), new Vector3(0.1670325f, 0.08172022f, 1.174f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.73f, -2.163f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.065f, 0.241f, 1f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(0.777f, -2.153f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.065f, 0.241f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Semicircle", new Vector3(0.04f, -0.23f, 0f), new Vector3(0f, 0f, 180.7273f), new Vector3(0.1942161f, 0.2004828f, 1f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(0.02f, -1.4f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2965688f, 0.3193749f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F33");
    }

    void Puzzle34()
    {
        //puzzle 34 in the Farm scene
        //the cow side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 7;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 9;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(0.29f, -0.514f, 0f), new Vector3(0f, 0f, 180.5274f), new Vector3(0.8275002f, 0.8863484f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-1.45f, 0.12f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.221259f, 0.3477088f, 1.126f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-2.07f, 0.84f, 0f), new Vector3(0f, 0f, 338.1617f), new Vector3(0.1603307f, 0.086056f, 1.147f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.78f, 0.74f, 0f), new Vector3(0f, 0f, 15.84028f), new Vector3(0.1670325f, 0.08172022f, 1.174f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(-1.47f, -0.42f, 0f), new Vector3(0f, 0f, 180.7273f), new Vector3(0.1942161f, 0.2004828f, 1f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(0.28f, -1.12f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4915673f, 0.1782112f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Square", new Vector3(-0.697f, -1.689f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.08098886f, 0.2866454f, 1f), "Shape2", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 6, false);
        Global.RenderShapeVariable("Shape7", "Square", new Vector3(1.214f, -1.7f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.07551896f, 0.286549f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 7, false);
        Global.RenderShapeVariable("Shape8", "Square", new Vector3(2.44f, 0.03f, 0f), new Vector3(0f, 0f, 44.07355f), new Vector3(0.045045f, 0.241f, 1f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 8, false);
        Global.RenderShapeVariable("Shape9", "TriangleI", new Vector3(2.84f, -0.39f, 0f), new Vector3(0f, 0f, 38.78345f), new Vector3(0.1136403f, 0.1263334f, 1f), "Shape4", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), true, 9, false);

        //spawn target image
        Global.RenderPuzzleImage("F34");
    }

    void Puzzle35()
    {
        //puzzle 35 in the Farm scene
        //the windmill

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 7;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Trapezoid", new Vector3(0.009f, -1.37f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.296325f, 0.5325553f, 0.846f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(0.0086f, -0.0065f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2427757f, 0.1968183f, 0.8450585f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Trapezoid", new Vector3(-0.776f, -0.679f, 0f), new Vector3(0f, 0f, 308.0613f), new Vector3(0.11244f, 0.366168f, 1f), "Shape3", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Trapezoid", new Vector3(0.68f, -0.772f, 0f), new Vector3(0f, 0f, 44.32429f), new Vector3(0.11244f, 0.366168f, 1f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Trapezoid", new Vector3(0.773f, 0.591f, 0f), new Vector3(0f, 0f, 129.069f), new Vector3(0.11244f, 0.366168f, 1f), "Shape3", new Vector4(0f, 0f, 0f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Trapezoid", new Vector3(-0.645f, 0.71f, 0f), new Vector3(0f, 0f, 221.0829f), new Vector3(0.11244f, 0.366168f, 1f), "Shape3", new Vector4(0.4056604f, 0.2916426f, 0.01722142f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Hexagon", new Vector3(0f, -0.05f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0765585f, 0.0762644f, 1f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F35");
    }

    void Puzzle36()
    {
        //puzzle 36 in the Farm scene
        //the pink barn

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 8;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-0.803f, -1.261f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.57486f, 0.38522f, 1f), "Shape1", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(0.9387f, -1.2649f, 1.0763f), new Vector3(5.122642E-06f, 310.388f, 269.6192f), new Vector3(0.2637552f, 0.3396441f, 1f), "Shape2", new Vector4(0.9150943f, 0.6690548f, 0.679166f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleI", new Vector3(-0.8151f, 0.0582f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.474591f, 0.2143158f, 1f), "Shape2", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Parallelogram", new Vector3(0.262f, 0.302f, 0f), new Vector3(0f, 0f, 323.7875f), new Vector3(0.3021032f, 0.2094022f, 1f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(0.9291f, -0.3893f, 0f), new Vector3(0f, 0f, 94.10343f), new Vector3(0.1635611f, 0.2103845f, 1f), "Shape3", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-0.828f, -1.632f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.132319f, 0.217288f, 1f), "Shape3", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), true, 5, false);

        //spawn target image
        Global.RenderPuzzleImage("F36");
    }

    void Puzzle37()
    {
        //puzzle 37 in the Farm scene
        //the pig side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 8;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.39f, -0.537f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.7069083f, 0.6107688f, 0.7069083f), "Shape1", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-1.266f, 0.094f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3847501f, 0.3204969f, 0.3847501f), "Shape2", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-1.3f, 0.02f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1598488f, 0.118144f, 1.136f), "Shape3", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(1.16f, -2.057f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0745668f, 0.2127864f, 1f), "Shape2", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.44f, -2.03f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0693f, 0.2181877f, 1f), "Shape2", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-2f, 0.78f, 0f), new Vector3(0f, 0f, 38.57444f), new Vector3(0.1365692f, 0.16618f, 1.186f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(-0.44f, 0.76f, 0f), new Vector3(0f, 0f, 318.5152f), new Vector3(0.1308116f, 0.1591741f, 1.136f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Semicircle", new Vector3(2.245f, -0.021f, 0f), new Vector3(0f, 0f, 222.0782f), new Vector3(0.1598404f, 0.169926f, 1f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F37");
    }

    void Puzzle38()
    {
        //puzzle 38 in the Farm scene
        //the pig front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 8;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.02f, -0.537f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.7069083f, 0.6107688f, 0.7069083f), "Shape1", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.016f, 0.352f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3847501f, 0.3204969f, 0.3847501f), "Shape2", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(0.028f, 0.128f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1598488f, 0.118144f, 1.136f), "Shape3", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(0.41f, -2.048f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0745668f, 0.2127864f, 1f), "Shape2", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.387f, -2.03f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.0693f, 0.2181877f, 1f), "Shape2", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-0.784f, 1.009f, 0f), new Vector3(0f, 0f, 38.57444f), new Vector3(0.1365692f, 0.16618f, 1.186f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.839f, 1.026f, 0f), new Vector3(0f, 0f, 318.5152f), new Vector3(0.1308116f, 0.1591741f, 1.136f), "Shape3", new Vector4(1f, 0.7122642f, 0.7264733f, 1f), true, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F38");
    }

    void Puzzle39()
    {
        //puzzle 39 in the Farm scene
        //the horse front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 8;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(-0.021f, -0.3756f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.441f, 0.5215853f, 1f), "Shape1", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(-0.004f, 0.252f, 0f), new Vector3(0f, 0f, 179.6705f), new Vector3(0.168f, 0.3159279f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(0.0013f, -0.62f, 0f), new Vector3(0f, 0f, 180.0177f), new Vector3(0.1411781f, 0.1691712f, 1f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.326f, 1.221f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09971964f, 0.1293104f, 1f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleR", new Vector3(-0.328f, 1.224f, 0f), new Vector3(0f, 0f, 0f), new Vector3(-0.09305574f, 0.1293104f, 1f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-0.0055f, 0.7504f, 0f), new Vector3(0f, 0f, 179.1448f), new Vector3(0.07403725f, 0.1028722f, 1f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Trapezoid", new Vector3(-0.458f, -2.0875f, 0f), new Vector3(0f, 0f, 178.7963f), new Vector3(0.06039895f, 0.3638402f, 1f), "Shape2", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Trapezoid", new Vector3(0.342f, -2.097f, 0f), new Vector3(0f, 0f, 178.7963f), new Vector3(0.06039895f, 0.3638402f, 1f), "Shape2", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F39");
    }

    void Puzzle40()
    {
        //puzzle 40 in the Farm scene
        //the horse side on

        //note: fixed glitches by changing layers

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 8;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 8;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.88f, -0.57f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.820701f, 0.3990127f, 1f), "Shape1", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Trapezoid", new Vector3(-1.04f, 0.02f, 0f), new Vector3(0f, 0f, 60.92901f), new Vector3(0.1716367f, 0.377431f, 1f), "Shape2", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Trapezoid", new Vector3(-2.03f, 0.31f, 0f), new Vector3(0f, 0f, 142.1716f), new Vector3(0.168f, 0.3159279f, 1f), "Shape3", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Trapezoid", new Vector3(0.24f, -2.06f, 0f), new Vector3(0f, 0f, 178.7963f), new Vector3(0.07778376f, 0.3412392f, 1f), "Shape3", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Trapezoid", new Vector3(1.69f, -2.04f, 0f), new Vector3(0f, 0f, 182.9477f), new Vector3(0.07725798f, 0.3317f, 1f), "Shape4", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(2.89f, -1.24f, 0f), new Vector3(0f, 0f, 12.8708f), new Vector3(0.1753545f, 0.417f, 1f), "Shape5", new Vector4(0f, 0f, 0f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Semicircle", new Vector3(-2.52f, -0.35f, 0f), new Vector3(0f, 0f, 144.2929f), new Vector3(0.1411781f, 0.1691712f, 1f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleR", new Vector3(-1.91f, 1.22f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09971964f, 0.1293104f, 1f), "Shape4", new Vector4(0.764151f, 0.3647237f, 0.03244036f, 1f), true, 7, false);
        Global.RenderShapeVariable("Shape8", "Semicircle", new Vector3(-0.97f, 0.32f, 0f), new Vector3(0f, 0f, 152.841f), new Vector3(0.37f, 0.183f, 1f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 8, false);

        //spawn target image
        Global.RenderPuzzleImage("F40");
    }

    void Puzzle41()
    {
        //puzzle 41 in the Farm scene
        //the grey dog

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 9;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.1f, -0.687f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.7071042f, 0.3162852f, 1f), "Shape1", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Square", new Vector3(-0.91f, 0.51f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.254895f, 0.250848f, 1f), "Shape2", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(2.14f, 0.19f, 0f), new Vector3(0f, 0f, 225.1351f), new Vector3(0.215f, 0.197f, 1f), "Shape2", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(-0.94f, -1.79f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.06128212f, 0.216664f, 1f), "Shape2", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(0.95f, -1.83f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.06128212f, 0.216664f, 1f), "Shape2", new Vector4(0.6981132f, 0.6445877f, 0.5631008f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "TriangleR", new Vector3(-1.692f, 0.634f, 0f), new Vector3(0f, 0f, 284.2675f), new Vector3(0.1680446f, 0.1632259f, 1f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleR", new Vector3(-0.161f, 0.629f, 0f), new Vector3(0f, 0f, 74.16363f), new Vector3(-0.1637595f, 0.1632259f, 1f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Trapezoid", new Vector3(-0.9091f, 0.3136f, 0f), new Vector3(0f, 0f, 179.9535f), new Vector3(0.102702f, 0.1096832f, 1f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F41");
    }

    void Puzzle42()
    {
        //puzzle 42 in the Farm scene
        //the cat front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 9;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 8;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.01f, -1.0693f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.430205f, 0.5622178f, 1f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.022f, 0.41f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2932f, 0.2932f, 0.2932f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), true, 1, true);
        Global.RenderShapeVariable("Shape2", "TriangleR", new Vector3(0.726f, 1.029f, 0f), new Vector3(0f, 0f, 313.5851f), new Vector3(0.1489f, 0.1668f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleR", new Vector3(-0.716f, 0.99f, 0f), new Vector3(0f, 0f, 48.00928f), new Vector3(-0.1346503f, 0.1668f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Semicircle", new Vector3(-1.02f, -1.55f, 0f), new Vector3(0f, 0f, 107.1874f), new Vector3(0.354f, 0.33f, 1f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Semicircle", new Vector3(1f, -1.62f, 0f), new Vector3(0f, 0f, 249.4901f), new Vector3(0.356f, 0.331296f, 1f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Semicircle", new Vector3(-0.855f, -2.1803f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2273183f, 0.1339646f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Semicircle", new Vector3(0.921f, -2.1763f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2561985f, 0.1339646f, 1f), "Shape3", new Vector4(1f, 0.7064719f, 0f, 1f), true, 7, false);
        Global.RenderShapeVariable("Shape8", "Circle", new Vector3(-1.3f, 0.08f, 0f), new Vector3(0f, 0f, 24.76471f), new Vector3(0.08509102f, 0.4055117f, 1f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), true, 8, false);

        //spawn target image
        Global.RenderPuzzleImage("F42");
    }

    void Puzzle43()
    {
        //puzzle 43 in the Farm scene
        //the cat side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 9;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.3f, -0.1f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.805f, 0.839f, 1f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(1.8f, -0.45f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2932f, 0.2932f, 0.2932f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), true, 1, true);
        Global.RenderShapeVariable("Shape2", "TriangleR", new Vector3(2.47f, 0.25f, 0f), new Vector3(0f, 0f, 313.5851f), new Vector3(0.1489f, 0.1668f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleR", new Vector3(1.09f, 0.2f, 0f), new Vector3(0f, 0f, 48.00928f), new Vector3(-0.1346503f, 0.1668f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(1.14f, -1.83f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.08f, 0.391f, 1f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-1.49f, -1.824f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.08f, 0.388263f, 1f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-2.35f, 0.02f, 0f), new Vector3(0f, 0f, 16.74406f), new Vector3(0.1068717f, 0.48923f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), true, 6, false);

        //spawn target images
        Global.RenderPuzzleImage("F43");
    }

    void Puzzle44()
    {
        //puzzle 44 in the Farm scene
        //the green bird front on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 9;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.009f, -0.825f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.481194f, 0.463871f, 0.481194f), "Shape1", new Vector4(0.3065593f, 0.7830189f, 0.3283265f, 1f), false, 0, true);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(-1.476f, -0.621f, 0f), new Vector3(0f, 0f, 63.91113f), new Vector3(0.468981f, 0.506268f, 1f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(1.464f, -0.561f, 0f), new Vector3(0f, 0f, 303.7715f), new Vector3(0.468981f, 0.506268f, 1f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.019f, 0.651f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.35f, 0.35f, 0.35f), "Shape3", new Vector4(0.6494749f, 0.990566f, 0.6682506f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(0.028f, 0.1f, 0f), new Vector3(0f, 0f, 181.028f), new Vector3(0.109f, 0.196137f, 1f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Trapezoid", new Vector3(-0.006f, -2.192f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04896f, 0.177021f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.005f, -2.642f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2117551f, 0.07834944f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F44");
    }

    void Puzzle45()
    {
        //puzzle 45 in the Farm scene
        //the green bird side on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 9;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(0.14f, -0.75f, 0f), new Vector3(0f, 0f, 168.1927f), new Vector3(0.8096901f, 0.7736541f, 1.056f), "Shape1", new Vector4(0.3065593f, 0.7830189f, 0.3283265f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-1.57f, 0.54f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.365737f, 0.365737f, 0.365737f), "Shape2", new Vector4(0.6494749f, 0.990566f, 0.6682506f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(0.58f, -0.42f, 0f), new Vector3(0f, 0f, 176.7424f), new Vector3(0.579328f, 0.579328f, 0.579328f), "Shape2", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleI", new Vector3(-2.57f, -0.26f, 0f), new Vector3(0f, 0f, 124.7609f), new Vector3(0.13392f, 0.255045f, 1f), "Shape3", new Vector4(0f, 0f, 0f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Trapezoid", new Vector3(2.4f, -0.33f, 0f), new Vector3(0f, 0f, 103.9921f), new Vector3(0.112f, 0.224f, 1f), "Shape3", new Vector4(0.3820755f, 0.6195526f, 1f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(0.5f, -2.029f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04848991f, 0.1939464f, 1f), "Shape2", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.504f, -2.5529f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2192376f, 0.07628313f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F45");
    }

    void Puzzle46()
    {
        //puzzle 46 in the Farm scene
        //the owl standing on

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 10;
        Global.FarmPuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.013f, -0.682f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.413f, 0.6f, 1f), "Shape1", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Semicircle", new Vector3(-0.749f, -0.459f, 0f), new Vector3(0f, 0f, 72.71806f), new Vector3(0.438768f, 0.3135079f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(0.758f, -0.561f, 0f), new Vector3(0f, 0f, 282.2191f), new Vector3(0.438768f, 0.3135079f, 1f), "Shape2", new Vector4(0.6320754f, 0.3734991f, 0.1580189f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.01f, 0.56f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3368717f, 0.3368717f, 0.3368717f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.002f, 0.395f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.250266f, 0.250266f, 0.250266f), "Shape4", new Vector4(0.9811321f, 0.9306628f, 0.8098968f, 1f), false, 4, true);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(-0.002f, 0.1094f, 0.001f), new Vector3(0.7182347f, 0.01088271f, 179.6502f), new Vector3(0.06575177f, 0.114062f, 1.172f), "Shape5", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Trapezoid", new Vector3(-0.012f, -2.2163f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.05811455f, 0.1167248f, 1f), "Shape2", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(-0.01f, -2.536f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2359104f, 0.08968446f, 1f), "Shape3", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), false, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F46");
    }

    void Puzzle47()
    {
        //puzzle 47 in the Farm scene
        //the owl in flight

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 10;
        Global.FarmPuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.01f, -0.83f, 0f), new Vector3(0f, 0f, 179.4312f), new Vector3(1.527272f, 0.9707983f, 1f), "Shape1", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(0.013f, -0.682f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.413f, 0.6f, 1f), "Shape2", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.01f, 0.56f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3368717f, 0.3368717f, 0.3368717f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.002f, 0.395f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.250266f, 0.250266f, 0.250266f), "Shape4", new Vector4(0.9811321f, 0.9306628f, 0.8098968f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(-0.002f, 0.1094f, 0.001f), new Vector3(0.7182347f, 0.01088271f, 179.6502f), new Vector3(0.06575177f, 0.114062f, 1.172f), "Shape5", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Trapezoid", new Vector3(-0.04f, -2.38f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2997972f, 0.1786683f, 1f), "Shape3", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), false, 5, false);
        Global.RenderShapeVariable("Shape6", "Pentagon", new Vector3(-0.45f, -1.86f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.170562f, 0.191168f, 1f), "Shape4", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Pentagon", new Vector3(0.4f, -1.84f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.170562f, 0.191168f, 1f), "Shape4", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), true, 7, false);

        //spawn target image
        Global.RenderPuzzleImage("F47");
    }

    void Puzzle48()
    {
        //puzzle 48 in the Farm scene
        //the frog

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 10;
        Global.FarmPuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 9;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Semicircle", new Vector3(-0.01f, -0.63f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.587f, 0.916608f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.007f, 0.297f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4479049f, 0.3174937f, 1f), "Shape2", new Vector4(0.02443039f, 0.5754717f, 0.04960487f, 1f), true, 1, false);
        Global.RenderShapeVariable("Shape2", "Semicircle", new Vector3(-0.67f, 0.95f, 0f), new Vector3(0f, 0f, 24.69724f), new Vector3(0.164f, 0.193f, 1f), "Shape3", new Vector4(0.3065593f, 0.7830189f, 0.3283265f, 1f), true, 2, false);
        Global.RenderShapeVariable("Shape3", "Semicircle", new Vector3(0.69f, 0.92f, 0f), new Vector3(0f, 0f, 332.6049f), new Vector3(0.164f, 0.193f, 1f), "Shape3", new Vector4(0.3065593f, 0.7830189f, 0.3283265f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-1.3176f, -0.9367f, 0f), new Vector3(0f, 0f, 22.51048f), new Vector3(0.1567702f, 0.3510936f, 1f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(1.286f, -0.922f, 0f), new Vector3(0f, 0f, 339.4714f), new Vector3(0.1533466f, 0.329549f, 1f), "Shape2", new Vector4(0.6494749f, 0.990566f, 0.6682506f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(1.499f, -1.692f, 0f), new Vector3(0f, 0f, 76.56792f), new Vector3(0.1546894f, 0.243518f, 1f), "Shape3", new Vector4(0.6494749f, 0.990566f, 0.6682506f, 1f), false, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(-1.458f, -1.722f, 0f), new Vector3(0f, 0f, 282.3848f), new Vector3(0.1546894f, 0.243518f, 1f), "Shape3", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 7, false);
        Global.RenderShapeVariable("Shape8", "Trapezoid", new Vector3(-0.2909f, -1.5279f, 0f), new Vector3(0f, 0f, 180.6938f), new Vector3(0.05141918f, 0.2693569f, 1f), "Shape4", new Vector4(0.4877625f, 0.9150943f, 0.507962f, 1f), true, 8, false);
        Global.RenderShapeVariable("Shape9", "Trapezoid", new Vector3(0.3974f, -1.518f, 0f), new Vector3(0f, 0f, 180.6938f), new Vector3(0.05001833f, 0.2693569f, 1f), "Shape4", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 9, false);

        //spawn target image
        Global.RenderPuzzleImage("F48");
    }

    void Puzzle49()
    {
        //puzzle 49 in the Farm scene
        //the red barn

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 10;
        Global.FarmPuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-0.9f, -1.4f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.674f, 0.494f, 1f), "Shape1", new Vector4(1f, 0f, 0.05237484f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(-0.905f, 0.32f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.54648f, 0.292f, 1f), "Shape2", new Vector4(1f, 0f, 0.05237484f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Parallelogram", new Vector3(1.2096f, -1.3958f, 0f), new Vector3(0f, 0f, 13.4149f), new Vector3(0.2619911f, 0.4146946f, 1f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Parallelogram", new Vector3(0.48f, 0.311f, 0f), new Vector3(0f, 0f, 312.0205f), new Vector3(0.4306009f, 0.2770956f, 1f), "Shape3", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-0.94f, -1.74f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3853815f, 0.3382104f, 1f), "Shape3", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Parallelogram", new Vector3(1.31f, -1.15f, 0f), new Vector3(0f, 0f, 15.03945f), new Vector3(0.154305f, 0.1813579f, 1f), "Shape4", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Square", new Vector3(1f, 0.623f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.08150399f, 0.22222f, 1f), "Shape4", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), false, 6, false);

        //spawn target image
        Global.RenderPuzzleImage("F49");
    }

    void Puzzle50()
    {
        //puzzle 50 in the Farm scene
        //the pink stilts barn

        //note: still a little glitchy on last piece

        Global.NextPuzzleReady = false;

        //record level and puzzle numbers
        Global.FarmLevel = 10;
        Global.FarmPuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.FarmPuzzle - 1, Mask, LevelText, Global.FarmLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 9;

        //spawn anchor shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-0.66f, -0.93f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5282902f, 0.3872038f, 0.7838133f), "Shape1", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), false, 0, false);

        //spawn movable shapes 
        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(-0.677f, 0.41f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.423522f, 0.2263f, 0.775f), "Shape2", new Vector4(0.9528302f, 0.8443089f, 0.5797881f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Parallelogram", new Vector3(0.9963f, -0.9486f, 0f), new Vector3(0f, 0f, 13.4149f), new Vector3(0.2066882f, 0.3236986f, 0.805113f), "Shape2", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Parallelogram", new Vector3(0.409f, 0.455f, 0f), new Vector3(0f, 0f, 312.0205f), new Vector3(0.3775654f, 0.2335096f, 0.8106824f), "Shape3", new Vector4(0.7830189f, 0.4764596f, 0.4899844f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Square", new Vector3(-1.323f, 0.413f, 0f), new Vector3(0f, 0f, 313.2704f), new Vector3(0.03986017f, 0.3765796f, 1f), "Shape3", new Vector4(0.8679245f, 0.6018156f, 0.6103997f, 1f), true, 4, false);
        Global.RenderShapeVariable("Shape5", "Square", new Vector3(-1.7153f, -2.1625f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04787672f, 0.1879005f, 1f), "Shape3", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "Square", new Vector3(0.501f, -2.1625f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04787672f, 0.1879005f, 1f), "Shape4", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "Square", new Vector3(1.472f, -1.957f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.04787672f, 0.1879005f, 1f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 7, false);
        Global.RenderShapeVariable("Shape8", "Semicircle", new Vector3(-0.784f, -1.248f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1716156f, 0.4920554f, 1f), "Shape5", new Vector4(0.7075472f, 0.7075472f, 0.7075472f, 1f), false, 8, false);
        Global.RenderShapeVariable("Shape9", "Parallelogram", new Vector3(-0.8596f, -2.1792f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1437185f, 0.1879517f, 1f), "Shape5", new Vector4(0.3490566f, 0.3490566f, 0.3490566f, 1f), true, 9, false);

        //spawn target image
        Global.RenderPuzzleImage("F50");
    }
}

