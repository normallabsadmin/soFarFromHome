﻿using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (0.1f, 1f)]
	public float currentSpeed;
	[Tooltip ( "Average number of seconds between spawns" )]
	public float seenEverySecond;
	
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( Vector3.left * currentSpeed * Time.deltaTime );
		if ( !currentTarget ) {
			anim.SetBool ( "isAttacking",false);
		}
	}
	
	void OnTriggerEnter2D () {
	
	}
	
	public void SetSpeed ( float speed ) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget ( float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage( damage ) ;
			}
		}
	}
	
	public void Attack ( GameObject obj) {
		currentTarget = obj;
	}
}
