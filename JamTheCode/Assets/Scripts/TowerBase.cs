using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {
    [SerializeField]
    public TowerBase parentTower;
    [SerializeField]
    public Tower[] children;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Animation animations;
    private GameObject ashes;


    [SerializeField]
    protected bool isActive = true;

    // Use this for initialization
    protected virtual void Start () {
        //children = new Tower[4];
        //GetComponent<SpriteRenderer>().color = Color.green;

        animations = gameObject.GetComponentInChildren<Animation>();
        //ashes =

        //animations = GameObject.Find("TowerV1").GetComponent<Animation>();

        if (!isActive) animations.Play("Destroyed");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetParent(TowerBase tower) {
		parentTower = tower;
	}

	public void AddChild(Tower child) {
		if (children.Length == 4) {
			Debug.Log("Tower exceeds children limit!");
		}
		children[children.Length] = child;
	}

	public Tower GetChildByKey(Tower.ActivateKeys input) {
		for (int i = 0; i < children.Length; i++) {
			Tower tempChild = children[i];
			if (tempChild.GetActivationKey() == input) {
				return tempChild;
			}
		}

		return null;
	}
    
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            Die();
        }
    }
    
    public void OnActivation() {
        GameObject go = Instantiate(explosion, transform);
        go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    virtual public void Die() {
        if (!isActive) return;

        //TODO REMOVE WHEN MAIN TOWER HAS MODEL
        if (gameObject.name != "MainTower") {
            animations.Play("Destruction");
        }
        isActive = false;
        GetComponent<SpriteRenderer>().color = Color.red;
        //GetComponent<SpriteRenderer>().enabled = false;
    }

    public bool Active() {
        return isActive;
    }

    public void SetActive() {
        OnActivation();
        if (parentTower.Active()) {
            isActive = true;
            animations.Play("Repair");
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
