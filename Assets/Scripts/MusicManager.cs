using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	//publics
	public AudioClip[] levelMusicChangeArray;
	
	//priavtes
	private AudioSource audioSource;	
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad ( gameObject);
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded( int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		
		if ( thisLevelMusic ) { //If music was attached to this level in array (see inspector)
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume ( float volume ) {
		 audioSource.volume = volume;
		
	}
}
