using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MovieRotate : MonoBehaviour
{
    // controls translation, rotation, pinch and double-tap in MovieMaker


    public static string[] movieArray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10",
                                                       "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20",
                                                       "F21", "F22", "F23", "F24", "F25", "F26", "F27", "F28", "F29", "F30",
                                                       "F31", "F32", "F33", "F34", "F35", "F36", "F37", "F38", "F39", "F40",
                                                       "F41", "F42", "F43", "F44", "F45", "F46", "F47", "F48", "F49", "F50",
                                                       "MS1", "MS2", "MS3", "MS4", "MS5", "MS6", "MS7", "MS8", "MS9", "MS10",
                                                       "MS11", "MS12", "MS13", "MS14", "MS15",};  //the array of shape names
    public static Vector3[] selectionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f),
                                                  new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)}; //the arrow of toolbar positions
    public static bool[] playArray = new bool[] { false, false, false, false, false, false, false, false, false, false, 
                                                  false, false, false, false, false, false, false, false, false, false,
                                                  false, false, false, false, false, false, false, false, false, false,
                                                  false, false, false, false, false, false, false, false, false, false,
                                                  false, false, false, false, false, false, false, false, false, false,
                                                  false, false, false, false, false, false, false, false, false, false,
                                                  false, false, false, false, false};

    private Collider2D myCollider;

    Vector3 wp;
    Vector2 touchPos;

    float maxScale = 2;                           //maximum x/y scale up
    float minScale = 0.5f;                        //min x/y scale down
    float scaleIncrement = 0.05f;                 //increment of scaling up/down each loop
    float pinchThresh = 1f;                       //pinchAmount threshold before scaling begins

    void Start()
    {

    }

    void Update()
    {
        if (Global.LeftArrowActiveMovie == true)                                           //updatesleft and right toolbat arrows
        {
            GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = false;
        }

        if (Global.RightArrowActiveMovie == true)
        {
            GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = false;
        }


        if (Input.touchCount > 0)                                                                                                        //at least one touch detected                                                                    
        {
            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                                                             //Vector3 of the touch location on the screen
            touchPos = new Vector2(wp.x, wp.y);

            foreach (string name in movieArray)
            {
                GameObject go = GameObject.Find(name);

                if (go)
                {
                    myCollider = go.gameObject.GetComponent<CircleCollider2D>();

                    if (myCollider)                                                                                                     //collider will not exist for the anchor shape0
                    {
                        if (myCollider == Physics2D.OverlapPoint(touchPos))                                                             //if the touch position overlaps with the 2D collider of the shape
                        {
                            playArray[System.Array.IndexOf(movieArray, go.name)] = true;  //in play


                            if (Input.touchCount == 2)
                            {                                                                                                            //updates rotation                                                                                                     
                                Quaternion desiredRotation = go.gameObject.transform.rotation;                                           //start desiredRotation as the current orientation of the shape
                                float pinchAmount = 0;
                                
                                DetectTouchPinch.Calculate();

                                if (Mathf.Abs(DetectTouchPinch.pinchDistanceDelta) > 0)
                                {    //PINCH
                                    pinchAmount = DetectTouchPinch.pinchDistanceDelta;                              
                                    
                                    if (pinchAmount > pinchThresh)
                                    {
                                        //positive pinch scale up
                                        if (Mathf.Abs(go.gameObject.transform.localScale.x) < maxScale && Mathf.Abs(go.gameObject.transform.localScale.y) < maxScale)
                                        {                                         
                                            go.gameObject.transform.localScale *= (1 + scaleIncrement); 
                                        }                                 
                                    }
                                    if (pinchAmount < -pinchThresh)
                                    {
                                        //negative pinch scale down
                                        if (Mathf.Abs(go.gameObject.transform.localScale.x) > minScale && Mathf.Abs(go.gameObject.transform.localScale.y) > minScale)
                                        {
                                            go.gameObject.transform.localScale *= (1 - scaleIncrement);
                                        }
                                    }
                                }
                                                              
                                if (Mathf.Abs(DetectTouchPinch.turnAngleDelta) > 0)                                                    //if the detected turn angle is large enough and the shape is not small/circular
                                {   //ROTATE 
                                    Vector3 rotationDeg = Vector3.zero;
                                    rotationDeg.z = DetectTouchPinch.turnAngleDelta;
                                    desiredRotation *= Quaternion.Euler(rotationDeg);                                                  //update the desiredRotation to include this change in angle

                                    go.gameObject.transform.rotation = desiredRotation;                                                //upate the shape rotated orientation
                                }
                            }
                            foreach (UnityEngine.Touch touch in Input.touches)
                            {                                                                                                          //https://answers.unity.com/questions/369230/how-to-detect-double-tap-in-android.html?childToView=1695525#answer-1695525
                                if (touch.tapCount >= 2)                                                                               //flips on vertical axis if double tapped (finnicky)
                                {  //DOUBLE TAP
                                    Vector3 temp = go.gameObject.transform.localScale;
                                    temp.x *= -1;
                                    go.gameObject.transform.localScale = temp;
                                }
                                else if (Input.touchCount == 1)
                                {   //TRANSLATE                                                                                          //updates shape translated position https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
                                    go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                                                0.0f);
                                }
                            }
                        }
                    }
                }
            }
        }
        else 
        { //no touch counts
            foreach (string name in movieArray)
            {
                GameObject go = GameObject.Find(name);

                if (go)
                {
                    if ((go.transform.position.y < Camera.main.ScreenToWorldPoint(GameObject.Find("Divider").transform.position).y) && (Global.Recording == false) )
                    {
                        //if released in the toolbar return to correct place, orientation and scale
                        playArray[System.Array.IndexOf(movieArray, go.name)] = false;                               //not in play

                        go.transform.position = selectionArray[System.Array.IndexOf(movieArray, go.name)];
                        go.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        go.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f); 
                    }
                    
                }
            }

        }

    } //end update

}
