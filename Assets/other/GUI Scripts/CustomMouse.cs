// Used for setting the mouse cursor in the center of the screen and hiding the mouse cursor

using UnityEngine;
using System.Collections;

public class CustomMouse : MonoBehaviour {

	void Start()
	{
	}
	
	void Update () {
		//Vector3 screen_pos = Input.mousePosition;
		//screen_pos.x /= Screen.width;
		//screen_pos.y /= Screen.height;
		//transform.position = screen_pos;
		
		// Hide mouse cursor
		Cursor.visible = false;
		
		// Lock the cursor inside gameview
		Screen.lockCursor = true;		
	}
}
