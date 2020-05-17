using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Global : MonoBehaviour
{
    // Start is called before the first frame update

    //public static Vector3 shapeOffset = new Vector3(3, 0, 0);
    public static Vector3 shapeOffset = new Vector3(2.5f, 0f, 0f);  //in use

    public static Vector3 currentVal1 = new Vector3(0, 0, 0);
    public static Vector3 currentVal2 = new Vector3(0, 0, 0);


    public static Vector3 leftPosition = new Vector3(-2000, -60, 0);  //in use for menus
    public static Vector3 rightPosition = new Vector3(2000, -60, 0);
    public static Vector3 bottomPosition = new Vector3(0, -2000, 0);
    public static Vector3 topPosition = new Vector3(0, 2000, 0);
    public static Vector3 centrePosition = new Vector3(0, -60, 0);


    //public static float positionTolerance = 0.35f;  // x y     // in use
    //public static float rotationTolerance = 0.15f;  //z        // in use

    //public static float positionTolerance = 0.90f;  // x y     // in use
    //public static float rotationTolerance = 0.40f;  //z        // in use

    public static float positionTolerance = 0.6f;  // x y     // in use
    public static float rotationTolerance = 15.0f;  //z        // in use

    public static bool greenMode = false;                      //kind of in use
    public static bool redMode = false;                        //kind of in use

    public static bool puzzleLoaded = false; 

}
