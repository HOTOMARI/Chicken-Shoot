using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private GameObject target;

    public int direction = 1;   // 치킨 이동 방향
    public float speed = 10f;   // 치킨 속도
    public float size = 0.5f;   // 치킨 크기

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.1f, 0.5f);    // 사이즈
        transform.localScale = new Vector2(size, size);

        direction = Random.Range(-1, 1);    //방향
        if (direction >= 0) direction = 1;

        speed = Random.Range(2f, 7f);    // 속도
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(direction * speed * Time.deltaTime, 0));
        if (Input.GetMouseButtonDown(0)) // 마우스 눌렀을때 처리
        {
            CastRay();
            //Debug.Log("Click!");
            if (target == this.gameObject) // 타겟이 본인이라면 실행
            {
                Debug.Log("Chicken!");
            }
        }
    }

    void CastRay()  // 레이를 쏴서 유닛 히트처리
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if(hit.collider != null)    // 히트되었다면 실행
        {
            target = hit.collider.gameObject;   // 히트 된 게임 오브젝트를 타겟으로 지정
        }
    }
}
