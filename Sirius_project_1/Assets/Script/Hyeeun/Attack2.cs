using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    public bool isDelay;
    public float dealyTime = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isDelay)
            {
                isDelay = true;
                Debug.Log("I key press - Attack !");
                StartCoroutine(CountSkillDelay());
            }
            else
            {
                Debug.Log("delay now.. cool time..");
            }
        }
    }

    IEnumerator CountSkillDelay()
    {
        yield return new WaitForSeconds(dealyTime);
        isDelay = false;
    }
}
