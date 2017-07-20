using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Company {

	public string CompanyName { get; protected set; }
	public string OwnerName { get; protected set; }
	public int Money { get; set; }
	public List<Movie> Movies { get; protected set; }


	public Company(string companyName, string ownerName, int money = 0) {
		CompanyName = companyName;
		OwnerName = ownerName;
		Money = money;
		Movies = new List<Movie> ();
	}
	public Company(string companyName, string ownerName, int money, List<Movie> movies) {
		CompanyName = companyName;
		OwnerName = ownerName;
		Money = money;
		Movies = movies;
	}
	public void AddMovie(Movie movie) {
	
		Movies.Add (movie);
	}


}
