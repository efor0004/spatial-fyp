using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    // controls the progress bars in the World Selection Menu
    // NOTE the buttons and progress bars for "Playground", "Triangle" and "Wild" worlds have been removed from the UI but can be easily added by following the naming/colour conventions and uncommenting the related lines


    //Image PlaygroundMask;
    //Image TriangleMask;
    Image MouseMask;
   //Image WildMask;
    Image FarmMask;

    //how many levels are in this world
    //int PlaygroundLevelsPerWorld = 5; //?
    //int TriangleLevelsPerWorld = 5; //?
    int MouseLevelsPerWorld = 3; 
    //int WildLevelsPerWorld = 5; //?
    int FarmLevelsPerWorld = 10;

    void Start()
    {
        //assign mask images for each progress bar
        //PlaygroundMask = GameObject.Find("PlaygroundMask").GetComponent<Image>();
        //TriangleMask = GameObject.Find("TriangleMask").GetComponent<Image>();
        MouseMask = GameObject.Find("MouseMask").GetComponent<Image>();
       //WildMask = GameObject.Find("WildMask").GetComponent<Image>();
        FarmMask = GameObject.Find("FarmMask").GetComponent<Image>();

        //update each progress bar
        // need to adjust as the puzzle progress gets updated inside puzzle

        //if (Global.PlaygroundPuzzle == 5)
        //{
        //    Global.ProgressCircle(PlaygroundLevelsPerWorld, Global.PlaygroundLevel, PlaygroundMask);
        //}
        //else 
        //{
        //    Global.ProgressCircle(PlaygroundLevelsPerWorld, Global.PlaygroundLevel - 1, PlaygroundMask);
        //}

        //if (Global.TrianglePuzzle == 5)
        //{
        //    Global.ProgressCircle(TriangleLevelsPerWorld, Global.TriangleLevel, TriangleMask);
        //}
        //else
        //{
        //    Global.ProgressCircle(TriangleLevelsPerWorld, Global.TriangleLevel - 1, TriangleMask);
        //}

        if (Global.MousePuzzle == 5)
        {
            Global.ProgressCircle(MouseLevelsPerWorld, Global.MouseLevel, MouseMask);
        }
        else
        {
            Global.ProgressCircle(MouseLevelsPerWorld, Global.MouseLevel - 1, MouseMask);
        }

        //if (Global.WildPuzzle == 5)
        //{
        //    Global.ProgressCircle(WildLevelsPerWorld, Global.WildLevel, WildMask);
        //}
        //else
        //{
        //    Global.ProgressCircle(WildLevelsPerWorld, Global.WildLevel - 1, WildMask);
        //}

        if (Global.FarmPuzzle == 5)
        {
            Global.ProgressCircle(FarmLevelsPerWorld, Global.FarmLevel, FarmMask);
        }
        else
        {
            Global.ProgressCircle(FarmLevelsPerWorld, Global.FarmLevel - 1, FarmMask);
        }



        //disable Worlds while not populated
       //GameObject.Find("PlaygroundButton").GetComponent<Button>().interactable = false;
       //GameObject.Find("TriangleButton").GetComponent<Button>().interactable = false;
       //GameObject.Find("WildButton").GetComponent<Button>().interactable = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
