using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject FeverObject;

    private float respawnTime;
    private int i;
    private int j;
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTime());
        StartCoroutine(SpawnerTime2());
    }
    void SetRandom()
    {
        respawnTime = Random.Range(0.2f, 1.5f);
        i = Random.Range(0, 4);
        j = Random.Range(0, 4);
    }
    void SpawnEnemy()
    {
        if (GameController.III.gameStartCheck)
        {
            Instantiate(enemy, spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
    void SpawnFever()
    {
        if (GameController.III.gameStartCheck)
        {
            Instantiate(FeverObject, spawnPoints[j].transform.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnerTime()
    {
        while (true)
        {
            SetRandom();
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
    IEnumerator SpawnerTime2()
    {
        while (true)
        {
            SetRandom();
            yield return new WaitForSeconds(10);
            SpawnFever();
        }
    }
}
