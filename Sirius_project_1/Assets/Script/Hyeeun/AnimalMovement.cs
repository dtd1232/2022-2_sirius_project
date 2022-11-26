using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalMovement : MonoBehaviour
{
    public float speed=4;

    // private bool isMovingBack = false;

    public float speed_back = 0.1f;
    private float distance;

    private float distance_enemy;
    public GameObject player;
    GameObject enemy;

    private float enemyMinDistance = 0.5f;

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

        // if(distance_enemy == enemyMinDistance){
        //         transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, -speed * 2 * Time.deltaTime);
        //     }

        if (distance_enemy < 15)
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

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log("충돌!");
    //     if(other.collider.CompareTag("Enemy"))
    //     {
    //         Debug.Log ("animal, enemy 서로 충돌!!");
    //         Debug.Log (other.gameObject);
    //     }
    // }
    // {
    //     if(collision.collider.CompareTag("Enemy"))
    //     {
    //         Debug.Log ("animal, enemy 서로 충돌!!");
    //         Debug.Log (collision.gameObject);
    //     }
    // }

    void OnTriggerEnter2D (Collider2D other)
    {
        // Debug.Log("충돌");
        // Debug.Log (other.gameObject);
        // Debug.Log (other.gameObject.tag);
        // isMovingBack = true;
        if (other.tag == "Enemy")
        {
            Debug.Log ("animal, enemy 서로 충돌!!");
            // Debug.Log (other.gameObject);
            MoveBack();
            
        }
    }

    public void MoveBack()
    {
        Debug.Log ("충돌해서 뒤로 이동");
        
        // transform.Translate(new Vector3(-2, 0, 0));
        // isMovingBack = false;
        // if (distance_enemy == 2)
        // {
        //     isMovingBack = false;
        // }
        transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, -speed * 20 * Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, pos_move, 30*speed * Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, transform.position, Time.deltaTime); 
    }
}
