using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMovieController : MonoBehaviour {

	//Toggle game objects

	public GameObject SelectDistributor;
	public GameObject NewMovie;
	public GameObject CompanyScreen;

	public Toggle isAction;
	public Toggle isDrama;
	public Toggle isHorror;
	public InputField movieName;
	public InputField movieDescription;

	public WorldController worldController;

	public void ActiveToggle() {
		if (isAction.isOn) {
			Debug.Log ("Player Select action");
		} else if (isDrama.isOn) {
			Debug.Log ("Player Select drama");
		} else if (isHorror.isOn) {
			Debug.Log ("Player Select horror");
		} else {
			Debug.Log ("No genre selected");
		}
	
	}

	public void SubmitClicked() {
		SelectDistributor.SetActive (true);
		NewMovie.SetActive (false);
		worldController.World.MovieNew (movieName.text,movieDescription.text,new Genre() );

	}
	public void BackClicked() {
		CompanyScreen.SetActive (true);
		NewMovie.SetActive (false);
	}
	public void OnEnable() {
		movieName.text = "";
		movieDescription.text = "";
	}

}
