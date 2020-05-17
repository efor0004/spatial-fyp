using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    // controls the shape 2-finger rotation and placement

    public static string[] nameArray = new string[] {"Shape0", "Shape1", "Shape2", "Shape3", "Shape4", "Shape5", "Shape6", "Shape7", "Shape8", "Shape9"};  //the array of shape names

    //values updated at puzzle instantiation
    public static Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    public static Vector3[] rotationArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    public static bool[] activeArray = new bool[] { false, false, false, false, false, false, false, false, false, false, false };
    public static bool[] activeArrayCopy = new bool[] { false, false, false, false, false, false, false, false, false, false, false };    //will be used to save current active status when all shapes need to be made temporarily inactive
    public static bool[] smallArray = new bool[] { false, false, false, false, false, false, false, false, false, false, false};
    public static Vector3[] toolbarArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) }; //saves "rest" position
    private Collider2D myCollider; 


    void Start()
    {
        //this is activating too early
        //need to wait for shapes to load
        StartCoroutine(Wait()); //
    }

    IEnumerator Wait()
    {
       // Debug.Log("Waiting for shapes to load...");
        yield return new WaitUntil(() => Global.puzzleLoaded == true);
       // Debug.Log("Shapes are all here!");
    }
    void Update()
    {
        //adapted code from http://wiki.unity3d.com/index.php/DetectTouchMovement
        if (Input.touchCount == 2)                                                                                //at least one touch detected                                                                    
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                             //Vector3 of the touch location on the screen
            Vector2 touchPos = new Vector2(wp.x, wp.y);                                                          //Vector2 format of touch location

            foreach (string name in nameArray)
            {

                GameObject go = GameObject.Find(name);                                                            //checks if the shape exists

                if (go)
                {
                    if (activeArray[System.Array.IndexOf(nameArray, go.name)] == true)
                    {
                        myCollider = go.gameObject.GetComponent<CircleCollider2D>();

                        if (myCollider)                                                                                //collider will not exist for the anchor shape0
                        {
                            if (myCollider == Physics2D.OverlapPoint(touchPos))                                        //if the touch position overlaps with the 2D collider of the shape
                            {

                                Quaternion desiredRotation = go.gameObject.transform.rotation;                   //start desiredRotation as the current orientation of the shape
                                DetectTouchMovement.Calculate();                                                 //determines turnAngle and turnAngleDelta from 2 finger rotation on screen

                                if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0 & smallArray[System.Array.IndexOf(nameArray, go.name)] == false)   //if the detected turn angle is large enough and the shape is not small
                                {
                                    Vector3 rotationDeg = Vector3.zero;
                                    rotationDeg.z = DetectTouchMovement.turnAngleDelta;
                                    desiredRotation *= Quaternion.Euler(rotationDeg);                            //update the desiredRotation to include this change in angle

                                    go.gameObject.transform.rotation = desiredRotation;                          //upate the shape rotated orientation

                                   // Debug.Log("rotation:  " + desiredRotation + " position: " + go.gameObject.transform.position);
                                }

                                                                                                                  //updates shape translated position (1 or 2 fingers)
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
        else
        {
            foreach (string name in nameArray)
            {
                GameObject go = GameObject.Find(name);                                                              //checks if the shape exists

                if (go)
                {
                    if (activeArray[System.Array.IndexOf(nameArray, go.name)] == true)                              // if a piece is active and there are less than 2 fingers on the screen 
                    {
                        Vector3 TargetPosition = positionArray[System.Array.IndexOf(nameArray, go.name)];
                        Vector3 TargetRotation = rotationArray[System.Array.IndexOf(nameArray, go.name)];

                        if ((TargetPosition.x - Global.positionTolerance) < go.transform.position.x & go.transform.position.x < (TargetPosition.x + Global.positionTolerance)    //if shape is placed within tolerances leave it
                            & (TargetPosition.y - Global.positionTolerance) < go.transform.position.y & go.transform.position.y < (TargetPosition.y + Global.positionTolerance)
                            & (TargetRotation.z - Global.rotationTolerance) < go.transform.rotation.eulerAngles.z & go.transform.rotation.eulerAngles.z < (TargetRotation.z + Global.rotationTolerance))                                                                                     //in the correct position, leave where it is
                        {
                                                                                                                   //could make this snap to position
                            activeArray[System.Array.IndexOf(nameArray, go.name)] = false;                          //make inactive
                        }
                        else                                                                                        //not in the correct position, return to toolbar
                        {
                            //Debug.Log("name: " + go.name + " target rotaion: " + rotationArray[System.Array.IndexOf(nameArray, go.name)] + " actual rotation: " + go.transform.rotation.eulerAngles); //compare rotation of shapes that fail

                            go.transform.position = toolbarArray[System.Array.IndexOf(nameArray, go.name)];
                            go.transform.rotation = Quaternion.Euler(0, 0, 0);                                      //check this line if things fuck up/////////////////////////////////////////////////////
                        }
                    }
                }
            }
        }

    }//end update
}

//Update code with small condition/////////////////////////////////////////////////////////////////
//void Update()
//{
//    //adapted code from http://wiki.unity3d.com/index.php/DetectTouchMovement
//    if (Input.touchCount > 0)                                                                                //at least one touch detected                                                                    
//    {
//        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                             //Vector3 of the touch location on the screen
//        Vector2 touchPos = new Vector2(wp.x, wp.y);                                                          //Vector2 format of touch location

//        foreach (string name in nameArray)
//        {
//            // Debug.Log(name);
//            GameObject go = GameObject.Find(name);                                                            //checks if the shape exists

//            if (go)
//            {
//                if (activeArray[System.Array.IndexOf(nameArray, go.name)] == true)
//                {
//                    Debug.Log("the name of the shape that is active: " + go.name);

//                    collider = go.gameObject.GetComponent<CircleCollider2D>();

//                    //if (Input.touchCount == 2 & activeArray[System.Array.IndexOf(shapeArray, go)] == true)     //controls 2 finger rotation and translation 
//                    // if (Input.touchCount == 2 & activeArray[n] == true) //controls 2 finger rotation and translation 
//                    if (collider)                                                                                //collider will not exist for the anchor shape0
//                    {
//                        if (collider == Physics2D.OverlapPoint(touchPos))                                        //if the touch position overlaps with the 2D collider of the shape
//                        {
//                            //Debug.Log("index of the shapes: " + System.Array.IndexOf(nameArray, go.name));

//                            if (Input.touchCount == 2 & smallArray[System.Array.IndexOf(nameArray, go.name)] == false)       //rotate and translate for non-small shapes
//                            {
//                                Quaternion desiredRotation = go.gameObject.transform.rotation;                   //start desiredRotation as the current orientation of the shape
//                                DetectTouchMovement.Calculate();                                                 //determines turnAngle and turnAngleDelta from 2 finger rotation on screen

//                                if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)                           //if the detected turn angle is large enough
//                                {
//                                    Vector3 rotationDeg = Vector3.zero;
//                                    rotationDeg.z = DetectTouchMovement.turnAngleDelta;
//                                    desiredRotation *= Quaternion.Euler(rotationDeg);                            //update the desiredRotation to include this change in angle

//                                    go.gameObject.transform.rotation = desiredRotation;                          //upate the shape rotated orientation
//                                }

//                                //updates shape translated position (1 or 2 fingers)
//                                //https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
//                                go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
//                                                                           Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
//                                                                            0.0f);
//                            }

//                            if (Input.touchCount == 1 & smallArray[System.Array.IndexOf(nameArray, go.name)] == true)  //if small shape can translate with 1 finger
//                            {
//                                go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
//                                                                          Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
//                                                                           0.0f);
//                            }


//                            //enable 1 finger drag for only small shapes?
//                        }
//                    }

//                }
//            }


//        }

//    }

//    foreach (string name in nameArray)
//    {
//        //Debug.Log(name);
//        GameObject go = GameObject.Find(name);

//        if (go)
//        {
//            if (activeArray[System.Array.IndexOf(nameArray, go.name)] == true)
//            {

//                if (Input.touchCount < 2 & smallArray[System.Array.IndexOf(nameArray, go.name)] == false)             //if not-small and touches less than 2, return to rest position and 0 orientation
//                {
//                    go.transform.position = toolbarArray[System.Array.IndexOf(nameArray, go.name)];
//                    go.transform.rotation = Quaternion.Euler(0, 0, 0);
//                }
//                else if (Input.touchCount < 1 & smallArray[System.Array.IndexOf(nameArray, go.name)] == true)         //if small and touches less than 1, return to rest position keep orientation
//                {
//                    go.transform.position = toolbarArray[System.Array.IndexOf(nameArray, go.name)];
//                    // go.transform.rotation = Quaternion.Euler(0, 0, 0);  //could also equal to the target orientation but should not be able to change that
//                }
//            }
//        }
//    }



//}//end update








//old reset code////////////////////////////////////////////////////////////////////////////////////
//target positions - use n?
//positionArray[System.Array.IndexOf(shapeArray, go)];   
//rotationArray[System.Array.IndexOf(shapeArray, go)];

//if (Input.touchCount < 2)  //controls the resting place of the shape (in the toolbar or the correct placement on screen )
//{

//    Vector3 shadowPos = GameObject.Find("TriangleRedShadow").transform.position;
//    Quaternion shadowRot = GameObject.Find("TriangleRedShadow").transform.rotation;

//    if ((shadowPos.x - Global.positionTolerance) < transform.position.x & transform.position.x < (shadowPos.x + Global.positionTolerance)
//        & (shadowPos.y - Global.positionTolerance) < transform.position.y & transform.position.y < (shadowPos.y + Global.positionTolerance)
//        & (shadowRot.z - Global.rotationTolerance) < transform.rotation.z & transform.rotation.z < (shadowRot.z + Global.rotationTolerance))
//    {

//        shapeLoc = transform.position;
//        Active = false;
//    }
//    else
//    {
//        transform.position = shapeLoc;
//        transform.rotation = Quaternion.Euler(0, 0, 0);
//    }
//}



