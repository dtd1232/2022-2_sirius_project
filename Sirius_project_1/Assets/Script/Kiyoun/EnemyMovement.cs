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

        if (distance < 8 && distance > minDistance) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
        }
        if (player.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
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
    public float Health {
        set
        {
            health = 3;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        get
        {
            return health;
        }
    }
    public float health = 3;
}
