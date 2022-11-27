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

    bool facingRight = true;

    private float enemyMinDistance = 0.5f;

    float minDistance = 2f;
    public void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        animator = GetComponent<Animator>();
        
    }

    public void FixedUpdate()
    {
        Debug.Log (distance_enemy);
        //animator.SetBool("isIdle", true);
        distance = Vector3.Distance(transform.position, player.transform.position);
        distance_enemy = Vector3.Distance(transform.position, enemy.transform.position);

        if (distance_enemy < 15 && distance_enemy >= 1.2)
        {
            if (enemy.transform.position.x < transform.position.x && facingRight)
            {
                Flip();
            }
            else if (enemy.transform.position.x > transform.position.x && !facingRight)
            {
                Flip();
            }
           
            ChaseEnemy();            
        }

        else if (distance_enemy >= 15 || distance_enemy < 0.05)
        {
            if (distance < 8 && distance > minDistance) 
            {
                if (player.transform.position.x < transform.position.x && facingRight)
                {
                    Debug.Log (facingRight);
                    Debug.Log ("지금!!");
                    Flip();
                }
                else if (player.transform.position.x > transform.position.x && !facingRight)
                {
                    Debug.Log (facingRight);
                    Flip();
                }
                ChasePlayer();
            }
        }
        
    }
    public void ChasePlayer()
    {
        Debug.Log ("플레이어 따라가는 중");
        //animator.SetBool("isIdle", false);
        animator.SetBool("isMoving", true);
        
       transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    public void ChaseEnemy()
    {
        Debug.Log ("적 따라가는 중");
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

    void OnTriggerExit2D (Collider2D other)
    {
        Debug.Log ("떨어짐");
        if (other.tag == "Enemy")
        {
            Debug.Log ("animal, enemy 서로 떨어짐");

            //animator.SetBool("isMoving", true);
            animator.SetBool("isAttack", false);
            
            
        }
    }

    public void MoveBack()
    {
        Debug.Log ("충돌해서 뒤로 이동");
        
        transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, -speed * 20 * Time.deltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
