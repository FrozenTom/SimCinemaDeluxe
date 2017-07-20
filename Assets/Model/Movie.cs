using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Movie {
	public string Name { get; protected set; }
	public string Desc { get; protected set; }
	public string Distributor { get;  set; }
	public Genre Genre { get; protected set; }
	public int Budget { get; set; }

	List<Actor> actors;

	//variables
	static int PrintAdCost = 1;
	static int TVAdCost = 6;
	static int InternetAdCost = 4;
	static int TrailerAdCost = 2;

	public int Violence { get; set; }
	public int Profanity { get; set; }
	public int Sex { get; set; }

	//Quality Variables
	public int Buzz { get; set; }
	public float AverageReview { get; set; }
	public int Quality { get; set; }
	public int Theaters { get; set; }
	public int Earnings { get; set; }
	public int WeekEarnings { get; set; }
	public DateTime TimeSinceRelease { get; set; }


	//Production Vairables
	public int Progress1 { get; set; }
	public int Progress2 { get; set; }
	public int Progress3 { get; set; }
	public int Progress4 { get; set; }
	public bool isReleased { get; set; }

	public int TVAd { get; set; }
	public int TrailerAd { get; set; }
	public int InternetAd { get; set; }
	public int PrintAd { get; set; }
	private int TotalAd{ get{return TVAd +TrailerAd +InternetAd+PrintAd ; } }

	public int CurrentMoney { get; set; }
	public int NextWeekCost { get; set; }

	public bool PopUp { get; set; }
	public string Message { get; set; }

	public Movie () {
		Name = "defaultName";
		Desc = "defaultDesc";
		actors = new List<Actor> ();
	}
	public Movie (string name, string desc, Genre genre) {
		Name = name;
		Desc = desc;
		Genre = genre;

		Progress1 = 0;
		Progress2 = 0;
		Progress3 = 0;
		Progress4 = 0;
		isReleased = false;

		Buzz = 0;
		Earnings = 0;
		TimeSinceRelease = new DateTime ();
		Theaters = 1000;
		AverageReview = 5.23f;
		WeekEarnings = 20;

		TVAd = 0;
		TrailerAd = 0;
		InternetAd = 0;
		PrintAd = 0;
		actors = new List<Actor> ();

		PopUp = false;
		Message = "Movie Created";
	}

	public bool addActor(Actor actor) {
		if (CurrentMoney >= actor.Cost) {
			actors.Add (actor);
			CurrentMoney -= actor.Cost;
			return true;
		} else {
			return false;
		}
	}

	public Actor getActor(ActorType type) {
		foreach (Actor actor in actors) {
			if (actor.Type == type) {
				return actor;
			}
		}
		Debug.Log ("Movie does not contain actor of some type" );
		return null;
	}
	public bool ProgressMovie() {
		if (isReleased) {
			
			WeekEarnings -= 1;
			Earnings += WeekEarnings;
			PopUp = false;
			Message = "week progressed";
			return true;
		} else {
			if (CurrentMoney < NextWeekCost) {
				Debug.Log ("Tried to progress week without enough money");
				PopUp = true;
				Message = "Not enough money to Pass Week";
				return false;
			} else {
				Debug.Log ("Week Progressed");
				Buzz += (int)Math.Floor (TotalAd * UnityEngine.Random.value);
				CurrentMoney -= NextWeekCost;
				NextWeekCost = UnityEngine.Random.Range (1, 3);
				if (Progress4 == 100) {
					NextWeekCost = 0;
				} else if (Progress3 == 100) {
					Progress4 += 20;
				} else if (Progress2 == 100) {
					Progress3 += 20;
				} else if (Progress1 == 100) {
					Progress2 += 20;
				} else {
					Progress1 += 20;
				}

				PopUp = false;
				Message = "Production continues, week progressed";

				return true;
			}
		}

	}

	public bool BuyPrintAd() {
		if (CurrentMoney >= PrintAdCost) {
			PrintAd += PrintAdCost;
			CurrentMoney -= PrintAdCost;
			PopUp = false;
			Message = "You bought a print Ad";
			Debug.Log ("Ad bought");
			return true;
		} else {
			Debug.Log ("Not enough money");
			PopUp = true;
			Message = "You can't afford that!";
			return false;
		}
	}
	public bool BuyTrailerAd() {
		if (CurrentMoney >= TrailerAdCost) {
			PrintAd += TrailerAdCost;
			CurrentMoney -= TrailerAdCost;
			PopUp = false;
			Message = "You bought a trailer Ad";
			Debug.Log ("Ad bought");
			return true;
		} else {
			Debug.Log ("Not enough money");
			PopUp = true;
			Message = "You can't afford that!";
			return false;
		}
	}
	public bool BuyInternetAd() {
		if (CurrentMoney >= InternetAdCost) {
			PrintAd += InternetAdCost;
			CurrentMoney -= InternetAdCost;
			PopUp = false;
			Message = "You bought an internet Ad";
			Debug.Log ("Ad bought");
			return true;
		} else {
			Debug.Log ("Not enough money");
			PopUp = true;
			Message = "You can't afford that!";
			return false;
		}
	}
	public bool BuyTVAd() {
		if (CurrentMoney >= TVAdCost) {
			PrintAd += TVAdCost;
			CurrentMoney -= TVAdCost;
			PopUp = false;
			Message = "You bought a TV Ad";
			Debug.Log ("Ad bought");
			return true;
		} else {
			Debug.Log ("Not enough money");
			PopUp = true;
			Message = "You can't afford that!";
			return false;
		}
	}
	public bool Release() {
		if (Progress1 + Progress2 == 200) {
			isReleased = true;
			PopUp = false;
			Message = "Movie Has been Released!";
			return true;
		} else {
			
			PopUp = true;
			Message = "Movie isn't ready";
			return false;
		}
	}

}
