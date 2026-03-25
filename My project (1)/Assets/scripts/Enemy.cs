using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum EnemyType
    {
        Basic,
        Triple,
        Shot,
        Fast
    }

    public EnemyType enemyType;

    public float moveSpeed = 2f;
    public Transform player;
    public Transform firePoint;

    public GameObject missilePrefab;
    public float fireDelay = 2f;
    private float fireTimer = 0f;

    void SetEnemyType()
    {
        switch (enemyType)
        {
            case EnemyType.Basic:
                moveSpeed = 1f;
                fireDelay = 2f;
                break;
            case EnemyType.Triple:
                moveSpeed = 0.75f;
                fireDelay = 2.5f;
                break;
            case EnemyType.Shot:
                moveSpeed = 0.5f;
                fireDelay = 3f;
                break;
            case EnemyType.Fast:
                moveSpeed = 1f;
                fireDelay = 1f;
                break;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        SetEnemyType();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        Move();
        Fire();
    }

    void Move()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void LookAtPlayer()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }

    void Fire()
    {
        fireTimer = Time.deltaTime;

        if(fireTimer >= fireDelay)
        {
            fireTimer = 0f;

            switch(enemyType)
            {
                case EnemyType.Basic:
                    FireSingle();
                    break;
                case EnemyType.Triple:
                    FireSingle();
                    FireSingle();
                    FireSingle();
                    break;
                case EnemyType.Shot:
                    FireSingle();
                    break;
                case EnemyType.Fast:
                    FireSingle();
                    break;

            }
        }
    }

    void FireSingle()
    {
        Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
    }
}
