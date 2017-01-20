using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TowerBase {
	private string activationKey;

	// Use this for initialization
	void Start () {
		activationKey = "";

        if (isActive) {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseDown() {
        SetActive();
        
    }

    public override void Die() {
        base.Die();

        if (parentTower != null && parentTower.Active() && parentTower.name != "MainTower") {
            parentTower.Die();
        }

        for (int i = 0; i < children.Length; i++) {
            if (children[i].Active()) children[i].Die();
        }
    }

    public void SetActive() {
        if (parentTower.Active()) {
            isActive = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

	public string GetActivationKey() {
		return activationKey;
	}

    
}
