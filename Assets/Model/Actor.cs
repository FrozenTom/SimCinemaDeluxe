using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ActorType {ACTOR, ACTRESS, DIRECTOR}

[Serializable]
public class Actor {
	public string Name { get; protected set; }
	public ActorType Type { get; protected set; }
	public int Cost { get; protected set; }
	int cost;

	

	public Actor(ActorType type, string name = "defaultName", int cost = 1) {
		Type = type;
		Name = name;
		Cost = cost;
	}



}
