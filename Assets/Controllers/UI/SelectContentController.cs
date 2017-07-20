using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectContentController : MonoBehaviour {

	public GameObject CompanyScreen;
	public GameObject SelectContent;
	public GameObject SelectActors;


	public ToggleGroup Violence;
	public ToggleGroup Profanity;
	public ToggleGroup Sex;

	public WorldController worldController;

	// Use this for initialization
	void Awake () {
		
	}

	public void ClickDone() {
		int tempViolence = 1, tempProfanity= 1, tempSex = 1;

		foreach (Toggle toggle in Violence.ActiveToggles()) {
			if (toggle.name.Contains ("Light")) {
				tempViolence = 1;
				Debug.Log ("light violence");
			} else if (toggle.name.Contains ("Medium")) {
				tempViolence = 2;
				Debug.Log ("medium violence");
			} else {
				tempViolence = 3;
				Debug.Log ("heavy violence");
			}
		}
		foreach (Toggle toggle in Profanity.ActiveToggles()) {
			if (toggle.name.Contains ("Light")) {
				tempProfanity = 1;
				Debug.Log ("light Profanity");
			} else if (toggle.name.Contains ("Medium")) {
				tempProfanity = 2;
				Debug.Log ("medium Profanity");
			} else {
				tempProfanity = 3;
				Debug.Log ("heavy Profanity");
			}
		}
		foreach (Toggle toggle in Sex.ActiveToggles()) {
			if (toggle.name.Contains ("Light")) {
				tempSex = 1;
				Debug.Log ("light Sex");
			} else if (toggle.name.Contains ("Medium")) {
				tempSex = 2;
				Debug.Log ("medium Sex");
			} else {
				tempSex = 3;
				Debug.Log ("heavy Sex");
			}
		}
		worldController.World.MovieSetContent (tempViolence, tempProfanity, tempSex);
		SelectContent.SetActive (false);
		SelectActors.SetActive (true);
	}
	public void ClickBack () {
		SelectContent.SetActive (false);
		CompanyScreen.SetActive (true);
	}


}
