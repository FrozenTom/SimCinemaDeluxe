using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distributor : MonoBehaviour {
	public bool haveAsked = false;
	public Text DistributorName;
	public Text DistributorOffer;
	public int amountOffered = 0;

	void Start() {
		DistributorOffer.text = "Have Not Asked";
	}
	public void Ask() {
		haveAsked = true;
		DistributorOffer.text = "$100 Million";
		amountOffered = 100;
	}
	public void SetDistributorName(string tempName) {
		DistributorName.text = tempName;
	}

}
