using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlaygroundHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the Playground scene

    delegate void PuzzleMethod();                                       //creates an empty method
    List<PuzzleMethod> Puzzle = new List<PuzzleMethod>();               //creates a list of empty methods

    int PuzzlesPerLevel = 5;
    Image Mask;
    Text LevelText;


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
        CreateList();                                                    //initiate this list with function calls for all avilable puzzles in this world
        Mask = GameObject.Find("Mask").GetComponent<Image>();
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();

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
            n = (Global.PlaygroundLevel - 1) * 5 + Global.PlaygroundPuzzle;              //index of array = puzzle number -1
            Puzzle[n]();                                                       //calls the puzzle by indexing the array of function calls
        }

    }

      
    void RenderShapeFixed(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n, bool Circle)
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
         // objToSpawn.GetComponent<SpriteRenderer>().color = Color - Global.ColourOffset;           // 
                                                                                                                       //no 2d collider required 

            TouchRotate.activeArray[n] = false;                                                      //instantiate anchor shape as inactive
            TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                            //save "rest" position
        }

        void RenderShapeVariable(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n, bool Circle)
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
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                           //small shapes spawn in their final orientation 
           TouchRotate.toolbarRotationArray[n] = Rotation;
            objToSpawn.GetComponent<CircleCollider2D>().radius = Global.smallCollider;                 //small shapes get a much larger circle collider
        }
        else if (Circle == true)
        {
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                          //circular shapes spawn in their final orientation
            TouchRotate.toolbarRotationArray[n] = Rotation;                                     
            objToSpawn.GetComponent<CircleCollider2D>().radius = Global.regularCollider;
        }
        else
        {
            objToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, 0f);                        
            TouchRotate.toolbarRotationArray[n] = new Vector3(0f, 0f, 0f);                       
            objToSpawn.GetComponent<CircleCollider2D>().radius = Global.regularCollider;                          
        }

        objToSpawn.transform.position = new Vector3(Global.toolbarXstart + n * Global.toolbarXoffset, Global.toolbarY, 0f);  //place in the toolbar

        TouchRotate.positionArray[n] = Position;                                                //save target location  
        TouchRotate.rotationArray[n] = Rotation;                                                //save target rotatation

        TouchRotate.smallArray[n] = Small;                                                      //save small status
        TouchRotate.circleArray[n] = Circle;                                                      //save small status

        TouchRotate.activeArray[n] = true;                                                      //instantiate all new shapes as active   ///this is causing the issue somehow.............
        TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                            //save "rest" position
  
        }

    void RenderPuzzleImage(string Sprite) 
    {
        //renders the objective puzzle image
        //everything is fixed except the name of the sprite used
        //also attach the rotate script here


        //Vector3 Position = new Vector3(0.1035244f, 3.630444f, 0f);
        Vector3 Position = new Vector3(-0.2f, 3.630444f, 0f);
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
        //is triggered when a puzzle is completed correctly

        Global.piecesPlaced = 0;                                                                //reset to avoid looping
        Debug.Log("PUZZLE COMPLETE!");

        GameObject.Find("PopupStart").transform.localPosition = Global.popupPosition;          //creates a popup

        Global.LeftArrowActive = false;
        Global.RightArrowActive = false; 

    }

    void Puzzle1()
    {
        //puzzle 1 in the Playground scene
        //the ....

        Global.NextPuzzleReady = false; //check this is the case of not completing a puzzle or returning to progress!!!!!!!

        //record level and puzzle numbers
        Global.PlaygroundLevel = 1;
        Global.PlaygroundPuzzle = 1;

        Global.ProgressBar(PuzzlesPerLevel, Global.PlaygroundPuzzle - 1, Mask, LevelText, Global.PlaygroundLevel); //updates the progress bar

        //set number of pieces in the puzzle
        Global.puzzlePieces = 5;

        //spawn anchor shape
       
        //spawn movable shapes   
      

        //spawn target image
        RenderPuzzleImage("PG1");  //has the touchrotate script attached --> run after all shapes are loaded

    }

}
