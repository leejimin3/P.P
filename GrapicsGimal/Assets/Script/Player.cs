using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    public static Vector2 move = new Vector2(1.8f, 0);
    public static float speed = 0.15f;

    public Vector2 speed_vec;
    // Start is called before the first frame update

    // Update is called once per frame

    void Start()
    {
        SetResolution();
    }
    void Update()
    {
        transform.localPosition = Move(transform.localPosition);
        speed_vec = Vector2.zero;
        //float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (Input.touchCount > 0)
        {
            int deviceWidth = Screen.width;
            int deviceHeight = Screen.height;

            Vector2 pos = Input.GetTouch(0).position;

            int dWidth = deviceWidth / 2;

            if (pos.x < dWidth)
                speed_vec.x -= speed;
            else
                speed_vec.x += speed;
           
            transform.Translate(speed_vec);
        }


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    move = speed * Time.deltaTime;
        //speed_vec.x += 0.05f;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    move = -speed * Time.deltaTime;
        //    // speed_vec.x -= 0.05f;
        //}
        //this.transform.Translate(new Vector2(move, 0));

    }

    public Vector3 Move(Vector3 position)
    {
        if(gameObject.name == "Player")
            return new Vector3(Mathf.Clamp(position.x, -move.x,move.x),-4.2f,0);
        else
            return new Vector3(Mathf.Clamp(position.x, -move.x, move.x), 4.2f, 0);
    }
    private void SetResolution()
    {
        int setWidth = 1080;
        int setHeight = 1920;

        int deviceWidth = Screen.width;
        int deviceHeight = Screen.height;

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ�����λ���ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ������ػ󵵺񰡴�ū���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο�ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο�Rect ����
        }
        else 
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο�Rect ����
        }
    }
}


