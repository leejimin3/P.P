using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball(Clone)")
        {
            count -= 1;
            if (count == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255/255f, 226/255f, 81/255f, 255/ 255f);
            }
            else if(count == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(81 / 255f, 108 / 255f, 255 / 255f, 255 / 255f);
            }
            else if (count == 0)
            {
                    MainGame.boxcount -= 1;
                    Destroy(gameObject);

                    if (MainGame.boxcount == 0)
                    {
                    if (MainGame.lev == 3)
                    {
                        GameObject.Find("Canvas").transform.Find("EndPanel").gameObject.SetActive(true);
                        Time.timeScale = 0.0f;
                        Destroy(GameObject.Find("Ball(Clone)"));

                    }
                    else
                    {
                        Destroy(GameObject.Find("Ball(Clone)"));
                        EndGame();
                        MainGame.lev += 1;
                    }
                    }
            }
        }
    }
    void EndGame() 
    {
        GameObject.Find("Canvas").transform.Find("ItemPanel").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

}
