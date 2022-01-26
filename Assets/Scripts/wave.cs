using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wave : MonoBehaviour

{

    public GameObject[] enemy;

    public int count;

    public float rate;

    public float waveTimer;

    public Transform SpawnPos;

    public wave[] waves;

    public float TimeBetweenWAves = 3f;

    public bool spawn = true;

    public bool wavespawn = true;

    public int nextwave = 0;


    void Awake()
    {
        if (spawn)

        {
            StartCoroutine(DoSpawn());
        }
    }



    IEnumerator DoSpawn()
    {
        while (nextwave <= waves.Length)
        {
            if (wavespawn)
            {
                yield return new WaitForSeconds(TimeBetweenWAves);
                for (int i = 0; i < waves[nextwave].enemy.Length; i++)
                {
                    for (int j = 0; j < waves[nextwave].count; j++)
                    {
                        yield return new WaitForSeconds(waves[nextwave].rate);
                        SpawnUnit(waves[nextwave].enemy[i], waves[nextwave]);
                    }
                }
                wavespawn = false;
            }

            yield return new WaitForSeconds(waves[nextwave].waveTimer);

            if (nextwave + 1 > waves.Length - 1)
            {
                Debug.Log("waves completed");
                spawn = false;
                yield break;
            }
            else
            {
                nextwave++;

                wavespawn = true;
            }
        }


        void SpawnUnit(GameObject enemy, wave _wave)
        {
            Instantiate(enemy, _wave.SpawnPos.position, Quaternion.identity);
        }

    }
}


