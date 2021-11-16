using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextPeople : MonoBehaviour
{
    bool Comein = false; // true면 사람이 들어옴
    bool Pass = false; // true면 사람을 통과시킴
    bool NoPass = false; // true면 샤럄얼 불통과시킴
    bool StopButton = false; // true면 버튼 동작 x
    bool Card = false; // true면 카드를 꺼냄 (카드가 이동)
    static bool Onstage = false; // true면 사람이 중간에 있음
    float speed = 0.03f; //사람의 이동 스피드
    public GameObject[] Humans;
    public GameObject JuminCard;
    public GameObject CoovCard;
    
    void Start()
    {
        NextHuman();
    }

    void Update()
    {
        if (Comein == true)
        {
            StopButton = true;
            GameObject.FindWithTag("People").GetComponent<Transform>().position = Vector3.MoveTowards(GameObject.FindWithTag("People").GetComponent<Transform>().position, new Vector3(0, 2, 0), speed);
            if(GameObject.FindWithTag("People").GetComponent<Transform>().position == new Vector3(0, 2, 0))
            {
                CheckCard();
                Comein = false;
                StopButton = false;
            }
        }
        if (Pass == true)
        {
            GameObject.FindWithTag("People").GetComponent<Transform>().position = Vector3.MoveTowards(GameObject.FindWithTag("People").GetComponent<Transform>().position, new Vector3(5, 2, 0), speed);
            if (GameObject.FindWithTag("People").GetComponent<Transform>().position == new Vector3(5, 2, 0))
            {
                Destroy(GameObject.FindWithTag("People"));
                Pass = false;
                NextHuman();
            }
        }
        if (NoPass == true)
        {
            GameObject.FindWithTag("People").GetComponent<Transform>().position = Vector3.MoveTowards(GameObject.FindWithTag("People").GetComponent<Transform>().position, new Vector3(-5, 2, 0), speed);
            if (GameObject.FindWithTag("People").GetComponent<Transform>().position == new Vector3(-5, 2, 0))
            {
                Destroy(GameObject.FindWithTag("People"));
                NoPass = false;
                NextHuman();
            }
        }




        if (Card == true) 
        {
            Transform JuminCard = GameObject.Find("JuminCard(Clone)").GetComponent<Transform>();        // 업데이트 프레임 NULL참조 오류
            Transform CoovCard = GameObject.Find("CoovCard(Clone)").GetComponent<Transform>();

            //Vector3 Ran1 = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0.5f, 1.5f), 0);     //벡터값 프레임마다 업데이트 이슈
            //Vector3 Ran2 = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0.5f, 1.5f), 0);

            Vector3 Ran1 = new Vector3(-1.3f, 0, 0);
            Vector3 Ran2 = new Vector3(1.3f, 0, 0);


            JuminCard.position = Vector3.MoveTowards(JuminCard.position, Ran1, speed);
            CoovCard.position = Vector3.MoveTowards(CoovCard.position, Ran2, speed);

            if(JuminCard.position == Ran1 && CoovCard.position == Ran2)
            {
                Card = false;
            }
            
        }

    }
    public void ComeinPeople()
    {
        if (Onstage == false)
        {
            Comein = true;
            Onstage = true;
        }
    }
    public void PassPeople()
    {
        if (StopButton == false)
        {
            if (Onstage == true)
            {
                Destroy(GameObject.Find("JuminCard(Clone)"));
                Destroy(GameObject.Find("CoovCard(Clone)"));
                Onstage = false;
                Pass = true;
                Card = false;
            }
        }
    }
    public void NoPassPeople()
    {
        if (StopButton == false)
        {
            if (Onstage == true)
            {
                Destroy(GameObject.Find("JuminCard(Clone)"));
                Destroy(GameObject.Find("CoovCard(Clone)"));
                Onstage = false;
                NoPass = true;
                Card = false;
            }
        }
    }
    public void NextHuman() 
    {
        Instantiate(Humans[Random.Range(0, Humans.Length)]);
        Comein = true;
        Onstage = true;
    }

    public void CheckCard() 
    {
        Instantiate(JuminCard);
        Instantiate(CoovCard);
        Card = true;
    }








}
