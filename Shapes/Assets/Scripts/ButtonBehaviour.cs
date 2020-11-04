using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour
{
    // lists all of the methods that could be executed when a given button is pressed
    // exception is for Record and Stop in Movie Maker (UIManager.cs)

    private Vector3 velocity = Vector3.zero;
    public void LeftArrow()
    {
        // shifts all shapes in toolbar right letting the user "scroll left"
        // triggered by left arrow in the toolbar in a given puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        for (int i = 0; i < TouchRotate.toolbarArray.Length; i++)
        {
            TouchRotate.toolbarArray[i] = TouchRotate.toolbarArray[i] + Global.shapeOffset;
        }

        Global.RightArrowActive = true;                      //if the left arrow is pushed, the right arrow must become active

        Global.CheckArrows();                                //checks whether arrows need to be disabled in one direction
    }

    public void RightArrow()
    {
        // shifts all shapes in toolbar left letting the user "scroll right"
        // triggered by right arrow in the toolbar in a given puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        for (int i = 0; i < TouchRotate.toolbarArray.Length; i++)
        {
            TouchRotate.toolbarArray[i] = TouchRotate.toolbarArray[i] - Global.shapeOffset;
        }

        Global.LeftArrowActive = true;                     //if the right arrow is pushed, the left arrow must become active

        Global.CheckArrows();                              //checks whether arrows need to be disabled in one direction

    }

    public void LeftArrowMovie()
    {
        //shifts all displayed shapes right letting the user "scroll left"
        //triggered by left arrow in the toolbar in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        for (int i = 0; i < MovieRotate.selectionArray.Length; i++)
        {
            MovieRotate.selectionArray[i] = MovieRotate.selectionArray[i] + Global.shapeOffset;
        }

        Global.RightArrowActiveMovie = true;                      //if the left arrow is pushed, the right arrow must become active

        Global.CheckArrowsMovie();                                //checks whether arrows need to be disabled in one direction (MovieMaker)
    }

    public void RightArrowMovie()
    {
        //shifts all displayed shapes left letting the user "scroll right"
        //triggered by right arrow in the toolbar in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        for (int i = 0; i < MovieRotate.selectionArray.Length; i++)
        {
            MovieRotate.selectionArray[i] = MovieRotate.selectionArray[i] - Global.shapeOffset;
        }

        Global.LeftArrowActiveMovie = true;                     //if the right arrow is pushed, the left arrow must become active

        Global.CheckArrowsMovie();                              //checks whether arrows need to be disabled in one direction  (MovieMaker)
    }

    public void StartButton()
    {
        //loads the World Selection scene
        //triggered by start button on main menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        SceneManager.LoadScene("Worlds");
    }

    public void SettingsButton()
    {
        //moves the home screen menu out of view (to the right) and brings the settings menu into view (centre screen)
        //triggered by the settings button on home screen

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button");

        GameObject.Find("MainMenu").transform.localPosition = Global.rightPosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.centrePosition;
    }

    public void ParentalInfoButton()
    {
        //moves the home screen menu out of view (upwards) and brings the parental info menu into view (centre screen)
        //triggered by the Parental Info button on home screen

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("MainMenu").transform.localPosition = Global.topPosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.centrePosition;
    }

    public void SettingsBackButton()
    {
        //moves the settings menu out of view (to the right) and brings the home menu into view (centre screen)
        //triggered by the back button on settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        Save.SaveSettings();                                                           //save changes to settings

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("SettingsMenu").transform.localPosition = Global.rightPosition;
    }

    public void MusicButton()
    {
        //toggles the music on and off
        //triggered by pressing the music on/off button in the settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        Global.Music = !Global.Music;

        if (Global.Music == true)
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
            FindObjectOfType<AudioManager>().Play("BackgroundMusic"); 
        }
        else
        {
            GameObject.Find("MusicButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
            FindObjectOfType<AudioManager>().Stop("BackgroundMusic"); 
        }
    }

    public void SoundEffectsButton()
    {
        //toggles the sound effects on and off
        //triggered by pressing the sound effects on/off button in the settings menu

        Global.SoundEffects = !Global.SoundEffects;

        if (Global.SoundEffects == true)
        {
            FindObjectOfType<AudioManager>().Play("Button"); 
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("on");
        }
        else
        {
            GameObject.Find("SoundEffectsButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("off");
        }
    }

    public void EasyButton()
    {
        //sets game to Easy mode (larger tolerances in shape placement)
        //triggered by tapping Easy button in Settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        Global.Easy = true;
        Global.Medium = false;
        Global.Hard = false;

        Global.positionTolerance = Global.EasyPositionTolerance;
        Global.rotationTolerance = Global.EasyRotationTolerance;

        GameObject.Find("EasyButton").GetComponent<Image>().color = Color.white;     //shows "Easy" in colour
        GameObject.Find("MediumButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("HardButton").GetComponent<Image>().color = Color.black;
    }

    public void MediumButton()
    {
        //sets game to Medium mode (default tolerance in shape placement)
        //triggered by tapping Medium button in Settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        Global.Easy = false;
        Global.Medium = true;
        Global.Hard = false;

        Global.positionTolerance = Global.MediumPositionTolerance;
        Global.rotationTolerance = Global.MediumRotationTolerance;

        GameObject.Find("EasyButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("MediumButton").GetComponent<Image>().color = Color.white; //shows "Medium" in colour
        GameObject.Find("HardButton").GetComponent<Image>().color = Color.black;
    }

    public void HardButton()
    {
        //sets game to Hard mode (smaller tolerances in shape placement)
        //triggered by tapping Hard button in Settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button");

        Global.Easy = false;
        Global.Medium = false;
        Global.Hard = true;

        Global.positionTolerance = Global.HardPositionTolerance;
        Global.rotationTolerance = Global.HardRotationTolerance;

        GameObject.Find("EasyButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("MediumButton").GetComponent<Image>().color = Color.black;
        GameObject.Find("HardButton").GetComponent<Image>().color = Color.white; //shows "Hard" in colour
    }


    public void SettingsHelpButton()
    {
        // presents a popup that explains the settings buttons
        // triggered by pressing the "i" button from the settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("HelpPopup").transform.localPosition = Global.centrePosition;

        GameObject.Find("SettingsBackButton").GetComponent<Button>().interactable = false;         //deactivates other buttons
        GameObject.Find("MusicButton").GetComponent<Button>().interactable = false;
        GameObject.Find("SoundEffectsButton").GetComponent<Button>().interactable = false;
        GameObject.Find("EasyButton").GetComponent<Button>().interactable = false;
        GameObject.Find("MediumButton").GetComponent<Button>().interactable = false;
        GameObject.Find("HardButton").GetComponent<Button>().interactable = false;
        GameObject.Find("ResetButton").GetComponent<Button>().interactable = false;

    }

    public void ClosSettingsHelpButton()
    {
        // closes popup that explains the settings buttons
        // triggered by pressing the "X" button from the settings help popup

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("HelpPopup").transform.localPosition = Global.rightPosition;

        GameObject.Find("SettingsBackButton").GetComponent<Button>().interactable = true;  //activates other buttons
        GameObject.Find("MusicButton").GetComponent<Button>().interactable = true;
        GameObject.Find("SoundEffectsButton").GetComponent<Button>().interactable = true;
        GameObject.Find("EasyButton").GetComponent<Button>().interactable = true;
        GameObject.Find("MediumButton").GetComponent<Button>().interactable = true;
        GameObject.Find("HardButton").GetComponent<Button>().interactable = true;
        GameObject.Find("ResetButton").GetComponent<Button>().interactable = true;
    }

    public void ResetDataButton()
    {
        //resets all saved data and returns settings to default value and throws up a popup for confirmation
        //triggered by pressing reset data in settings menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        Save.ResetData();

        GameObject.Find("ResetPopup").transform.localPosition = Global.centrePosition;

        GameObject.Find("SettingsBackButton").GetComponent<Button>().interactable = false;      //activates other buttons
        GameObject.Find("MusicButton").GetComponent<Button>().interactable = false;
        GameObject.Find("SoundEffectsButton").GetComponent<Button>().interactable = false;
        GameObject.Find("EasyButton").GetComponent<Button>().interactable = false;
        GameObject.Find("MediumButton").GetComponent<Button>().interactable = false;
        GameObject.Find("HardButton").GetComponent<Button>().interactable = false;
        GameObject.Find("ResetButton").GetComponent<Button>().interactable = false;
        GameObject.Find("SettingsHelpButton").GetComponent<Button>().interactable = false;
    }

    public void CloseResetPopup()
    {
        //closes the popup which appears after reset data is pressed
        //triggered by pressing the x on the reset data popup

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button");

        GameObject.Find("ResetPopup").transform.localPosition = Global.rightPosition;

        GameObject.Find("SettingsBackButton").GetComponent<Button>().interactable = true;     //activates other buttons
        GameObject.Find("MusicButton").GetComponent<Button>().interactable = true;
        GameObject.Find("SoundEffectsButton").GetComponent<Button>().interactable = true;
        GameObject.Find("EasyButton").GetComponent<Button>().interactable = true;
        GameObject.Find("MediumButton").GetComponent<Button>().interactable = true;
        GameObject.Find("HardButton").GetComponent<Button>().interactable = true;
        GameObject.Find("ResetButton").GetComponent<Button>().interactable = true;
        GameObject.Find("SettingsHelpButton").GetComponent<Button>().interactable = true;
    }

    public void ParentalinfoBackButton()
    {
        //moves the parental info menu out of view (above) and brings the home menu into view (centre screen)
        //triggered by the back button on the parental info menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("MainMenu").transform.localPosition = Global.centrePosition;
        GameObject.Find("ParentalinfoMenu").transform.localPosition = Global.topPosition;
    }

    public void CompleteHomeButton()
    {
        //loads the home scene
        //triggered by the home button on the completed puzzle popup

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;   //reactivate buttons globally
        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;

        SceneManager.LoadScene("Menu");
    }
    public void HomeButton()
    {
        //loads the home scene
        //triggered by the home button on the world selection menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        SceneManager.LoadScene("Menu");
    }

    public void StartNewPuzzle()
    {
        //resets popups and global variables and destroys shapes ready for a new puzzle to load
        //triggered when the START button is pressed on the popup after a puzzle is complete

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("PopupPuzzle").transform.localPosition = Global.rightPosition;    
        GameObject.Find("PopupLevel").transform.localPosition = Global.rightPosition;     
        GameObject.Find("PopupWorld").transform.localPosition = Global.rightPosition;     

        Global.piecesPlaced = 0;

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;

        Global.DestroyShapes();                                                           //destroy all existing shapes

        Global.NextPuzzleReady = true;                                                    //flag variable allows next puzzle to load in Handler script
    }

    public void MenuButton()
    {
        //pop-up displays menu options
        //triggered when hamburger menu button is pressed in a puzzle 

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupMenu").transform.localPosition = Global.centrePosition;     
        
        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;             //de-activates buttons

        string name = GameObject.Find("PopupMenu").scene.name;
        if (name == "MovieMaker")
        {
            GameObject.Find("SceneButton").GetComponent<Button>().interactable = false;         //de-activates buttons
            GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = false;        
            GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = false;         
            GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = false;         
        }

        Global.LeftArrowActive = false;
        Global.RightArrowActive = false;

        
        Global.PieceActive = true;                                                              // de-activate shapes
        Global.ActiveNameCopy = Global.ActiveName;                                              //saves the current active shape so that all shapes can be made inactive while menu is open
        Global.ActiveName = "null"; 
    }

    public void MenuHomeButton()
    {
        //loads home menu
        //triggered by pressing home button in hamburger popup menu within a puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     

        string scene = GameObject.Find("PopupMenu").scene.name;

        switch (scene)                                     //find which scene it was called in, and reduce puzzle number by 1
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
            //case "Wild":                                             //these scenes are not in use currently
            //    if (Global.WildPuzzle != 1)
            //    {
            //        Global.WildPuzzle = Global.WildPuzzle - 1;
            //    }

            //    else
            //    {
            //        Global.WildPuzzle = 5;
            //        Global.WildLevel = Global.WildLevel - 1;
            //    }
            //    break;
            //case "Playground":
            //    if (Global.PlaygroundPuzzle != 1)
            //    {
            //        Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 1;
            //    }

            //    else
            //    {
            //        Global.PlaygroundPuzzle = 5;
            //        Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
            //    }
            //    break;
            //case "Triangle":
            //    if (Global.TrianglePuzzle != 1)
            //    {
            //        Global.TrianglePuzzle = Global.TrianglePuzzle - 1;
            //    }

            //    else
            //    {
            //        Global.TrianglePuzzle = 5;
            //        Global.TriangleLevel = Global.TriangleLevel - 1;
            //    }
            //    break;
            case "MovieMaker":
                if (Global.Music == true)
                    FindObjectOfType<AudioManager>().Play("BackgroundMusic"); //restarts background music (does not play in MovieMaker)
                break; 
            default:
                Debug.Log("Error in switch case in MenuHomeButton");
                break;
        }

        Global.piecesPlaced = 0;                                             //reset placed pieces

       
        Global.PieceActive = false;                                          // re - activate shapes
        Global.ActiveName = Global.ActiveNameCopy;

        SceneManager.LoadScene("Menu");

    }

    public void MenuClose()
    {
        //closes the menu pop up
        //triggered by pressing the X button on the menu pop-up within a puzzle 

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;     

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;              //activates buttons

        string name = GameObject.Find("PopupMenu").scene.name;
        if (name == "MovieMaker")
        {
            GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;          //activates buttons
            GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;        

            GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
            GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
        }

        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;

       
        Global.PieceActive = false;                                                             // re-activate shapes
        Global.ActiveName = Global.ActiveNameCopy; 
    }

    public void RestartButton()
    {
        //starts the puzzle over from scratch
        //triggered by pressing the restart button in the hamburdger menu within a puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;    

        string name = GameObject.Find("PopupMenu").scene.name;

       
            switch (name)                                       //find which scene it was called in, and reduce puzzle number by 1
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
            //case "Wild":                                                 //these scenes are not in use currently
            //    if (Global.WildPuzzle != 1)
            //    {
            //        Global.WildPuzzle = Global.WildPuzzle - 1;
            //    }

            //    else
            //    {
            //        Global.WildPuzzle = 5;
            //        Global.WildLevel = Global.WildLevel - 1;
            //    }
            //    break;
            //case "Playground":
            //    if (Global.PlaygroundPuzzle != 1)
            //    {
            //        Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 1;
            //    }

            //    else
            //    {
            //        Global.PlaygroundPuzzle = 5;
            //        Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
            //    }
            //    break;
            //case "Triangle":
            //    if (Global.TrianglePuzzle != 1)
            //    {
            //        Global.TrianglePuzzle = Global.TrianglePuzzle - 1;
            //    }

            //    else
            //    {
            //        Global.TrianglePuzzle = 5;
            //        Global.TriangleLevel = Global.TriangleLevel - 1;
            //    }
            //    break;
            default:
                    Debug.Log("Error in Switch Statement/ RestartButton()");
                    break;
            }

      
        Global.PieceActive = false;                                         // re-activate shapes
        Global.ActiveName = Global.ActiveNameCopy;

        StartNewPuzzle();                                                  //start the same puzzle (the puzzle index has been set back by 1) 
    }

    public void SkipButton()
    {
        //skips current puzzle and starts next sequential puzzle
        //triggered by pressing the skip button in the hamburdger menu within a puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;    


        Global.PieceActive = false;                         // re-activate shapes
        Global.ActiveName = Global.ActiveNameCopy;

        Save.SaveProgress(); 

        StartNewPuzzle();                                   //start next puzzle (index already points to next puzzle)

    }

    public void PreviousButton()
    {
        //loads previous puzzle
        //triggered by pressing the previousbutton in the hamburger menu within a puzzle

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupMenu").transform.localPosition = Global.leftPosition;    

        string name = GameObject.Find("PopupMenu").scene.name;

        switch (name)                                            //find which scene it was called in, and reduce puzzle number by 2
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
                    Global.MousePuzzle = Global.MousePuzzle - 2;
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
                    Global.FarmPuzzle = Global.FarmPuzzle - 2;
                }
                break;
            //case "Wild":                                                //these scenes are not in use currently
            //    if (Global.WildLevel == 1)
            //    {
            //        Global.WildPuzzle = Global.WildPuzzle - 2;
            //    }

            //    else if (Global.WildPuzzle == 1)
            //    {
            //        Global.WildLevel = Global.WildLevel - 1;
            //        Global.WildPuzzle = 4;
            //    }

            //    else if (Global.WildPuzzle == 2)
            //    {
            //        Global.WildLevel = Global.WildLevel - 1;
            //        Global.WildPuzzle = 5;
            //    }

            //    else
            //    {
            //        Global.WildPuzzle = Global.WildPuzzle - 2;
            //    }
            //    break;
            //case "Playground":
            //    if (Global.PlaygroundLevel == 1)
            //    {
            //        Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 2;
            //    }

            //    else if (Global.PlaygroundPuzzle == 1)
            //    {
            //        Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
            //        Global.PlaygroundPuzzle = 4;
            //    }

            //    else if (Global.PlaygroundPuzzle == 2)
            //    {
            //        Global.PlaygroundLevel = Global.PlaygroundLevel - 1;
            //        Global.PlaygroundPuzzle = 5;
            //    }

            //    else
            //    {
            //        Global.PlaygroundPuzzle = Global.PlaygroundPuzzle - 2;
            //    }
            //    break;
            //case "Triangle":
            //    if (Global.TriangleLevel == 1)
            //    {
            //        Global.TrianglePuzzle = Global.TrianglePuzzle - 2;
            //    }

            //    else if (Global.TrianglePuzzle == 1)
            //    {
            //        Global.TriangleLevel = Global.TriangleLevel - 1;
            //        Global.TrianglePuzzle = 4;
            //    }

            //    else if (Global.TrianglePuzzle == 2)
            //    {
            //        Global.TriangleLevel = Global.TriangleLevel - 1;
            //        Global.TrianglePuzzle = 5;
            //    }

            //    else
            //    {
            //        Global.TrianglePuzzle = Global.TrianglePuzzle - 2;
            //    }
            //    break;
            default:
                Debug.Log("Error in Switch Statement/ RestartButton()");
                break;
        }

        
        Global.PieceActive = false;                                         // re-activate shapes
        Global.ActiveName = Global.ActiveNameCopy;

        StartNewPuzzle();    //start the same puzzle (the puzzle index has been set back by 2) 
    }


    //public void PlaygroundButton() //NOT CURRENTLY IN USE
    //{
    //    //loads the Playground scene 
    //    //triggered by the Playground button on the world selection menu

    //    if (Global.SoundEffects == true)
    //        FindObjectOfType<AudioManager>().Play("Button"); 

    //    if (Global.PlaygroundComplete == 1)
    //    {
           
    //        Global.PlaygroundLevel = 1;                               //resets progress if World is completed
    //        Global.PlaygroundPuzzle = 0;

    //        Global.PlaygroundComplete = 0;
    //    }

    //    SceneManager.LoadScene("Playground");
    //}

    //public void TriangleButton()    //NOT CURRENTLY IN USE
    //{
    //    //loads the Triangle scene 
    //    //triggered by the Triangle City button on the world selection menu

    //    if (Global.SoundEffects == true)
    //        FindObjectOfType<AudioManager>().Play("Button"); 

    //    if (Global.TriangleComplete == 1)
    //    {  
    //        Global.TriangleLevel = 1;                               //resets progress if World is completed
    //        Global.TrianglePuzzle = 0;

    //        Global.TriangleComplete = 0;
    //    }

    //    SceneManager.LoadScene("Triangle");
    //}

    public void MouseButton()
    {
        //loads the Mouse scene 
        //triggered by the Mouse Shapes button on the world selection menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button");

        if (Global.MouseComplete == 1)
        {
           
            Global.MouseLevel = 1;                              //resets progress if World is completed
            Global.MousePuzzle = 0;

            Global.MouseComplete = 0;
        }

        SceneManager.LoadScene("Mouse");
    }

    //public void WildButton()  //NOT CURRENTLY IN USE
    //{
    //    //loads the Wild scene
    //    //triggered by the Wild button on the world selection menu

    //    if (Global.SoundEffects == true)
    //        FindObjectOfType<AudioManager>().Play("Button"); 

    //    if (Global.WildComplete == 1)
    //    {
    //        Global.WildLevel = 1;             //resets progress if World is completed
    //        Global.WildPuzzle = 0;

    //        Global.WildComplete = 0;
    //    }

    //    SceneManager.LoadScene("Wild");
    //}

    public void FarmButton()
    {
        //loads the Farm scene
        //triggered by the Farm button on the world selection menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        if (Global.FarmComplete == 1)
        {
            Global.FarmLevel = 1;             //resets progress if World is completed
            Global.FarmPuzzle = 0;

            Global.FarmComplete = 0;
        }

        SceneManager.LoadScene("Farm");
    }

    public void MovieMakerButton()
    {
        //loads the MovieMaker scene
        //triggered by the MovieMaker button on the world selection menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        if (Global.Music == true)
            FindObjectOfType<AudioManager>().Stop("BackgroundMusic"); //stops background music (no background music in Movie Maker scene)

        SceneManager.LoadScene("Moviemaker");
    }

    public void RestartMovieButton()
    {
        //Clears scene in Movie Maker
        //triggered by pressing the "clear scene" button in the hamburger menu in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;           //activates buttons
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
        
        Global.DestroyShapesMovie();                                                         //destroy existing shapes and background
        SceneManager.LoadScene("MovieMaker");                                                //reload scene
    }

    public void SceneButton()
    {
        //opens and popup menu to select a background in MovieMaker
        //triggered by pressing the scene button in the top right of MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupScene").transform.localPosition = Global.centrePosition;    

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;         //de-activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = false;         
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = false;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = false;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = false;

    }

    public void CloseSceneButton()
    {
        //closes scene button
        //triggered by pressing the X on the scenes popup in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("PopupScene").transform.localPosition = Global.rightPosition;     

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //de-activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;        
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
    }

    public void PondButton()
    {
        //sets background to a pond
        //triggered by pressing the "pond" button within the scene popup menu in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("scenePond");

        GameObject.Find("PopupScene").transform.localPosition = Global.rightPosition;     

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
    }

    public void CropsButton()
    {
        //sets background to crops
        //triggered by pressing the "crops" button within the scene popup menu in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button");

        GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sceneCrops");

        GameObject.Find("PopupScene").transform.localPosition = Global.rightPosition;     

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;        
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
    }

    public void HillButton()
    {
        //sets background to a hill
        //triggered by pressing the "hill" button within the scene popup menu in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); //plays button sound

        GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sceneHill");

        GameObject.Find("PopupScene").transform.localPosition = Global.rightPosition;     

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
    }

    public void BarnButton()
    {
        //sets background to a barn
        //triggered by pressing the "barn" button within the scene popup menu in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sceneBarn");

        GameObject.Find("PopupScene").transform.localPosition = Global.rightPosition;    

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;        
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
    }

    public void BlankButton()
    {
        //sets background to blank white
        //triggered by pressing the "blank" button within the scene popup menu in MovieMaker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sceneBlank");

        GameObject.Find("PopupScene").transform.localPosition = Global.rightPosition;    

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons
        GameObject.Find("SceneButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("StartRecordButton").GetComponent<Button>().interactable = true;         
        GameObject.Find("LeftArrowMovie").GetComponent<Button>().interactable = true;
        GameObject.Find("RightArrowMovie").GetComponent<Button>().interactable = true;
    }

    public void TutorialPuzzleButton()
    { 
        //loads the puzzle tutorial scene
        //triggered by pressing the "puzzle tutorial" button in the world selection menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 
       
        SceneManager.LoadScene("TutorialPuzzle");
    }

    public void TutorialMovieButton()
    {
        //loads the movie maker tutorial scene
        //triggered by pressing the "movie maker tutorial" button in the world selection menu

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        SceneManager.LoadScene("TutorialMovie");
    }
    public void TutePuzzleButton()
    {
        //makes the next instruction appear in the puzzle tutorial
        //triggered by selecting the tick in the tutorial for puzzles

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        TutePuzzleHandler.popUpIndex++;          //increments index counter in TutePuzzleHandler
        TutePuzzleHandler.TuteLoadManager();     //calls function to update loaded objects in TutePuzzleHandler
    }

    public void TuteMovieButton()
    {
        //makes the next instruction appear in the movie maker tutorial
        //triggered by selecting the tick in the tutorial for movie maker

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        TuteMovieHandler.popUpIndex++;          //increments index counter in TuteMovieHandler
        TuteMovieHandler.TuteLoadManager();     //calls function to update loaded objects in TuteMovieHandler
    }

    public void EndTutorialButton()
    {
        //ends tutorials by reseting variables and loading Worlds scene
        //triggered by the button at the end of the movie maker or puzzle tutoris

        FindObjectOfType<AudioManager>().Stop("p1");       //cuts off any voiceovers
        FindObjectOfType<AudioManager>().Stop("p2");
        FindObjectOfType<AudioManager>().Stop("p3");
        FindObjectOfType<AudioManager>().Stop("p4");
        FindObjectOfType<AudioManager>().Stop("p5");
        FindObjectOfType<AudioManager>().Stop("p6");
        FindObjectOfType<AudioManager>().Stop("p7");
        FindObjectOfType<AudioManager>().Stop("p8");
        FindObjectOfType<AudioManager>().Stop("p9");
        FindObjectOfType<AudioManager>().Stop("p10"); 

        FindObjectOfType<AudioManager>().Stop("m1");
        FindObjectOfType<AudioManager>().Stop("m2");
        FindObjectOfType<AudioManager>().Stop("m3");
        FindObjectOfType<AudioManager>().Stop("m4");
        FindObjectOfType<AudioManager>().Stop("m5");
        FindObjectOfType<AudioManager>().Stop("m6");
        FindObjectOfType<AudioManager>().Stop("m7");
        FindObjectOfType<AudioManager>().Stop("m8");
        FindObjectOfType<AudioManager>().Stop("m9");
        FindObjectOfType<AudioManager>().Stop("m10");
        FindObjectOfType<AudioManager>().Stop("m11");
        FindObjectOfType<AudioManager>().Stop("m12");

        SceneManager.LoadScene("Worlds");
    }

    public void CloseInstructionPopup()
    {
        // closes the instruction popup that appears at the first level of each puzzle world
        // triggered by pressing the X button on the instruction popup

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        GameObject.Find("InstructionPopup").transform.localPosition = Global.leftPosition; 
        
        GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         //activates buttons

        Global.LeftArrowActive = true;
        Global.RightArrowActive = true;
   
        Global.PieceActive = false;                                                        //re-activate shapes
        Global.ActiveName = Global.ActiveNameCopy;

        string name = GameObject.Find("InstructionPopup").scene.name;
        if (name == "Farm" && Global.Music == true)
        { 
            FindObjectOfType<AudioManager>().Stop("OldMcDonald");       // stops Old McDonald song that plays furing the Farm world popup
            FindObjectOfType<AudioManager>().Play("BackgroundMusic");   // starts background music
        }
    }

    public void CloseParentalPopup()
    {
        //closes parental info popups in menu, Mouse Shapes and Farm World
        //triggered by pressing X button on popup

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        string name = GameObject.Find("ParentalPopup").scene.name;

        switch (name)                                                                               //activates buttons based on location of popup
        {
            case "Menu":
                GameObject.Find("StartButton").GetComponent<Button>().interactable = true;
                GameObject.Find("SettingsButton").GetComponent<Button>().interactable = true;
                GameObject.Find("ParentalButton").GetComponent<Button>().interactable = true;
                break;
            case "Mouse":
                if (GameObject.Find("InstructionPopup").transform.localPosition != Global.centrePosition)
                {
                    GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         
                    Global.LeftArrowActive = true;
                    Global.RightArrowActive = true;
                    Global.PieceActive = false;
                    Global.ActiveName = Global.ActiveNameCopy;
                }
                GameObject.Find("CloseInstructionPopup").GetComponent<Button>().interactable = true;
                break;
            case "Farm":
                if (GameObject.Find("InstructionPopup").transform.localPosition != Global.centrePosition)
                {
                    GameObject.Find("MenuButton").GetComponent<Button>().interactable = true;         
                    Global.LeftArrowActive = true;
                    Global.RightArrowActive = true;
                    Global.PieceActive = false;
                    Global.ActiveName = Global.ActiveNameCopy;
                }
                GameObject.Find("CloseInstructionPopup").GetComponent<Button>().interactable = true;
                break;
            default:
                Debug.Log("Error in Switch Statement/ LoadParentalPopup()");
                break;
        }

        GameObject.Find("ParentalPopup").transform.localPosition = Global.rightPosition; 

        Save.SavePopup(); 
    }

    public void TickBox()
    {
        //ticks or unticks the checkbox on the Parental Info Popup
        //triggered by tapping checkbox on popup

        if (Global.SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("Button"); 

        string name = GameObject.Find("ParentalPopup").scene.name;

        switch (name)                                            //find which scene it was called in, and reduce puzzle number by 1
        {
            case "Menu":
                Global.GenPopup = !Global.GenPopup;

                if (Global.GenPopup == true)
                {
                    GameObject.Find("TickBoxButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("TickBox"); //option in unchecked; continue making popups
                }
                else
                {
                    GameObject.Find("TickBoxButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Tick"); //option is checked; do not show again
                }
                break;
            case "Mouse":
                Global.MousePopup = !Global.MousePopup;

                if (Global.MousePopup == true)
                {
                    GameObject.Find("TickBoxButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("TickBox"); //option in unchecked; continue making popups
                }
                else
                {
                    GameObject.Find("TickBoxButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Tick"); //option is checked; do not show again
                }
                break;
            case "Farm":
                Global.FarmPopup = !Global.FarmPopup;

                if (Global.FarmPopup == true)
                {
                    GameObject.Find("TickBoxButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("TickBox"); //option in unchecked; continue making popups
                }
                else
                {
                    GameObject.Find("TickBoxButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Tick"); //option is checked; do not show again
                }
                break;
            default:
                Debug.Log("Error in Switch Statement/ Tickbox()");
                break;
        }

    }

}
