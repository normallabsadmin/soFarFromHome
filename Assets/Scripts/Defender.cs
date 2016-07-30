using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int alloyCost = 10;
	public AlloyDisplay alloyDisplay;
	
	void Start () {
		alloyDisplay = FindObjectOfType<AlloyDisplay>();
	}
	
	public void AddAlloy ( int amount ) {
		alloyDisplay.AddAlloy( amount );
	}

}
