using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public Sprite[] cardFace;
	public Sprite cardBack;

	public GameObject[] cards;
	public Text matchText;

	private bool _init = false;
	private int _matches = 13;
	
	// Update is called once per frame
	void Update () {
		if (!_init) {
			initializeCards ();
		}

		if (Input.GetMouseButtonUp (0))
		{
			print("left clicked");

			checkCards ();
		}
	}

	void initializeCards (){
		print ("inside initializeCards");

		for (int id = 0; id < 2; id++) {
			for (int i = 1; i < 14; i++) {

				bool test = false;
				int choice = 0;
				while (!test) {
					choice = Random.Range (0, cards.Length);
					test = !(cards [choice].GetComponent<Card> ().initialized);
				}
				cards [choice].GetComponent<Card> ().cardValue = i;
				cards [choice].GetComponent<Card> ().initialized = true;
			}
		}

		foreach (GameObject c in cards) {
			c.GetComponent<Card> ().setUpGraphics ();
		}

		if (!_init) {
			_init = true;
		}
	}

	public Sprite getCardBack(){
		return cardBack;
	}

	public Sprite getCardFace(int i){
		return cardFace[i - 1];
	}

	void checkCards(){
		print ("inside check card************");

		List<int> c = new List<int> ();
		for (int i = 0; i < cards.Length; i++) {

			print (cards [i].GetComponent<Card> ().state);

			if (cards [i].GetComponent<Card> ().state == 1) {
				c.Add (i);
			}
		}
		if (c.Count == 2) {
			print("just b4 calling card comparison");
			cardComparison (c);
		}
	}

	void cardComparison(List<int> c){

		print ("inside card comparison");
		Card.DO_NOT = true;

		int x = 0;

		if (cards [c [0]].GetComponent<Card> ().cardValue == cards [c [1]].GetComponent<Card> ().cardValue) {
			x = 2;
			_matches--;
			matchText.text = "Number of Matches: " + _matches;
			if (_matches == 0) {
				SceneManager.LoadScene ("GameOver");
			}
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<Card> ().state = x;
			cards [c [i]].GetComponent<Card> ().falseCheck ();
		}
	}
}
