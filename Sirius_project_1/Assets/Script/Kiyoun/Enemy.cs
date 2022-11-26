using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed=4;
    private float distance;
    GameObject player;
    Animator animator;
    Rigidbody2D rb;
    float minDistance = 1f;
    float maxhealth=10;
    bool facingRight;

    private float enemyMinDistance = 0.5f;
    float enemyDistance;
    GameObject otherEnemy;

    public void Start(){
        animator = GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        otherEnemy=GameObject.FindWithTag("Enemy");
    }
    //chase player if character is in range
    public void FixedUpdate(){
        distance = Vector3.Distance(transform.position, player.transform.position);
        enemyDistance=Vector3.Distance(transform.position, otherEnemy.transform.position);

        if(enemyDistance<enemyMinDistance){
            transform.position = Vector3.MoveTowards(transform.position, otherEnemy.transform.position, -speed * 2 * Time.deltaTime);
        }
        if (player.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (player.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        if (distance < 8 && distance > minDistance)
            ChasePlayer();
        else 
            animator.SetBool("isMoving", false);

        if(distance<=minDistance)
            enemyAttack();
        else
            animator.SetBool("isAttacking", false);
    }

    public void ChasePlayer()
    {
        //set animation to "isMoving"
        animator.SetBool("isMoving", true);
        //move towards the player
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    public void enemyAttack(){
        //print("test");
        animator.SetBool("isAttacking", true);
    }

    public void TakeDamage(float damage)
    {
        if(gameObject!=null){
            maxhealth-=damage;
            print(maxhealth);
            if(maxhealth<=0){
                //disable myself
                // Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}