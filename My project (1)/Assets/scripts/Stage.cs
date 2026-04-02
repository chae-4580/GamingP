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

    
    public GameObject[] Enemies1;

    public float spawnDelay = 2f;
    private float timer = 0f;

    public int score = 0;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI timerText;


    void Awake()
    {
        currentTimer = limitTime;
        UpdateScoreUI();
    }

    void Update()
    {
        currentTimer -= Time.deltaTime; 
        UpdateTimer();
        if(currentTimer <= 0)
        {
            stage++;
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
    void UpdateScoreUI() //1
    {
        if(scoretext != null)
        {
            scoretext.text = "Score: " + score.ToString();

        }
    }
    void SpawnEnemy() //1
    {
        if (Enemies1.Length == 0) return;

        int rand = Random.Range(0, Enemies1.Length);
        Vector2 spawnPos = GetSpawnPosition();

        Instantiate(Enemies1[rand], spawnPos, Quaternion.identity);
    }//적 스폰 코드

    Vector2 GetSpawnPosition() //2
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        return new Vector2(x, y);
    } //스폰 포지션 및 속도 코드

    public void AddScore(int amount) //3
    {
        score += amount;
        UpdateScoreUI();
    } //스코어판 코드

    
    //오류남
   
    void UpdateTimer() //5
    {
        if ((timerText != null))
        {
            timerText.text = "Time: " + Mathf.CeilToInt(currentTimer).ToString();
        }
    }

    public void GameOver() //6
    {  
            SceneManager.LoadScene(stage - 1);
    }

}

/*
     * void UpdateScoreUI()
    {
        if(scoretext != null)
        {
            scoretext.text = "Score: " + score.ToString();
        }
    }

    void UpdateTimer()
    {
        if((timerText != null))
        {
            timerText.text = "Time: " + Mathf.CeilToInt(currentTimer).ToString;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(stage - 1);
    }

    void SpawnEnemy()
    {
        if (Enemies1.Length == 0) return;

        int rand = Random.Range(0, Enemies1.Length);
        Vector2 spqwnPos = GetSpawnPosition();

        Instantiate(Enemies1[rand]m spawnPos, Q)
    }

    Vector2 GetSpawnPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        return new Vector2(x, y);
    }

    public void AddSocre(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    */
}
