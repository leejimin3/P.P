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
        if(collision.gameObject.name == "Ball")
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
                Destroy(gameObject);
            }
        }
    }
}
