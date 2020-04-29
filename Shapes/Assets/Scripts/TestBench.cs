using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;

public class TestBench : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WriteString(); 
    }

        [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/TextFiles/test.txt";

        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("\n *********************** NEW TEST ************************ \n"); 

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            //if (gameObject.tag == "Shape")
            if (gameObject.GetComponent<SpriteRenderer>())
            {
                writer.WriteLine("\n name: " + gameObject.name + "\t position: " + gameObject.transform.position + "\t rotation: " + gameObject.transform.rotation.eulerAngles + "\t scale: " + gameObject.transform.localScale + "\t sorting layer: " + gameObject.GetComponent<SpriteRenderer>().sortingLayerName);
            }
        }
        writer.Close();

        Debug.Log("done"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
