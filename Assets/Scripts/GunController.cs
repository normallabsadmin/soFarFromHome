using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	//publics
	public AudioClip shotSound;
	
	//priavtes
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Fire() {
		audioSource.clip = shotSound;
		audioSource.Play();
	}
}
