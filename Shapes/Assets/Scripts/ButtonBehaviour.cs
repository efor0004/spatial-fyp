using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonBehaviour : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    public void LeftArrow() 
    {
        //if (TouchRotateSquarePurple.Active == true)
        //{
        //    GameObject.Find("SquarePurple").transform.position += Global.shapeOffset;
        //    TouchRotateSquarePurple.shapeLoc = GameObject.Find("SquarePurple").transform.position;
        //}

        //if (TouchRotateTriangleRed.Active == true)
        //{
        //    GameObject.Find("TriangleRed").transform.position += Global.shapeOffset;
        //    TouchRotateTriangleRed.shapeLoc = GameObject.Find("TriangleRed").transform.position;
        //}

        //if (TouchRotateDiamondYellow.Active == true)
        //{
        //    GameObject.Find("DiamondYellow").transform.position += Global.shapeOffset;
        //    TouchRotateDiamondYellow.shapeLoc = GameObject.Find("DiamondYellow").transform.position;
        //}

    }

    public void RightArrow()
    {
        //if (TouchRotateSquarePurple.Active == true)
        //{
        //    GameObject.Find("SquarePurple").transform.position -= Global.shapeOffset;
        //    TouchRotateSquarePurple.shapeLoc = GameObject.Find("SquarePurple").transform.position;
        //}

        //if (TouchRotateTriangleRed.Active == true)
        //{
        //    GameObject.Find("TriangleRed").transform.position -= Global.shapeOffset;
        //    TouchRotateTriangleRed.shapeLoc = GameObject.Find("TriangleRed").transform.position;
        //}

        //if (TouchRotateDiamondYellow.Active == true)
        //{
        //    GameObject.Find("DiamondYellow").transform.position -= Global.shapeOffset;
        //    TouchRotateDiamondYellow.shapeLoc = GameObject.Find("DiamondYellow").transform.position;
        //}
    }

    public void StartButton()
    {
        GameObject.Find("MainMenu").transform.localPosition = Global.leftPosition;
        GameObject.Find("ModeMenu").transform.localPosition = Global.centrePosition;

        // GameObject.Find("MainMenu").transform.localPosition = Vector3.SmoothDamp(Global.centrePosition, Global.leftPosition, ref velocity, 2f);   
        // GameObject.Find("ModeMenu").transform.localPosition = Vector3.SmoothDamp(Global.rightPosition, Global.centrePosition, ref velocity, 2f);
    }

    public void SettingsButton()
    {
        GameObject.Find("MainMenu").transform.localPosition = Global.rightPosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.centrePosition;
    }

    public void ParentalInfoButton()
    {
        GameObject.Find("MainMenu").transform.localPosition = Global.topPosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.centrePosition;
    }

    public void ModeBackButton()
    {
        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("ModeMenu").transform.localPosition = Global.leftPosition;
    }

    public void SettingsBackButton()
    {
        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.rightPosition;
    }

    public void ParentalinfoBackButton()
    {
        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.topPosition;
    }

    public void GreenModeButton()
    {
        Global.greenMode = true;
        Global.redMode = false;

        SceneManager.LoadScene("Lands"); 

    }

    public void RedModeButton()
    {
        Global.redMode = true;
        Global.greenMode = false;

        SceneManager.LoadScene("Lands");
    }

    public void ModeInfoButton()
    {
        GameObject.Find("InfoPopup").transform.localPosition = Global.centrePosition;
    }

    public void InfoCloseButton()
    {
        Debug.Log("Entered closs button"); 
        GameObject.Find("InfoPopup").transform.localPosition = Global.rightPosition;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
