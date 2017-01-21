using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy;
    private float interval;

    public float spawnDistance;

    private List<Vector3> spawnPositions;

    // Use this for initialization
    void Start()
    {
        interval = 2f;
        spawnPositions = new List<Vector3>();
        spawnDistance = 10f;
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            Vector3 randomPosition = RandomCircle(new Vector3(transform.position.x, 0, transform.position.z), spawnDistance);
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }

    }

    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        // create random angle between 0 to 360 degrees
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        //pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        //pos.z = center.z;

        return pos;
    }
}
