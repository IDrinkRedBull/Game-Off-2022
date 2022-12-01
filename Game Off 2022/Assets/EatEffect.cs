using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.09f);
        transform.Rotate(new Vector3(0, 0, Random.Range(-360, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
