using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    // controls the shape 2-finger rotation and placement

    public string[] nameArray = new string[] { "Shape0", "Shape1", "Shape2", "Shape3", "Shape4", "Shape5", "Shape6", "Shape7", "Shape8", "Shape9"};  //the array of shape names

    //values updated at puzzle instantiation
    public Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    public Vector3[] rotationArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    public bool[] activeArray = new bool[] { true, true, true, true, true, true, true, true, true, true, true};

    private Collider2D collider; 

    int n; 
    // Start is called before the first frame update
    void Start()
    {
        //n = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //adapted code from http://wiki.unity3d.com/index.php/DetectTouchMovement
        if (Input.touchCount == 2) //controls 2 finger rotation and translation 
        {
            Debug.Log("1. fingers detected"); 

            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); //Vector3 of the touch location on the screen
            Vector2 touchPos = new Vector2(wp.x, wp.y);                              //Vector2 format of touch location

            foreach (string name in nameArray)
            {
                GameObject go = GameObject.Find(name);                                                //checks if the shape exists

                if (go)
                {
                    Debug.Log("2. checking shape: " + go.name);

                    collider = go.gameObject.GetComponent<CircleCollider2D>(); //cannot pass the overlap test

                    //if (Input.touchCount == 2 & activeArray[System.Array.IndexOf(shapeArray, go)] == true) //controls 2 finger rotation and translation 
                    // if (Input.touchCount == 2 & activeArray[n] == true) //controls 2 finger rotation and translation 
                    if (collider == Physics2D.OverlapPoint(touchPos))                       //if the touch position overlaps with the 2D collider of the shape
                        {
                            Debug.Log("3. overlap detected");

                            Quaternion desiredRotation = go.gameObject.transform.rotation;           //start desiredRotation as the current orientation of the shape
                            DetectTouchMovement.Calculate();                                         //determines turnAngle and turnAngleDelta from 2 finger rotation on screen

                            if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)             //if the detected turn angle is large enough
                            {  
                               Vector3 rotationDeg = Vector3.zero;
                                rotationDeg.z = DetectTouchMovement.turnAngleDelta;
                                desiredRotation *= Quaternion.Euler(rotationDeg);              //update the desiredRotation to include this change in angle

                                go.gameObject.transform.rotation = desiredRotation;            //upate the shape rotated orientation
                            }
                            //updates shape translated position
                            //https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
                            go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                                       Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                                        0.0f);
                        Debug.Log("4. position and rotation updated");
                    }//end if overlap

                }//end if go


            }//end for each shape
           // n = n + 1;
        }//end if 2 touches
    }//end update
}

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



