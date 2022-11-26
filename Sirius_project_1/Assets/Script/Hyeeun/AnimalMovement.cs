using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalMovement : MonoBehaviour
{
    public float speed=4;
    private float distance;

    private float distance_enemy;
    public GameObject player;
    GameObject enemy;

    float minDistance = 2f;
    public void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }
    //chase player if character is in range
    public void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        distance_enemy = Vector3.Distance(transform.position, enemy.transform.position);

        if (distance_enemy < 15 )
        {
            ChaseEnemy();
        }

        else if (distance < 8 && distance > minDistance) {
            ChasePlayer();
        }
    }
    public void ChasePlayer()
    {
        //move towards the player
       transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    public void ChaseEnemy()
    {
        //move towards the player
       transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("충돌");
        if(other.collider.CompareTag("Enemy"))
        {
            Debug.Log ("animal, enemy 서로 충돌!!");
            Debug.Log (other.gameObject);
        }
    }
    // {
    //     if(collision.collider.CompareTag("Enemy"))
    //     {
    //         Debug.Log ("animal, enemy 서로 충돌!!");
    //         Debug.Log (collision.gameObject);
    //     }
    // }

    // void OnTriggerEnter2D (Collider2D other)
    // {
    //     Debug.Log("충돌");
    //     Debug.Log (other.gameObject);
    //     Debug.Log (other.gameObject.tag);
    //     if (other.tag == "Enemy")
    //     {
    //         Debug.Log ("animal, enemy 서로 충돌!!");
    //         Debug.Log (other.gameObject);
    //     }
    // }
}
