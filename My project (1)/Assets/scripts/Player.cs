using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 게임오버 시 장면 전환을 위해 필요

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    [Header("이동 설정")]
    public float Speed = 3f;

    [Header("상태 설정")]
    public float hp = 100f; // 현재 피
    public float maxHp = 100f; // 최대 피

    public int powerLevel = 1;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 MoveVelocity = Vector3.zero;

        // 입력을 받음
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        MoveVelocity = new Vector3(h, v, 0);
        //위아래 속도 감소 -> MoveVelocity = new Vector3(h, v * 0.8f, 0);

        MoveVelocity = MoveVelocity.normalized;

        transform.position += MoveVelocity * Speed * Time.deltaTime;
    }

    //총알과 부딪혔을 때 실행되는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //부딪힌 물체의 태그가 "Bullet"이라면
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(10f); //10만큼 데미지 입음

            //부딪힌 총알 제거
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        //Debug.Log("남은 HP: " + hp);

        if (hp <= 0)
        {
            GameObject.FindObjectOfType<Stage>().GameOver();  
        }
    }
}

