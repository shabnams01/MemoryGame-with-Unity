﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public void restartMenu(){
		SceneManager.LoadScene ("Main");
	}
}
