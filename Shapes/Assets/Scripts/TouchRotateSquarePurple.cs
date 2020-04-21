using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotateSquarePurple : MonoBehaviour
{
    //adapted code from http://wiki.unity3d.com/index.php/DetectTouchMovement

    // Start is called before the first frame update
    private Collider2D collider;
    public static Vector3 shapeLoc;
    public static bool Active = true;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        shapeLoc = transform.position;
        //Debug.Log("Square Purple position: " + shapeLoc + "\n");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 2 & Active == true)
        {
            // float pinchAmount = 0;
            Quaternion desiredRotation = transform.rotation;
            DetectTouchMovement.Calculate();

            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            if (collider == Physics2D.OverlapPoint(touchPos))
            { // rotate

                if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
                {
                    Vector3 rotationDeg = Vector3.zero;
                    rotationDeg.z = DetectTouchMovement.turnAngleDelta;
                    desiredRotation *= Quaternion.Euler(rotationDeg);

                    transform.rotation = desiredRotation;
                }

                //https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                           Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                            0.0f);
            }
        }

        if (Input.touchCount < 2)
        {
            Vector3 shadowPos = GameObject.Find("SquarePurpleShadow").transform.position;
            Quaternion shadowRot = GameObject.Find("SquarePurpleShadow").transform.rotation;

            if ((shadowPos.x - Global.positionTolerance) < transform.position.x & transform.position.x < (shadowPos.x + Global.positionTolerance)
                & (shadowPos.y - Global.positionTolerance) < transform.position.y & transform.position.y < (shadowPos.y + Global.positionTolerance)
                & (shadowRot.z - Global.rotationTolerance) < transform.rotation.z & transform.rotation.z < (shadowRot.z + Global.rotationTolerance))
            {

                shapeLoc = transform.position;
                Active = false;
            }
            else
            {
                transform.position = shapeLoc;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }
}
