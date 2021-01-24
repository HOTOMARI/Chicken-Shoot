using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private GameObject target;
    private int bullet;
    private int score;

    float timer;

    public float reloadtime;
    public bool reload;
    public Text bulletText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        bullet = 8;
        score = 0;

        timer = 0;
        reloadtime = 2.0f;
        reload = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임이 끝나지 않았을경우 실행합니다.
        if (GameObject.FindGameObjectWithTag("GameMannager").GetComponent<GameMannager>().GetPlayerLive())
        {
            if (reload)
            {
                timer += 2.0f * Time.deltaTime;
                if (timer > 2.0f)
                {
                    timer = 0;
                    reload = false;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0)) // 마우스 눌렀을때 처리
                {
                    Debug.Log("Click!");
                    if (bullet > 0)
                    {
                        CastRay();
                        if (target != null)
                        {
                            if (target.tag == "Chicken") // 타겟이 치킨이라면 실행
                            {
                                if (target.GetComponent<Chicken>().GetChickenAlive())
                                {
                                    Debug.Log("Chicken!");
                                    target.GetComponent<Chicken>().KillChicken();
                                    score++;
                                    RefreshScore();
                                }

                            }
                            else
                            {
                               // Debug.Log("Click!");
                            }
                        }
                        ShotBullet();
                    }

                }

                if (Input.GetKeyDown(KeyCode.R)) //재장전 처리
                {
                    Debug.Log("reloading");
                    ReloadBullet();
                }
            }
        }
    }
    void CastRay()  // 레이를 쏴서 유닛 히트처리
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)    // 히트되었다면 실행
        {
            target = hit.collider.gameObject;   // 히트 된 게임 오브젝트를 타겟으로 지정
        }
    }

    void ShotBullet()
    {
        bullet--;
        RefreshBullet();
    }

    void ReloadBullet()
    {
        reload = true;
        bullet = 8;
        RefreshBullet();
    }

    void RefreshBullet()
    {
        bulletText.text = "X " + bullet;
    }

    void RefreshScore()
    {
        scoreText.text = score.ToString();
    }
}

