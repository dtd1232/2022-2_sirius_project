using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed;
    float h;
    float v;
    Rigidbody2D rigid;
    bool facingRight;
    [SerializeField] private GameObject enemy;
    float minDistance;
    
    public Attack attack;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        minDistance = enemy.GetComponent<EnemyMovement>().minDistance;
    }
    void FixedUpdate()
    {
        Vector3 moveVelocity = new Vector3(h, v, 0);
        rigid.velocity = moveVelocity * Speed;
        //if user mouse click, attack
        
        if (Input.GetMouseButtonDown(0))
            attacks();
        if (Input.GetMouseButtonUp(0))
            EndAttacks();

        if (h < 0 && !facingRight)
        {
            Flip();
        }
        else if (h > 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public void attacks()
    {
        if (facingRight)
            attack.AttackRight();
        else
        {
            attack.AttackLeft();
        }
    }
    public void EndAttacks()
    {
        attack.StopAttack();
    }
}

