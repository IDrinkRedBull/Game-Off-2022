 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    
    public Transform AttackPoint;
    public float AttackRange;
    public LayerMask EnemyHitBox;
    public int dmg = 1;
    public float AttackRate = 3f;
    float NextAttackTime = 0f;
    [SerializeField] int NumOfAttack = 1;
    bool combo = false;

    
    // Update is called once per frame
    void Update()
    {
        if (Time.time - NextAttackTime > AttackRate)
        {
            NumOfAttack = 1;
            combo = !combo;
        }
        if ( Time.time >= NextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack1();
                NextAttackTime = Time.time + AttackRate;//swing spam controller
                NumOfAttack++;
                combo = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && NumOfAttack == 2 && combo)
        {
            Attack2();
            NumOfAttack++;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && NumOfAttack == 3 && combo)
        {
            Attack3();
            NumOfAttack++;
        }
        NumOfAttack = Mathf.Clamp(NumOfAttack, 0, 3);
        //Debug.Log("atktime " + NextAttackTime);
        //Debug.Log("time" + Time.time);
    }


    void Attack1()
    {
        Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);

        foreach(Collider2D a in Hit)
        {
            Debug.Log("1 hitet " + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
        NumOfAttack++;
    }

    void Attack2()
    {
        Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
        foreach (Collider2D a in Hit)
        {
            Debug.Log("2 hitet " + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
        NumOfAttack++;
    }


    void Attack3()
    {
        //dash abit forward
        
        Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
        foreach (Collider2D a in Hit)
        {
            Debug.Log("3 hitet " + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
        NumOfAttack++;
    }


    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    

}
