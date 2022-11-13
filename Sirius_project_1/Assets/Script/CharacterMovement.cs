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
    public Attack attack;
    float minDistance;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Vector3 moveVelocity = new Vector3(h, v, 0);
        rigid.velocity = moveVelocity * Speed;
        
        if (h < 0 && !facingRight)
        {
            Flip();
        }
        else if (h > 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetMouseButtonDown(0))
            attacks();
        if (Input.GetMouseButtonUp(0))
            EndAttacks();

    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public void attacks()
    {
        attack.AttackRight();
    }
    public void EndAttacks()
    {
        attack.StopAttack();
    }
}