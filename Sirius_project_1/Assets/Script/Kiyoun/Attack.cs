using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D attackCollider;
    public float damage=1;
    Vector2 attackPosition;
    private void Start()
    {
        attackPosition = transform.localPosition;
    }
    public void AttackRight()
    {
        print("right attack");
        attackCollider.enabled = true;
        transform.localPosition = attackPosition;
    }
    public void AttackLeft()
    {
        print("left attack");
        attackCollider.enabled = true;
        transform.localPosition = new Vector3(attackPosition.x*-1, attackPosition.y);
    }
    public void StopAttack()
    {
        attackCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}