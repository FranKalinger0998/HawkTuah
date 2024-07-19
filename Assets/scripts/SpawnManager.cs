using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] allEnemies;
    [SerializeField] GameObject[] crawliesAndRunners;
    [SerializeField] GameObject crawlerOnly;
    [SerializeField] Transform[] enemySpawnPoints;
    public GameEvent onWaveEnd;

    int waveNumber = 0;
    int timer = 0;
    int spawnDelay = 6;
    bool isTimeToSpawn;
    int llamasAsleep = 0;
    private void Start()
    {
        StartCoroutine(StartOfWaveTimer());
    }

    IEnumerator EnemySpawner()
    {
        while (isTimeToSpawn)
        {
            if (waveNumber <= 2)
            {
                Instantiate(crawlerOnly, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, crawlerOnly.transform.rotation);
            }
            else if (waveNumber <= 5)
            {
                Instantiate(crawliesAndRunners[Random.Range(0, crawliesAndRunners.Length)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, crawliesAndRunners[Random.Range(0, crawliesAndRunners.Length)].transform.rotation);
            }
            else if (waveNumber > 5)
            {
                Instantiate(allEnemies[Random.Range(0, allEnemies.Length)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, allEnemies[Random.Range(0, allEnemies.Length)].transform.rotation);
            }

            yield return new WaitForSeconds(spawnDelay);
        }

    }
    IEnumerator EndOfWaveTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
            if (timer == 45)
            {
                isTimeToSpawn = false;
                Resetllamas();
                Debug.Log("Buy phase");
                timer = 0;
                StartCoroutine(StartOfWaveTimer());
                break;

            }
        }

    }
    IEnumerator StartOfWaveTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
            //Debug.Log(timer);
            if (timer == 30)
            {
                Debug.Log("Start wave");
                waveNumber++;
                isTimeToSpawn = true;
                StartCoroutine(EnemySpawner());
                StartCoroutine(EndOfWaveTimer());
                break;
            }
        }

    }
    public void StartEarly()
    {
        timer = 29;
    }
    public void Resetllamas()
    {
        onWaveEnd.Raise(this, llamasAsleep);
        Debug.Log("I was called");
    }
}
