using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stage = 1;

    public GameObject[] stage1Enemies;
    public GameObject[] stage2Enemies;
    public GameObject[] stage3Enemies;

    private GameObject[] currentEnemies;

    public float spawnDelay = 2f;
    private float timer = 0f;


    void Awake()
    {
        SetStage(stage);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnDelay)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }
    void SetStage(int stage)
    {
        switch (stage)
        {
            case 1:
                currentEnemies = stage1Enemies;
                spawnDelay = 2f;
                break;
            case 2:
                currentEnemies = stage2Enemies;
                spawnDelay = 1.5f;
                break;
            case 3:
                currentEnemies = stage3Enemies;
                spawnDelay = 1f;
                break;
        }

    }

    void SpawnEnemy()
    {
        if (currentEnemies.Length == 0) return;

        int rand = Random.Range(0, currentEnemies.Length);
        Vector2 spawnPos = GetSpawnPosition();

        Instantiate(currentEnemies[rand], spawnPos, Quaternion.identity);
    }

    Vector2 GetSpawnPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        return new Vector2(x, y);
    }
}
