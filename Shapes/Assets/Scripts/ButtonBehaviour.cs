using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ButtonBehaviour : MonoBehaviour
{
    //lists all of the methods that could be executed when a given button is pressed

    private Vector3 velocity = Vector3.zero;
    public void LeftArrow() 
    {
        //triggered by left arrow controlling the displayed shapes in the toolbar in a given puzzle
        //selection of this button shifts all displayed shapes right letting the user "scroll left"

        for (int i = 0; i < TouchRotate.toolbarArray.Length; i++)
        {
            TouchRotate.toolbarArray[i]  = TouchRotate.toolbarArray[i] + Global.shapeOffset;
        }

        int Index = 0;
        for (int j = 0; j < Global.puzzlePieces; j++)
        {
            if (TouchRotate.activeArray[j] == true)
            {
                Index = j; //return index of first active shape
                break;
            }
        }

        if (TouchRotate.toolbarArray[Index].x >= 0.15f) //if the x coord of the first active shape is
        {
            
          GameObject.Find("LeftArrow").GetComponent<Image>().color = Color.red;
           //Global.LeftArrowActive = false;
        }
        else
        {
        
          GameObject.Find("LeftArrow").GetComponent<Image>().color = Color.white;
            //Global.LeftArrowActive = true;
        }
 
        GameObject.Find("RightArrow").GetComponent<Image>().color = Color.white;
        //Global.RightArrowActive = true;
    }

    public void RightArrow()
    {
        //triggered by right arrow controlling the displayed shapes in the toolbar in a given puzzle
        //selection of this button shifts all displayed shapes left letting the user "scroll right"

        for (int i = 0; i < TouchRotate.toolbarArray.Length; i++)
        {
            TouchRotate.toolbarArray[i] = TouchRotate.toolbarArray[i] - Global.shapeOffset;
        }

        int Index = 0;
        for (int j = Global.puzzlePieces; j > 0; j--)
        {
            if (TouchRotate.activeArray[j] == true)
            {
                Index = j; //return index of first active shape
                break;
            }
        }

        if (TouchRotate.toolbarArray[Index].x <= 1.5f) //if the x coord of the first active shape is
        {
           
            GameObject.Find("RightArrow").GetComponent<Image>().color = Color.red; 
            //Global.RightArrowActive = false; 
        }
        else
        {
            
            GameObject.Find("RightArrow").GetComponent<Image>().color = Color.white;
           // Global.RightArrowActive = true;
        }

        GameObject.Find("LeftArrow").GetComponent<Image>().color = Color.white;
        //Global.LeftArrowActive = true;
    }

    public void StartButton()
    {
        //triggered by start button on home screen
        //loads the World Selection scene

        SceneManager.LoadScene("Worlds");
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

    public void HomeButton()
    {
        //is triggered by the home button on the land selection menu
        //loads the home scene

        SceneManager.LoadScene("Menu");
    }

    public void StartNewPuzzle()
    {
        //is triggered when the START button is pressed on the popup after a puzzle is complete

        GameObject.Find("PopupStart").transform.localPosition = Global.rightPosition;     //moves the pop-up box out of screen

        GameObject.Find("HomeButton").GetComponent<Button>().interactable = true;         //activates buttons
        GameObject.Find("LeftArrow").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrow").GetComponent<Button>().interactable = true;

        Global.DestroyShapes();                                                           //destroy all existing shapes

        Global.NextPuzzleReady = true;                                                    //allow next puzzle to load


    }

    public void PlaygroundButton()
    {
        //is triggered by the Playground button on the land selection menu
        //loads the Playground scene

        //SceneManager.LoadScene("Playground");
    }

    public void TriangleButton()
    {
        //is triggered by the Triangle City button on the land selection menu
        //loads the Triangle scene

       // SceneManager.LoadScene("Triangle");
    }

    public void MouseButton()
    {
        //is triggered by the Mouse Shapes button on the land selection menu
        //loads the Mouse scene

       SceneManager.LoadScene("Mouse");
    }

    public void WildButton()
    {
        //is triggered by the Wild button on the land selection menu
        //loads the Wild scene

        //SceneManager.LoadScene("Wild");
    }

    public void FarmButton()
    {
        //is triggered by the Farm button on the land selection menu
        //loads the Farm scene

       // SceneManager.LoadScene("Farm");
    }

    public void FreeplayButton()
    {
        //is triggered by the Free Play button on the land selection menu
        //loads the Free Play scene

        //SceneManager.LoadScene("FreePlay");
    }
}
