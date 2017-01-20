using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TowerBase {
	private string activationKey;

	// Use this for initialization
	void Start () {
		activationKey = "";
	}
	
	// Update is called once per frame
	void Update () {

	}

	public string GetActivationKey() {
		return activationKey;
	}

    
}
