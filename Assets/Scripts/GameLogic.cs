using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject obstacles;
    [SerializeField] GameObject fuelObject;
    [SerializeField] Player player;

    float obstacleSpawnTime = 0f;
    float obstacleSpawnDelay = 3f;

    float fuelSpawnTime = 0f;
    float fuelSpawnDelay = 5f;

    Vector3[] obstaclePositions = new Vector3[2];
    Vector3 playerPos;

    GameObject spawnObstacle;

    [SerializeField] TextMeshProUGUI score;
    float increaseScore;

    private void Update()
    {
        increaseScore = increaseScore + Time.deltaTime;

        HandleSpawn();
        HandleScore();
    }

    void HandleScore()
    {
        score.text = Mathf.FloorToInt(increaseScore).ToString();
    }

    void HandleSpawn()
    {
        obstacleSpawnTime += 1f * Time.deltaTime;
        fuelSpawnTime += 1f * Time.deltaTime;

        if (obstacleSpawnTime > obstacleSpawnDelay)
        {
            obstacleSpawnTime = 0f;
            SpawnObstacles();
        }

        if (fuelSpawnTime > fuelSpawnDelay)
        {
            fuelSpawnTime = 0f;
            SpawnFuel();
        }
    }

    void SpawnFuel()
    {
        Instantiate(fuelObject, new Vector3(playerPos.x, playerPos.y, playerPos.z), player.transform.rotation);
    }

    void SpawnObstacles()
    {
        playerPos = player.transform.position;

        obstaclePositions[0] = new Vector3(playerPos.x + 5, playerPos.y, playerPos.z);
        obstaclePositions[1] = new Vector3(playerPos.x - 5, playerPos.y, playerPos.z);

        for (int i = 0; i < 2; i++)
        {
            spawnObstacle = Instantiate(obstacles, obstaclePositions[i], player.transform.rotation);
        }

    }

}