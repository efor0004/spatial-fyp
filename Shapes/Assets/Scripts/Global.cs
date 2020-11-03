using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Global : MonoBehaviour
{
    //defines all flag variables, tuning variables and functions that relate to multiple scenes/scripts

    //ButtonBehaviour
    public static Vector3 leftPosition = new Vector3(-2000, -60, 0);    //positions of popups
    public static Vector3 rightPosition = new Vector3(2000, -60, 0);
    public static Vector3 bottomPosition = new Vector3(0, -2000, 0);
    public static Vector3 topPosition = new Vector3(0, 2000, 0);
    public static Vector3 centrePosition = new Vector3(0, -60, 0);

    public static Vector3 popupPosition = new Vector3(0, 625, 0);       //for popup boxes

    public static bool LeftArrowActive = true;                          //toolbar arrows
    public static bool RightArrowActive = true;

    public static bool LeftArrowActiveMovie = true;
    public static bool RightArrowActiveMovie = true;

    public static bool Music = true;                                    //audio settings
    public static bool SoundEffects = true;

    public static bool GenPopup = true;                                 //parental info popup preferences
    public static bool MousePopup = true;
    public static bool FarmPopup = true;

    public static bool Easy = false;                                    //difficult settings
    public static bool Medium = true;
    public static bool Hard = false;

    public static bool Recording = false;                                //movie maker recording flag


    //TouchRotate
    public static float EasyPositionTolerance = 1.2f;                    //position/rotation tolerance for placing shapes at each difficulty
    public static float EasyRotationTolerance = 40.0f;

    public static float MediumPositionTolerance = 0.8f;
    public static float MediumRotationTolerance = 30.0f;

    public static float HardPositionTolerance = 0.4f;
    public static float HardRotationTolerance = 20.0f;

    public static Vector3 shapeOffset = new Vector3(2.5f, 0f, 0f);         //shape spacing in toolbar

    public static Vector3 currentVal1 = new Vector3(0, 0, 0);            
    public static Vector3 currentVal2 = new Vector3(0, 0, 0);

    public static float positionTolerance = MediumPositionTolerance;        //default tolerances
    public static float rotationTolerance = MediumRotationTolerance;        

    public static int puzzlePieces = 11;                                   //tracking puzzle completion
    public static int piecesPlaced = 0;

    public static int MouseLevel = 1;                                     //tracking level progress 
    public static int MousePuzzle = 0;
    public static int FarmLevel = 1;
    public static int FarmPuzzle = 0;
    //public static int PlaygroundLevel = 1;                              //related scenes not currently in use
    //public static int PlaygroundPuzzle = 0;
    //public static int TriangleLevel = 1;
    //public static int TrianglePuzzle = 0;
    //public static int WildLevel = 1;
    //public static int WildPuzzle = 0;

    public static bool PieceActive = false;                              //tracking active piece
    public static string ActiveName;
    public static string ActiveNameCopy;

    public static Vector4 ColourOffset = new Vector4(0.2f, 0.2f, 0.2f, 0f);

    //"Scene"Handler 
    public static bool NextPuzzleReady = true;                           

    public static float toolbarY = -4f;                                 //toolbar shape position
    public static float toolbarXoffset = 2.5f;                          

    public static float toolbarXstart = -2.3f;

    public static float movieCollider = 1.65f;                  //a small collider for movie maker characters (less chance of selecting wrong character)
    public static float smallCollider = 4.5f;                   //a larger collider for small shapes
    public static float regularCollider = 2.5f;                 //a regular sized collider for regular shapes

    public static int PuzzlesPerLevel = 5;

    public static int MouseComplete = 0;                               //determines whether a world is complete
    public static int FarmComplete = 0;
    //public static int PlaygroundComplete = 0;                        //related scenes not currently in use
    //public static int TriangleComplete = 0;
    //public static int WildComplete = 0;

    // Menu
    public static bool StartUpMenu = true;
    public static bool StartUpMouse = true;
    public static bool StartUpFarm = true;


    public static void DestroyShapes()
    {
        //destroy all current shapes by name   
        //triggered when a puzzle is ended/exited
        //adapted from https://answers.unity.com/questions/1414048/destroy-specific-gameobject-with-name.html

        foreach (string name in TouchRotate.nameArray)
        {
            GameObject go = GameObject.Find(name);                                                //checks if the shape exists                                                                                                
            
            if (go)                                                                              //if the tree exist then destroy it
                Destroy(go.gameObject);
        }

        Destroy(GameObject.Find("Puzzle"));                                                       //destroys the objective puzzle object
    }

    public static void DestroyShapesMovie()
    {
        //destroys all current shapes by name in MovieMaker      
        //adapted from https://answers.unity.com/questions/1414048/destroy-specific-gameobject-with-name.html

        foreach (string name in MovieRotate.movieArray)
        {
            GameObject go = GameObject.Find(name);                                                //checks if the shape exists
                                                                                                 
            if (go)                                                                               //if the tree exist then destroy it
                Destroy(go.gameObject);
        }

        Destroy(GameObject.Find("background"));                                                   //to destroy the objective puzzle object
    }

    public static void CheckArrows()
    {
        //checks whether the toolbar arrows should be disabled to signal there are no more shapes in that direction
        //triggered when an arrow is pressed in a puzzle world
         
        int Index = 0;                                            //check Left Arrow
        for (int j = 0; j < Global.puzzlePieces; j++)
        {
            if (TouchRotate.activeArray[j] == true)
            {
                Index = j;                                        //returns the index of the first active shape i.e. shape in left most position in toolbar
                break;
            }
        }

        if (TouchRotate.toolbarArray[Index].x >= 0.15f)          //value from manual testing
        {
            Global.LeftArrowActive = false;
        }
        else
        {
            Global.LeftArrowActive = true;
        }


        Index = 0;                                              //Check Right Arrow
        for (int j = Global.puzzlePieces; j > 0; j--)
        {
            if (TouchRotate.activeArray[j] == true)
            {
                Index = j;                                     //returns the index of the last active shape i.e. shape in right most position in toolbar
                break;
            }
        }

        if (TouchRotate.toolbarArray[Index].x <= 2f)            //value from manual testing
        {
            Global.RightArrowActive = false;
        }
        else
        {
            Global.RightArrowActive = true;
        }

    }

    public static void CheckArrowsMovie()
    {
        //checks whether the toolbar arrows should be disabled to signal there are no more shapes in that direction for MovieMaker
        //triggered when an arrow is pressed in a movie maker

        int Index = 0;
        int j;
        int i;
       

        for (j = 0; j < MovieRotate.movieArray.Length; j++)               //check Left Arrow
        {
            if (MovieRotate.playArray[j] == false)                       //find the left-most shape not in play (in the toolbar)
            {
                Index = j;                                               //returns the index of the first active shape i.e. shape in left most position in toolbar
                break;
            }
        }


        if (MovieRotate.selectionArray[Index].x >= 0.15f)
        {
            Global.LeftArrowActiveMovie = false;
        }
        else
        {
            Global.LeftArrowActiveMovie = true;
        }


        Index = 0;                                                        //Check Right Arrow
        for (i = MovieRotate.movieArray.Length - 1; i > -1 ; i--)
        {
            if (MovieRotate.playArray[i] == false)                        //find the right-most shape not in play (in the toolbar)
            {
                Index = i;                                               //returns the index of the last active shape i.e. shape in right most position in toolbar
                break;
            }
        }


        if (MovieRotate.selectionArray[Index].x <= 2f)  
        {
            Global.RightArrowActiveMovie = false;
        }
        else
        {
            Global.RightArrowActiveMovie = true;
        }
     
    }

    public static void ProgressBar(int max, int current, Image mask, Text Text, int Level)
    {
        //updates the progress bar and level X at the top right hand of the puzzle screen
        //called when a puzzle is loaded
        //adapted from https://www.youtube.com/watch?v=J1ng1zA3-Pk

        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
        Text.text = "Level " + Level; 
    }

    public static void ProgressCircle(int max, int current, Image mask)
    {
        //updates the progress circles on the World Select menu
        //triggered when the World scene is loaded
        //adapted from https://www.youtube.com/watch?v=J1ng1zA3-Pk

        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
    }


   public static void RenderShapeFixed(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n, bool Circle)
    {
        //creates a sprite game object that is the "anchor shape" in the puzzle 
        //this shape loads in position and cannot be moved
        //triggered when a puzzle is loaded

        GameObject objToSpawn = new GameObject(Name);                                            //assign name
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder
        objToSpawn.transform.position = Position;                                                //set position vector
        objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                              //set rotation vector
        objToSpawn.transform.localScale = (Scale);                                               //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name
        objToSpawn.GetComponent<SpriteRenderer>().color = Color;                                 //set colour vector (RGBA) 
                                                                                               
        TouchRotate.activeArray[n] = false;                                                      //instantiate anchor shape as inactive
        TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                             //save "rest" position (not strictly necessary to save this)
    }

    public static void RenderShapeVariable(string Name, string Sprite, Vector3 Position, Vector3 Rotation, Vector3 Scale, string SortingLayer, Vector4 Color, bool Small, int n, bool Circle)
    {
        //creates a sprite game object of the moveable puzzle pieces
        //these shapes load in the toolbar but their final position/rotation is saved
        //triggered when a puzzle is loaded

        GameObject objToSpawn = new GameObject(Name);                                            //assign name
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder

        objToSpawn.transform.localScale = (Scale);                                               //set scale vector

        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = "Shape6";
        TouchRotate.layerArray[n] = SortingLayer; 
            
        objToSpawn.GetComponent<SpriteRenderer>().color = Color;                                 //set colour vector (RGBA) 
        objToSpawn.AddComponent<CircleCollider2D>();                                             //assign circle collider    //sized correctly

        if (Small == true)
        {
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                          //small shapes spawn in their final orientation 
            TouchRotate.toolbarRotationArray[n] = Rotation;
            objToSpawn.GetComponent<CircleCollider2D>().radius = smallCollider;                  //small shapes get a much larger circle collider
        }
        else if (Circle == true)
        {
            objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                          //circular shapes spawn in their final orientation
            TouchRotate.toolbarRotationArray[n] = Rotation;
            objToSpawn.GetComponent<CircleCollider2D>().radius = regularCollider;
        }
        else
        {
            objToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, 0f);                        //standard shapes spawn in a neutral orientation
            TouchRotate.toolbarRotationArray[n] = new Vector3(0f, 0f, 0f);
            objToSpawn.GetComponent<CircleCollider2D>().radius = regularCollider;
        }

        objToSpawn.transform.position = new Vector3(toolbarXstart + n * toolbarXoffset, toolbarY, 0f);  //place in the toolbar

        TouchRotate.positionArray[n] = Position;                                                //save target location  
        TouchRotate.rotationArray[n] = Rotation;                                                //save target rotatation

        TouchRotate.smallArray[n] = Small;                                                      //save small status
        TouchRotate.circleArray[n] = Circle;                                                    //save small status

        TouchRotate.activeArray[n] = true;                                                      //instantiate all new shapes as active  
        TouchRotate.toolbarArray[n] = objToSpawn.transform.position;                            //save "rest" position
    }

    public static void RenderPuzzleImage(string Sprite)
    {
        //renders the target puzzle image
        //everything is fixed except the name of the sprite used
        //the rotate script here 
        //triggered when a puzzle is loaded

        Vector3 Position = new Vector3(-0.4f, 3.0f, 0f);
        Vector3 Rotation = new Vector3(0f, 0f, 0f);
        Vector3 Scale = new Vector3(1f, 1f, 1f);
        string SortingLayer = "Foreground";

        GameObject objToSpawn = new GameObject("Puzzle");                                        //assign name
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Sprite);       //assign sprite from resources folder
        objToSpawn.transform.position = Position;                                                //set position vector
        objToSpawn.transform.rotation = Quaternion.Euler(Rotation);                              //set rotation vector
        objToSpawn.transform.localScale = (Scale);                                               //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name

        objToSpawn.AddComponent<TouchRotate>();                                                  //add script (without this image, other shapes will not be interactable unless the script is moved)
    }

    public static void PuzzleComplete()
    {
        //popup asks if the user wants to play another puzzle or go home
        //triggered when a puzzle is completed correctly

        Debug.Log("Puzzle Complete!");
        piecesPlaced = 0;                                                                //reset to avoid looping

        GameObject.Find("PopupPuzzle").transform.localPosition = popupPosition;          //creates a popup
        
        if (SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("PuzzleComplete");                  

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;      //disables background buttons
        LeftArrowActive = false;
        RightArrowActive = false;

        Save.SaveProgress();                                                             //save game progress
    }

    public static void LevelComplete()
    { 
        
      //popup appears to signifiy a level is complete
      //triggered when the 5th puzzle within a level is completed

        Debug.Log("Level Complete!");
        piecesPlaced = 0;                                                                //reset to avoid looping

        GameObject.Find("PopupLevel").transform.localPosition = popupPosition;          //creates a popup
        
        if (SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("PuzzleComplete"); 

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;     //disables background buttons
        LeftArrowActive = false;
        RightArrowActive = false;

        Save.SaveProgress();

    }

    public static void WorldComplete()
    { 
        
        //popup appears to signify the world is complete
        //triggered when final puzzle in final level is completed

        Debug.Log("World Complete!");
        piecesPlaced = 0;                                                                //reset to avoid looping

        GameObject.Find("PopupWorld").transform.localPosition = popupPosition;          //creates a popup
        
        if (SoundEffects == true)
            FindObjectOfType<AudioManager>().Play("PuzzleComplete"); 

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;    //disables background buttons
        LeftArrowActive = false;
        RightArrowActive = false;

        Save.SaveProgress();
    }

    public static void RenderMovieVariable(string Name, Vector3 Scale, string SortingLayer,int n)
    {
        //renders the puzzle character in MovieMaker
        //characters load into toolbar but have no final position/orientation (free play)
        //triggered when MovieMaker scene loads

        GameObject objToSpawn = new GameObject(Name);                                            //assign name
        objToSpawn.AddComponent<SpriteRenderer>();                                               //add a sprite renderer
        objToSpawn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Name);         //assign sprite from resources folder

        objToSpawn.transform.localScale = (Scale);                                               //set scale vector
        objToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = SortingLayer;               //set sorting layer by name
        objToSpawn.AddComponent<CircleCollider2D>();
        objToSpawn.GetComponent<CircleCollider2D>().radius = movieCollider;                      //radius of circle is smaller than default

        objToSpawn.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        objToSpawn.transform.position = new Vector3(Global.toolbarXstart + (n+1) * Global.toolbarXoffset, Global.toolbarY, 0f);  //place in the toolbar

        MovieRotate.selectionArray[n] = objToSpawn.transform.position;                            //save "rest" position
        MovieRotate.playArray[n] = false;                                                         //set to not in play
    }

    public static void InstructionPopup()
    {
        //loads the instruction popup
        //triggered for the first puzzle in each puzzle world  

        GameObject.Find("InstructionPopup").transform.localPosition = centrePosition; 

        GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;              //de-activates buttons

        LeftArrowActive = false;
        RightArrowActive = false;

        
        PieceActive = true;                                                                    // de-activate shapes
        ActiveNameCopy = ActiveName;                                                           //saving the current active shape so that all shapes can be made inactive while menu is open
        ActiveName = "null";

        string name = GameObject.Find("InstructionPopup").scene.name;
        if (name == "Farm" && Global.Music == true)
        {
            FindObjectOfType<AudioManager>().Stop("BackgroundMusic");                         // stops background
            FindObjectOfType<AudioManager>().Play("OldMcDonald");                             // starts Old McDonald (song plays only for farm popup)
        }

    }

    public static void LoadParentalPopup()
    {
        // loads parental info popups in menu, Mouse Shapes and Farm World
        // triggered by loading that scene if the "do not show this again" tickbox is unchecked

        string name = GameObject.Find("ParentalPopup").scene.name;

        switch (name)                                            //find which scene it was called in and de-activate relevant buttons in background
        {
            case "Menu":
                GameObject.Find("StartButton").GetComponent<Button>().interactable = false;
                GameObject.Find("SettingsButton").GetComponent<Button>().interactable = false;
                GameObject.Find("ParentalButton").GetComponent<Button>().interactable = false;
                break;
            case "Mouse":
                GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;        
                GameObject.Find("CloseInstructionPopup").GetComponent<Button>().interactable = false;
                Global.LeftArrowActive = false;
                Global.RightArrowActive = false;
                Global.PieceActive = true;
                Global.ActiveNameCopy = Global.ActiveName;   //saving the current active shape so that all shapes can be made inactive while menu is open
                Global.ActiveName = "null";
                break;
            case "Farm":
                GameObject.Find("MenuButton").GetComponent<Button>().interactable = false;         
                GameObject.Find("CloseInstructionPopup").GetComponent<Button>().interactable = false;
                Global.LeftArrowActive = false;
                Global.RightArrowActive = false;
                Global.PieceActive = true;
                Global.ActiveNameCopy = Global.ActiveName;  //saving the current active shape so that all shapes can be made inactive while menu is open
                Global.ActiveName = "null";
                break;
            default:
                Debug.Log("Error in Switch Statement/ LoadParentalPopup()");
                break;
        }

        GameObject.Find("ParentalPopup").transform.localPosition = Global.centrePosition;
    }

}