using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    // controls the progress bars in the World Selection Menu
    // NOTE the buttons and progress bars for "Playground", "Triangle" and "Wild" worlds have been removed from the UI but can be easily added by following the naming/colour conventions and uncommenting the related lines

    Image MouseMask;
    Image FarmMask;
    //Image PlaygroundMask;                         //related scenes not currently in use
    //Image TriangleMask;
    //Image WildMask;

    int MouseLevelsPerWorld = 3;                    //how many levels are in this world
    int FarmLevelsPerWorld = 10;
    //int PlaygroundLevelsPerWorld = 5;             //related scenes not currently in use
    //int TriangleLevelsPerWorld = 5; 
    //int WildLevelsPerWorld = 5; 

    void Start()
    {       
        MouseMask = GameObject.Find("MouseMask").GetComponent<Image>();                //assign mask images for each progress bar
        FarmMask = GameObject.Find("FarmMask").GetComponent<Image>();
        //PlaygroundMask = GameObject.Find("PlaygroundMask").GetComponent<Image>();    //related scenes not currently in use
        //TriangleMask = GameObject.Find("TriangleMask").GetComponent<Image>();
        //WildMask = GameObject.Find("WildMask").GetComponent<Image>();


        //update each progress bar
        //need to adjust as the puzzle progress gets updated inside puzzle

        if (Global.MousePuzzle == 5)
        {
            Global.ProgressCircle(MouseLevelsPerWorld, Global.MouseLevel, MouseMask);
        }
        else
        {
            Global.ProgressCircle(MouseLevelsPerWorld, Global.MouseLevel - 1, MouseMask);
        }

        if (Global.FarmPuzzle == 5)
        {
            Global.ProgressCircle(FarmLevelsPerWorld, Global.FarmLevel, FarmMask);
        }
        else
        {
            Global.ProgressCircle(FarmLevelsPerWorld, Global.FarmLevel - 1, FarmMask);
        }

        //if (Global.PlaygroundPuzzle == 5)                                                                //related scenes not currently in use
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

        //if (Global.WildPuzzle == 5)
        //{
        //    Global.ProgressCircle(WildLevelsPerWorld, Global.WildLevel, WildMask);
        //}
        //else
        //{
        //    Global.ProgressCircle(WildLevelsPerWorld, Global.WildLevel - 1, WildMask);
        //}

    }

    void Update()
    {
        
    }
}
