using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private TowerBase towerBase;

    public TowerBase currentTower;
    private TowerBase tower = null;
    private TowerBase mainTower;

    bool isButtonDown = false;
    private float timer;
    [SerializeField]
    private float activationTime = 1f;

    // Use this for initialization
    void Start () {
        ChangeCurrenTower(towerBase);
        mainTower = GameObject.Find("MainTower").GetComponent<TowerBase>();
        mainTower.TextActivator(mainTower.children);
    }
	
	// Update is called once per frame
	void Update () {
       InputHandler();

    }

    private void InputHandler() {
        if (!currentTower.Active()) {
            ChangeCurrenTower(towerBase);
        }

        bool hasActiveChild = false;
        for (int i = 0; i < currentTower.children.Length; i++)
        {
            if (currentTower.children[i].Active())
            {
                hasActiveChild = true;
                //currentTower.GetComponent<SpriteRenderer>().color = Color.magenta;
            }
        }
        if (!hasActiveChild)
        {
            ChangeCurrenTower(towerBase);
        }

        if (Input.GetButtonDown("X"))
        {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.X);
            HandlePlayerInput(tower);
        } else if (Input.GetButtonDown("Circle")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Circle);
            HandlePlayerInput(tower);
        } else if (Input.GetButtonDown("Square")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Square);
            HandlePlayerInput(tower);
        } else if (Input.GetButtonDown("Triangle")) {
            tower = currentTower.GetChildByKey(Tower.ActivateKeys.Triangle);
            HandlePlayerInput(tower);
        }
        
        if (currentTower.children.Length == 0) {
            //currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            ChangeCurrenTower(towerBase);
            currentTower.TextActivator(currentTower.children);
        }
    }

    void HandlePlayerInput(TowerBase tower)
    {
        if (tower != null)
        {
            tower.TextActivator(tower.children);
            if (tower.Active())
            {
                mainTower.ResetTextTowers();
                Explosion(tower);
            }
        }
        else
        {
            //TODO Enter combo breaker
            //currentTower.GetComponent<SpriteRenderer>().color = Color.green;
            //currentTower = towerBase;
        }
    }

    void ChangeCurrenTower(TowerBase tower)
    {
        currentTower = tower;
        currentTower.TextActivator(currentTower.children);
    }
    void Explosion(TowerBase tower)
    {
        tower.SetActive();
        //currentTower.GetComponent<SpriteRenderer>().color = Color.green;
        ChangeCurrenTower(tower);
    }
}
