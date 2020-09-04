using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuteMovieHandler : MonoBehaviour
{

    //handles the tutorial for standard puzzles
    //https://www.youtube.com/watch?v=a1RFxtuTVsk

    public GameObject[] popUps;
    public static int popUpIndex = 0;

    public static bool translateFlag = false;
    public static bool rotateFlag = false;
    public static bool tapFlag = false;
    public static bool toolbarFlag = false;
    public static bool disableFlag = false;


    private Collider2D myCollider;
    Vector3 wp;
    Vector2 touchPos;
    void Start()
    {

        for (int i = 0; i < popUps.Length; i++) //only display first popup
        {
            if (i == 0)
            {
                popUps[i].SetActive(true);

            }
            else
            {
                popUps[i].SetActive(false);

            }

        }
    }


    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        //touchrotate script here
        if ((Input.touchCount > 0) && (translateFlag == true) && (disableFlag == false))                                                                                                         //at least one touch detected                                                                    
        {


            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                                                              //Vector3 of the touch location on the screen
            touchPos = new Vector2(wp.x, wp.y);

            GameObject go = GameObject.Find("Rooster");

            if (go)
            {
                myCollider = go.gameObject.GetComponent<BoxCollider2D>();


                if (myCollider)                                                                                                     //collider will not exist for the anchor shape0
                {
                    if (myCollider == Physics2D.OverlapPoint(touchPos))                                                             //if the touch position overlaps with the 2D collider of the shape
                    {
                        //if (Input.touchCount == 1)
                        //{                                                                                                             //updates shape translated position https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
                        //    go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                        //                                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                        //                                                0.0f);
                        //    if (popUpIndex == 5)
                        //    {
                        //        popUpIndex = 6; //////////////
                        //        TuteLoadManager();
                        //    }

                        //}

                        if ((Input.touchCount == 2) && (rotateFlag == true))
                        {

                            Quaternion desiredRotation = go.gameObject.transform.rotation;                                           //start desiredRotation as the current orientation of the shape
                            DetectTouchMovement.Calculate();                                                                         //determines turnAngle and turnAngleDelta from 2 finger rotation on screen

                            if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)                                                  //if the detected turn angle is large enough and the shape is not small/circular
                            {
                                Vector3 rotationDeg = Vector3.zero;
                                rotationDeg.z = DetectTouchMovement.turnAngleDelta;
                                desiredRotation *= Quaternion.Euler(rotationDeg);                                                    //update the desiredRotation to include this change in angle

                                go.gameObject.transform.rotation = desiredRotation;                                                  //upate the shape rotated orientation

                                if (popUpIndex == 6)
                                {
                                    popUpIndex = 7; //////////////
                                    TuteLoadManager();

                                }
                            }
                        }

                       foreach (UnityEngine.Touch touch in Input.touches)
                      {                                                                                                                     //https://answers.unity.com/questions/369230/how-to-detect-double-tap-in-android.html?childToView=1695525#answer-1695525
                            if ((touch.tapCount >= 2) ) //flips on vertical axis if double tapped (finnicky)
                            {
                                    Vector3 temp = go.gameObject.transform.localScale;
                                    temp.x *= -1;
                                    go.gameObject.transform.localScale = temp;


                                if (popUpIndex == 7)
                                {
                                        popUpIndex = 8; //////////////
                                        TuteLoadManager();
                                }
                            }
                            else if (Input.touchCount == 1)
                            {                                                                                                             //updates shape translated position https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
                                    go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                                                0.0f);

                                if (popUpIndex == 5)
                                {
                                        popUpIndex = 6; //////////////
                                        TuteLoadManager();
                                }
                            }

                       }
                       
                    }
                }


            }
        } 
        else
        { //no touch counts

            GameObject go = GameObject.Find("Rooster");

            if (go)
            {
                if ((go.transform.position.y < Camera.main.ScreenToWorldPoint(GameObject.Find("Divider").transform.position).y) && (toolbarFlag == true))
                {
                    //if released in the toolbar return to correct place and orientation                  
                    go.transform.position = new Vector3(-0.0159f, Global.toolbarY, 0f);
                    go.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                    if (popUpIndex == 8)
                    {
                        popUpIndex = 9; //////////////
                        TuteLoadManager();
                    }
                }               

            }

        }
        
    }

    public static void TuteLoadRooster()
    {
        GameObject objToSpawn2 = new GameObject("Rooster");                                                        //assign name
        objToSpawn2.AddComponent<SpriteRenderer>();                                                                  //add a sprite renderer
        objToSpawn2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("F27");                           //assign sprite from resources folder

        objToSpawn2.transform.position = new Vector3(-0.0159f, Global.toolbarY, 0f);
        objToSpawn2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        objToSpawn2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);                                           //set scale vector
        
        objToSpawn2.GetComponent<SpriteRenderer>().sortingLayerName = "Shape2";                                      //set sorting layer by name  
        objToSpawn2.AddComponent<BoxCollider2D>();
    }

    public static void TuteLoadManager()
    {
        if (popUpIndex == 5)
        {
            TuteLoadRooster();
            TuteMovieHandler.translateFlag = true; //enable translation
        }
        else if (popUpIndex == 6)
        {
            TuteMovieHandler.rotateFlag = true; //enable rotation

        }
        else if (popUpIndex == 7)
        {
            TuteMovieHandler.tapFlag = true; //enable translation
        }
        else if (popUpIndex == 8)
        {
            TuteMovieHandler.toolbarFlag = true; //enable toolbar return
        }
        else if (popUpIndex == 9)
        {
            TuteMovieHandler.disableFlag = true; //disable interaction with rooster
        }
    }
}

 
