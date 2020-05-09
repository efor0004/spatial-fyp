using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the jungle scene

    float toolbarY = -4f;
    float toolbarXoffset = 2.5f;
    // float toolbarXstart = -3.75f; //(-2.5/2) 
    float toolbarXstart = -4.8f;

    // Start is called before the first frame update
    void Start()
    {
        Puzzle1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Puzzle1() 
    {
        //puzzle 1 in the Jungle scene
        //REMEMBER to remove (1) etc from the end of the shape name

        //spawn shapes
        RenderShapeFixed("Shape0", "Circle", new Vector3(0.58f, 0.04f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.109f, 0.592f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f), false, 0);

        RenderShapeVariable("Shape1", "TriangleR", new Vector3(-3.08f, 0.11f, 0f), new Vector3(0f, 0f, 132.6898f), new Vector3(0.42174f, 0.3764183f, 0.495f), "Shape1", new Vector4(0f, 0.5116174f, 0.7169812f, 1f), false, 1);
        RenderShapeVariable("Shape2", "TriangleR", new Vector3(0.65f, 1.841f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.2384341f, 0.2459473f, 0.291346f), "Shape2", new Vector4(0f, 0.7135715f, 1f, 1f), false, 2);
        RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.37f, 0.45f, 0f), new Vector3(0f, 0f, 23.02961f), new Vector3(0.264f, 0.264f, 0.264f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f), false, 3);
        RenderShapeVariable("Shape4", "Circle", new Vector3(1.91f, 0.39f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.162f, 0.162f, 0.162f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f), true, 4);
        RenderShapeVariable("Shape5", "Circle", new Vector3(1.91f, 0.39f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1186388f, 0.1186388f, 0.1186388f), "Shape3", new Vector4(0f, 0f, 0f, 1f), true, 5);

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
        //no 2d collider as it cannot be interacted with
        //small and n are not required - would it cause issues to not have shape0 update the global arrays?
 
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

        //will not spawn at this location, but will save them as targets
        if (Small == true)
        { 
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                          //small shapes spawn in their final orientation
        }
        else
        {
            objToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, 0f);                       //large shapes are set a neutral orientation
        }

        
        objToSpawn.transform.position = new Vector3(toolbarXstart + n * toolbarXoffset, toolbarY, 0f);  //place in the toolbar


        TouchRotate.positionArray[n] = Position;                                                //save target location  
        TouchRotate.rotationArray[n] = Rotation;                                                //save target rotatation

        TouchRotate.smallArray[n] = Small;                                                      //save small status
    
        TouchRotate.activeArray[n] = true;                                                      //instantiate all new shapes as active


        //  Debug.Log(objToSpawn.name + " 2dcircle collider radius: " + objToSpawn.GetComponent<CircleCollider2D>().radius);
        //  Debug.Log(objToSpawn.name + " 2dcircle collider bounds: " + objToSpawn.GetComponent<CircleCollider2D>().bounds);
    }
    public void DestroyShapes()
    {
        //destroy all current shapes by name   
        //adapted from https://answers.unity.com/questions/1414048/destroy-specific-gameobject-with-name.html

        string[] myObjectsNames = new string[] { "Shape0", "Shape1", "Shape2", "Shape3", "Shape4", "Shape5", "Shape6", "Shape7", "Shape8", "Shape9"};  //the array of shape names

        foreach (string name in myObjectsNames)
        {
            GameObject go = GameObject.Find(name);                                                //checks if the shape exists
                                                                                                  //if the tree exist then destroy it
            if (go)
                Destroy(go.gameObject);
        }
    }
}
