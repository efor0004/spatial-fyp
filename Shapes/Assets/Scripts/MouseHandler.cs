﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MouseHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the Mouse Shapes scene

    float toolbarY = -4f;
    float toolbarXoffset = 2.5f;
    // float toolbarXstart = -3.75f; //(-2.5/2) 
    float toolbarXstart = -4.8f;

    delegate void PuzzleMethod();                                      //creates an empty method
    List<PuzzleMethod> Puzzle = new List<PuzzleMethod>();              //creates a list of empty methods
    void CreateList()                                 
    {
        //populates the list of empty methods with a function call for each puzzle

        Puzzle.Add(Puzzle1);
        Puzzle.Add(Puzzle2);
        Puzzle.Add(Puzzle3);
    }

    
    void Start()
    {
        // Start is called before the first frame update

        Global.NextPuzzleReady = true;                                     //set as true every time the scene is opened
        //CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        //Puzzle1();
        Puzzle3(); 
    }
        void Update()
        {
        //called each frame

            if (Global.piecesPlaced == Global.puzzlePieces)                    //puzzle completion 
                {
                    PuzzleComplete(); 
                }

        if (Global.NextPuzzleReady == true)
        {
            int n;
            n = (Global.MouseLevel - 1) * 5 + Global.MousePuzzle;              //index of array = puzzle number -1
            Puzzle[n]();                                                       //calls the puzzle by indexing the array of function calls
        }

    }

       

    void RenderShapeFixed(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n)
        {
            //creates a sprite game object
            //renders it in the given position

            GameObject objToSpawn = new GameObject(Name);                                            //assign name
            objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
            objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder
            objToSpawn.transform.position = Position;                                                //set position vector
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                              //set rotation vector
            objToSpawn.transform.localScale = (Scale);                                               //set scale vector
            objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name
            objToSpawn.GetComponent<SpriteRenderer>().color = Color;                                 //set colour vector (RGBA) 
            //no 2d collider required 
        
            TouchRotate.activeArray[n] = false;                                                      //instantiate anchor shape as inactive
            TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                            //save "rest" position
        }

        void RenderShapeVariable(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n)
        {
            //creates a sprite game object
            //renders it in the toolbar and saves its target position/orientation

            GameObject objToSpawn = new GameObject(Name);                                            //assign name
            objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
            objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder

            objToSpawn.transform.localScale = (Scale);                                               //set scale vector
            objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name
            objToSpawn.GetComponent<SpriteRenderer>().color = Color;                                 //set colour vector (RGBA) 
            objToSpawn.AddComponent<CircleCollider2D>();                                             //assign circle collider    //sized correctly

        if (Small == true)
            {
                objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                          //small shapes spawn in their final orientation
                objToSpawn.GetComponent<CircleCollider2D>().radius = 4.5f;                           //small shapes get a much larger circle collider
            }
        else
            {
                objToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, 0f);                       //large shapes are set a neutral orientation
                objToSpawn.GetComponent<CircleCollider2D>().radius = 2.5f;                          //large shapes get a slightly larger 2d circle collider
            }

        objToSpawn.transform.position = new Vector3(toolbarXstart + n * toolbarXoffset, toolbarY, 0f);  //place in the toolbar


        TouchRotate.positionArray[n] = Position;                                                //save target location  
        TouchRotate.rotationArray[n] = Rotation;                                                //save target rotatation

        TouchRotate.smallArray[n] = Small;                                                      //save small status

        TouchRotate.activeArray[n] = true;                                                      //instantiate all new shapes as active   ///this is causing the issue somehow.............
        TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                            //save "rest" position
  
        }

    void RenderPuzzleImage(string Sprite) 
    {
        //renders the objective puzzle image
        //everything is fixed except the name of the sprite used
        //also attach the rotate script here


        Vector3 Position = new Vector3(0.1035244f, 3.630444f, 0f);
        Vector3 Rotation = new Vector3(0f, 0f, 0f);
        Vector3 Scale = new Vector3(1f, 1f, 1f);
        string SortingLayer = "Foreground";

        GameObject objToSpawn = new GameObject("Puzzle");                                          //assign name
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder
        objToSpawn.transform.position = Position;                                                //set position vector
        objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                              //set rotation vector
        objToSpawn.transform.localScale = (Scale);                                               //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name

        objToSpawn.AddComponent<TouchRotate>();                                                  //add script
    }

    void PuzzleComplete()
    {
        Global.piecesPlaced = 0; //reset to avoid looping
        Debug.Log("PUZZLE COMPLETE!");

        GameObject.Find("PopupStart").transform.localPosition = Global.popupPosition; //creates a popup

        GameObject.Find("HomeButton").GetComponent<Button>().interactable = false; //set home button to inactive
        GameObject.Find("LeftArrow").GetComponent<Button>().interactable = false;   
        GameObject.Find("RightArrow").GetComponent<Button>().interactable = false;         
        
       //Global.DestroyShapes(); //destroy all existing shapes

    }

    void Puzzle1()
    {
        //puzzle 1 in the Mouse Shapes scene

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 1;

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        RenderShapeFixed("Shape0", "Circle", new Vector3(0.45f, -0.97f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.109f, 0.592f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0);
        //spawn movable shapes   
        RenderShapeVariable("Shape1", "TriangleR", new Vector3(-3.23f, -0.86f, 0f), new Vector3(0f, 0f, 132.8008f), new Vector3(0.4183661f, 0.3734069f, 0.495f), "Shape2", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1);
        RenderShapeVariable("Shape2", "TriangleR", new Vector3(0.48f, 0.62f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.4347749f, 0.1773904f, 0.291346f), "Shape2", new Vector4(0f, 0.7135715f, 1f, 1f), false, 2);
        RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.259f, -0.721f, 0f), new Vector3(0f, 0f, 27.04025f), new Vector3(0.3475402f, 0.2874415f, 0.264f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 3);
        RenderShapeVariable("Shape4", "Circle", new Vector3(1.6992f, -0.5492f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1752192f, 0.1752192f, 0.162f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), true, 4);
        RenderShapeVariable("Shape5", "Circle", new Vector3(1.71f, -0.549f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1362686f, 0.1318552f, 0.1186388f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 5);

        //spawn target image
        RenderPuzzleImage("Puzzle1");  //has the touchrotate script attached --> run after all shapes are loaded

    }

    void Puzzle2()
    {
        //puzzle 2 in the Mouse Shapes scene

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 2;

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
        RenderShapeFixed("Shape0", "Square", new Vector3(-0.146f, -2.661f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.183059f, -0.04520125f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0);
        //spawn movable shapes   
        RenderShapeVariable("Shape1", "Square", new Vector3(-2f, -1.65f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3297423f, 0.3897292f, 1f), "Shape2", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 1);
        RenderShapeVariable("Shape2", "TriangleI", new Vector3(-1.97f, -0.16f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.408812f, 0.259939f, 1f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), false, 2);
        RenderShapeVariable("Shape3", "Square", new Vector3(2.15f, -2.01f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.139024f, 0.2311544f, 1f), "Shape2", new Vector4(0.7735849f, 0.5361769f, 0f, 1f), false, 3);
        RenderShapeVariable("Shape4", "TriangleI", new Vector3(2.18f, -0.41f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2844304f, 0.4700956f, 1f), "Shape3", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 4);
        RenderShapeVariable("Shape5", "Circle", new Vector3(0.36f, -0.09f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.30806f, 0.314768f, 1f), "Shape2", new Vector4(1f, 0.7064719f, 0f, 1f), false, 5);

        //spawn target image
        RenderPuzzleImage("Puzzle2");  //has the touchrotate script attached --> run after all shapes are loaded
    }

    void Puzzle3()
    {
        // puzzle 3 in the Mouse Shapes scene

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.MouseLevel = 1;
        Global.MousePuzzle = 3;

        //set number of pieces in the puzzle
        Global.puzzlePieces = 6;

        //spawn anchor shape
        RenderShapeFixed("Shape0", "Circle", new Vector3(-0.05f, -0.87f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.7549642f, 0.7549642f, 0.7549642f), "Shape1", new Vector4(1f, 0.4678748f, 0f, 1f), false, 0);
        
        RenderShapeVariable("Shape1", "TriangleI", new Vector3(-1.87f, 0.59f, 0f), new Vector3(0f, 0f, 51.07933f), new Vector3(0.2188039f, 0.3065733f, 1f), "Shape2", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), false, 1);
        RenderShapeVariable("Shape2", "TriangleR", new Vector3(1.8f, 0.58f, 0.02f), new Vector3(0f, 0f, 310.699f), new Vector3(0.3250957f, 0.3028033f, 1.116f), "Shape2", new Vector4(1f, 0.3632075f, 0.3965594f, 1f), false, 2);
        RenderShapeVariable("Shape3", "Circle", new Vector3(-0.7f, -0.52f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.12425f, 0.12425f, 0.12425f), "Shape3", new Vector4(0.3820755f, 0.6195526f, 1f, 1f), true, 3);
        RenderShapeVariable("Shape4", "Semicircle", new Vector3(0.736f, -0.439f, 0f), new Vector3(0f, 0f, 34.34164f), new Vector3(0.136999f, 0.1496053f, 0.1518836f), "Shape3", new Vector4(0.3820755f, 0.6195526f, 1f, 1f), true, 4);
        RenderShapeVariable("Shape5", "TriangleI", new Vector3(-0.01f, -1.28f, 0f), new Vector3(0f, 0f, 179.3278f), new Vector3(0.1430812f, 0.135563f, 0.1174722f), "Shape3", new Vector4(0.7169812f, 0f, 0.03755178f, 1f), true, 5);
        RenderShapeVariable("Shape6", "TriangleI", new Vector3(0.01f, -1.817f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1753337f, 0.08821746f, 0.1523316f), "Shape2", new Vector4(0f, 0f, 0f, 1f), true, 6);

        //spawn target image
        RenderPuzzleImage("Puzzle3");  //has the touchrotate script attached --> run after all shapes are loaded
    }

}
