
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour
{
    public int runSpeed = 1;
    float horizontal;
    float vertical;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0.0f);

        transform.position = transform.position + movement * Time.deltaTime;

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
