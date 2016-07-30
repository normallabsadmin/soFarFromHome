using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	public AudioClip shotSound;
	
	//priavtes
	private AudioSource audioSource;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		animator = GameObject.FindObjectOfType<Animator>();
		//find bullet parent, if it's not there grab it
	
		projectileParent = GameObject.Find ("Projectiles");
		
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update () {
		if ( IsAttackerAheadInLane() ) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
	
	bool IsAttackerAheadInLane () {
		if (myLaneSpawner.transform.childCount <= 0 ) {
			
			return false;
		} 
		
		foreach ( Transform attacker in myLaneSpawner.transform ) {
			if ( attacker.transform.position.x > transform.position.x ) {
				return true;
			}
		}
		
		return false; //all attackers are behind
	}
	
	
	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = FindObjectsOfType<Spawner>();
		foreach ( Spawner spawner in spawnerArray ) {
			if ( spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}	
		}
		Debug.LogError("There are no spawners in this lane OR this object is not in a lane");
	}

	
	public void Fire() {
		audioSource.clip = shotSound;
		audioSource.Play();
		GameObject bullet = Instantiate ( projectile ) as GameObject;
		bullet.transform.parent = projectileParent.transform;
		bullet.transform.position = gun.transform.position;
		
	}
	
	
}
