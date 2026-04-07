using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{

    public enum EnemyType
    {
        Basic,
        Triple,
        Shot,
        Fast,
        Boom
    }

    public EnemyType enemyType;

    public float moveSpeed = 2f;
    public Transform player;
    public Transform firePoint;

    public GameObject missilePrefab;
    public float fireDelay = 2f;
    private float fireTimer = 0f;

    public float hp = 10f;

    void SetEnemyType()
    {
        switch (enemyType)
        {
            case EnemyType.Basic:
                moveSpeed = 1f;
                fireDelay = 2f;
                hp = 30f;
                break;
            case EnemyType.Triple:
                moveSpeed = 0.75f;
                fireDelay = 2.5f;
                hp = 40f;
                break;
            case EnemyType.Shot:
                moveSpeed = 0.5f;
                fireDelay = 3f;
                hp = 60f;
                break;
            case EnemyType.Fast:
                moveSpeed = 1f;
                fireDelay = 1f;
                hp = 60f;
                break;
            case EnemyType.Boom:
                moveSpeed = 1f;
                fireDelay = 2f;
                hp = 60f;
                break;
        }
    }


    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        SetEnemyType();
    }


    void Update()
    {
        LookAtPlayer();
        Move();
        Fire();
    }

    void Move() //1
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void LookAtPlayer() //2
    {
        Vector3 dir = (player.position - transform.position).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }

    void Fire() //3
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireDelay)
        {
            fireTimer = 0f;

            FireSingle();
        }
    }

    void FireSingle() //4
    {
        Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision) //5
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(10f);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damage) //6
    {
        hp -= damage;
        Debug.Log("적의 남은 체력: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die() //7
    {
        GameObject.FindObjectOfType<Stage>().AddScore(100);
        Destroy(gameObject);
    }

}
    