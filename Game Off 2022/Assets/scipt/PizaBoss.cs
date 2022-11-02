using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaBoss : MonoBehaviour
{
    public Transform pizaSpawn;
    public GameObject piza;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("create",1f,0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void create()
    {
        Instantiate(piza, pizaSpawn.position, pizaSpawn.rotation);
    }

}
