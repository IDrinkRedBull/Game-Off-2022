 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange;
    public LayerMask EnemyHitBox;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }


    void Attack()
    {
        Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);

        foreach(Collider2D a in Hit)
        {
            Debug.Log("hitet" + a.name);
        }
    }


    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

}
