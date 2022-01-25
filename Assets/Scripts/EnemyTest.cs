using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float Health;
    public float Speed;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("Damage taken");
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fireball")
        {
            Destroy(gameObject);
        }
    }
}
