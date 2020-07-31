using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the Mouse Shapes scene

    delegate void PuzzleMethod();                                       //creates an empty method
    List<PuzzleMethod> Puzzle = new List<PuzzleMethod>();               //creates a list of empty methods

   // int PuzzlesPerLevel = 5;
    Image Mask;
    Text LevelText;
    int TotalPuzzles = 15;
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
    }

    
    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened        
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();

        CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        //Puzzle15();
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

            else if (Global.MousePuzzle == 5)
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
                Global.MouseComplete = 1;
                SceneManager.LoadScene("Worlds"); //go to main menu
            }
            else
            {
                n = (Global.MouseLevel - 1) * 5 + Global.MousePuzzle;              //index of array = puzzle number -1
                Puzzle[n]();                                                       //calls the puzzle by indexing the array of function calls
            }
        }

    }


    void Puzzle1()
    {
        //puzzle 1 in the Mouse Shapes scene
        //the house 

        GameObject.Find("PreviousButton").GetComponent<Button>().interactable = false; //make previous button false on first puzzle

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle (those to be placed)
        Global.puzzlePieces = 1;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-0.02f, -1.19f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4931631f, 0.4931631f, 0.4931631f), "Shape1", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(-0.0159f, 0.61f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.487235f, 0.285789f, 0.439f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 1, false);

        //spawn target image
        Global.RenderPuzzleImage("MS1");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle2()
    {
        //puzzle 2 in the Mouse Shapes scene
        //the tree 

        GameObject.Find("PreviousButton").GetComponent<Button>().interactable = true; //make previous button true on second puzzle

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 1;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.09f, -1.71f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1159224f, 0.1780652f, 1.309f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 0, false);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(0.08f, -0.1f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2759099f, 0.5331357f, 1.254f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 1, false);

        //spawn target image
        Global.RenderPuzzleImage("MS2");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle3()
    {
        //puzzle 3 in the Mouse Shapes scene
        //the tree and house

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0f, -0.58f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.7401015f, 0.5834169f, 1f), "Shape1", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "Square", new Vector3(-0.902f, -1.227f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3335518f, 0.2961208f, 0.8318f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleI", new Vector3(-0.92f, 0.11f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3371702f, 0.2719221f, 0.2719221f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(1.441f, -1.57f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.088558f, 0.1360315f, 1f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(1.44f, -0.243f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2200239f, 0.4251481f, 1f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 4, false);


        //spawn target image
        Global.RenderPuzzleImage("MS3");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle4()
    {
        //puzzle 4 in the Mouse Shapes scene
        //the tree house and sun

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(-0.009f, -0.4584f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.029177f, 0.5834169f, 1f), "Shape1", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "Square", new Vector3(-1.56f, -1.102f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3335518f, 0.2961208f, 0.8318f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleI", new Vector3(-1.55f, 0.21f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3371702f, 0.2719221f, 0.2719221f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Square", new Vector3(0.31f, -1.44f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.088558f, 0.1360315f, 1f), "Shape3", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 3, false);
        Global.RenderShapeVariable("Shape4", "TriangleI", new Vector3(0.284f, -0.114f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2200239f, 0.4251481f, 1f), "Shape2", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), false, 4, false);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(1.65f, 0.22f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.27654f, 0.27654f, 0.27654f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 5, true);


        //spawn target image
        Global.RenderPuzzleImage("MS4");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle5()
    {
        //puzzle 5 in the Mouse Shapes scene
        //the wagon

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 2;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.12f, -0.49f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.005744f, 0.2132736f, 1.12888f), "Shape1", new Vector4(1f, 0.3766058f, 0f, 1f), false, 0, false);
        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-1.09f, -1.098f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.345744f, 0.345744f, 0.345744f), "Shape2", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(1.32f, -1.14f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.345744f, 0.345744f, 0.345744f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 2, true);


        //spawn target image
        Global.RenderPuzzleImage("MS5");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle6()
    {
        //puzzle 6 in the Mouse Shapes scene
        //the book

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 2;
        Global.MousePuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 1;

        //spawn shapes
        Global.RenderShapeFixed("Shape0", "Parallelogram", new Vector3(1.06f, -0.51f, 0f), new Vector3(0f, 0f, 17.73857f), new Vector3(0.3540921f, 0.3540921f, 0.3540921f), "Shape1", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 0, false);
        Global.RenderShapeVariable("Shape1", "Parallelogram", new Vector3(-0.84f, -0.56f, 0f), new Vector3(0f, 0f, 345.4295f), new Vector3(-0.3353252f, 0.3540921f, 0.3540921f), "Shape2", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1, false);

        //spawn target image
        Global.RenderPuzzleImage("MS6");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle7()
    {
        //puzzle 7 in the Mouse Shapes scene
        //the fish

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 2;
        Global.MousePuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn  shapes
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.45f, -0.97f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.109f, 0.592f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "TriangleR", new Vector3(-3.23f, -0.86f, 0f), new Vector3(0f, 0f, 132.8008f), new Vector3(0.4183661f, 0.3734069f, 0.495f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleR", new Vector3(0.48f, 0.62f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4347749f, 0.1773904f, 0.291346f), "Shape2", new Vector4(0f, 0.7135715f, 1f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.259f, -0.721f, 0f), new Vector3(0f, 0f, 27.04025f), new Vector3(0.3475402f, 0.2874415f, 0.264f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 3, false);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(1.6992f, -0.5492f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1752192f, 0.1752192f, 0.162f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(1.71f, -0.549f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1362686f, 0.1318552f, 0.1186388f), "Shape4", new Vector4(0f, 0f, 0f, 1f), true, 5, true);

        //spawn target image
        Global.RenderPuzzleImage("MS7");  //has the touchrotate script attached --> run after all shapes are loaded

    }


    void Puzzle8()
    {
        // puzzle 8 in the Mouse Shapes scene
        // the cat face

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 2;
        Global.MousePuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 9;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -0.83f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.7795436f, 0.7795436f, 0.7795436f), "Shape1", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), false, 0, true);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(1.79f, 0.66f, 0f), new Vector3(0f, 0f, 314.8847f), new Vector3(0.2457284f, 0.2692189f, 0.9561415f), "Shape2", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "TriangleR", new Vector3(-1.86f, 0.56f, 0f), new Vector3(0f, 0f, 51.59638f), new Vector3(-0.2789333f, 0.3027976f, 1.048f), "Shape2", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), false, 2, false);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-0.69f, -0.45f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1260679f, 0.1260679f, 1.401613f), "Shape4", new Vector4(0.0201524f, 0f, 0.754717f, 1f), true, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.89f, -0.447f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1216024f, 0.1216024f, 1.322655f), "Shape4", new Vector4(0f, 0.3845291f, 1f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "TriangleI", new Vector3(0.074f, -1.34f, 0f), new Vector3(0f, 0f, 179.1029f), new Vector3(0.1235724f, 0.1041851f, 1.540362f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 5, false);
        Global.RenderShapeVariable("Shape6", "TriangleI", new Vector3(-0.28f, -1.98f, 0f), new Vector3(0f, 0f, 162.2769f), new Vector3(0.11f, 0.11f, 0.9182897f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 6, false);
        Global.RenderShapeVariable("Shape7", "TriangleI", new Vector3(0.44f, -1.989f, 0f), new Vector3(0f, 0f, 197.4107f), new Vector3(0.11f, 0.11f, 0.9353637f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 7, false);
        Global.RenderShapeVariable("Shape8", "TriangleI", new Vector3(-0.86f, -1.62f, 0f), new Vector3(0f, 0f, 134.5187f), new Vector3(0.11f, 0.11f, 1.314814f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 8, false);
        Global.RenderShapeVariable("Shape9", "TriangleI", new Vector3(1.034f, -1.6f, 0f), new Vector3(0f, 0f, 228.8403f), new Vector3(0.11f, 0.11f, 0.9191778f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 9, false);

        //spawn target image
        Global.RenderPuzzleImage("MS8");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle9()
    {
        // puzzle 9 in the Mouse Shapes scene
        // the arm-less mouse

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 2;
        Global.MousePuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 8;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -1.02f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5137529f, 0.4958907f, 0.4252922f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 0, true);


        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(0.05999997f, -0.1f, 0.01f), new Vector3(0f, 0f, 179.1464f), new Vector3(0.3603483f, 0.4349289f, 0.3603483f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.71f, 0.71f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2379704f, 0.2379704f, 0.2379704f), "Shape4", new Vector4(1f, 0.3026949f, 0f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.86f, 0.71f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2471231f, 0.2471231f, 0.2471231f), "Shape4", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.25f, -0.17f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1485383f, 0.1485383f, 0.1485383f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(0.438f, -0.19f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.145177f, 0.145177f, 0.145177f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-0.241f, -0.18f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09979951f, 0.09979951f, 0.09979952f), "Shape5", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(0.448f, -0.198f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09902804f, 0.09902804f, 0.09902804f), "Shape5", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 7, true);
        Global.RenderShapeVariable("Shape8", "Square", new Vector3(0.9f, -2.28f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.208962f, 0.08692878f, 1f), "Shape3", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), false, 8, false);



        //spawn target image
        Global.RenderPuzzleImage("MS9");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle10()
    {
        // puzzle 10 in the Mouse Shapes scene
        // the collapsed mouse

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 2;
        Global.MousePuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -1.02f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5137529f, 0.4958907f, 0.4252922f), "Shape2", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, true);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(-0.85f, -2.03f, 0f), new Vector3(358.8159f, 357.4445f, 128.5431f), new Vector3(0.3603483f, 0.464489f, 0.3603483f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.69f, -0.7f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.49f, -1.94f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(1f, 0f, 0.05237484f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.92f, -1.64f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1562903f, 0.1562903f, 0.1562903f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(-0.43f, -2.18f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1562387f, 0.1562387f, 0.1562387f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-0.92f, -1.65f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09426609f, 0.09426609f, 0.0942661f), "Shape5", new Vector4(0.0201524f, 0f, 0.754717f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(-0.4f, -2.18f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09814046f, 0.09814046f, 0.09814046f), "Shape5", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), true, 7, true);


        //spawn target image
        Global.RenderPuzzleImage("MS10");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle11()
    {
        // puzzle 11 in the Mouse Shapes scene
        // the square mouse

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 3;
        Global.MousePuzzle = 1;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 12;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.01f, -1.12f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4252922f, 0.4252922f, 0.4252922f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(0.08f, 0.4966f, 0f), new Vector3(0f, 0f, 329.6572f), new Vector3(0.3603483f, 0.3603483f, 0.3603483f), "Shape3", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.992f, 0.319f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.45f, 1.086f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(1f, 0f, 0.05237484f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.199f, -0.095f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1396197f, 0.1396197f, 0.1396197f), "Shape4", new Vector4(1f, 0.3026949f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(0.452f, 0.224f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1412264f, 0.1412264f, 0.1412264f), "Shape4", new Vector4(1f, 0.6183392f, 0.1179245f, 1f), true, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-0.1930001f, -0.0999999f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.100943f, 0.100943f, 0.100943f), "Shape5", new Vector4(0.0201524f, 0f, 0.754717f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(0.463f, 0.231f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09614316f, 0.09614316f, 0.09614316f), "Shape5", new Vector4(0f, 0.3845291f, 1f, 1f), true, 7, true);
        Global.RenderShapeVariable("Shape8", "Square", new Vector3(-0.9736f, -2.2652f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2177115f, 0.08069123f, 1f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 8, false);
        Global.RenderShapeVariable("Shape9", "Square", new Vector3(0.9936f, -2.2647f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2177115f, 0.08089081f, 1f), "Shape3", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 9, false);
        Global.RenderShapeVariable("Shape10", "Square", new Vector3(-1.4952f, -0.5604f, 0f), new Vector3(0f, 0f, 337.8174f), new Vector3(0.2858144f, 0.06361307f, 1f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 10, false);
        Global.RenderShapeVariable("Shape11", "Square", new Vector3(1.5275f, -0.5197f, 0f), new Vector3(0f, 0f, 22.80273f), new Vector3(0.2899614f, 0.06707884f, 1f), "Shape3", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 11, false);
        Global.RenderShapeVariable("Shape12", "Semicircle", new Vector3(-1.5312f, -1.3971f, 0f), new Vector3(0f, 0f, 139.4809f), new Vector3(0.3010172f, 0.1875972f, 1f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 12, false);

        //spawn target image
        Global.RenderPuzzleImage("MS11");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle12()
    {
        // puzzle 12 in the Mouse Shapes scene
        // the red circle mouse 

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 3;
        Global.MousePuzzle = 2;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 12;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -1.02f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5137529f, 0.4958907f, 0.4252922f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 0, true);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(0.42f, 0.25f, 0f), new Vector3(-2.134434E-07f, 357.0003f, 292.9856f), new Vector3(0.3603483f, 0.3603483f, 0.3603483f), "Shape3", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.514f, 0.655f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(1f, 0.4678748f, 0f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.995f, 0.534f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.159f, -0.149f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1396197f, 0.1396197f, 0.1396197f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(0.485f, -0.168f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1412264f, 0.1412264f, 0.1412264f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-0.159f, -0.154f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.100943f, 0.100943f, 0.100943f), "Shape5", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(0.485f, -0.17f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1014791f, 0.1014791f, 0.1014791f), "Shape5", new Vector4(0f, 0.7735849f, 0.03656648f, 1f), true, 7, true);
        Global.RenderShapeVariable("Shape8", "Square", new Vector3(-0.928f, -2.193f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2177115f, 0.08069123f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 8, false);
        Global.RenderShapeVariable("Shape9", "Square", new Vector3(0.939f, -2.219f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2177115f, 0.08089081f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 9, false);
        Global.RenderShapeVariable("Shape10", "Square", new Vector3(-1.033f, -0.056f, 0f), new Vector3(359.8121f, 359.8167f, 314.2907f), new Vector3(0.2858144f, 0.06361307f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 10, false);
        Global.RenderShapeVariable("Shape11", "Square", new Vector3(1.47f, -0.264f, 0f), new Vector3(0f, 0f, 43.73672f), new Vector3(0.2899614f, 0.06707884f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 11, false);
        Global.RenderShapeVariable("Shape12", "TriangleR", new Vector3(-1.693f, -1.458f, -0.004f), new Vector3(357.9538f, 9.454397f, 92.49583f), new Vector3(-0.08116494f, 0.2991237f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 12, false);


        //spawn target image
        Global.RenderPuzzleImage("MS12");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle13()
    {
        // puzzle 13 in the Mouse Shapes scene
        // the green circle mouse 

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 3;
        Global.MousePuzzle = 3;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 12;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Circle", new Vector3(0.06f, -1.02f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.5137529f, 0.4958907f, 0.4252922f), "Shape2", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0, true);

        Global.RenderShapeVariable("Shape1", "TriangleI", new Vector3(0.42f, 0.25f, 0f), new Vector3(-2.134434E-07f, 357.0003f, 292.9856f), new Vector3(0.3603483f, 0.3603483f, 0.3603483f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 1, false);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-0.514f, 0.655f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(0.995f, 0.534f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2179216f, 0.2179216f, 0.2179216f), "Shape4", new Vector4(1f, 0f, 0.05237484f, 1f), false, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(-0.203f, -0.142f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1562903f, 0.1562903f, 0.1562903f), "Shape4", new Vector4(0.9750406f, 1f, 0f, 1f), true, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(0.5182f, -0.2012f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1562387f, 0.1562387f, 0.1562387f), "Shape4", new Vector4(1f, 0.7064719f, 0f, 1f), true, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-0.203f, -0.1473f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09426609f, 0.09426609f, 0.0942661f), "Shape5", new Vector4(0.0201524f, 0f, 0.754717f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(0.529f, -0.199f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09814046f, 0.09814046f, 0.09814046f), "Shape5", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), true, 7, true);
        Global.RenderShapeVariable("Shape8", "Square", new Vector3(-0.928f, -2.193f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2177115f, 0.08069123f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 8, false);
        Global.RenderShapeVariable("Shape9", "Square", new Vector3(0.939f, -2.219f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2177115f, 0.08089081f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 9, false);
        Global.RenderShapeVariable("Shape10", "Square", new Vector3(-1.512f, -0.203f, 0f), new Vector3(359.8121f, 359.8167f, 330.4486f), new Vector3(0.2858144f, 0.06361307f, 1f), "Shape3", new Vector4(1f, 0.3766058f, 0f, 1f), false, 10, false);
        Global.RenderShapeVariable("Shape11", "Square", new Vector3(1.308f, -0.823f, 0f), new Vector3(0f, 0f, 13.58755f), new Vector3(0.2899614f, 0.06707884f, 1f), "Shape3", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 11, false);
        Global.RenderShapeVariable("Shape12", "Semicircle", new Vector3(1.645f, -1.528f, -0.569f), new Vector3(0f, 0f, 203.4635f), new Vector3(-0.2493712f, 0.2019982f, 1f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 12, false);


        //spawn target image
        Global.RenderPuzzleImage("MS13");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle14()
    {
        // puzzle 14 in the Mouse Shapes scene
        // the circles

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 3;
        Global.MousePuzzle = 4;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 4;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "Square", new Vector3(0.14f, -0.821f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.896459f, 0.3988133f, 1f), "Shape1", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-0.556f, -0.811f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3983997f, 0.3933989f, 0.8334723f), "Shape2", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(-1.613f, -1.482f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.09912924f, 0.09912924f, 0.09912924f), "Shape5", new Vector4(1f, 0.7064719f, 0f, 1f), true, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(1.768f, -1.345f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1600438f, 0.1600438f, 0.1600438f), "Shape4", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.838f, -1.2538f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2028437f, 0.2012901f, 0.187177f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), false, 4, true);

        //spawn target image
        Global.RenderPuzzleImage("MS14");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle15()
    {
        // puzzle 15 in the Mouse Shapes scene
        // the cheese

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 3;
        Global.MousePuzzle = 5;

        Global.ProgressBar(Global.PuzzlesPerLevel, Global.MousePuzzle - 1, Mask, LevelText, Global.MouseLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 7;

        //spawn shape
        Global.RenderShapeFixed("Shape0", "TriangleR", new Vector3(-0.027f, -0.585f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.04328f, 0.677061f, 1f), "Shape1", new Vector4(1f, 0.8103144f, 0.3537736f, 1f), false, 0, false);

        Global.RenderShapeVariable("Shape1", "Circle", new Vector3(-1.78f, -1.53f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.24153f, 0.24153f, 0.24153f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), false, 1, true);
        Global.RenderShapeVariable("Shape2", "Circle", new Vector3(1.26f, -1.79f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1258371f, 0.1258371f, 0.1258371f), "Shape3", new Vector4(1f, 0.4678748f, 0f, 1f), true, 2, true);
        Global.RenderShapeVariable("Shape3", "Circle", new Vector3(-2.03f, 0.34f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1258371f, 0.1258371f, 0.1258371f), "Shape3", new Vector4(0.9750406f, 1f, 0f, 1f), true, 3, true);
        Global.RenderShapeVariable("Shape4", "Circle", new Vector3(0.22f, -1.483f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2625783f, 0.2625783f, 0.2625783f), "Shape2", new Vector4(0.9750406f, 1f, 0f, 1f), false, 4, true);
        Global.RenderShapeVariable("Shape5", "Circle", new Vector3(-1.042f, -0.598f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2328496f, 0.2328496f, 0.2328496f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 5, true);
        Global.RenderShapeVariable("Shape6", "Circle", new Vector3(-0.8f, -1.6f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1196847f, 0.1196847f, 0.1196847f), "Shape4", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), true, 6, true);
        Global.RenderShapeVariable("Shape7", "Circle", new Vector3(-1.99f, -0.484f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1201737f, 0.1201737f, 0.1201737f), "Shape5", new Vector4(0.7818722f, 0.8018868f, 0f, 1f), true, 7, true);


        //spawn target image
        Global.RenderPuzzleImage("MS15");  //has the touchrotate script attached --> run after all shapes are loaded
    }

}
