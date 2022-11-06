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
    float minDistance;
    float distanceTemp;

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
        distanceTemp = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);

        if (h < 0 && !facingRight)
        {
            Flip();
        }
        else if (h > 0 && facingRight)
        {
            Flip();
        }
        //character being hit if it is too close to the obejct with tag "Enemy"
        if (distanceTemp < minDistance)
        {
            //Call the attack function once every exact second
            if (Time.time > time)
            {
                time = Time.time + 1;
                Debug.Log("Character is being hit.");

            }
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

}
