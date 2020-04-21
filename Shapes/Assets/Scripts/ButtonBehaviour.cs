using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
   // int n;
    public void OnButtonPress()
    {
      //  Debug.Log("Entered On Button Press\n");

      //  n++;
      //  Debug.Log("Button clicked " + n + " times.");
    }
    public void LeftArrow() 
    {
        if (TouchRotateSquarePurple.Active == true)
        {
            GameObject.Find("SquarePurple").transform.position += Global.menuOffset;
            TouchRotateSquarePurple.shapeLoc = GameObject.Find("SquarePurple").transform.position;
        }

        if (TouchRotateTriangleRed.Active == true)
        {
            GameObject.Find("TriangleRed").transform.position += Global.menuOffset;
            TouchRotateTriangleRed.shapeLoc = GameObject.Find("TriangleRed").transform.position;
        }

        if (TouchRotateDiamondYellow.Active == true)
        {
            GameObject.Find("DiamondYellow").transform.position += Global.menuOffset;
            TouchRotateDiamondYellow.shapeLoc = GameObject.Find("DiamondYellow").transform.position;
        }

    }

    public void RightArrow()
    {
        if (TouchRotateSquarePurple.Active == true)
        {
            GameObject.Find("SquarePurple").transform.position -= Global.menuOffset;
            TouchRotateSquarePurple.shapeLoc = GameObject.Find("SquarePurple").transform.position;
        }

        if (TouchRotateTriangleRed.Active == true)
        {
            GameObject.Find("TriangleRed").transform.position -= Global.menuOffset;
            TouchRotateTriangleRed.shapeLoc = GameObject.Find("TriangleRed").transform.position;
        }

        if (TouchRotateDiamondYellow.Active == true)
        {
            GameObject.Find("DiamondYellow").transform.position -= Global.menuOffset;
            TouchRotateDiamondYellow.shapeLoc = GameObject.Find("DiamondYellow").transform.position;
        }
    }

}
