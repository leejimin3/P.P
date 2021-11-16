using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextPeople : MonoBehaviour
{
    bool Comein = false; // true�� ����� ����
    bool Pass = false; // true�� ����� �����Ŵ
    bool NoPass = false; // true�� ���c�� �������Ŵ
    bool StopButton = false; // true�� ��ư ���� x
    bool Card = false; // true�� ī�带 ���� (ī�尡 �̵�)
    static bool Onstage = false; // true�� ����� �߰��� ����
    float speed = 0.03f; //����� �̵� ���ǵ�
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
            Transform JuminCard = GameObject.Find("JuminCard(Clone)").GetComponent<Transform>();        // ������Ʈ ������ NULL���� ����
            Transform CoovCard = GameObject.Find("CoovCard(Clone)").GetComponent<Transform>();

            //Vector3 Ran1 = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0.5f, 1.5f), 0);     //���Ͱ� �����Ӹ��� ������Ʈ �̽�
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
