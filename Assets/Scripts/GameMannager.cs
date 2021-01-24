using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager : MonoBehaviour
{
    public bool PlayerLive;
    public GameObject EndText;

    void Awake()
    {
        EndText = GameObject.Find("End");
        EndText.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetPlayerLive() == false)
        {
            GameOver();
        }
    }

    public void ChangePlayerLive() // 게임 진행상태 변경
    {
        PlayerLive = false;
    }

    public bool GetPlayerLive() // 게임 진행상태 받아오기
    {
        return PlayerLive;
    }

    void GameOver()
    {
        EndText.SetActive(true);
    }
}
