using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TowerBase {
    [SerializeField]
	private ActivateKeys activationKey;

    public enum ActivateKeys {
        X=0,
        Circle=1,
        Square=2,
        Triangle=3
    }

	// Use this for initialization
	void Start () {

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



	public ActivateKeys GetActivationKey() {
		return activationKey;
	}

    
}
