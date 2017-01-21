using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

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

    private List<Vector2> spawnPositions;

    // Use this for initialization
    void Start()
    {
        interval = 2f;
        spawnPositions = new List<Vector2>();
        waveCount = 0;
        waveEnemyAmount = 15;
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
            for (int i = 0; i < waveEnemyAmount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
            //TODO: RESET ALL TOWERS FUNCTION
            waveEnemyAmount *= 2;
            yield return new WaitForSeconds(15f);
            UpdateWaveCount();
            UpdateWaveMiddle();

        }

    }

    private void UpdateWaveCount()
    {
        waveCount++;
        waveCountText.text = "Wave: " + waveCount;
    }

    private void UpdateWaveMiddle()
    {
        waveCountMessage.text = "Wave: " + waveCount;
    }

    private void SpawnEnemy()
    {
        Vector2 randomPosition = RandomCircle(this.transform.position, spawnDistance);
        Instantiate(enemy, randomPosition, Quaternion.identity);
    }
    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        // create random angle between 0 to 360 degrees
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;

        return pos;
    }
}
