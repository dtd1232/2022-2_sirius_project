using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectorMovement : MonoBehaviour
{
    public int moveFlag = 1;
    public Animator animator;
    public GameObject player;
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
        //Move();
        spectorAi();
    }

    void Move(){
         Vector3 moveVelocity = Vector3.zero;

        if(this.moveFlag == 1){
            animator.SetBool("Direction", false);
            moveVelocity = new Vector3(-0.12f,0,0);
        }
        else{
            animator.SetBool("Direction", true);
            moveVelocity = new Vector3(+0.12f,0,0);
        }
        transform.position += moveVelocity*speed*Time.deltaTime;
    }
    IEnumerator ChangeDirection(){
        if(moveFlag ==1){
            moveFlag = 2;
        }
        else{
            moveFlag = 1;
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine("ChangeDirection");
    }

    //player attack
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player Attack");
            health--;
            if(health == 0){
                Destroy(gameObject);
            }
        }
    }

    void spectorAi(){
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
    
}
