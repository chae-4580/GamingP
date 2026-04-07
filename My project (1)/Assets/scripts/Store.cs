using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public string[] inven = {"","",""};
    public GameObject shop;
    public TextMeshProUGUI coinText;

    int[] price = {1000, 500, 1100 };

    void Update()
    {
        coinText.text = "Coin: " + Stage.totalCoin;

        if (Input.GetKeyUp(KeyCode.Alpha1)) Use(0);
        if (Input.GetKeyUp(KeyCode.Alpha2)) Use(1);
        if (Input.GetKeyUp(KeyCode.Alpha3)) Use(2);
    }

    public void buy(int index)
    {
        if (Stage.totalCoin < price[index]) return;
        
        for(int i = 0; i < 3; i++)
        {
            if (inven[i] == "")
            {
                Stage.totalCoin -= price[index];
                inven[i] = (index == 0) ? "Hp" : (index == 2) ? "Slow" : "Bomb";
                return;           
            }
        }
    }

    void Use(int slot)
    {
        if (inven[slot] == "") return;

        string item = inven[slot];

        if (item == "Hp")
        {
            Player p = FindObjectOfType<Player>();
            if(p != null) p.hp = Mathf.Min(p.hp + 30, 100);
        }

        if (item == "Slow")
        {
            Time.timeScale = 0.5f;
            Invoke("ResetTime", 3f);
        }

        if(item == "Bomb")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int count = Mathf.Min(enemies.Length, 3);
            for(int i = 0; i<count; i++)
            {
                Destroy(enemies[i]);
            }
        }
        inven[slot] = "";
    }

    void ResetTime()
    {
        Time.timeScale = 1f;
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
