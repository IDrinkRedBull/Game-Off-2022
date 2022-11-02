 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange;
    public LayerMask EnemyHitBox;
    public int dmg = 1;
    public float AttackRate;
    float NextAttackTime = 0f;

    
    // Update is called once per frame
    void Update()
    {
        if ( Time.time >= NextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                NextAttackTime = Time.time + 0.5f;//swing spam controller
            }
        }
        
    }


    void Attack()
    {
        Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);

        foreach(Collider2D a in Hit)
        {
            Debug.Log("hitet" + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
    }


    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

}
