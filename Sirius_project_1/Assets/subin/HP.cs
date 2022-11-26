using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HP : MonoBehaviour
{
    Slider HPbar;
    float fSliderBarTime;

    public GameObject player;

    void Start()
    {
       HPbar = GetComponent<Slider>();
       HPbar.value = 100;
    }
 
 
    void Update()
    {
        if (HPbar.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);

        if (HPbar.value <= 0)
            Destroy(player);

        //per second HP decrease
        fSliderBarTime += Time.deltaTime;
        if (fSliderBarTime >= 1)
        {
            // HPbar.value -= 1;
            fSliderBarTime = 0;
        }
    }
}
