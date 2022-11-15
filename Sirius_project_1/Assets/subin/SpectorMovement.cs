using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectorMovement : MonoBehaviour
{
    public int moveFlag = 1;
    public Animator animator;
    public GameObject enemy;
    public float speed = 3;
    private float distance;
    bool facingRight;
    float time;
    public float minDistance = 2f;
    public float health = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("ChangeDirection");
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate() {
        // Move(enemy);
        spectorAi();
        
    }

    void spectorAi(){
        enemy = GameObject.FindWithTag("Enemy");
        distance = Vector3.Distance(transform.position, enemy.transform.position);

        if (distance < 8) {
            enemy = GameObject.FindWithTag("Enemy");
            Move(enemy);
        }
        else{
            enemy = GameObject.Find("Player");
            Move(enemy);
        }

        if (enemy.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (enemy.transform.position.x > transform.position.x && !facingRight)
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

    void Move(GameObject enemy){
        animator.SetBool("isMoving", true);
        if(enemy == null){
            enemy = GameObject.Find("Player");
        }
        if(this.moveFlag == 1){
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Enemy Attack");
            health--;
            if(health == 0){
                Destroy(gameObject);
            }
        }
    }
}
