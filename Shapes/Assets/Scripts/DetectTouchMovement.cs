using UnityEngine;
using System.Collections;

public class DetectTouchMovement : MonoBehaviour
{

	//adapted code from http://wiki.unity3d.com/index.php/DetectTouchMovement
	//detects 2 finger rotation on screen and updates public variable turnAngle and turnAngleDelta

	//ROTATION
	const float pinchTurnRatio = (Mathf.PI / 2)/2;      //////magic number
	const float minTurnAngle = 0;   //magic number
	
	static public float turnAngleDelta; //The delta of the angle between two touch points
	static public float turnAngle; //The angle between two touch points
	

	static public void Calculate() 
	{
		//Calculates Turn and Translate - This should be used inside LateUpdate
		
		turnAngle = turnAngleDelta = 0;
		

		// if two fingers are touching the screen at the same time ...
		if (Input.touchCount == 2)
		{
			Touch touch1 = Input.touches[0];
			Touch touch2 = Input.touches[1];

			// ... if at least one of them moved ...
			if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
			{
				//ROTATION
				// ... check the delta angle between them ...
				turnAngle = Angle(touch1.position, touch2.position);
				float prevTurn = Angle(touch1.position - touch1.deltaPosition,
									   touch2.position - touch2.deltaPosition);
				turnAngleDelta = Mathf.DeltaAngle(prevTurn, turnAngle);

				// ... if it's greater than a minimum threshold, it's a turn!
				if (Mathf.Abs(turnAngleDelta) > minTurnAngle)
				{
					turnAngleDelta *= pinchTurnRatio;
				}
				else
				{
					turnAngle = turnAngleDelta = 0;
				}

			}
		}
		
	}

	static private float Angle(Vector2 pos1, Vector2 pos2)
	{
		Vector2 from = pos2 - pos1;
		Vector2 to = new Vector2(1, 0);

		float result = Vector2.Angle(from, to);
		Vector3 cross = Vector3.Cross(from, to);

		if (cross.z > 0)
		{
			result = 360f - result;
		}

		return result;
	}
}