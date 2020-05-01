using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonBehaviour : MonoBehaviour
{
    //lists all of the methods that could be executed when a given button is pressed

    private Vector3 velocity = Vector3.zero;
    public void LeftArrow() 
    {
        //triggered by left arrow controlling the displayed shapes in the toolbar in a given puzzle
        //selection of this button shifts all displayed shapes right letting the user "scroll left"

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
        //triggered by right arrow controlling the displayed shapes in the toolbar in a given puzzle
        //selection of this button shifts all displayed shapes left letting the user "scroll right"

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
        //triggered by start button on home screen
        //moves home screen menu out of view to the left and brings the mode selection menu into view

        GameObject.Find("MainMenu").transform.localPosition = Global.leftPosition;
        GameObject.Find("ModeMenu").transform.localPosition = Global.centrePosition;
    }

    public void SettingsButton()
    {
        //triggered by the settings button on home screen
        //moves the home screen menu out of view to the right and brings the settings menu into view

        GameObject.Find("MainMenu").transform.localPosition = Global.rightPosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.centrePosition;
    }

    public void ParentalInfoButton()
    {
        //triggered by the Parental Info button on home screen
        //moves the home screen menu out of view upwards and brings the parental info menu into view

        GameObject.Find("MainMenu").transform.localPosition = Global.topPosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.centrePosition;
    }

    public void ModeBackButton()
    {
        //triggered by the back button on mode selection menu
        //moves the mode selection menu out of view to the left and brings the home menu into view

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("ModeMenu").transform.localPosition = Global.leftPosition;
    }

    public void SettingsBackButton()
    {
        //triggered by the back button on settings menu
        //moves thesettings menu out of view to the right and brings the home menu into view

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.rightPosition;
    }

    public void ParentalinfoBackButton()
    {
        //triggered by the back button on the parental info menu
        //moves the parental info menu out of view above and brings the home menu into view

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.topPosition;
    }

    public void GreenModeButton()
    {
        //sets the mode of the puzzle to green mode and loads the land selections scene
        // in green mode only the shapes necessary to complete the puzzle will be shown in the toolbar

        Global.greenMode = true;
        Global.redMode = false;

        SceneManager.LoadScene("Lands"); 

    }

    public void RedModeButton()
    {
        //sets the mode of the puzzle to red mode and loads the land selection scene
        // in red mode more shapes than are necessary to complete the puzzle will be shown in the toolbar

        Global.redMode = true;
        Global.greenMode = false;

        SceneManager.LoadScene("Lands");
    }

    public void ModeInfoButton()
    {
        //triggered by the info button on the mode selection menu
        //a popup is brought into view on top of the mode selection menu

        GameObject.Find("InfoPopup").transform.localPosition = Global.centrePosition;
    }

    public void InfoCloseButton()
    {
        //triggered by the sloe button on the info popup in the mode selection menu
        //the popup is moved out of view to the right

        Debug.Log("Entered closs button"); 
        GameObject.Find("InfoPopup").transform.localPosition = Global.rightPosition;
    }

    public void HomeButton()
    {
        //is triggered by the home button on the land selection menu
        //loads the home scene

        SceneManager.LoadScene("Menu");
    }

    public void JungleButton()
    {
        //is triggered by the Jungleland button on the land selection menu
        //loads the jungle scene

        SceneManager.LoadScene("Jungle");
    }
}
