using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 1;
    public void Update()
    {
        if (Health <= 0) Destroy(gameObject);
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
