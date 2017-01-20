using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private TowerBase towerBase;

    private TowerBase currentTower;

	// Use this for initialization
	void Start () {
	    currentTower = towerBase;
	}
	
	// Update is called once per frame
	void Update () {
       InputHandler();

    }

    private void InputHandler() {
        TowerBase tower;

        if (!currentTower.Active()) {
            currentTower = towerBase;
        }

        if (Input.GetButtonDown("X")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.X);
            tower.SetActive();
            currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            currentTower = tower;
            Debug.Log("0");
        } else if (Input.GetButtonDown("Circle")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Circle);
            tower.SetActive();
            currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            currentTower = tower;
            Debug.Log("1");
        } else if (Input.GetButtonDown("Square")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Square);
            tower.SetActive();
            currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            currentTower = tower;
            Debug.Log("2");
        } else if (Input.GetButtonDown("Triangle")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Triangle);
            currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            tower.SetActive();
            currentTower = tower;
        }

        if (currentTower.children.Length == 0) {
            //TODO Add build section here
            currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            currentTower = towerBase;
        }
    }
}
