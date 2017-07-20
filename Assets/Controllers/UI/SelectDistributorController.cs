using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDistributorController : MonoBehaviour {

	public GameObject SelectDistributor;
	public GameObject CompanyScreen;
	public GameObject SelectContent;

	List<Distributor> distributors;
	public Distributor SampleDistributor;
	public GameObject DistributorList;
	//public Text SampleDistributorName;
	//public Text SampleDistributorOffer;
	float childHeight = 35f;
	Distributor currentlySelected;

	public WorldController worldController;

	void Awake () {
		
	}


	public void itemSelected(string movieName, int movieBudget) {
		//movieNameText.text = movieName;
		//movieBudgetText.text = movieBudget.ToString();
	}

	public void BackClicked() {
		SelectDistributor.SetActive (false);
		CompanyScreen.SetActive (true);
		//Destroy(this);
	}
	public void AskClicked() {
		if(currentlySelected.haveAsked) {
			Debug.Log (currentlySelected.DistributorName.text + " has already been asked");
		} else {
			currentlySelected.Ask ();
		}
	}
	public void SelectClicked() {
		if (currentlySelected.haveAsked) {
			Debug.Log ("You have selected " + currentlySelected.DistributorName.text + " for " + currentlySelected.DistributorOffer.text);
			worldController.World.MovieSetDistributor (currentlySelected.DistributorName.text, currentlySelected.amountOffered);
			SelectDistributor.SetActive (false);
			SelectContent.SetActive (true);
		} else {
			Debug.Log ("you have not asked " + currentlySelected.DistributorName.text); 
		}

	}
	public void itemSelected(Distributor temp) {
		
		currentlySelected = temp;
		Debug.Log (currentlySelected.DistributorName.text + " has been selected");
	}
	public void OnEnable() {
		distributors = new List<Distributor> ();
		distributors.Add (Instantiate(SampleDistributor));
		distributors[0].SetDistributorName("Disney");
		distributors.Add (Instantiate(SampleDistributor));
		distributors[1].SetDistributorName("Warner");
		distributors.Add (Instantiate(SampleDistributor));
		distributors[2].SetDistributorName("Fox");
		distributors.Add (Instantiate(SampleDistributor));
		distributors[3].SetDistributorName("Universal");

		foreach (Distributor distributor in distributors) {
			//adds listeners

			distributor.DistributorName.GetComponent<Button>().onClick.AddListener(
				() => {
					itemSelected(distributor);
				}
			);
			distributor.transform.SetParent (DistributorList.transform, false);

		}
		Vector2 size = DistributorList.GetComponent<RectTransform> ().sizeDelta;
		size.y = DistributorList.transform.childCount * childHeight;

		DistributorList.GetComponent<RectTransform> ().sizeDelta = size;
		Debug.Log ("Enable called");
	}
	public void OnDisable() {
		foreach (Distributor distributor in distributors) {
			Debug.Log ("Thing destoryed called");

			Destroy (distributor.gameObject);
		}
	}
}
