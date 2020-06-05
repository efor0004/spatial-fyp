using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Global : MonoBehaviour
{
    //ButtonBehaviour
    public static Vector3 leftPosition = new Vector3(-2000, -60, 0);  //ButtonVehaviour
    public static Vector3 rightPosition = new Vector3(2000, -60, 0);
    public static Vector3 bottomPosition = new Vector3(0, -2000, 0);
    public static Vector3 topPosition = new Vector3(0, 2000, 0);
    public static Vector3 centrePosition = new Vector3(0, -60, 0);

    public static Vector3 popupPosition = new Vector3(0, 625, 0); //for popup boxes

    public static bool LeftArrowActive = true;
    public static bool RightArrowActive = true;

    public static bool Music = true;
    public static bool SoundEffects = true;


    //TouchRotate
    public static Vector3 shapeOffset = new Vector3(2.5f, 0f, 0f);  //toolbar shifting

    public static Vector3 currentVal1 = new Vector3(0, 0, 0);
    public static Vector3 currentVal2 = new Vector3(0, 0, 0);

    public static float positionTolerance = 0.8f;         //tolerance in placement //0.5
    public static float rotationTolerance = 20.0f;  //15

    public static int puzzlePieces = 11;                //tracking puzzle completion
    public static int piecesPlaced = 0;

    public static int PlaygroundLevel = 1;              //tracking progress
    public static int PlaygroundPuzzle = 0;
    public static int TriangleLevel = 1;
    public static int TrianglePuzzle = 0;
    public static int MouseLevel = 1;
    public static int MousePuzzle = 0;
    public static int WildLevel = 1;
    public static int WildPuzzle = 0;
    public static int FarmLevel = 1;
    public static int FarmPuzzle = 0;

    public static bool PieceActive = false;        //tracking active piece
    public static string ActiveName;

    public static Vector4 ColourOffset = new Vector4(0.2f, 0.2f, 0.2f, 0f);
    //public static Vector4 FlashColour = new Vector4(1f, 1f, 1f, 1f); 

    //"Scene"Handler
    public static bool NextPuzzleReady = true;

    public static float toolbarY = -4f;
    public static float toolbarXoffset = 2.5f;                  // -3.75f; //(-2.5/2) 
    public static float toolbarXstart = -4.8f;

    public static float smallCollider = 4.5f;                   //a larger collider for small shapes
    public static float regularCollider = 2.5f;                 //a regular sized collider for regular shapes


    public static void DestroyShapes()
    {
        //destroy all current shapes by name   
        //adapted from https://answers.unity.com/questions/1414048/destroy-specific-gameobject-with-name.html

        foreach (string name in TouchRotate.nameArray)
        {
            GameObject go = GameObject.Find(name);                                                //checks if the shape exists
                                                                                                  //if the tree exist then destroy it
            if (go)
                Destroy(go.gameObject);
        }

        Destroy(GameObject.Find("Puzzle"));  //////to destroy the objective puzzle object
    }

    public static void CheckArrows()
    {
        //checks whether the toolbar arrows should be disabled to signal there are no more shapes in that direction
         
        int Index = 0;                                            //check Left Arrow
        for (int j = 0; j < Global.puzzlePieces; j++)
        {
            if (TouchRotate.activeArray[j] == true)
            {
                Index = j;                                        //returns the index of the first active shape i.e. shape in left most position in toolbar
                break;
            }
        }

        if (TouchRotate.toolbarArray[Index].x >= 0.15f)
        {
            Global.LeftArrowActive = false;
        }
        else
        {
            Global.LeftArrowActive = true;
        }


        Index = 0;                                              //Check Right Arrow
        for (int j = Global.puzzlePieces; j > 0; j--)
        {
            if (TouchRotate.activeArray[j] == true)
            {
                Index = j;                                     //returns the index of the last active shape i.e. shape in right most position in toolbar
                break;
            }
        }

        if (TouchRotate.toolbarArray[Index].x <= 2f) 
        {
            Global.RightArrowActive = false;
        }
        else
        {
            Global.RightArrowActive = true;
        }


    }

    public static void ProgressBar(int max, int current, Image mask, Text Text, int Level)
    {
        // adapted from https://www.youtube.com/watch?v=J1ng1zA3-Pk
        //updates the progress bar and level X at the top right hand of the puzzle screen
        //called in the puzzlex() function

        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
        Text.text = "Level " + Level; 
    }

    public static void ProgressCircle(int max, int current, Image mask)
    {
        //adapted from https://www.youtube.com/watch?v=J1ng1zA3-Pk
        //updates the progress circles on the World Select menu
        //triggered when the World scene is loaded

        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
    }


   public static void RenderShapeFixed(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n, bool Circle)
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

    public static void RenderShapeVariable(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n, bool Circle)
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
            objToSpawn.GetComponent<CircleCollider2D>().radius = smallCollider;                 //small shapes get a much larger circle collider
        }
        else if (Circle == true)
        {
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                          //circular shapes spawn in their final orientation
            TouchRotate.toolbarRotationArray[n] = Rotation;
            objToSpawn.GetComponent<CircleCollider2D>().radius = regularCollider;
        }
        else
        {
            objToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            TouchRotate.toolbarRotationArray[n] = new Vector3(0f, 0f, 0f);
            objToSpawn.GetComponent<CircleCollider2D>().radius = regularCollider;
        }

        objToSpawn.transform.position = new Vector3(toolbarXstart + n * toolbarXoffset, toolbarY, 0f);  //place in the toolbar

        TouchRotate.positionArray[n] = Position;                                                //save target location  
        TouchRotate.rotationArray[n] = Rotation;                                                //save target rotatation

        TouchRotate.smallArray[n] = Small;                                                      //save small status
        TouchRotate.circleArray[n] = Circle;                                                      //save small status

        TouchRotate.activeArray[n] = true;                                                      //instantiate all new shapes as active   ///this is causing the issue somehow.............
        TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                            //save "rest" position

    }

    public static void RenderPuzzleImage(string Sprite)
    {
        //renders the objective puzzle image
        //everything is fixed except the name of the sprite used
        //also attach the rotate script here


        //Vector3 Position = new Vector3(0.1035244f, 3.630444f, 0f);
        Vector3 Position = new Vector3(-0.4f, 3.630444f, 0f);
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

    public static void PuzzleComplete()
    {
        //is triggered when a puzzle is completed correctly
        //popup asks if the user wants to play another puzzle or go home

        piecesPlaced = 0;                                                                //reset to avoid looping
        Debug.Log("PUZZLE COMPLETE!");

        GameObject.Find("PopupStart").transform.localPosition = popupPosition;          //creates a popup

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;    //disables background buttons
        LeftArrowActive = false;
        RightArrowActive = false;

    }

    public static void LevelComplete()
    { //event to signifiy a level is complete
      //triggered when the 5th puzzle within a level is completed

        Debug.Log("Level Complete!"); 
    
    }
}