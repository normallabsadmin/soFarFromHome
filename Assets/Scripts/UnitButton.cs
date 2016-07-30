using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitButton : MonoBehaviour {
	private UnitButton[] unitButtonArray;
	
	public static GameObject selectedUnit;
	public GameObject buttonUnit;
	
	private Text costText;

	
	// Use this for initialization
	void Start () {
		unitButtonArray = GameObject.FindObjectsOfType<UnitButton>();
		costText = GetComponentInChildren<Text>();
		
		if (!costText) {
			Debug.LogWarning(name + " has not cost");
		}
		
		costText.text = buttonUnit.GetComponent<Defender>().alloyCost.ToString();
		
		foreach (UnitButton thisButton in unitButtonArray ) {
			thisButton.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f); 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		foreach (UnitButton thisButton in unitButtonArray ) {
			thisButton.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f); 
		}
		
		GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		
		if ( buttonUnit ) {
			selectedUnit = buttonUnit;
			
		}
		
	}
}
