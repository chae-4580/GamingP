using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiitleM : MonoBehaviour
{
    public void GameStart()
    { 
        SceneManager.LoadScene(1);
    }

    // 게임 종료 버튼에 연결
    public void GameExit()
    {
        Application.Quit();
        Debug.Log("게임 종료!");
    }
}
