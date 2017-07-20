using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionController : MonoBehaviour {

	public Text MovieName;
	public Text MovieDesc;
	public Text MoiveDist;
	public Text MovieGenre;
	public Text MovieBudget;
	public Text MovieMoney;
	public Text MovieBuzz;
	public Text MovieViolence;
	public Text MovieProfanity;
	public Text MovieSex;
	public Text Progress1;
	public Text Progress2;
	public Text Progress3;
	public Text Progress4;

	public Text Review;
	public Text Theater;
	public Text Earnings;
	public Text WeekEarnings;



	public Text PopUp;
	public Text Notification;

	public Text MovieTitle;

	//Release changes
	public GameObject ReleaseButton;
	public GameObject ProgressGroups;
	public GameObject ReleaseGroups;



	public GameObject AdButtons;
	public GameObject MovieInfo;
	public GameObject PopUpBox;


	public WorldController worldController;
	public GameObject ProductionScreen;
	public GameObject CompanyScreen;

	// Use this for initialization
	void OnEnable () {

		MovieTitle.text = worldController.World.activeMovie.Name;
		ReleaseButton.SetActive (true);
		ReleaseGroups.SetActive (false);
		ProgressGroups.SetActive (true);
		UpdateText ();

	}
	
	// Update is called once per frame
	public void ClickRelease() {
		//worldController
		if (worldController.World.activeMovie.Release ()) {
			ReleaseButton.SetActive (false);
			ReleaseGroups.SetActive (true);
			ProgressGroups.SetActive (false);
		}
		Notify ();

	}
	public void ClickPassWeek() {
		worldController.World.PassWeek ();
		UpdateText ();
		Notify ();
		if (worldController.World.activeMovie.WeekEarnings < 0) {
			FinishMovie ();
		}
	}

	public void ClickBuyAds() {
		MovieInfo.SetActive (false);
		AdButtons.SetActive (true);

	}
	public void ClickMovieInfo() {
		AdButtons.SetActive (false);
		MovieInfo.SetActive (true);
	}
	public void ClickBuySpecificAd(string adType) {
		worldController.World.BuyAd (adType);
		AdButtons.SetActive (false);
		MovieInfo.SetActive (false);
		Notify ();
		UpdateText ();
	}
	public void ClickBuyAdsBack() {
		AdButtons.SetActive (false);
	}
	public void ClickPopUp() {
		PopUpBox.SetActive (false);
	}

	public void UpdateText() {
		MovieName.text = worldController.World.activeMovie.Name;
		MovieDesc.text = worldController.World.activeMovie.Desc;
		MoiveDist.text = worldController.World.activeMovie.Distributor;
		MovieGenre.text = worldController.World.activeMovie.Genre.Name;
		MovieBudget.text = worldController.World.activeMovie.Budget.ToString();
		MovieMoney.text = worldController.World.activeMovie.CurrentMoney.ToString();
		MovieBuzz.text = worldController.World.activeMovie.Buzz.ToString();
		MovieViolence.text = worldController.World.activeMovie.Violence.ToString();
		MovieProfanity.text = worldController.World.activeMovie.Profanity.ToString();
		MovieSex.text = worldController.World.activeMovie.Sex.ToString();
		Progress1.text = worldController.World.activeMovie.Progress1 + "%";
		Progress2.text = worldController.World.activeMovie.Progress2 + "%";
		Progress3.text = worldController.World.activeMovie.Progress3 + "%";
		Progress4.text = worldController.World.activeMovie.Progress4 + "%";

		Review.text = worldController.World.activeMovie.AverageReview + "";
		Theater.text = worldController.World.activeMovie.Theaters + "";
		Earnings.text = worldController.World.activeMovie.Earnings + " m";
		WeekEarnings.text = worldController.World.activeMovie.WeekEarnings + " m";

	}
	public void Notify() {
		if (worldController.World.activeMovie.PopUp) {
			PopUp.text = worldController.World.activeMovie.Message;
			PopUpBox.SetActive (true);
		} else {
			Notification.text += "\n - " + worldController.World.activeMovie.Message;
		}
	}
	public void FinishMovie() {
		worldController.World.CurrentCompany.AddMovie (worldController.World.activeMovie);
		worldController.World.Save ();
		ProductionScreen.SetActive (false);
		CompanyScreen.SetActive (true);
	}
}
