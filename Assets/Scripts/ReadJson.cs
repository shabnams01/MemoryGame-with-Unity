using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using LitJson;

public class ReadJson : MonoBehaviour {

	public Text scoreText;
	private string jsonString;


	// Use this for initialization
	void Start () {
		jsonString = File.ReadAllText (Application.dataPath + "/Resources/Scores.json");
			print(jsonString);

		scoreText.text = jsonString;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
