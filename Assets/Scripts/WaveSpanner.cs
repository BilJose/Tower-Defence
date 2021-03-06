﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpanner : MonoBehaviour
{


    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private int waveIndex = 0;

    public Text waveCountdownText;

    private float countdown = 2f;
    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if( countdown <= 0f)
        {

            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

     IEnumerator SpawnWave()
    {


        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.countEnemy; i++)
        {
            
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f/ wave.rateEnemy);
        }
        waveIndex++;
        if (waveIndex == waves.Length)
        {
            Debug.Log("Level Won");
            this.enabled = false;
        }
        
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
