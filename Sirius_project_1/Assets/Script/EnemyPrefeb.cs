using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefeb : MonoBehaviour
{
    public GameObject prefeb;
    public transform parent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject myInstance = new Instantiate(prefeb);
    }

    // Update is called once per frame
    void Update()
    {
        //x = 14, topY = 1.25, bottomY = -5 


    }
}
