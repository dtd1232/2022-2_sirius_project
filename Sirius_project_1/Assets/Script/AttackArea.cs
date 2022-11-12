using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public enum AttackDirection
    { left, right }
    public AttackDirection attackDirection;
    Collider2D attack;
    Vector2 rightAttackOffset;
    private void Start()
    {
        attack = GetComponent<Collider2D>();
    }
    public void Attack()
    {
        switch (attackDirection)
        {
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;
        }
    }
    private void StopAttack()
    {
        attack.enabled = false;
    }
    private void AttackRight()
    {
        attack.enabled = true;
        transform.position = rightAttackOffset;
    }
    private void AttackLeft()
    {
        attack.enabled = true;
        transform.position = new Vector3(-rightAttackOffset.x, rightAttackOffset.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                enemy.health--;
            }
        }
    }
}