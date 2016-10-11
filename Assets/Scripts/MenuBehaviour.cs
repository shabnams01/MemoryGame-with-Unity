using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

	public void triggerMenu(int i){
		switch (i) {
		default:
		case(0):
			SceneManager.LoadScene ("Game");
			break;
		case(1):
			Application.Quit ();
			break;
		}
	}
}
