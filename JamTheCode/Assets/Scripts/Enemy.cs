using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    
    private Rigidbody2D rigidBody;
    private float speed;
  

    private List<TowerBase> towers;
    private Vector3 closestTower;
    private Vector3 currentPosition;
    private float offset;
	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody2D>();
        speed = 0.5f;
        offset = 1f;
	    GetTowers();

        //Debug.Log(towers.Count);
        transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
    }

    void GetTowers() {
        GameObject[] towersTEMP = GameObject.FindGameObjectsWithTag("Tower");
        towers = new List<TowerBase>();
        for (int i = 0; i < towersTEMP.Length; i++) {
            towers.Add(towersTEMP[i].GetComponent<TowerBase>());
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Explosion")) {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentPosition = this.transform.position;
        closestTower = GetClosestTower(currentPosition);

        transform.position = Vector3.MoveTowards(currentPosition, closestTower, Time.deltaTime*speed);
    }

    private Vector3 GetClosestTower(Vector3 currentPos) {
        float minDist = Mathf.Infinity;
        Vector3 tMin = new Vector3();

        foreach (TowerBase tower in towers) {
            if (!tower.Active()) continue;

            float dist = Vector3.Distance(currentPos, tower.transform.position);
            if(dist < minDist)
            {
                tMin = tower.transform.position;
                minDist = dist;
            }
        }
        //Debug.Log(tMin);
        return tMin;
    }

}
