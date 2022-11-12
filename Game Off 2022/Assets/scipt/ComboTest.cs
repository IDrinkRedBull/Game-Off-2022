using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTest : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask EnemyHitBox;
    public Transform Hitbox3;

    public float AttackRange;
    public int NumOfClick = 0;
    public int dmg = 1;

    float cooldown = 0.3f;
    float resetTimer = 1;
    

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        resetTimer -= Time.deltaTime;

        if (resetTimer < 0) NumOfClick = 0;

        if (Input.GetMouseButtonDown(0) && cooldown < 0)
        {
            Debug.Log("slashing");
            cooldown = 0.3f;
            resetTimer = 1;

            NumOfClick++;

            if (NumOfClick == 1) atk1();
            else if (NumOfClick == 2) atk2();
            else if (NumOfClick == 3) atk3();
            
            
        }
    }

    public void atk1()
    {
        //atk1

        Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
        foreach (Collider2D a in Hit)
        {
            Debug.Log("1 hitet " + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
        Debug.Log("First attack");
    }
    public void atk2()
    {
        //atk2

        Collider2D[] Hit2 = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
        foreach (Collider2D a in Hit2)
        {
            Debug.Log("2 hitet " + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
        Debug.Log("Second attack");
    }

    public void atk3()
    {
        //atk3

        Collider2D[] Hit3 = Physics2D.OverlapBoxAll(Hitbox3.position, Hitbox3.localScale, 0, EnemyHitBox);
        foreach (Collider2D a in Hit3)
        {
            Debug.Log("3 hitet " + a.name);
            a.GetComponent<EnemyScipt>().GetHit(dmg);
        }
        NumOfClick = 0;
        Debug.Log("Third attack");
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
