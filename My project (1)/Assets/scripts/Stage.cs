using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public int stage = 1;

    public float limitTime = 60f;
    private float currentTimer = 0f;


    public GameObject[] stage1Enemies;
    public GameObject[] stage2Enemies;
    public GameObject[] stage3Enemies;

    private GameObject[] currentEnemies;

    public float spawnDelay = 2f;
    private float timer = 0f;

    public int score = 0;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI timerText;


    void Awake()
    {
        currentTimer = limitTime;
        SetStage(stage);
        UpdateScoreUI();
    }

    void Update()
    {
        currentTimer -= Time.deltaTime; 
        UpdateTimer();
        if(currentTimer <= 0)
        {
            GameOver();
            return;
        }

        timer += Time.deltaTime;
        if (timer >= spawnDelay)
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
    }//적 스폰 코드

    Vector2 GetSpawnPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        return new Vector2(x, y);
    } //스폰 포지션 및 속도 코드

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    } //스코어판 코드

    void UpdateScoreUI()
    {
        if(scoretext != null)
        {
            scoretext.text = "Score: " + score.ToString();

        }
    }
    //오류남
   
    void UpdateTimer()
    {
        if ((timerText != null))
        {
            timerText.text = "Time: " + Mathf.CeilToInt(currentTimer).ToString();
        }
    }

    public void GameOver()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
