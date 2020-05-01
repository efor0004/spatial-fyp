using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleHandler : MonoBehaviour
{
    //the script that controls all of the puzzles in the jungle scene

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

        //spawn shapes
        RenderShapeFixed("Shape0", "Circle", new Vector3(0.58f, 0.04f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1.109f, 0.592f, 1f), "Shape1", new Vector4(0f, 0.4716981f, 0.02229664f, 1f));

        RenderShapeVariable("Shape1", "TriangleR", new Vector3(-3.4f, 0.21f, 0f), new Vector3(0f, 0f, 132.6898f), new Vector3(0.495f, 0.495f, 0.495f), "Shape1", new Vector4(0f, 0.5116174f, 0.7169812f, 1f));
        RenderShapeVariable("Shape2", "TriangleR", new Vector3(0.64f, 1.93f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.291346f, 0.291346f, 0.291346f), "Shape2", new Vector4(0f, 0.7135715f, 1f, 1f));
        RenderShapeVariable("Shape3", "TriangleR", new Vector3(0.37f, 0.45f, 0f), new Vector3(0f, 0f, 23.02961f), new Vector3(0.264f, 0.264f, 0.264f), "Shape2", new Vector4(0.495283f, 0.8554347f, 1f, 1f));
        RenderShapeVariable("Shape4", "Circle", new Vector3(1.91f, 0.39f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.162f, 0.162f, 0.162f), "Shape2", new Vector4(1f, 0.4678748f, 0f, 1f));
        RenderShapeVariable("Shape5", "Circle", new Vector3(1.91f, 0.39f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.1186388f, 0.1186388f, 0.1186388f), "Shape3", new Vector4(0f, 0f, 0f, 1f));

    }

    void RenderShapeFixed(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color)
    {
        //creates a sprite game object
        //renders it in the given position

        GameObject objToSpawn = new GameObject(Name);                                            //assign name
        objToSpawn.AddComponent<CircleCollider2D>();                                             //assign circle collider
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder
        objToSpawn.transform.position = Position;                                                //set position vector
        objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                              //set rotation vector
        objToSpawn.transform.localScale = (Scale);                                               //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name
        objToSpawn.GetComponent<SpriteRenderer>().color = Color;                                 //set colour vector (RGBA) 
    }

    void RenderShapeVariable(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color) 
    {
        //creates a sprite game object
        //renders it in the toolbar and saves its target position/orientation

        GameObject objToSpawn = new GameObject(Name);                                            //assign name
        objToSpawn.AddComponent<CircleCollider2D>();                                             //assign circle collider
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder
        objToSpawn.transform.position = Position;                                                //set position vector
        objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                              //set rotation vector
        objToSpawn.transform.localScale = (Scale);                                               //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name
        objToSpawn.GetComponent<SpriteRenderer>().color = Color;                                 //set colour vector (RGBA) 
    }
}
