using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool isDelay;
    public float dealyTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
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
        }

        // if (isDelay)
        // {
        //     timer += Time.deltaTime;

        //     if(timer >= dealyTime)
        //     {
        //         timer = 0f;
        //         isDelay = false;
        //     }
        // }
    }

    IEnumerator CountSkillDelay()
    {
        yield return new WaitForSeconds(dealyTime);
        isDelay = false;
    }
}
