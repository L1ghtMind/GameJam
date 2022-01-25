using System;
using UnityEngine;

public class PlayerStaffAttack : MonoBehaviour
{
    [SerializeField] private float AttackRate;
    public float StartAttackTimer;

    [SerializeField] private Transform StaffPoint;
    [SerializeField] private LayerMask HittedObject;
    [SerializeField] private int Damage;
    public float AttackRange;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider2D[] ObjectToHit = Physics2D.OverlapCircleAll(StaffPoint.position, AttackRange,HittedObject);
            for (int i = 0; i < ObjectToHit.Length; i++)
            {
                ObjectToHit[i].GetComponent<EnemyTest>().TakeDamage(Damage);
            }
        }
        if (StartAttackTimer <= 0)
        {
            AttackRate = StartAttackTimer;
        }
        else
        {
            AttackRate -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(StaffPoint.position, AttackRange);
    }
}
