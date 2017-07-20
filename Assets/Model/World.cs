using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class World {
	public List<Actor> Actors;
	public List<Company> Companies;
	public Company CurrentCompany{ get{return Companies[CurrentCompanyIndex] ; } }
	public int CurrentCompanyIndex;
	public Movie activeMovie;
	public DateTime date;

	public string PopUp;
	public string notification;

	// Use this for initialization
	public World() {
		Actors = new List<Actor> ();
		Actors.Add(new Actor(ActorType.ACTOR, "Jeff Goldblum",5));
		Actors.Add(new Actor(ActorType.ACTOR, "Jeff Goldblum",10));
			
		Actors.Add(new Actor(ActorType.ACTRESS, "Emma Stone",5));
		Actors.Add(new Actor(ActorType.ACTRESS, "Anne Hathaway",10));

		Actors.Add(new Actor(ActorType.DIRECTOR, "Mel Brooks",5));
		Actors.Add(new Actor(ActorType.DIRECTOR, "Nolan",15));
		Load ();
		//TestingStuff ();
		date = new DateTime (2015, 1, 1);

	}

	public void MovieNew (string name, string desc, Genre genre) {
		activeMovie = new Movie (name, desc, genre);
	}
	public void MovieSetDistributor(string name, int budget) {
		activeMovie.Budget = budget;
		activeMovie.CurrentMoney = budget;
		activeMovie.Distributor = name;
	}
	public void MovieSetContent(int violence, int profanity, int sex) {
		activeMovie.Violence = violence;
		activeMovie.Profanity = profanity;
		activeMovie.Sex = sex;
	}
	public void MovieAddActor (Actor actor) {
		activeMovie.addActor (actor);
	}
	public void PassWeek() {
		if (activeMovie.ProgressMovie()) {
			date.AddDays (7); 
		} 
	}
	public void BuyAd(string adType) {
		if (adType == "tv") {
			activeMovie.BuyTVAd ();
		} else if (adType == "print") {
			activeMovie.BuyTVAd ();
		} else if (adType == "internet") {
			activeMovie.BuyInternetAd ();
		} else if (adType == "trailer") {
			activeMovie.BuyInternetAd ();
		} else {
			Debug.Log ("Invalid Ad Type (World.BuyAd)");
		}
	}
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "\\SimCinemaInfo.dat", FileMode.Create);
		bf.Serialize (file, Companies);
		file.Close ();

	}
	public void Load() {
		
		Companies = new List<Company> ();
		if (File.Exists (Application.persistentDataPath + "\\SimCinemaInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "\\SimCinemaInfo.dat", FileMode.Open);
			Companies = (List<Company>)bf.Deserialize (file);
			Debug.Log ("Something loaded");
		} 
	}
	public void SetCurrentCompany(Company company) {
		if (Companies.Contains (company)) {
			CurrentCompanyIndex = Companies.IndexOf (company);
		} else {
			Debug.LogError ("Company does not exist");
		}
	}
}


