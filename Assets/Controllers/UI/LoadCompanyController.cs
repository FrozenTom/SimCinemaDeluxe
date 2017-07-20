using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCompanyController : MonoBehaviour {

	List<Text> TextCompanies;

	public GameObject CompanyScreen;
	public GameObject LoadCompany;
	public GameObject companyList;

	public GameObject NewCompanyPopUp;
	public InputField CompanyName;
	public InputField PlayerName;

	public Text companyListItem;
	public Text companyNameText;
	public Text companyCashText;
	float childHeight = 35f;
	public WorldController worldController;
	public Company currentlySelected;
	// Use this for initialization
	void Awake () {


	}

	public void itemSelected(string companyName, int companyCash) {
		companyNameText.text = companyName;
		companyCashText.text = companyCash.ToString();
	}

	public void ClickLoadCompany() {
		worldController.World.SetCurrentCompany (currentlySelected);
		LoadCompany.SetActive (false);
		CompanyScreen.SetActive (true);

	}
	public void ClickNewCompany() {
		NewCompanyPopUp.SetActive (true);
	}
	public void ClickConfirm() {
		Company temp = new Company (CompanyName.text, PlayerName.text); 
		worldController.World.Companies.Add (temp);
		worldController.World.SetCurrentCompany (temp);
		NewCompanyPopUp.SetActive (false);
		CompanyScreen.SetActive (true);
		LoadCompany.SetActive (false);
	}
	public void ClickCancel() {
		NewCompanyPopUp.SetActive (false);

	}
		
	public void OnEnable() {
		Debug.Log ("controller enabled");
		TextCompanies = new List<Text> ();


		foreach (Company company in worldController.World.Companies) {
			TextCompanies.Add (Instantiate (companyListItem));
			TextCompanies[TextCompanies.Count-1].text = company.CompanyName;
			TextCompanies[TextCompanies.Count-1].name = company.CompanyName;
			TextCompanies[TextCompanies.Count-1].GetComponent<Button>().onClick.AddListener(
				() => {
					itemSelected(company.CompanyName, company.Money);
				}
			);
			TextCompanies[TextCompanies.Count-1].GetComponent<Button>().onClick.AddListener(
				() => {
					itemSelected(company);
				}
			);
			TextCompanies[TextCompanies.Count-1].transform.SetParent (companyList.transform, false);
		}
		Vector2 size = companyList.GetComponent<RectTransform> ().sizeDelta;
		size.y = companyList.transform.childCount * childHeight;
		companyList.GetComponent<RectTransform> ().sizeDelta = size;
	}
	void OnDisable() {
		foreach (Text movie in TextCompanies) {
			Debug.Log ("Thing destoryed called");

			Destroy (movie.gameObject);
		}
	}
	public void itemSelected (Company company){
		currentlySelected = company;
	}

}
