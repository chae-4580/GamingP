using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Transform Target;
    public float Speed = 2f;

    void Awake()
    {
        Target = GameObject.FindWithTag("Player").transform;
        // 플레이어의 위치를 받음 
    }

    private void Update()
    {
        Vector3 dir = (Target.position - transform.position).normalized;
        transform.position += dir * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            //충돌하면 안 나타남
        }
    }
}
