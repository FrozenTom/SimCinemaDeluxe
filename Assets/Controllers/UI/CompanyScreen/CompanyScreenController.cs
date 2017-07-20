using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanyScreenController : MonoBehaviour {

	List<Text> TextMovies;

	public GameObject CompanyScreen;
	public GameObject NewMovie;
	public GameObject movieList;
	public Text movieListItem;
	public Text movieNameText;
	public Text movieBudgetText;

	public Text CompanyNameText;

	float childHeight = 35f;
	public WorldController worldController;

	// Use this for initialization
	void Awake () {
		

	}

	public void itemSelected(string movieName, int movieBudget) {
		movieNameText.text = movieName;
		movieBudgetText.text = movieBudget.ToString();
	}

	public void newMovieClicked() {
		CompanyScreen.SetActive (false);
		NewMovie.SetActive (true);
	}
	public void OnEnable() {
		Debug.Log ("controller enabled");
		TextMovies = new List<Text> ();

		CompanyNameText.text = worldController.World.CurrentCompany.CompanyName;

		foreach (Movie movie in worldController.World.CurrentCompany.Movies) {
			TextMovies.Add (Instantiate (movieListItem));
			TextMovies[TextMovies.Count-1].text = movie.Name;
			TextMovies[TextMovies.Count-1].name = movie.Name;
			TextMovies[TextMovies.Count-1].GetComponent<Button>().onClick.AddListener(
				() => {
					itemSelected(movie.Name, movie.Budget);
				}
			);
			TextMovies[TextMovies.Count-1].transform.SetParent (movieList.transform, false);
		}
		Vector2 size = movieList.GetComponent<RectTransform> ().sizeDelta;
		size.y = movieList.transform.childCount * childHeight;
		movieList.GetComponent<RectTransform> ().sizeDelta = size;
	}
	void OnDisable() {
		foreach (Text movie in TextMovies) {
			Debug.Log ("Thing destoryed called");

			Destroy (movie.gameObject);
		}
	}

}
