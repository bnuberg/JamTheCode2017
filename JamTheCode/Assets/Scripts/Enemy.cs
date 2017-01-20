using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    
    private Rigidbody2D rigidBody;
    private float speed;
  

    private List<TowerBase> towers;
    private Vector2 closestTower;
    private Vector2 currentPosition;
	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody2D>();
        speed = 2.5f;




	    GetTowers();

        Debug.Log(towers.Count);

    }

    void GetTowers() {
        GameObject[] towersTEMP = GameObject.FindGameObjectsWithTag("Tower");
        towers = new List<TowerBase>();
        for (int i = 0; i < towersTEMP.Length; i++) {
            towers.Add(towersTEMP[i].GetComponent<TowerBase>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentPosition = this.transform.position;
        closestTower = GetClosestTower(currentPosition);

        transform.position = Vector2.MoveTowards(currentPosition, closestTower, Time.deltaTime*speed);
    }

    private Vector2 GetClosestTower(Vector2 currentPos)
    {
        float minDist = Mathf.Infinity;
        Vector2 tMin = new Vector2();

        foreach (TowerBase tower in towers) {
            if (!tower.Active()) continue;

            float dist = Vector3.Distance(currentPos, tower.transform.position );
            if(dist < minDist)
            {
                tMin = tower.transform.position;
                minDist = dist;
            }
        }
        Debug.Log(tMin);
        return tMin;
    }

}
