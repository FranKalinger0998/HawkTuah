using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] allEnemies;
    [SerializeField] GameObject[] crawliesAndRunners;
    [SerializeField] GameObject crawlerOnly;
    [SerializeField] Transform[] enemySpawnPoints;
    [SerializeField] TMP_Text waveIndexText;
    [SerializeField] TMP_Text notificationText;
    public GameEvent onWaveEnd;
    int levelToSpawn = 1;

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
                Instantiate(crawlerOnly, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, crawlerOnly.transform.rotation).GetComponent<EnemyScript>().SetLevel(1);
            }
            else if (waveNumber <= 5)
            {
                Instantiate(crawliesAndRunners[Random.Range(0, crawliesAndRunners.Length)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, crawliesAndRunners[Random.Range(0, crawliesAndRunners.Length)].transform.rotation).GetComponent<EnemyScript>().SetLevel(1);
            }
            else if (waveNumber > 5)
            {
                Instantiate(allEnemies[Random.Range(0, allEnemies.Length)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, allEnemies[Random.Range(0, allEnemies.Length)].transform.rotation).GetComponent<EnemyScript>().SetLevel(1);
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
            if (timer == 35)
            {
                notificationText.text = "";
            }

            else if (timer == 45)
            {
                isTimeToSpawn = false;
                notificationText.text = "Wave over";
                Resetllamas();
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
            if(timer== 5)
            {
                notificationText.text = "";
            }
            //Debug.Log(timer);
            else if (timer == 30)
            {
                waveNumber++;
                levelToSpawn=Mathf.FloorToInt(waveNumber/2f);
                notificationText.text = $"Wave {waveNumber} start!";
                UpdateWaveDisplay();
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
    public void UpdateWaveDisplay()
    {
        waveIndexText.text="Wave: "+waveNumber.ToString();
    }
}
