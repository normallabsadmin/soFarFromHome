using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private AlloyDisplay alloyDisplay;
	
	void Start () {
		defenderParent = GameObject.Find ("Defender");
		alloyDisplay = GameObject.FindObjectOfType<AlloyDisplay>();
		
		if (!defenderParent) {
			defenderParent = new GameObject("Defender");
		}
		
	}
	
	
	
	void OnMouseDown() {
		GameObject defender = UnitButton.selectedUnit;
		int unitCost = defender.GetComponent<Defender>().alloyCost;
		
		if ( alloyDisplay.UseAlloy(unitCost) == AlloyDisplay.Status.SUCCESS  ) {
			Vector2 rawPos = CalculateWorldPositionOfMouseClick();
			Vector2 roundedPos = SnapToGrid(rawPos);
			SpawnDefender (roundedPos, defender);
		} else {
			//too little alloy to spawn
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		GameObject newDefender = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid( Vector2 rawWorldPosition) {
		float newX = Mathf.RoundToInt(rawWorldPosition.x);	
		float newY = Mathf.RoundToInt(rawWorldPosition.y);
		return new Vector2(newX,newY);
	}
	
	Vector2 CalculateWorldPositionOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos  = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos; 
	}
}
