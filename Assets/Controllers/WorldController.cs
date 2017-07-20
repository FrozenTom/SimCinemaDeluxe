using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	public World World { get; protected set; }

	// Use this for initialization
	void Start () {
		World = new World ();
		Debug.Log ("World Created");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
