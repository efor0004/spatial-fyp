using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
	//controls the saving of player data
	// level/puzzle progress and settings preferences
	// adapted from: https://www.red-gate.com/simple-talk/dotnet/c-programming/saving-game-data-with-unity/

	public static void SaveProgress()
	{
		//saves progress data
		//triggered when puzzle is completed 

		PlayerPrefs.SetInt("MouseLevel", Global.MouseLevel);
		PlayerPrefs.SetInt("MousePuzzle", Global.MousePuzzle);

		PlayerPrefs.SetInt("FarmLevel", Global.FarmLevel);
		PlayerPrefs.SetInt("FarmPuzzle", Global.FarmPuzzle);

		//PlayerPrefs.SetInt("PlaygroundLevel", Global.PlaygroundLevel);        //related scenes are not currently in use
		//PlayerPrefs.SetInt("PlaygroundPuzzle", Global.PlaygroundPuzzle);

		//PlayerPrefs.SetInt("TriangleLevel", Global.TriangleLevel);
		//PlayerPrefs.SetInt("TrianglePuzzle", Global.TrianglePuzzle);

		//PlayerPrefs.SetInt("WildLevel", Global.WildLevel);
		//PlayerPrefs.SetInt("WildPuzzle", Global.WildPuzzle);

		PlayerPrefs.Save();
		Debug.Log("Game Progress data saved!");
}
	public static void SaveSettings()
	{
		//saves settings data
		//triggered when settings are changed

		PlayerPrefsX.SetBool("Music", Global.Music);
		PlayerPrefsX.SetBool("SoundEffects", Global.SoundEffects);
		PlayerPrefsX.SetBool("Easy", Global.Easy);
		PlayerPrefsX.SetBool("Medium", Global.Medium);
		PlayerPrefsX.SetBool("Hard", Global.Hard);

		PlayerPrefs.Save();
		Debug.Log("Game Settings data saved!");
	}

	public static void SavePopup()
	{
		//saves popup preferences 
		//whether or not "do not show me again" checkbox was ticked
		//triggered when popups are closed

		PlayerPrefsX.SetBool("GenPopup", Global.GenPopup);
		PlayerPrefsX.SetBool("MousePopup", Global.MousePopup);
		PlayerPrefsX.SetBool("FarmPopup", Global.FarmPopup);

		PlayerPrefs.Save();
		Debug.Log("Popup preference data saved!");
	}

	public static void LoadGame()
	{
		//loads game data - progress and settings preferences
		//triggered when app opens after being closed

		if (PlayerPrefs.HasKey("MouseLevel"))    //if one piece of data exists, assume rest of data exists
		{  //progress data

			Global.MouseLevel = PlayerPrefs.GetInt("MouseLevel");
			Global.MousePuzzle = PlayerPrefs.GetInt("MousePuzzle");

			Global.FarmLevel = PlayerPrefs.GetInt("FarmLevel");
			Global.FarmPuzzle = PlayerPrefs.GetInt("FarmPuzzle");

			//Global.PlaygroundLevel = PlayerPrefs.GetInt("PlaygroundLevel");    //related scenes are not currently in use
			//Global.PlaygroundPuzzle = PlayerPrefs.GetInt("PlaygroundPuzzle");

			//Global.TriangleLevel = PlayerPrefs.GetInt("TriangleLevel");
			//Global.TrianglePuzzle = PlayerPrefs.GetInt("TrianglePuzzle");

			//Global.WildLevel = PlayerPrefs.GetInt("WildLevel");
			//Global.WildPuzzle = PlayerPrefs.GetInt("WildPuzzle");

		}
		else
		{
			Debug.Log("there is no saved progress data");  		
		}

		if (PlayerPrefs.HasKey("Music"))  //if one piece of data exists, assume rest of data exists
		{   //settings data

			Global.Music = PlayerPrefsX.GetBool("Music");
			Global.SoundEffects = PlayerPrefsX.GetBool("SoundEffects");
			Global.Easy = PlayerPrefsX.GetBool("Easy");
			Global.Medium = PlayerPrefsX.GetBool("Medium");
			Global.Hard = PlayerPrefsX.GetBool("Hard");
		}
		else
		{
			Debug.Log("there is no saved settings data");
		}

		if (PlayerPrefs.HasKey("GenPopup"))  //if one piece of data exists, assume rest of data exists
		{   //popup data
			Global.GenPopup = PlayerPrefsX.GetBool("GenPopup");
			Global.MousePopup = PlayerPrefsX.GetBool("MousePopup");
			Global.FarmPopup = PlayerPrefsX.GetBool("FarmPopup");
		}
		else
		{
			Debug.Log("there is no saved popup data");
		}

		Debug.Log("Game data loaded!");
			
	}


	public static void ResetData()
	{
		PlayerPrefs.DeleteAll();                 //delete saved data

		Global.Music = true;                     //return variables to default
		Global.SoundEffects = true;

	    Global.Easy = false;
	    Global.Medium = true;
	    Global.Hard = false;

		Global.GenPopup = true;
		Global.MousePopup = true;
		Global.FarmPopup = true;

		Global.MouseLevel = 1;
		Global.MousePuzzle = 0;
		Global.FarmLevel = 1;
		Global.FarmPuzzle = 0;
		//	Global.PlaygroundLevel = 1;               //related scenes are not currently in use 
		//	Global.PlaygroundPuzzle = 0;
		//	Global.TriangleLevel = 1;
		//	Global.TrianglePuzzle = 0;
		//	Global.WildLevel = 1;
		//	Global.WildPuzzle = 0;

		Debug.Log("Data reset complete");
	}

}
