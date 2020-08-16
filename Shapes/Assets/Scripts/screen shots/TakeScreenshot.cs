using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
	//handles taking a screen shot in MovieMaker
	//https://www.youtube.com/watch?v=DQeylS0l4S4

	[SerializeField]
	GameObject blink;

	public void TakeAShot()
	{
		StartCoroutine("CaptureIt");
	}

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;  //disbale UI buttons before screenshot
		yield return new WaitForEndOfFrame();
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;  //re-enable UI buttons after screenshot
		Instantiate(blink, new Vector2(0f, 0f), Quaternion.identity);      //blink persists... it should just be a flash

		//old version that does not hide UI elements
		//string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		//string fileName = "Screenshot" + timeStamp + ".png";
		//string pathToSave = fileName;
		//ScreenCapture.CaptureScreenshot(pathToSave);
		//yield return new WaitForEndOfFrame();
		//Instantiate(blink, new Vector2(0f, 0f), Quaternion.identity);
	}

}