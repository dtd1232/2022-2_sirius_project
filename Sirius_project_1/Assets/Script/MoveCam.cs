using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void LateUpdate()
    {
        if(target.position.x>-6&&target.position.x<26.5)
            transform.position = new Vector3(target.position.x,-2.5f,-10f);

    }
}
