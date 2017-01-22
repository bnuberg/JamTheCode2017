﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private GameObject mainTower;

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float interval;
    
    public float spawnDistance;
    private int waveCount;

    [SerializeField]
    private int waveEnemyAmount;
    [SerializeField]
    private Text waveCountText;
    [SerializeField]
    private Text waveCountMessage;

    //private List<Vector3> spawnPositions;

    // Use this for initialization
    void Start()
    {
        mainTower = GameObject.Find("MainTower");

        interval = 1f;
        //spawnPositions = new List<Vector3>();
        waveCount = 0;
        waveEnemyAmount = 5;
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
        yield return new WaitForSeconds(1.5f);
        while (waveCount < 4)
        {
            waveCountMessage.text = "";
            for (int i = 0; i < waveEnemyAmount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(interval);
            }

            while (AreEnemiesLeft())
            {
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(4f);
            NextWave();
            yield return new WaitForSeconds(6f);

            //Vector3 randomPosition = RandomCircle(new Vector3(transform.position.x, 0, transform.position.z), spawnDistance);
            //Instantiate(enemy, randomPosition, Quaternion.identity);
        }

        Debug.Log("You beat 3 waves, move on to next level!");
    }

    private bool AreEnemiesLeft()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(enemies.Length);

        if (enemies.Length == 0)
            return false;
        else
            return true;
        ;
    }

    private void NextWave()
    {
        waveEnemyAmount += 2;
        interval *= 0.9f;
        UpdateWaveCount();
        UpdateWaveMiddle();
    }

    private void UpdateWaveCount()
    {
        mainTower.GetComponent<TowerBase>().activateAllChildren();
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

        return pos;
    }
}
