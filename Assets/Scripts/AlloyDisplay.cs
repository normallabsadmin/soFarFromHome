using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlloyDisplay : MonoBehaviour {
	
	private Text text;
	private int alloy = 120;
	
	public enum Status { SUCCESS, FAILURE };

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateText();
	}
	
	public void AddAlloy ( int amount ) {
		alloy += amount;
		UpdateText ();
	}
	
	public Status UseAlloy ( int amount ) {
		if ( alloy >= amount ) {
			alloy -= amount;
			UpdateText ();
			return Status.SUCCESS;
		} else {
			return Status.FAILURE;
		}
	}
	
	void UpdateText ( ) {
		text.text = alloy.ToString("0000");
	}
}
