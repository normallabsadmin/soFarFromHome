using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 120;

	private AudioSource audioSource;
	private Slider slider;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find("You Win");
		if (!winLabel) {
			Debug.LogWarning("Missing You Win Label");
		}
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value =  Time.timeSinceLevelLoad / levelSeconds   ;
	
		if (Time.timeSinceLevelLoad >=  levelSeconds && !isEndOfLevel ) {
			isEndOfLevel = true;
			winLabel.SetActive(true);
			audioSource.Play (); 
			Invoke("LoadNextLevel", audioSource.clip.length);
			
		}
	}
	
	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}
