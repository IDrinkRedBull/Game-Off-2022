using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTest : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange;
    public LayerMask EnemyHitBox;
    public int dmg = 1;
    public int NumOfClick = 0;
    float LCT = 0;
    public float delay = 0.9f;
    int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LCT < delay)
        {
            NumOfClick = 0;
            num = 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            LCT = Time.time;
            NumOfClick++;
            
            if (NumOfClick == 1)
            {
                Collider2D[] Hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
                foreach (Collider2D a in Hit)
                {
                    Debug.Log("1 hitet " + a.name);
                    a.GetComponent<EnemyScipt>().GetHit(dmg);
                }
            }
            Debug.Log(NumOfClick);
            NumOfClick = Mathf.Clamp(NumOfClick, 0,3);
            return1();
            return2();
        }

        
    }



    public void return1()
    {
        if(NumOfClick == 2)
        {
            if(num == 1)
            {
                //atk2
                Collider2D[] Hit2 = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
                foreach (Collider2D a in Hit2)
                {
                    Debug.Log("2 hitet " + a.name);
                    a.GetComponent<EnemyScipt>().GetHit(dmg);
                }
                num = 2;
            
            }
            else
            {
                NumOfClick = 0;
            }
        }
        
    }
    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    public void return2()
    {
        if (NumOfClick == 2)
        {
            if (num == 2)
            {
                //atk3
                Collider2D[] Hit3 = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyHitBox);
                foreach (Collider2D a in Hit3)
                {
                    Debug.Log("3 hitet " + a.name);
                    a.GetComponent<EnemyScipt>().GetHit(dmg);
                }
                num = 3;

            }
            else
            {
                NumOfClick = 0;
            }
        }

    }

    
    
    public void return3()
    {
        NumOfClick = 0;
    }

}
