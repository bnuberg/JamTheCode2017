using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private GameObject mainTower;

    [SerializeField]
    private GameObject enemy;
    private float interval;
    
    public float spawnDistance;

    private int waveCount;
    private int waveEnemyAmount;
    [SerializeField]
    private Text waveCountText;
    [SerializeField]
    private Text waveCountMessage;

    private List<Vector3> spawnPositions;

    // Use this for initialization
    void Start()
    {
        mainTower = GameObject.Find("MainTower");

        interval = 0.000001f;
        spawnPositions = new List<Vector3>();
        waveCount = 0;
        waveEnemyAmount = 10000;
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawner()
    {
        UpdateWaveCount();
        yield return new WaitForSeconds(1f);
        UpdateWaveMiddle();
        while (true)
        {
            
            yield return new WaitForSeconds(1.5f);
            waveCountMessage.text = "";
            Debug.Log(interval);
            for (int i = 0; i < waveEnemyAmount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(interval);
            }

            waveEnemyAmount *= 2;
            yield return new WaitForSeconds(15f);
            UpdateWaveCount();
            UpdateWaveMiddle();

            Vector3 randomPosition = RandomCircle(new Vector3(transform.position.x, 0, transform.position.z), spawnDistance);
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }

    private void UpdateWaveCount()
    {
        //mainTower.GetComponent<TowerBase>().activateAllChildren();
        waveCount++;
        waveCountText.text = "Wave: " + waveCount;
    }

    private void UpdateWaveMiddle()
    {
        waveCountMessage.text = "Wave: " + waveCount;
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = RandomCircle(this.transform.position, spawnDistance);
        Instantiate(enemy, randomPosition, Quaternion.identity);
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
