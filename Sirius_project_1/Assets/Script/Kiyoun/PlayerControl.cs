using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// Takes and handles input and movement for a player character
public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public Attack simpleAttack;
    bool canMove = true;
    Vector2 moveInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (canMove) {
            if (moveInput != Vector2.zero)
            {
                bool success = TryMove(moveInput);
                if (!success)
                {
                    success = TryMove(new Vector2(moveInput.x, 0));
                    if (!success)
                        success = TryMove(new Vector2(0, moveInput.y));
                }
                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction, 
                movementFilter, 
                castCollision, 
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0) { 
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime); 
                return true; 
            }
            else return false;
        }
        else { return false; }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnFire()
    {

        animator.SetTrigger("Attack");
    }
    public void charAttack()
    {
        //LockMovement();

        if(spriteRenderer.flipX==true)
            simpleAttack.AttackLeft();
        else
            simpleAttack.AttackRight();
    }
    public void EndAttack()
    {
        //UnlockMovement();
        simpleAttack.StopAttack();
    }

    // public void LockMovement()
    // {
    //     canMove = false;
    // }
    // public void UnlockMovement()
    // {
    //     canMove = true;
    // }
}