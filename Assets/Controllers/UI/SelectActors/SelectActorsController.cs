using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActorsController : MonoBehaviour {

	public GameObject CompanyScreen;
	public GameObject SelectActors;
	public GameObject Production;

	List<Distributor> distributors;

	public ActorType currentActorType;
	public Text ActorTypeLabel;

	public SampleActorListItem sampleActorListItem;
	public GameObject ActorList;

	public Text MovieTitle;
	public Text MovieMoney;


	public WorldController worldController;




	float childHeight = 35f;
	SampleActorListItem currentlySelected;


	void OnEnable() {
		currentActorType = ActorType.ACTOR;
		PopulateList ();
		ActorTypeLabel.text = "Select an Actor:";
		MovieTitle.text = worldController.World.activeMovie.Name;
		MovieMoney.text = "$" + worldController.World.activeMovie.CurrentMoney +" million";
	}

	void PopulateList() {
		
		while(ActorList.transform.childCount > 0) {
			DestroyImmediate (ActorList.transform.GetChild(0).gameObject);
		}




		foreach (Actor actor in worldController.World.Actors) {

			if(actor.Type == currentActorType) {
				SampleActorListItem temp = Instantiate (sampleActorListItem);
				temp.SelectbleActorName.text = actor.Name;
				temp.ActorCost.text = "$" + actor.Cost + " million";
				temp.actor = actor;

				temp.SelectbleActorName.GetComponent<Button>().onClick.AddListener(
					() => {
						itemSelected(temp);
					}
				);
				temp.transform.SetParent (ActorList.transform);
				temp.transform.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			}
		}


		Vector2 size = ActorList.GetComponent<RectTransform> ().sizeDelta;
		size.y = ActorList.transform.childCount * childHeight;
		ActorList.GetComponent<RectTransform> ().sizeDelta = size;
	}



	public void ClickedCancel() {
		CompanyScreen.SetActive (true);
		SelectActors.SetActive (false);
	}

	public void ClickedSelect() {
		Debug.Log( " Select has been Clicked");
		if (worldController.World.activeMovie.addActor (currentlySelected.actor)) {
			Debug.Log (currentlySelected.actor.Name + " has been selected");
			if (currentActorType == ActorType.ACTOR) {
				ActorTypeLabel.text = "Select an Actress:";
				currentActorType = ActorType.ACTRESS;
			} else if (currentActorType == ActorType.ACTRESS) {
				ActorTypeLabel.text = "Select a Director:";
				currentActorType = ActorType.DIRECTOR;
			} else {
				SelectActors.SetActive (false);
				Production.SetActive (true);

			}
		} else {
			Debug.Log ("Cannot afford Actor");
		}

		MovieTitle.text = worldController.World.activeMovie.Name;
		MovieMoney.text = "$" + worldController.World.activeMovie.CurrentMoney +" million";

		PopulateList ();



	}
	public void itemSelected(SampleActorListItem temp) {

		currentlySelected = temp;
		Debug.Log (currentlySelected.actor.Name + " has been highlighted");
	}
}
