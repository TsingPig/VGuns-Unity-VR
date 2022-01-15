using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public Transform[] TransformsList;


    public TextMeshProUGUI waveCountText;
    int waveCount = 1;

    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;

    public int enemyCount;

    public GameObject enemy;

    bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = "Wave: " + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            Transform transform = TransformsList[Random.Range(0, ((ICollection)TransformsList).Count)];
    
            Instantiate(enemy, transform.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnRate);
        }

        spawnRate -= 0.1f;
        enemyCount += 3;
        waveCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }
    
}