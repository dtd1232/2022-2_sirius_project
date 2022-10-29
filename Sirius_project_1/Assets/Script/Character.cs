
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour
{
    public int runSpeed = 1;
    float horizontal;
    float vertical;
    bool facingRight;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal*runSpeed, vertical*runSpeed, 0.0f);
        rb.velocity = movement;
        if (horizontal < 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal > 0 && facingRight)
        {
            Flip();
        }

    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
