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
    public static bool pinchFlag = false;


    private Collider2D myCollider;
    Vector3 wp;
    Vector2 touchPos;

    float maxScale = 3;                           //maximum x/y scale up
    float minScale = 0.5f;                        //min x/y scale down
    float scaleIncrement = 0.05f;                  //increment of scaling up/down each loop
    float pinchThresh = 1f;                     //pinchAmount threshold before scaling begins

    //Vector3 MaxHeight = new Vector3(0, 300f, 0);
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


      // TuteLoadManager(); 
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

                        if ((Input.touchCount == 2) && (rotateFlag == true))
                        {

                            Quaternion desiredRotation = go.gameObject.transform.rotation;                                           //start desiredRotation as the current orientation of the shape
                            DetectTouchPinch.Calculate();                                                                         //determines turnAngle and turnAngleDelta from 2 finger rotation on screen
                           
                            float pinchAmount = 0;

                            if (Mathf.Abs(DetectTouchPinch.turnAngleDelta) > 0)                                                  //if the detected turn angle is large enough and the shape is not small/circular
                            { //ROTATION
                                Vector3 rotationDeg = Vector3.zero;
                                rotationDeg.z = DetectTouchPinch.turnAngleDelta;
                                desiredRotation *= Quaternion.Euler(rotationDeg);                                                    //update the desiredRotation to include this change in angle

                                go.gameObject.transform.rotation = desiredRotation;                                                  //upate the shape rotated orientation

                                if (popUpIndex == 6)
                                {
                                    popUpIndex = 7; //////////////
                                    TuteLoadManager();
                                }
                            }

                          
                            if ((Mathf.Abs(DetectTouchPinch.pinchDistanceDelta) > 0) && pinchFlag == true)
                            { //PINCH
                                    pinchAmount = DetectTouchPinch.pinchDistanceDelta;

                                    //  Debug.Log("pinchAmount: " + pinchAmount);

                                    if (pinchAmount > pinchThresh)
                                    {
                                        //positive pinch scale up
                                        if (Mathf.Abs(go.gameObject.transform.localScale.x) < maxScale && Mathf.Abs(go.gameObject.transform.localScale.y) < maxScale)
                                        {
                                            // go.gameObject.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, 0f);
                                            go.gameObject.transform.localScale *= (1 + scaleIncrement);

                                           if (popUpIndex == 8)
                                            {
                                            popUpIndex = 9; //////////////
                                            TuteLoadManager();
                                            }
                                    }
                                        }
                                    if (pinchAmount < -pinchThresh)
                                    {
                                        //negative pinch scale down
                                        if (Mathf.Abs(go.gameObject.transform.localScale.x) > minScale && Mathf.Abs(go.gameObject.transform.localScale.y) > minScale)
                                        {
                                            //go.gameObject.transform.localScale -= new Vector3(scaleIncrement, scaleIncrement, 0f);
                                            go.gameObject.transform.localScale *= (1 - scaleIncrement);

                                           if (popUpIndex == 8)
                                           {
                                            popUpIndex = 9; //////////////
                                            TuteLoadManager();
                                           }
                                        }
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
                                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < Camera.main.ScreenToWorldPoint(GameObject.Find("MaxHeight").transform.position).y) // stops shape going behind instructions
                                {
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
        } 
        else
        { //no touch counts

            GameObject go = GameObject.Find("Rooster");

            if (go)
            {
                if ((go.transform.position.y < Camera.main.ScreenToWorldPoint(GameObject.Find("Divider").transform.position).y) && (toolbarFlag == true))
                {
                    //if released in the toolbar return to correct place orientation and scale                 
                    go.transform.position = new Vector3(-0.0159f, Global.toolbarY, 0f);
                    go.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    go.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

                    if (popUpIndex == 9)
                    {
                        popUpIndex = 10; ////////////////
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

        switch (popUpIndex)
        {
            case 0:
                {
                   // FindObjectOfType<AudioManager>().Play("m0");
                }
                break;
            case 1:
                {
                    FindObjectOfType<AudioManager>().Stop("m0");
                    FindObjectOfType<AudioManager>().Play("m1");               
                }
                break;
            case 2:
                {
                    FindObjectOfType<AudioManager>().Stop("m1");
                    FindObjectOfType<AudioManager>().Play("m2");
                }
                break;
            case 3:
                {
                    FindObjectOfType<AudioManager>().Stop("m2");
                    FindObjectOfType<AudioManager>().Play("m3");
                }
                break;
            case 4:
                {
                    FindObjectOfType<AudioManager>().Stop("m3");
                    FindObjectOfType<AudioManager>().Play("m4");
                }
                break;
            case 5:
                {
                    FindObjectOfType<AudioManager>().Stop("m4");
                    FindObjectOfType<AudioManager>().Play("m5");
                    TuteLoadRooster();
                    TuteMovieHandler.translateFlag = true; //enable translation
                }
                break;
            case 6:
                {
                    FindObjectOfType<AudioManager>().Stop("m5");
                    FindObjectOfType<AudioManager>().Play("m6");
                    TuteMovieHandler.rotateFlag = true; //enable rotation
                }
                break;
            case 7:
                {
                    FindObjectOfType<AudioManager>().Stop("m6");
                    FindObjectOfType<AudioManager>().Play("m7");
                    TuteMovieHandler.tapFlag = true; //enable translation
                }
                break;
            case 8:
                {
                    FindObjectOfType<AudioManager>().Stop("m7");  ////////////////////////
                    FindObjectOfType<AudioManager>().Play("m8");
                    TuteMovieHandler.pinchFlag = true; //enable toolbar return
                }
                break;
            case 9:
                {
                    FindObjectOfType<AudioManager>().Stop("m8");
                    FindObjectOfType<AudioManager>().Play("m9");
                    TuteMovieHandler.toolbarFlag = true; //enable toolbar return
                }
                break;
            case 10:
                {
                    FindObjectOfType<AudioManager>().Stop("m9");
                    FindObjectOfType<AudioManager>().Play("m10");
                    TuteMovieHandler.disableFlag = true; //disable interaction with rooster
                }
                break;
            case 11:
                {
                    FindObjectOfType<AudioManager>().Stop("m10");
                    FindObjectOfType<AudioManager>().Play("m11");
                }
                break;
            case 12:
                {
                    FindObjectOfType<AudioManager>().Stop("m11");
                    FindObjectOfType<AudioManager>().Play("m12");
                }
                break;
            default:
                {
                    Debug.Log("error in TutePuzzleHandler case statement");
                }
                break;
        }

        //if (popUpIndex == 5)
        //{
        //    TuteLoadRooster();
        //    TuteMovieHandler.translateFlag = true; //enable translation
        //}
        //else if (popUpIndex == 6)
        //{
        //    TuteMovieHandler.rotateFlag = true; //enable rotation

        //}
        //else if (popUpIndex == 7)
        //{
        //    TuteMovieHandler.tapFlag = true; //enable translation
        //}
        //else if (popUpIndex == 8)
        //{
        //    TuteMovieHandler.toolbarFlag = true; //enable toolbar return
        //}
        //else if (popUpIndex == 9)
        //{
        //    TuteMovieHandler.disableFlag = true; //disable interaction with rooster
        //}

    }
}

 
