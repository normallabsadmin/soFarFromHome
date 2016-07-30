using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	
	void Start () {
		if ( autoLoadNextLevelAfter <= 0 ) {
		
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	
	}

	//load level function, takes level name as a string
	public void LoadLevel ( string name) {
		Debug.Log ( "Level request for " + name );
	
		Application.LoadLevel(name);
		
	}
	
	//function that requests the application process be terminated
	public void QuitRequest ( )
	{
		Debug.Log ("Termination process started...");
		Application.Quit();
	}
	
	public void LoadNextLevel () {
	
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	
}
