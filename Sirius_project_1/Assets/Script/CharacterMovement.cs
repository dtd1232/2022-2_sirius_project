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
    float time;
    [SerializeField] private GameObject enemy;
    public AttackArea attacks;
    float minDistance;

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
        
        if (h < 0 && !facingRight)
        {
            Flip();
            attacks.attackDirection = AttackArea.AttackDirection.left;
        }
        else if (h > 0 && facingRight)
        {
            Flip();
            attacks.attackDirection = AttackArea.AttackDirection.right;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}

