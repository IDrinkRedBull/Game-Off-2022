using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScipt : MonoBehaviour
{
    int hp = 100;
    

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void GetHit(int dmg)
    {
        hp -= dmg;
    }
    
}
