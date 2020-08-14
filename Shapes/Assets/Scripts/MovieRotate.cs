using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MovieRotate : MonoBehaviour
{
    // controls translation and rotation for MovieMaker

    private Collider2D myCollider;

    Vector3 wp;
    Vector2 touchPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Global.LeftArrowActive == true)   //controls left and right arrows (verify how two commands work)
        {
            GameObject.Find("LeftArrow").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("LeftArrow").GetComponent<Button>().interactable = false;
        }

        if (Global.RightArrowActive == true)
        {
            GameObject.Find("RightArrow").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("RightArrow").GetComponent<Button>().interactable = false;
        }



        if (Input.touchCount > 0)                                                                                                         //at least one touch detected                                                                    
        {
            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                                                              //Vector3 of the touch location on the screen
            touchPos = new Vector2(wp.x, wp.y);

            //for each name in namearray//

            GameObject go = GameObject.Find("Shape1");

            if (go)
            {
                myCollider = go.gameObject.GetComponent<CircleCollider2D>();

                if (myCollider)                                                                                                     //collider will not exist for the anchor shape0
                {
                    if (myCollider == Physics2D.OverlapPoint(touchPos))                                                             //if the touch position overlaps with the 2D collider of the shape
                    {
                        if (Input.touchCount == 2)
                        {                                                                                                            //updates rotation                                                                                                     
                            Quaternion desiredRotation = go.gameObject.transform.rotation;                                           //start desiredRotation as the current orientation of the shape
                            DetectTouchMovement.Calculate();                                                                         //determines turnAngle and turnAngleDelta from 2 finger rotation on screen

                            if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)                                                  //if the detected turn angle is large enough and the shape is not small/circular
                            {
                                Vector3 rotationDeg = Vector3.zero;
                                rotationDeg.z = DetectTouchMovement.turnAngleDelta;
                                desiredRotation *= Quaternion.Euler(rotationDeg);                                                    //update the desiredRotation to include this change in angle

                                go.gameObject.transform.rotation = desiredRotation;                                                  //upate the shape rotated orientation
                            }
                        }
                        if (Input.touchCount == 1)
                        {                                                                                                             //updates shape translated position https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 
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
