using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotPreview : MonoBehaviour {

	//handles the screenshot in Gallery
	//https://www.youtube.com/watch?v=DQeylS0l4S4

	[SerializeField]
	GameObject canvas;
	[SerializeField]
	Sprite defaultImage;
	string[] files = null;
	int whichScreenShotIsShown= 0;

	// Use this for initialization
	void Start () {
		canvas.GetComponent<Image>().sprite = defaultImage;
		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
		Debug.Log(Application.persistentDataPath); ////////////////////////////////////
		GameObject.Find("PanelText").GetComponent<Text>().text = Application.persistentDataPath; ///////////////
		Debug.Log("file length: " + files.Length);  //////////////////////////////////////////
		if (files.Length > 0) {
			GetPictureAndShowIt ();
		}
	}

	void GetPictureAndShowIt()
	{
		string pathToFile = files [whichScreenShotIsShown];
		Texture2D texture = GetScreenshotImage (pathToFile);
		Sprite sp = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height),
			new Vector2 (0.5f, 0.5f));
		canvas.GetComponent<Image> ().sprite = sp;
	}

	Texture2D GetScreenshotImage(string filePath)
	{
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists (filePath)) {
			fileBytes = File.ReadAllBytes (filePath);
			texture = new Texture2D (2, 2, TextureFormat.RGB24, false);
			texture.LoadImage (fileBytes);
		}
		return texture;
	}

	public void DeleteImage()
	{
		if (files.Length > 0) {
			string pathToFile = files [whichScreenShotIsShown];
			if (File.Exists (pathToFile))
				File.Delete (pathToFile);
			files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
			if (files.Length > 0)
				NextPicture ();
			else
				canvas.GetComponent<Image> ().sprite = defaultImage;
		}
	}

	public void NextPicture()
	{
		if (files.Length > 0) {
			whichScreenShotIsShown += 1;
			if (whichScreenShotIsShown > files.Length - 1)
				whichScreenShotIsShown = 0;
			GetPictureAndShowIt ();
		} 
	}

	public void PreviousPicture()
	{
		if (files.Length > 0) {
			whichScreenShotIsShown -= 1;
			if (whichScreenShotIsShown < 0)
				whichScreenShotIsShown = files.Length - 1;
			GetPictureAndShowIt ();
		} 
	}
}
