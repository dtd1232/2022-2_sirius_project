using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    bool facingRight;
    float time;
    public float minDistance = 2f;
    [SerializeField] public float health, maxHealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //calculate x distance between enemy and the character
        
        distance = Vector3.Distance(transform.position, player.transform.position);


        if (distance < 8 && distance > minDistance) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
        }
        //if the player is to the left of the enemy look left
        if (player.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        //if the player is to the right of the enemy look right
        else if (player.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    void Attack()
    {
        Debug.Log("Enemy is attacking");
    }
}
