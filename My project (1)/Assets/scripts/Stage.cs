using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Stage : MonoBehaviour
{
    public static int totalCoin = 0;
    public static float totalTime = 0f;
    public static int totalKill = 0;
    //확인

    public int stage = 1;

    public float limitTime = 60f;
    private float currentTimer = 0f;


    public GameObject[] Enemies1;

    public float spawnDelay = 2f;
    private float timer = 0f;

    public int score = 0;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI itemText;
    private Store shop;
    public GameObject ending;
    public TextMeshProUGUI resultText;
    //확인

    void Awake()
    {
        currentTimer = limitTime;
        UpdateScoreUI();
        shop = FindObjectOfType<Store>(); //확인
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;
        totalTime += Time.deltaTime;//확인
        UpdateTimer();
        if (currentTimer <= 0)
        {
            if (stage >= 5) ShowEnding();
            else SceneManager.LoadScene(stage + 1);
            return;
        }//확인

        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            SpawnEnemy();
            timer = 0f;
        }

        if(shop != null && itemText != null)
        {
            itemText.text = "Item: " + shop.inven[0];
        }//확인
    }
    void UpdateScoreUI() //1
    {
        if (scoretext != null)
        {
            scoretext.text = "Score: " + score.ToString();
        }
    }

    void ShowEnding()
    {
        ending.SetActive(true);
        Time.timeScale = 0;
        resultText.text = $"Time: {(int)totalTime}s\n" +
            $"Kills: {totalKill}\n" +
            $"Total Coins: {totalCoin}";
    }//확인

    public void GoTitle()
    {
        totalCoin = 0; totalKill = 0; totalTime = 0f;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }//확인

    void SpawnEnemy() //1
    {
        if (Enemies1.Length == 0) return;

        int rand = Random.Range(0, Enemies1.Length);
        Vector2 spawnPos = GetSpawnPosition();

        Instantiate(Enemies1[rand], spawnPos, Quaternion.identity);
    }

    Vector2 GetSpawnPosition() //2
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        return new Vector2(x, y);
    } 

    public void AddScore(int amount) //3
    {
        score += amount;
        //확인
        totalCoin += amount;
        totalKill += amount / 100;
        UpdateScoreUI();
    }

    void UpdateTimer() //5
    {
        if ((timerText != null))
        {
            timerText.text = "Time: " + Mathf.CeilToInt(currentTimer).ToString();
        }
    }

    public void GameOver() //6
    {
        stage++; //확인
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