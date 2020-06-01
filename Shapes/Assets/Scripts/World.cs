using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    // controls the progress bars in the World Selection Menu
    Image PlaygroundMask;
    Image TriangleMask;
    Image MouseMask;
    Image WildMask;
    Image FarmMask;

    int LevelsPerWorld = 5;
 
    void Start()
    {
        //assign mask images for each progress bar
        PlaygroundMask = GameObject.Find("PlaygroundMask").GetComponent<Image>();
        TriangleMask = GameObject.Find("TriangleMask").GetComponent<Image>();
        MouseMask = GameObject.Find("MouseMask").GetComponent<Image>();
        WildMask = GameObject.Find("WildMask").GetComponent<Image>();
        FarmMask = GameObject.Find("FarmMask").GetComponent<Image>();

        //update each progress bar
        Global.ProgressCircle(LevelsPerWorld, Global.PlaygroundLevel - 1, PlaygroundMask);
        Global.ProgressCircle(LevelsPerWorld, Global.TriangleLevel - 1, TriangleMask);
        Global.ProgressCircle(LevelsPerWorld, Global.MouseLevel - 1, MouseMask);
        Global.ProgressCircle(LevelsPerWorld, Global.WildLevel - 1, WildMask);
        Global.ProgressCircle(LevelsPerWorld, Global.FarmLevel - 1, FarmMask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
