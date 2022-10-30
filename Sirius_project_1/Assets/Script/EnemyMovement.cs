using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    bool facingRight;
    private float minDistance = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (distance < minDistance)
        {
            //stop for 1 second
            //attack

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
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
