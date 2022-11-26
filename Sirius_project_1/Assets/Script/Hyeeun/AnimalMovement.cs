// using UnityEngine;
// using System.Collections;

// public class AnimalMovement : MonoBehaviour {

//     public Transform target; // 따라갈 타겟의 트랜스 폼
  
//     private float relativeHeigth = 1.0f; // 높이 즉 y값
//     private float zDistance = -1.0f;// z값 나는 사실 필요 없었다.
//     private float xDistance = 1.0f; // x값
//     public float dampSpeed = 2;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
 
 
//     void Start(){
    
//     // 타겟의 트랜스 폼을 가져 왔으면.. 변수에 담는 것이 옳으나.. 좀 헤깔려셔 패스
    
//     }

//     void Update () {
//         Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
//         transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime*dampSpeed); //그 둘 사이의 값을 더해 보정한다. 이렇게 되면 멀어지면 따라간다.
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    bool facingRight;
    float time;
    public float minDistance = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 8 && distance > minDistance) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
        }
        if (player.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (player.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public float Health {
        set
        {
            health = 3;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        get
        {
            return health;
        }
    }
    public float health = 3;
}

