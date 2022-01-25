using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float FireballSpeed = 10f;
    [SerializeField] private int FireballDamage = 10;

    private Rigidbody2D Rigidbody;
    private EnemyTest Enemy;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = transform.right * FireballSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Enemy.TakeDamage(FireballDamage);
            Destroy(gameObject);
        }
    }
}
