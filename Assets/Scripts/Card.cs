using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Card : MonoBehaviour {

	public static bool DO_NOT = false; //None of the cards should be flipped halts the whole card flipping process
	[SerializeField]
	private int _state;
	[SerializeField]
	private int _cardValue;
	[SerializeField]
	private bool _initialized = false;

	private Sprite _cardBack;
	private Sprite _cardFace;

	private GameObject _manager;

	void Start(){
		_state = 1;
		_manager = GameObject.FindGameObjectWithTag ("Manager");
		AudioSource audio = GetComponent<AudioSource>();
	}

	public void setUpGraphics(){
		print ("inside setUpGraphics()");
		_cardBack = _manager.GetComponent<GameManager> ().getCardBack ();
		_cardFace = _manager.GetComponent<GameManager> ().getCardFace (_cardValue);

		flipCard ();
	}

	public void flipCard(){

		print (_state);

		if (_state == 0) {
			_state = 1;
		} else if (_state == 1) {
			_state = 0;
		}

		print (_state);

		if (_state == 0 && !DO_NOT) {
			GetComponent<Image> ().sprite = _cardBack;

		} else if (_state == 1 && !DO_NOT) {
			GetComponent<Image> ().sprite = _cardFace;
			GetComponent<AudioSource>().Play();
		}


	}

	public int cardValue {
		get { return _cardValue; }
		set { _cardValue = value; }
	}

	public int state {
		get { return _state; }
		set { _state = value; }
	}

	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}


	public void falseCheck(){
		StartCoroutine (pause ());
	}

	//To make the user wait till the cards are flipped back
	IEnumerator pause(){
		yield return new WaitForSeconds (1);
		if (_state == 0) {
			GetComponent<Image> ().sprite = _cardBack;
		} else if (_state == 1) {
			GetComponent<Image> ().sprite = _cardFace;
		}
		GetComponent<AudioSource>().Play();
		DO_NOT = false;
	}
}
