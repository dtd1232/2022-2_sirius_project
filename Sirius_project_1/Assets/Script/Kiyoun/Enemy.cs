using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed=4;
    private float distance;
    GameObject player;
    Animator animator;
    float minDistance = 2f;
    public void Start(){
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }
    //chase player if character is in range
    public void FixedUpdate(){
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 8 && distance > minDistance) {
            ChasePlayer();
        }
        else animator.SetBool("isMoving", false);
    }
    public void ChasePlayer()
    {
        //set animation to "isMoving"
        animator.SetBool("isMoving", true);
        //move towards the player
       transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }
}
