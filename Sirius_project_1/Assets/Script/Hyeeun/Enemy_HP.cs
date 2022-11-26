using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Enemy_HP : MonoBehaviour
{
    Slider HPbar;
    // float fSliderBarTime;

    public Transform player;

    public float maxHp = 10;
    public float currenthp = 10;

    void Start()
    {
       HPbar = GetComponent<Slider>();
       transform.position = player.position;
    //    HPbar.value = 100;
        // transform.position = new Vector3(player.position.x, player.position.y+10, player.position.z);


    }
 
 
    void Update()
    {
        transform.position = player.position;

        if (HPbar.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);

        // if (HPbar.value <= 0)
        //     Destroy(player);

        // //per second HP decrease
        // fSliderBarTime += Time.deltaTime;
        // if (fSliderBarTime >= 1)
        // {
        //     // HPbar.value -= 1;
        //     fSliderBarTime = 0;
        // }
        transform.position = new Vector3(player.position.x, player.position.y+10, player.position.z);

        HPbar.value = currenthp / maxHp;
    }
}
