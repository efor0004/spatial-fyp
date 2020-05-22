using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Global : MonoBehaviour
{
    // Start is called before the first frame update

    //public static Vector3 shapeOffset = new Vector3(3, 0, 0);
    public static Vector3 shapeOffset = new Vector3(2.5f, 0f, 0f);  //TouchRotate (toolbar)

    public static Vector3 currentVal1 = new Vector3(0, 0, 0);
    public static Vector3 currentVal2 = new Vector3(0, 0, 0);


    public static Vector3 leftPosition = new Vector3(-2000, -60, 0);  //ButtonVehaviour
    public static Vector3 rightPosition = new Vector3(2000, -60, 0);
    public static Vector3 bottomPosition = new Vector3(0, -2000, 0);
    public static Vector3 topPosition = new Vector3(0, 2000, 0);
    public static Vector3 centrePosition = new Vector3(0, -60, 0);

    public static Vector3 popupPosition = new Vector3(0, 625, 0); //for popup boxes


    public static float positionTolerance = 0.5f;  //TouchRotate
    public static float rotationTolerance = 12.0f;  


    public static int puzzlePieces = 11; //Touch Rotate
    public static int piecesPlaced = 0; 

    public static int PlaygroundLevel = 1;               //keeps track of progress
    public static int PlaygroundPuzzle = 0;
    public static int TriangleLevel = 1;
    public static int TrianglesPuzzle = 0;
    public static int MouseLevel = 1;
    public static int MousePuzzle = 0;
    public static int WildLevel = 1;
    public static int WildPuzzle = 0;
    public static int FarmLevel = 1;
    public static int FarmPuzzle = 0;

    public static bool NextPuzzleReady = true; //"Scene"Handler

    public static bool PieceActive = false;  //TouchRotate
    public static string ActiveName; 

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

}
