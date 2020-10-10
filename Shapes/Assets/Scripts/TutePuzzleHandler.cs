using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutePuzzleHandler : MonoBehaviour
{
    //handles the tutorial for standard puzzles
    //https://www.youtube.com/watch?v=a1RFxtuTVsk

    public GameObject[] popUps;
    public static int popUpIndex = 0;
    public static int ChangeFlag = 0; 
    Vector3 TargetPosition = new Vector3(-0.0159f, 0.61f, 0f);
    Vector3 TargetRotation = new Vector3(0f, 0f, 0f);

    public static bool translateFlag = false;
    public static bool rotateFlag = false;
    public static bool toolbarFlag = false;
    public static bool completeFlag = false;

    private Collider2D myCollider;
    Vector3 wp;
    Vector2 touchPos;

    Vector3 MaxHeight = new Vector3(0, 300f, 0); 

    void Start()
    {

        TutePuzzleHandler.translateFlag = false;
        TutePuzzleHandler.rotateFlag = false;
        TutePuzzleHandler.toolbarFlag = false;
        TutePuzzleHandler.completeFlag = false;
        TutePuzzleHandler.popUpIndex = 0;

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

        //TuteLoadManager();

        //Debug.Log("Divider y position; " + Camera.main.ScreenToWorldPoint(GameObject.Find("Divider").transform.position).y); 

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
        if ((Input.touchCount > 0) && (translateFlag == true))                                                                                                         //at least one touch detected                                                                    
        {
  

            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                                                              //Vector3 of the touch location on the screen
            touchPos = new Vector2(wp.x, wp.y);
      
            GameObject go = GameObject.Find("RedTriangle");

                if (go)
                {
                    myCollider = go.gameObject.GetComponent<CircleCollider2D>();
   
                
                if (myCollider)                                                                                                     //collider will not exist for the anchor shape0
                    {
                        if (myCollider == Physics2D.OverlapPoint(touchPos))                                                             //if the touch position overlaps with the 2D collider of the shape
                        {

                        if (Input.touchCount == 1)
                        {      //updates shape translated position https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html 

                            if (((Camera.main.ScreenToWorldPoint(Input.mousePosition).y < Camera.main.ScreenToWorldPoint(GameObject.Find("MaxHeight").transform.position).y)&&(popUpIndex < 9)) 
                                || ((popUpIndex == 9)&&(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < Camera.main.ScreenToWorldPoint(GameObject.Find("MaxWidth").transform.position).x))) // stops shape going behind instructions
                            {
                                go.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                                           Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                                            0.0f);
                                if (popUpIndex == 6)
                                {
                                    popUpIndex = 7; //////////////
                                    TuteLoadManager();
                                }
                            }
                                        
                        }

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

                                if (popUpIndex == 7)
                                {
                                    popUpIndex = 8; //////////////
                                    TuteLoadManager();
                                 
                                }
                                }
                            }
                                                                                                                          //https://answers.unity.com/questions/369230/how-to-detect-double-tap-in-android.html?childToView=1695525#answer-1695525
     
                                 
                        }
                    }
                }
                
            
        }
        else
        { //no touch counts
              
            GameObject go = GameObject.Find("RedTriangle");

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
                else if (((TargetPosition.x - Global.positionTolerance) < go.transform.position.x && go.transform.position.x < (TargetPosition.x + Global.positionTolerance)
                        & (TargetPosition.y - Global.positionTolerance) < go.transform.position.y && go.transform.position.y < (TargetPosition.y + Global.positionTolerance)
                        & (TargetRotation.z - Global.rotationTolerance) < go.transform.rotation.eulerAngles.z && go.transform.rotation.eulerAngles.z < (TargetRotation.z + Global.rotationTolerance)) && (completeFlag == true))
                {

                    go.transform.position = TargetPosition;                            //snap to position
                    go.transform.rotation = Quaternion.Euler(TargetRotation);          //snap to orientation


                    if (popUpIndex == 9)
                    {
                        popUpIndex = 10; //////////////
                        TuteLoadManager();
                    }
                }

                }
           
        }



    }

    public static void TuteLoadTriangle()
    {
        GameObject objToSpawn2 = new GameObject("RedTriangle");                                                      //assign name
        objToSpawn2.AddComponent<SpriteRenderer>();                                                                  //add a sprite renderer
        objToSpawn2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TriangleI");                     //assign sprite from resources folder
        //objToSpawn2.transform.position = new Vector3(-0.0159f, 0.61f, 0f);                                           //set position vector
        
        float SpawnY = Camera.main.ScreenToWorldPoint(GameObject.Find("LeftArrow").transform.position).y;
        //objToSpawn2.transform.position = new Vector3(-0.0159f, Global.toolbarY, 0f);
        objToSpawn2.transform.position = new Vector3(-0.0159f, SpawnY, 0f);
        
        objToSpawn2.transform.localScale = new Vector3(0.487235f, 0.285789f, 0.439f);                                //set scale vector
        objToSpawn2.GetComponent<SpriteRenderer>().sortingLayerName = "Shape2";                                      //set sorting layer by name
        objToSpawn2.GetComponent<SpriteRenderer>().color = new Vector4(0.7169812f, 0f, 0.03755178f, 1f);             //set colour vector (RGBA) 
        objToSpawn2.AddComponent<CircleCollider2D>();
        objToSpawn2.GetComponent<CircleCollider2D>().radius = Global.regularCollider;
    }

   public static  void TuteLoadSquare()
    {
        GameObject objToSpawn = new GameObject("RedSquare");                                                          //assign name
        objToSpawn.AddComponent<SpriteRenderer>();                                                                    //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Square");                          //assign sprite from resources folder
        objToSpawn.transform.position = new Vector3(-0.02f, -1.19f, 0f);                                             //set position vector
        objToSpawn.transform.localScale = new Vector3(0.4931631f, 0.4931631f, 0.4931631f);                           //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = "Shape1";                                       //set sorting layer by name
        objToSpawn.GetComponent<SpriteRenderer>().color = new Vector4(0.7169812f, 0f, 0.03755178f, 1f);              //set colour vector (RGBA) 
    }

 public static void TuteLoadHouse()
    {
        GameObject objToSpawn3 = new GameObject("House");                                                            //assign name
        objToSpawn3.AddComponent<SpriteRenderer>();                                                                  //add a sprite renderer
        objToSpawn3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MS1");                           //assign sprite from resources folder
        objToSpawn3.transform.position = new Vector3(-0.4f, 3.630444f, 0f);                                          //set position vector
        objToSpawn3.transform.localScale = new Vector3(1f, 1f, 1f);                                                  //set scale vector
        objToSpawn3.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";                                  //set sorting layer by name

    }

    public static void TuteLoadManager()

    // FindObjectOfType<AudioManager>().Play("Button"); //plays button sound
    {

        switch (popUpIndex)
        {
            case 0:
                {
                   // FindObjectOfType<AudioManager>().Play("p0");
                }
                break;
            case 1:
                {
                    FindObjectOfType<AudioManager>().Stop("p0");
                    FindObjectOfType<AudioManager>().Play("p1");
                }
                break;
            case 2:
                {
                    FindObjectOfType<AudioManager>().Stop("p1");
                    FindObjectOfType<AudioManager>().Play("p2");
                }
                break;
            case 3:
                {
                    FindObjectOfType<AudioManager>().Stop("p2");
                    FindObjectOfType<AudioManager>().Play("p3");
                }
                break;
            case 4:
                {
                    FindObjectOfType<AudioManager>().Stop("p3");
                    FindObjectOfType<AudioManager>().Play("p4");
                }
                break;
            case 5:
                {
                    FindObjectOfType<AudioManager>().Stop("p4");
                    FindObjectOfType<AudioManager>().Play("p5");

                    TuteLoadHouse();
                }
                break;
            case 6:
                {
                    FindObjectOfType<AudioManager>().Stop("p5");
                    FindObjectOfType<AudioManager>().Play("p6");
                    TuteLoadTriangle();
                    TutePuzzleHandler.translateFlag = true;
                }
                break;
            case 7:
                {
                    FindObjectOfType<AudioManager>().Stop("p6");
                    FindObjectOfType<AudioManager>().Play("p7");
                    TutePuzzleHandler.rotateFlag = true; //enable rotation
                }
                break;
            case 8:
                {
                    FindObjectOfType<AudioManager>().Stop("p7");
                    FindObjectOfType<AudioManager>().Play("p8");
                    TutePuzzleHandler.toolbarFlag = true; //enable toolbar return
                }
                break;
            case 9:
                {
                    FindObjectOfType<AudioManager>().Stop("p8");
                    FindObjectOfType<AudioManager>().Play("p9");
                    TuteLoadSquare();
                    TutePuzzleHandler.completeFlag = true; //enable correct placement
                }
                break;
            case 10:
                {
                    FindObjectOfType<AudioManager>().Stop("p9");
                    FindObjectOfType<AudioManager>().Play("p10");
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
        //    TuteLoadHouse();
        //}
        //else if (popUpIndex == 6)
        //{
        //    TuteLoadTriangle();
        //    TutePuzzleHandler.translateFlag = true; //enable translation

        //}
        //else if (popUpIndex == 7)
        //{
        //    TutePuzzleHandler.rotateFlag = true; //enable rotation
        //}
        //else if (popUpIndex == 8)
        //{
        //    TutePuzzleHandler.toolbarFlag = true; //enable toolbar return
        //}
        //else if (popUpIndex == 9)
        //{
        //    TuteLoadSquare();
        //    TutePuzzleHandler.completeFlag = true; //enable correct placement
        //}

    }
}
