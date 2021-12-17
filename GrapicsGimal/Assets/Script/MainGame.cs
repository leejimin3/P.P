using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public GameObject[] boxs;
    public GameObject Ball;
    public static int lev = 1;
    public static int boxcount = 30;
    public static bool Ballsize = false;

    void Start()
    {
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        
    }

    void MakeBox() 
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Instantiate(boxs[Random.Range(0, lev)], new Vector2(boxs[0].transform.position.x + (j * 0.9f), boxs[0].transform.position.y + (i * 0.8f)), boxs[0].transform.rotation);
            }
        }
    }

    void DestroyBox()
    {
        GameObject[] boxs;
        boxs = GameObject.FindGameObjectsWithTag("Box");
        for(int i = 0; i < boxs.Length; i++)
        {
            Destroy(boxs[i]);
        }

    }

    public void GoFirst()
    {
        Player.move = new Vector2(1.8f, 0);
        Player.speed = 0.15f;
        GameObject.Find("Player").transform.localScale = new Vector3(2, 0.5f, 1);
        GameObject.Find("Player(Up)").transform.localScale = new Vector3(2, 0.5f, 1);
        lev = 1;
        Ballsize = false;
        GameObject.Find("Canvas").transform.Find("ExitPanel").gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    void SetBall() 
    {
        Instantiate(Ball, Ball.transform.position, Ball.transform.rotation);
        if (Ballsize == true)
        {
            GameObject.Find("Ball(Clone)").transform.localScale = new Vector3(0.75f, 0.75f, 1);
        }
    }
    public void GameStartButton() 
    {
        DestroyBox();
        MakeBox();
        SetBall();
        MainGame.boxcount = 30;
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ItemPanel").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Score.score = Box.SaveScore;
    }

    public void BarSpeedUp()
    {
        if (Box.SaveScore < 20)
        {
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Panel").gameObject.SetActive(true);
        }
        else
        {
            Player.speed = 0.3f;
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Button (1)").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Text (2)").gameObject.SetActive(false);
            Box.SaveScore -= 20;
            Score.score = Box.SaveScore;
        }
    }
    public void BarSizeUp()
    {
        if (Box.SaveScore < 10)
        {
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Panel").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Player").transform.localScale = new Vector3(4, 0.5f, 1);
            GameObject.Find("Player(Up)").transform.localScale = new Vector3(4, 0.5f, 1);
            Player.move = new Vector2(0.8f, 0);
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Button").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Text (1)").gameObject.SetActive(false);
            Box.SaveScore -= 10;
            Score.score = Box.SaveScore;
        }
    }
    public void BallSizeUp() 
    {
        if (Box.SaveScore < 30)
        {
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Panel").gameObject.SetActive(true);
        }
        else
        {
            Ballsize = true;
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Button (2)").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Text (3)").gameObject.SetActive(false);
            Box.SaveScore -= 30;
            Score.score = Box.SaveScore;
        }
    }

    public void PanelClose() 
    {
        GameObject.Find("Canvas").transform.Find("ItemPanel").transform.Find("Panel").gameObject.SetActive(false);
    }

    public void ShowExitPanel() 
    {
        GameObject.Find("Canvas").transform.Find("ExitPanel").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void No() 
    {
        GameObject.Find("Canvas").transform.Find("ExitPanel").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }


}