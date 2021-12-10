using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainGame : MonoBehaviour
{
    public GameObject[] boxs;
    int lev = 3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Instantiate(boxs[Random.Range(0,lev)], new Vector2(boxs[0].transform.position.x+(j*0.9f), boxs[0].transform.position.y+(i*0.8f)), boxs[0].transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
