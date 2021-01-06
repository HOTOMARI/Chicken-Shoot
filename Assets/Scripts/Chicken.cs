using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;

    public bool live = true;

    public int direction = 1;   // 치킨 이동 방향
    public float speed = 10f;   // 치킨 속도
    public float size = 0.5f;   // 치킨 크기

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

        size = Random.Range(0.1f, 0.5f);    // 사이즈
        transform.localScale = new Vector2(size, size);

        direction = Random.Range(-1, 1);    //방향
        if (direction >= 0) direction = 1;

        speed = Random.Range(2f, 7f);    // 속도
    }

    // Update is called once per frame
    void Update()
    {
        if (live)
        {
            transform.Translate(new Vector2(direction * speed * Time.deltaTime, 0));
        }
        else
        {
            color.a -= 1f * Time.deltaTime;
            spriteRenderer.color = color;
        }
        
    }

    void ChangeColor(ref Color color, int r, int g, int b)
    {
        color.r = r;
        color.g = g;
        color.b = b;
    }

    public void KillChicken()
    {
        live = false;
        speed = 0;
        //spriteRenderer.sprite = DeadSprite;
        //color.r = 0;
        //color.b = 0;
        ChangeColor(ref color, 0, 255, 0);
        spriteRenderer.color = color;
        Object.Destroy(gameObject, 1);
    }
}
