using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public GameObject bullet;

    float delay = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            delay = 2;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
