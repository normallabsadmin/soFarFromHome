using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetButton : MonoBehaviour {

	public LevelManager levelManager;
	public string myLevel;
	
	private Text myText;
	
	void Start() {
		myText = GetComponentInChildren<Text>();
		myText.text = myLevel.Substring(myLevel.Length - 2 );
	}
	
	void OnMouseDown() {
		if(myLevel != "") {
			levelManager.LoadLevel(myLevel);
		} else {
			Debug.LogWarning("This planet has no level");
		}
	}
	
}
