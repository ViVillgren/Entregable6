using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float spawnDelay = 1.8f;
    private float spawnRate = 1.4f;
    private Vector3 randomPos;
    private float spawnPos;

    private float yLim = 15;
    private float randomHeight;
    private PlayerController playerControllerScript;
    public GameObject[] obstaclePrefabs;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRate);

    }

    public void SpawnObstacle()
    {

        if (!playerControllerScript.gameOver)
        {
            randomHeight = Random.Range(-yLim, yLim);
            spawnPos = Random.Range(0, 2);

            if (spawnPos == 0)
            {
                randomPos = new Vector3(-20, randomHeight, 0);
                Instantiate(obstaclePrefabs[1], randomPos, obstaclePrefabs[1].transform.rotation);
            }

            if (spawnPos == 1)
            {
                randomPos = new Vector3(20, randomHeight, 0);
                Instantiate(obstaclePrefabs[0], randomPos, obstaclePrefabs[0].transform.rotation);
            }
        }
    }
}
