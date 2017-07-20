using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Genre {
	public string Name { get; protected set; }
	float weight;

	public Genre() {
		Name = "defaultGenre";
		weight = 1f;
	}

	public Genre(string name, float weight) {
		Name = name;
		this.weight = weight;
	}
}
