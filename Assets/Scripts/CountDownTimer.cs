﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour {
	float timeRemaining = 60;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
	}

	void OnGUI(){
		if (timeRemaining > 0) {
			GUI.Label (new Rect (20, 10, 200, 100), "Time Remaining : " + timeRemaining);
		} else {
			GUI.Label (new Rect (20, 10, 200, 100), "Time UP");
			SceneManager.LoadScene ("GameOver");
		}
	}
}
