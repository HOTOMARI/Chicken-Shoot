using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float remainTime;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        remainTime = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;
            UpdateText();
        }
        else
        {
            remainTime = 0;
            GameObject.FindGameObjectWithTag("GameMannager").GetComponent<GameMannager>().ChangePlayerLive();
        }
    }

    void UpdateText()
    {
        int min, sec;
        min = (int)(remainTime / 60f);
        sec = (int)(remainTime % 60f);

        timeText.text = min + ":" + sec.ToString("D2");
    }
}
