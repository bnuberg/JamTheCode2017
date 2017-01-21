using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private TowerBase towerBase;

    private TowerBase currentTower;
    private TowerBase tower = null;

    bool isButtonDown = false;
    private float timer;
    [SerializeField]
    private float activationTime = 1f;

    // Use this for initialization
    void Start () {
	    currentTower = towerBase;
	}
	
	// Update is called once per frame
	void Update () {
       InputHandler();

    }

    private void InputHandler() {
        if (!currentTower.Active()) {
            currentTower = towerBase;
        }

        if (Input.GetButtonDown("X"))
        {
            Debug.Log("0");
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.X);
            if (tower.Active())
            {
                Explosion(tower);
            }
            else
            {
                isButtonDown = true;
            }
        } else if (Input.GetButtonDown("Circle")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Circle);
            if (tower.Active())
            {
                Explosion(tower);
            }
            else
            {
                isButtonDown = true;
            }
            Debug.Log("1");
        } else if (Input.GetButtonDown("Square")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Square);
            if (tower.Active())
            {
                Explosion(tower);
            }
            else
            {
                isButtonDown = true;
            }
            Debug.Log("2");
        } else if (Input.GetButtonDown("Triangle")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Triangle);
            if (tower.Active())
            {
                Explosion(tower);
            }
            else
            {
                isButtonDown = true;
            }
        }

        if (Input.GetButtonUp("X") || Input.GetButtonUp("Circle") || Input.GetButtonUp("Square") || Input.GetButtonUp("Triangle"))
        {
            isButtonDown = false;
            tower = null;
            timer = 0;
        }

        if (isButtonDown)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);
        }

        if (timer > activationTime)
        {
            Debug.Log(tower);
            if (tower != null)
            {
                tower.SetActive();
                currentTower = tower;
            }
            timer = 0;
        }

        if (currentTower.children.Length == 0) {
            currentTower = towerBase;
        }
    }

    void Explosion(TowerBase tower)
    {
        currentTower.GetComponent<SpriteRenderer>().color = Color.green;
        tower.SetActive();
        currentTower = tower;
    }
}
