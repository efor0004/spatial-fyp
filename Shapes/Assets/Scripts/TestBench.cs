using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;

public class TestBench : MonoBehaviour
{
    //This script is used to find the image, colour, sorting layer position, rotation and scale of sprite gameobjects placed within the scene
    //the data is printed to the text file test.txt 
    //the data is printed to automatically create the funciton call that will render the shape  
 
    void Start()
    {
        WriteString();                                                                      // calls the method on start up       
    }

       // [MenuItem("Tools/Write file")]                                                     
    static void WriteString()                                                               //adapted from https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
    {
        string path = "Assets/TextFiles/test.txt";                                          //path to text file from current project directory

        List<GameObject> rootObjects = new List<GameObject>();                              //adapted from: https://answers.unity.com/questions/329395/how-to-get-all-gameobjects-in-scene.html
        Scene scene = SceneManager.GetActiveScene();                                        //creates a list of all of the gameobjects in a current scene  
        scene.GetRootGameObjects(rootObjects);

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine("\n *********************** NEW TEST ************************ \n"); //writes a heading for the start of a new test

        float minScale = 0.2f; 
        int n = 0;
        bool small = false;
        bool circle = false; 

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];                                          //for every game object in the list that renders a sprite
            if (gameObject.GetComponent<SpriteRenderer>())                                   //write its name (variant of the image rendered), position, rotation, scale, sorting layer and colour 
            {
              
                //creates a function to render the sprite
                //shapes are listed in order of creation (if the heirarchy is untouched)
                //the first shape will be the anchor shape and it needs a separate function to render it in position
                if (Mathf.Abs(gameObject.transform.localScale.x) < minScale && Mathf.Abs(gameObject.transform.localScale.y) < minScale)
                {
                    small = true;
                }
                else 
                {
                    small = false; 
                }

                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "Circle" && (gameObject.transform.localScale.x / gameObject.transform.localScale.y) > 0.95f && (gameObject.transform.localScale.x / gameObject.transform.localScale.y) < 1.05f)
                {
                    circle = true;
                }
                else 
                {
                    circle = false; 
                }

                if (n == 0)
                {
                    writer.WriteLine("Global.RenderShapeFixed(\"Shape" + n + "\", \"" + gameObject.GetComponent<SpriteRenderer>().sprite.name + "\", new Vector3("
                        + gameObject.transform.position.x + "f, " + gameObject.transform.position.y + "f, " + gameObject.transform.position.z + "f), new Vector3("
                        + gameObject.transform.rotation.eulerAngles.x + "f, " + gameObject.transform.rotation.eulerAngles.y + "f, " + gameObject.transform.rotation.eulerAngles.z + "f), new Vector3("
                        + gameObject.transform.localScale.x + "f, " + gameObject.transform.localScale.y + "f, " + gameObject.transform.localScale.z + "f), \""
                        + gameObject.GetComponent<SpriteRenderer>().sortingLayerName + "\", new Vector4("
                        + gameObject.GetComponent<SpriteRenderer>().color.r + "f, " + gameObject.GetComponent<SpriteRenderer>().color.g + "f, " + gameObject.GetComponent<SpriteRenderer>().color.b + "f, " + gameObject.GetComponent<SpriteRenderer>().color.a + "f), "
                        + small.ToString().ToLower() + ", " 
                        + n + ", "
                        + circle.ToString().ToLower() + ");"
                        );
                }
                else {
                    writer.WriteLine("Global.RenderShapeVariable(\"Shape" + n + "\", \"" + gameObject.GetComponent<SpriteRenderer>().sprite.name + "\", new Vector3("
                        + gameObject.transform.position.x + "f, " + gameObject.transform.position.y + "f, " + gameObject.transform.position.z + "f), new Vector3("
                        + gameObject.transform.rotation.eulerAngles.x + "f, " + gameObject.transform.rotation.eulerAngles.y + "f, " + gameObject.transform.rotation.eulerAngles.z + "f), new Vector3("
                        + gameObject.transform.localScale.x + "f, " + gameObject.transform.localScale.y + "f, " + gameObject.transform.localScale.z + "f), \""
                        + gameObject.GetComponent<SpriteRenderer>().sortingLayerName + "\", new Vector4("
                        + gameObject.GetComponent<SpriteRenderer>().color.r + "f, " + gameObject.GetComponent<SpriteRenderer>().color.g + "f, " + gameObject.GetComponent<SpriteRenderer>().color.b + "f, " + gameObject.GetComponent<SpriteRenderer>().color.a + "f), "
                        + small.ToString().ToLower() + ", "
                        + n + "," 
                        + circle.ToString().ToLower() + ");"
                        );
                }
                n = n + 1;
            }
        }
        writer.Close();

        Debug.Log("done");                                                                   //writes to console on completion
    }

}


//prints out values in natural format
// writer.WriteLine("\n name: " + gameObject.name + "\t position: " + gameObject.transform.position + "\t rotation: " + gameObject.transform.rotation.eulerAngles + "\t scale: " + gameObject.transform.localScale + "\t sorting layer: " + gameObject.GetComponent<SpriteRenderer>().sortingLayerName + "\t colour: " + gameObject.GetComponent<SpriteRenderer>().color);

//prints out values in (0.0f, 0.1f, 0.2f) format
//writer.WriteLine("\n name: " + gameObject.name 
//    + "\t position: (" + gameObject.transform.position.x + "f, " + gameObject.transform.position.y + "f, " + gameObject.transform.position.z + "f)" 
//    + "\t rotation: (" + gameObject.transform.rotation.eulerAngles.x + "f, " + gameObject.transform.rotation.eulerAngles.y + "f, " + gameObject.transform.rotation.eulerAngles.z + "f)" 
//    + "\t scale: (" + gameObject.transform.localScale.x + "f, " + gameObject.transform.localScale.y + "f, " + gameObject.transform.localScale.z + "f)"  
//    + "\t sorting layer: " + gameObject.GetComponent<SpriteRenderer>().sortingLayerName 
//    + "\t colour: (" + gameObject.GetComponent<SpriteRenderer>().color.r + "f, " + gameObject.GetComponent<SpriteRenderer>().color.g + "f, " + gameObject.GetComponent<SpriteRenderer>().color.b + "f, " + gameObject.GetComponent<SpriteRenderer>().color.a + "f)"
//    );