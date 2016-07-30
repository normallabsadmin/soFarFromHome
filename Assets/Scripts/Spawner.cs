using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update () {
		foreach ( GameObject thisAttacker in attackerPrefabArray ) {
			if ( isTimeToSpawn (thisAttacker)) {
				Spawn( thisAttacker ) ;
			}
		}
	}
	
	bool isTimeToSpawn ( GameObject attackerGameObject ) {
		Attacker attacker =  attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if( Time.deltaTime > meanSpawnDelay ) {
			Debug.Log("Spawn faster than framerate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5; //average spawn * gametime / number of lanes
		
		return ( Random.value < threshold );
		
	}
	
	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate( myGameObject ) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
}
