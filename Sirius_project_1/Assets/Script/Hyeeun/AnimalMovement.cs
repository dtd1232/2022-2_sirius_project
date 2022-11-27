using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalMovement : MonoBehaviour
{
    public float speed=3;

    public float Damage = 5;

    // private bool isMovingBack = false;

    public float speed_back = 0.1f;
    private float distance;

    private float distance_enemy;
    public GameObject player;
    Animator animator;
    GameObject enemy;

    private float enemyMinDistance = 0.5f;

    float minDistance = 2f;
    public void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        animator = GetComponent<Animator>();
        
    }

    public void FixedUpdate()
    {
        //animator.SetBool("isIdle", true);
        distance = Vector3.Distance(transform.position, player.transform.position);
        distance_enemy = Vector3.Distance(transform.position, enemy.transform.position);

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
        //animator.SetBool("isIdle", false);
        animator.SetBool("isMoving", true);
       transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    public void ChaseEnemy()
    {
        //animator.SetBool("isIdle", false);
        animator.SetBool("isMoving", true);
       transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime); 
    }

    // 부딪혀서 공격할 때
    void OnTriggerEnter2D (Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {
            Debug.Log ("animal, enemy 서로 충돌!!");
            //animator.SetBool("isMoving", false);
            animator.SetBool("isAttack", true);
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
        }
        //animator.SetBool("isAttack", false);
    }

    void OnOnTriggerExit2D (Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {
            Debug.Log ("animal, enemy 서로 떨어짐");

            //animator.SetBool("isMoving", true);
            animator.SetBool("isAttack", false);
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            
            
        }
    }

    public void MoveBack()
    {
        Debug.Log ("충돌해서 뒤로 이동");
        
        transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, -speed * 20 * Time.deltaTime);
    }
}
