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

        if(Global.SoundEffects == true)
           FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        for (int i = 0; i < TouchRotate.toolbarArray.Length; i++)
        {
            TouchRotate.toolbarArray[i]  = TouchRotate.toolbarArray[i] + Global.shapeOffset; 
        }

        Global.RightArrowActive = true;                      //if the left arrow is pushed, the right arrow must become active

        Global.CheckArrows();                                //checks whether arrows need to be disabled in one direction
    }

    public void RightArrow()
    {
        //triggered by right arrow controlling the displayed shapes in the toolbar in a given puzzle
        //selection of this button shifts all displayed shapes left letting the user "scroll right"

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        for (int i = 0; i < TouchRotate.toolbarArray.Length; i++)
        {
            TouchRotate.toolbarArray[i] = TouchRotate.toolbarArray[i] - Global.shapeOffset;
        }

        Global.LeftArrowActive = true;                     //if the right arrow is pushed, the left arrow must become active

        Global.CheckArrows();                              //checks whether arrows need to be disabled in one direction

    }

    public void StartButton()
    {
        //triggered by start button on home screen
        //loads the World Selection scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        SceneManager.LoadScene("Worlds");
    }

    public void SettingsButton()
    {
        //triggered by the settings button on home screen
        //moves the home screen menu out of view to the right and brings the settings menu into view

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("MainMenu").transform.localPosition = Global.rightPosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.centrePosition;
    }

    public void ParentalInfoButton()
    {
        //triggered by the Parental Info button on home screen
        //moves the home screen menu out of view upwards and brings the parental info menu into view

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("MainMenu").transform.localPosition = Global.topPosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.centrePosition;
    }

    public void SettingsBackButton()
    {
        //triggered by the back button on settings menu
        //moves thesettings menu out of view to the right and brings the home menu into view

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        Save.SaveSettings();                                                                          //save changes to settings

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.rightPosition;
    }

    public void MusicButton()
    {
        //is triggered by toggling the music button on the settings menu
        //toggles themusic on and off

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        Global.Music = !Global.Music;

        if (Global.Music == true)
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
            FindObjectOfType<AudioManager>().Play("BackgroundMusic"); //plays music
        }
        else
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
            FindObjectOfType<AudioManager>().Stop("BackgroundMusic"); //stops music
        }
    }

    public void SoundEffectsButton()
    {
        //is triggered by toggling the sound effects button on the settings menu
        //toggles the sound effects on and off

        Global.SoundEffects = !Global.SoundEffects;

        if (Global.SoundEffects == true)
        {
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
        }
        else
        {
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
        }
    }

    public void EasyButton()
    {
        //sets game to Easy mode (larger tolerances in placement)
        //triggered by tapping Easy button in Settings in main menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        Global.Easy = true;
        Global.Medium = false;
        Global.Hard = false;

        Global.positionTolerance = Global.EasyPositionTolerance;
        Global.rotationTolerance = Global.EasyRotationTolerance;

        GameObject.Find("EasyButton").GetComponent<Image>().color = Color.white;
        GameObject.Find("MediumButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("HardButton").GetComponent<Image>().color = Color.black;
    }

    public void MediumButton()
    {
        // sets game to Medium mode(standard tolerances in placement)
        //triggered by tapping Medium button in Settings in main menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        Global.Easy = false;
        Global.Medium = true;
        Global.Hard = false;

        Global.positionTolerance = Global.MediumPositionTolerance;
        Global.rotationTolerance = Global.MediumRotationTolerance;

        GameObject.Find("EasyButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("MediumButton").GetComponent<Image>().color = Color.white;
        GameObject.Find("HardButton").GetComponent<Image>().color = Color.black;
    }

    public void HardButton()
    {
        // sets game to Hard mode(smaller tolerances in placement)
        //triggered by tapping Hard button in Settings in main menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        Global.Easy = false;
        Global.Medium = false;
        Global.Hard = true;

        Global.positionTolerance = Global.HardPositionTolerance;
        Global.rotationTolerance = Global.HardRotationTolerance;

        GameObject.Find("EasyButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("MediumButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("HardButton").GetComponent<Image>().color = Color.white;
    }

    public void ParentalinfoBackButton()
    {
        //triggered by the back button on the parental info menu
        //moves the parental info menu out of view above and brings the home menu into view

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.topPosition;
    }

    public void CompleteHomeButton()
    {
        //is triggered by the home button on the completed puzzle popup
        //loads the home scene
        //note: do not add destroyshapes and nextpuzzle ready or a puzzle is skipped

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true; //reactivate buttons globally
        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;

        SceneManager.LoadScene("Menu");
    }
    public void HomeButton()
    {
        //is triggered by the home button on the world selection menu
        //loads the home scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        SceneManager.LoadScene("Menu");
    }

    public void StartNewPuzzle()
    {
        //is triggered when the START button is pressed on the popup after a puzzle is complete

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupPuzzle").transform.localPosition = Global.rightPosition;     //moves the pop-up box out of screen
        GameObject.Find("PopupLevel").transform.localPosition = Global.rightPosition;     //moves the pop-up box out of screen
        GameObject.Find("PopupWorld").transform.localPosition = Global.rightPosition;     //moves the pop-up box out of screen

        Global.piecesPlaced = 0;

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;

        Global.DestroyShapes();                                                           //destroy all existing shapes

        Global.NextPuzzleReady = true;                                                    //allow next puzzle to load
    }

    public void MenuButton()
    {
        //pop-up displays menu options
        //triggered when hamburdher symbol is pressed in puzzle 

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupMenu").transform.localPosition = Global.centrePosition;     //moves the pop-up into centre of screen
        
        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;         //de-activates buttons
        Global.LeftArrowActive = false;
        Global.RightArrowActive = false;

        // de - activate shapes
        Global.PieceActive = true;
        Global.ActiveNameCopy = Global.ActiveName;  //saving the current active shape so that all shapes can be made inactive while menu is open
        Global.ActiveName = "null"; 
    }

    public void MenuHomeButton()
    {
        //loads home menu
        //also remembers that the current puzzle is incomplete
        //triggered by pressing home button in hamburger popup menu within puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     //moves the pop-up off screen

        string scene = GameObject.Find("PopupMenu").scene.name;

        switch (scene)                                            //find which scene it was called in, and reduce puzzle number by 1
        {
            case "Mouse":
                if (Global.MousePuzzle != 1)
                {
                    Global.MousePuzzle = Global.MousePuzzle - 1;
                }

                else
                {
                    Global.MousePuzzle = 5;
                    Global.MouseLevel = Global.MouseLevel - 1;
                }
                break;
            case "Farm":
                if (Global.FarmPuzzle != 1)
                {
                    Global.FarmPuzzle = Global.FarmPuzzle - 1;
                }

                else
                {
                    Global.FarmPuzzle = 5;
                    Global.FarmLevel = Global.FarmLevel - 1;
                }
                break;
            case "Wild":
                if (Global.WildPuzzle != 1)
                {
                    Global.WildPuzzle = Global.WildPuzzle - 1;
                }

                else
                {
                    Global.WildPuzzle = 5;
                    Global.WildLevel = Global.WildLevel - 1;
                }
                break;
            case "Playground":
                if (Global.PlaygroundPuzzle != 1)
                {
                    Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 1;
                }

                else
                {
                    Global.PlaygroundPuzzle = 5;
                    Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
                }
                break;
            case "Triangle":
                if (Global.TrianglePuzzle != 1)
                {
                    Global.TrianglePuzzle = Global.TrianglePuzzle - 1;
                }

                else
                {
                    Global.TrianglePuzzle = 5;
                    Global.TriangleLevel = Global.TriangleLevel - 1;
                }
                break;


            default:
                Debug.Log("Error in Switch Statement/ RestartButton()");
                break;
        }

        Global.piecesPlaced = 0;  //reset placed pieces

        // re - activate shapes
        Global.PieceActive = false;
        Global.ActiveName = Global.ActiveNameCopy;

        SceneManager.LoadScene("Menu");

    }

    public void MenuClose()
    {
        //closes the menu pop up
        //triggered by pressing the X button on the menu pop-up within a puzzle 

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     //moves the pop-up off screen

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;

        // re - activate shapes
        Global.PieceActive = false;
        Global.ActiveName = Global.ActiveNameCopy;

    }

    public void RestartButton()
    {
        //starts the puzzle over from the beginning
        //triggered by pressing the restart button in the hamburdger menu within a puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     //moves the pop-up off screen

        string name = GameObject.Find("PopupMenu").scene.name;

       
            switch (name)                                            //find which scene it was called in, and reduce puzzle number by 1
            {
                case "Mouse":
                if (Global.MousePuzzle != 1)                          
                {
                    Global.MousePuzzle = Global.MousePuzzle - 1;
                }

                else
                {
                    Global.MousePuzzle = 5;
                    Global.MouseLevel = Global.MouseLevel - 1;
                }
                    break;
            case "Farm":
                if (Global.FarmPuzzle != 1)
                {
                    Global.FarmPuzzle = Global.FarmPuzzle - 1;
                }

                else
                {
                    Global.FarmPuzzle = 5;
                    Global.FarmLevel = Global.FarmLevel - 1;
                }
                break;
            case "Wild":
                if (Global.WildPuzzle != 1)
                {
                    Global.WildPuzzle = Global.WildPuzzle - 1;
                }

                else
                {
                    Global.WildPuzzle = 5;
                    Global.WildLevel = Global.WildLevel - 1;
                }
                break;
            case "Playground":
                if (Global.PlaygroundPuzzle != 1)
                {
                    Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 1;
                }

                else
                {
                    Global.PlaygroundPuzzle = 5;
                    Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
                }
                break;
            case "Triangle":
                if (Global.TrianglePuzzle != 1)
                {
                    Global.TrianglePuzzle = Global.TrianglePuzzle - 1;
                }

                else
                {
                    Global.TrianglePuzzle = 5;
                    Global.TriangleLevel = Global.TriangleLevel - 1;
                }
                break;


            default:
                    Debug.Log("Error in Switch Statement/ RestartButton()");
                    break;
            }

        // re - activate shapes
        Global.PieceActive = false;
        Global.ActiveName = Global.ActiveNameCopy;

        StartNewPuzzle();    //start the same puzzle, as the puzzle index has been set back by 1 
    }

    public void SkipButton()
    {
        //skips current puzzle and starts next sequential ouzzle
        //triggered by pressing the skip button in the hamburdger menu within a puzzle
        //note: do not add destroyshapes and nextpuzzle ready or a puzzle is skipped

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     //moves the pop-up off screen

        // re - activate shapes
        Global.PieceActive = false;
        Global.ActiveName = Global.ActiveNameCopy;

        Save.SaveProgress(); 

        StartNewPuzzle();  //start next puzzle

    }

    public void PreviousButton()
    {
        //loads previous puzzle
        //triggered by pressing the previousbutton in the hamburdger menu within a puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     //moves the pop-up off screen

        string name = GameObject.Find("PopupMenu").scene.name;

        switch (name)                                            //find which scene it was called in, and reduce puzzle number by 1
        {
            case "Mouse":
                if (Global.MouseLevel == 1)
                {
                    Global.MousePuzzle = Global.MousePuzzle-2;
                }

                else if (Global.MousePuzzle == 1)
                {
                    Global.MouseLevel = Global.MouseLevel - 1;
                    Global.MousePuzzle = 4;
                }

                else if (Global.MousePuzzle == 2)
                {
                    Global.MouseLevel = Global.MouseLevel - 1;
                    Global.MousePuzzle = 5;
                }

                else
                {
                    Global.MouseLevel = Global.MouseLevel - 1;
                }
                break;
            case "Farm":
                if (Global.FarmLevel == 1)
                {
                    Global.FarmPuzzle = Global.FarmPuzzle - 2;
                }

                else if (Global.FarmPuzzle == 1)
                {
                    Global.FarmLevel = Global.FarmLevel - 1;
                    Global.FarmPuzzle = 4;
                }

                else if (Global.FarmPuzzle == 2)
                {
                    Global.FarmLevel = Global.FarmLevel - 1;
                    Global.FarmPuzzle = 5;
                }

                else
                {
                    Global.FarmLevel = Global.FarmLevel - 1;
                }
                break;
            case "Wild":
                if (Global.WildLevel == 1)
                {
                    Global.WildPuzzle = Global.WildPuzzle - 2;
                }

                else if (Global.WildPuzzle == 1)
                {
                    Global.WildLevel = Global.WildLevel - 1;
                    Global.WildPuzzle = 4;
                }

                else if (Global.WildPuzzle == 2)
                {
                    Global.WildLevel = Global.WildLevel - 1;
                    Global.WildPuzzle = 5;
                }

                else
                {
                    Global.WildLevel = Global.WildLevel - 1;
                }
                break;
            case "Playground":
                if (Global.PlaygroundLevel == 1)
                {
                    Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 2;
                }

                else if (Global.PlaygroundPuzzle == 1)
                {
                    Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
                    Global.PlaygroundPuzzle = 4;
                }

                else if (Global.PlaygroundPuzzle == 2)
                {
                    Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
                    Global.PlaygroundPuzzle = 5;
                }

                else
                {
                    Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
                }
                break;
            case "Triangle":
                if (Global.TriangleLevel == 1)
                {
                    Global.TrianglePuzzle = Global.TrianglePuzzle - 2;
                }

                else if (Global.TrianglePuzzle == 1)
                {
                    Global.TriangleLevel = Global.TriangleLevel - 1;
                    Global.TrianglePuzzle = 4;
                }

                else if (Global.TrianglePuzzle == 2)
                {
                    Global.TriangleLevel = Global.TriangleLevel - 1;
                    Global.TrianglePuzzle = 5;
                }

                else
                {
                    Global.TriangleLevel = Global.TriangleLevel - 1;
                }
                break;
            default:
                Debug.Log("Error in Switch Statement/ RestartButton()");
                break;
        }

        // re - activate shapes
        Global.PieceActive = false;
        Global.ActiveName = Global.ActiveNameCopy;

        StartNewPuzzle();    //start the same puzzle, as the puzzle index has been set back by 1 

    }


    public void PlaygroundButton()
    {
        //is triggered by the Playground button on the land selection menu
        //loads the Playground scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        if (Global.PlaygroundComplete == 1)
        {
            //resets progress if World is completed
            Global.PlaygroundLevel = 1;
            Global.PlaygroundPuzzle = 0;

            Global.PlaygroundComplete = 0;
        }

        SceneManager.LoadScene("Playground");
    }

    public void TriangleButton()
    {
        //is triggered by the Triangle City button on the land selection menu
        //loads the Triangle scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        if (Global.TriangleComplete == 1)
        {
            //resets progress if World is completed
            Global.TriangleLevel = 1;
            Global.TrianglePuzzle = 0;

            Global.TriangleComplete = 0;
        }


        SceneManager.LoadScene("Triangle");
    }

    public void MouseButton()
    {
        //is triggered by the Mouse Shapes button on the land selection menu
        //loads the Mouse scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        if (Global.MouseComplete == 1)
        {
            //resets progress if World is completed
            Global.MouseLevel = 1;
            Global.MousePuzzle = 0;

            Global.MouseComplete = 0;
        }

        SceneManager.LoadScene("Mouse");
    }

    public void WildButton()
    {
        //is triggered by the Wild button on the land selection menu
        //loads the Wild scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        if (Global.WildComplete == 1)
        {
            //resets progress if World is completed
            Global.WildLevel = 1;
            Global.WildPuzzle = 0;

            Global.WildComplete = 0;
        }

        SceneManager.LoadScene("Wild");
    }

    public void FarmButton()
    {
        //is triggered by the Farm button on the land selection menu
        //loads the Farm scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        if (Global.FarmComplete == 1)
        {
            //resets progress if World is completed
            Global.FarmLevel = 1;
            Global.FarmPuzzle = 0;

            Global.FarmComplete = 0;
        }

        SceneManager.LoadScene("Farm");
    }

    public void MovieMakerButton()
    {
        //is triggered by the Free Play button on the land selection menu
        //loads the Free Play scene

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        SceneManager.LoadScene("Moviemaker");
    }

    public void ResetDataButton()
    {
        //resets all saved data and returns settings to default value 
        //triggered by pressing reset data in settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        Save.ResetData(); 

    }

}
