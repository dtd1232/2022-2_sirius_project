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
    /*public bool isDelay;
    public float delayTime = 2f;*/

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isDelay)
            {
                isDelay = true;
                Debug.Log("J key press - Skill !");
                StartCoroutine(CountSkillDelay());
            }
            else
            {
                Debug.Log("delay now.. cool time..");
            }
        }*/
    }
    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            if (!success)
            {
                TryMove(new Vector2(movementInput.x, 0));
                if (!success)
                {
                    TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
        
    }
    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
            return false;
    }
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
    /*IEnumerator CountSkillDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }*/
}
