using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed_move = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameMannager").GetComponent<GameMannager>().GetPlayerLive())
        {
            moveCamera();
        }
    }

    void moveCamera()
    {
        float keyH = Input.GetAxis("Horizontal");
        keyH = keyH * speed_move * Time.deltaTime;
        transform.Translate(Vector3.right * keyH);

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, 0, -10);
        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, 0, -10);
        }

    }
}
