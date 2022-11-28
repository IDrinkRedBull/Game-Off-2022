using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEat : MonoBehaviour
{
    public float highlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highlight -= 0.01f;

        if (highlight <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
