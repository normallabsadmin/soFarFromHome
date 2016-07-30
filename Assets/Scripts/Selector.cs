using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Find out where the mouse is in general, and save it's x and y
		Vector3 mousePosition = Input.mousePosition;
		//float mouseX = Mathf.Round( mousePosition.x / 133.333f );
		//float mouseY = Mathf.Round( mousePosition.y / 133.333f );
		float mouseX = Mathf.Floor( (mousePosition.x / Screen.width) * 11 );
		float mouseY = Mathf.Floor( (mousePosition.y / Screen.width) * 11 );
		//Debug.Log("X:" + mouseX + ", Y:" + mouseY);
		
		//if it's in the place space make sure the cursor is on and visible
		if ( ( mouseX > 0f && mouseX < 10f) && ( mouseY > 0f && mouseY < 6f )) { 
	
			//gameObject.SetActive ( true );
		
			Vector3 myPosition = new Vector3( 2f, 2f);			
			
			
			myPosition.x = Mathf.Clamp( mouseX, 1f, 9f);
			myPosition.y = Mathf.Clamp( mouseY, 1f, 5f);
			gameObject.transform.position = myPosition;
		} else { // just turn it off it it's not needed
			
		}
	}
	
	void OnMouseDown () {
		
		Debug.Log (UnitButton.selectedUnit);
		
		if (UnitButton.selectedUnit) {
			GameObject unitToSpawn = Instantiate( UnitButton.selectedUnit, gameObject.transform.position, Quaternion.identity) as GameObject;
		}
	}
}
