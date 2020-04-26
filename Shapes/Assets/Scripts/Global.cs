using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Global : MonoBehaviour
{
    // Start is called before the first frame update

    public static Vector3 shapeOffset = new Vector3(3, 0, 0);

    public static Vector3 currentVal1 = new Vector3(0, 0, 0);
    public static Vector3 currentVal2 = new Vector3(0, 0, 0);


    public static Vector3 leftPosition = new Vector3(-2000, -60, 0);
    public static Vector3 rightPosition = new Vector3(2000, -60, 0);
    public static Vector3 bottomPosition = new Vector3(0, -2000, 0);
    public static Vector3 topPosition = new Vector3(0, 2000, 0);
    public static Vector3 centrePosition = new Vector3(0, -60, 0);


    public static float positionTolerance = 0.35f;  // x y 
    public static float rotationTolerance = 0.15f;  //z
    public static bool greenMode = false;
    public static bool redMode = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
