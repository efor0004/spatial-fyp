using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class TouchRotate : MonoBehaviour
{
    // controls the shape 2-finger rotation and placement in puzzle worlds

    //values updated at puzzle instantiation (max 15 shapes in a puzzle)
    public static string[] nameArray = new string[] {"Shape0", "Shape1", "Shape2", "Shape3", "Shape4", "Shape5", "Shape6", "Shape7", "Shape8", "Shape9", "Shape10", "Shape11", "Shape12", "Shape13", "Shape14"};  //the array of shape names
    public static Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)};
    public static Vector3[] rotationArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)};
    public static bool[] activeArray = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    public static bool[] smallArray = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    public static bool[] circleArray = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    public static Vector3[] toolbarArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)}; //saves "rest" position
    public static Vector3[] toolbarRotationArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)}; //saves rest orientation
    public static string[] layerArray = new string[] { "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6", "Shape6" };  //the array of shape names
    
    private Collider2D myCollider;
    Vector3 wp;
    Vector2 touchPos;

    void Start()
    {
    
        Global.PieceActive = false; 
    
    }

    void Update()
    {
        
        if (Global.PieceActive == true)                                                          //determines whether toolbar arrows are active or not
        {
                GameObject.Find("LeftArrow").GetComponent<Button>().interactable = false;
                GameObject.Find("RightArrow").GetComponent<Button>().interactable = false;
        }
        else if (Global.PieceActive == false)
        {
            if (Global.LeftArrowActive == true)
            {
                GameObject.Find("LeftArrow").GetComponent<Button>().interactable = true;
            }
            else if (Global.LeftArrowActive == false)
            {
                GameObject.Find("LeftArrow").GetComponent<Button>().interactable = false;
            }

            if (Global.RightArrowActive == true)
            {
                GameObject.Find("RightArrow").GetComponent<Button>().interactable = true;
            }
            else if (Global.RightArrowActive == false)
            {
                GameObject.Find("RightArrow").GetComponent<Button>().interactable = false;
            }

        }


        //adapted code from http://wiki.unity3d.com/index.php/DetectTouchMovement
        if (Input.touchCount > 0)                                                                                                         //at least one touch detected                                                                    
        {
            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                                                              //Vector3 of the touch location on the screen
            touchPos = new Vector2(wp.x, wp.y);                                                                                           //Vector2 format of touch location

            foreach (string name in nameArray)
            {
                GameObject go = GameObject.Find(name);                                                                                     //checks if the shape exists

                if (go)
                {
                    if ((activeArray[System.Array.IndexOf(nameArray, go.name)] == true && Global.PieceActive == false) || (Global.ActiveName == go.name && Global.PieceActive == true))                             //if shape is active
                    {                                                                                                                       //the shape is active
                        myCollider = go.gameObject.GetComponent<CircleCollider2D>();                                                        

                        if (myCollider)                                                                                                     //collider will not exist for the anchor shape0
                        {
                            if (myCollider == Physics2D.OverlapPoint(touchPos))                                                             //if the touch position overlaps with the 2D collider of the shape
                            {

                                if (Input.touchCount == 2 && circleArray[System.Array.IndexOf(nameArray, go.name)] == false && smallArray[System.Array.IndexOf(nameArray, go.name)] == false)
                                {                                                                                                            //updates rotation                                                                                                     
                                    Quaternion desiredRotation = go.gameObject.transform.rotation;                                           //start desiredRotation as the current orientation of the shape
                                    DetectTouchMovement.Calculate();                                                                         //determines turnAngle and turnAngleDelta from 2 finger rotation on screen

                                    if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0 )                                                  //if the detected turn angle is large enough and the shape is not small/circular
                                    {
                                        Vector3 rotationDeg = Vector3.zero;
                                        rotationDeg.z = DetectTouchMovement.turnAngleDelta;
                                        desiredRotation *= Quaternion.Euler(rotationDeg);                                                    //update the desiredRotation to include this change in angle

                                        go.gameObject.transform.rotation = desiredRotation;                                                  //upate the shape rotated orientation
                                    }
                                }
                                if (Input.touchCount == 1)
                                {
                                                                                                                                              //updates shape translated position 
                                                                                                                                              //https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
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
        else                                                                                                                                         //no touches
        {
            
            foreach (string name in nameArray)
            {
                GameObject go = GameObject.Find(name);                                                                                                 //checks if the shape exists
                

                if (go)
                {
                    if ((activeArray[System.Array.IndexOf(nameArray, go.name)] == true && Global.PieceActive == false) ||(Global.ActiveName == go.name && Global.PieceActive == true))                             
                    {
                        Vector3 TargetPosition = positionArray[System.Array.IndexOf(nameArray, go.name)];
                        Vector3 TargetRotation = rotationArray[System.Array.IndexOf(nameArray, go.name)];

                        float TargetRotationOp = (TargetRotation.z + 180)%360; ///
                       

                        if ((TargetPosition.x - Global.positionTolerance) < go.transform.position.x && go.transform.position.x < (TargetPosition.x + Global.positionTolerance)         
                            && (TargetPosition.y - Global.positionTolerance) < go.transform.position.y && go.transform.position.y < (TargetPosition.y + Global.positionTolerance)
                            && ((TargetRotation.z - Global.rotationTolerance) < go.transform.rotation.eulerAngles.z && go.transform.rotation.eulerAngles.z < (TargetRotation.z + Global.rotationTolerance) ||
                             ((go.GetComponent<SpriteRenderer>().sprite.name == "Square" || go.GetComponent<SpriteRenderer>().sprite.name == "Parallelogram") && (TargetRotationOp - Global.rotationTolerance) < go.transform.rotation.eulerAngles.z && go.transform.rotation.eulerAngles.z < (TargetRotationOp + Global.rotationTolerance))
                            ))                                                                                    //in the correct position, leave where it is
                      
                        {                                                                                         //if shape is placed within tolerances 
                            Global.PieceActive = false;

                            activeArray[System.Array.IndexOf(nameArray, go.name)] = false;
                            Global.piecesPlaced++;                                                                                                        

                            for (int i = 0; i < toolbarArray.Length; i++)
                            {
                                if (i > System.Array.IndexOf(nameArray, go.name))
                                { 
                                toolbarArray[i] = toolbarArray[i] - Global.shapeOffset;
                                }
                            }

                            go.GetComponent<SpriteRenderer>().sortingLayerName = layerArray[System.Array.IndexOf(nameArray, go.name)]; //move to correct layer

                            go.GetComponent<CircleCollider2D>().enabled = false;               //disable collider of placed shape

                            go.transform.position = TargetPosition;                            //snap to position
                            go.transform.rotation = Quaternion.Euler(TargetRotation);          //snap to orientation

                            Vector4 OldColour = go.GetComponent<SpriteRenderer>().color;
                            Vector4 NewColour = OldColour + Global.ColourOffset;

                            if (Global.SoundEffects == true)
                                FindObjectOfType<AudioManager>().Play("Correct"); //plays correct placement sound
                           
                            StartCoroutine(FlashObject(go, OldColour, NewColour, 0.5f, 0.125f));                                                         //make correclty placed piece flash

                            Global.CheckArrows(); 

                        }
                        else if (go.transform.position.y < Camera.main.ScreenToWorldPoint(GameObject.Find("Divider").transform.position).y)              //if piece is released inside toolbar
                        {

                            go.transform.position = toolbarArray[System.Array.IndexOf(nameArray, go.name)];
                            go.transform.rotation = Quaternion.Euler(toolbarRotationArray[System.Array.IndexOf(nameArray, go.name)]);

                            Global.PieceActive = false;
                        }
                        else                                                                                                                             //if piece is released in assembly area                                                  
                        {
                            if (Global.PieceActive == false)
                            {
                                Global.PieceActive = true;
                                Global.ActiveName = go.name;  
                            }

                        }

                    }
                }
            }



        }

    }//end update

    IEnumerator FlashObject(GameObject toFlash, Color originalColor, Color flashColor, float flashTime, float flashSpeed)
    {
        //makes object flash colours for a certain time
        //triggered by correctly placing a piece
        //adapted from https://answers.unity.com/questions/1367570/how-to-make-enemies-flash-on-hit.html

        float flashingFor = 0;
        Color newColor = flashColor;
        while (flashingFor < flashTime)
        {
            toFlash.GetComponent<SpriteRenderer>().color = newColor;
            flashingFor += Time.deltaTime;
            yield return new WaitForSeconds(flashSpeed);
            flashingFor += flashSpeed;
            if (newColor == flashColor)
            {
                newColor = originalColor;
            }
            else
            {
                newColor = flashColor;
            }
        }
    }


}



                   
                          
                            