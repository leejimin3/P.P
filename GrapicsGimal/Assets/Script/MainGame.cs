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
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
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

    public void GoFirst()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void SetBall() 
    {
        Instantiate(Ball, Ball.transform.position, Ball.transform.rotation);
    }
    public void GameStartButton() 
    {
        MakeBox();
        SetBall();
        boxcount = 30;
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ItemPanel").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}