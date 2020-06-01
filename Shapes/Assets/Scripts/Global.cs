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

    public static float positionTolerance = 0.5f;         //tolerance in placement
    public static float rotationTolerance = 15.0f;

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
        //updates the progress bar and level X at the top right hand of the puzzle screen
        //called in the puzzlex() function

        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
        Text.text = "Level " + Level; 
    }

    public static void ProgressCircle(int max, int current, Image mask)
    {
        //updates the progress circles on the World Select menu
        //triggered when the World scene is loaded

        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
    }
}