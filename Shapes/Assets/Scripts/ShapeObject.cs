using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeObject : MonoBehaviour 
{
    //store gameObject reference
    GameObject objToSpawn;
    public void ShapeData(Sprite image, Vector3 position, Vector3 rotation, Vector3 scale, string sortingLayer, Vector4 color)
    {
        Sprite Image = image;
        Vector3 Position = position;
        Vector3 Scale = scale;
        string SortingLayer = sortingLayer;
        Vector4 Color = color; 


       // //spawn object
       // objToSpawn = new GameObject("Shape");

       // //Add Components
       //// objToSpawn.AddComponent<Rigidbody>();
       // objToSpawn.AddComponent<CircleCollider2D>();
       // objToSpawn.AddComponent<SpriteRenderer>();

       // //assign values
       // objToSpawn.GetComponent<SpriteRenderer>().sprite = image;     //set image
       // objToSpawn.transform.position = position;                     //set position
       // objToSpawn.transform.rotation = Quaternion.Euler(rotation);         //set rotation note: cannot manipualte transform.rotation.eulerAngles because it is not a variable
       // objToSpawn.transform.localScale = scale;                     //set scale
       // objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer; 
       // objToSpawn.GetComponent<SpriteRenderer>().color = color;     //set color

       // Debug.Log("built a shape!"); 

    }
}
