using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaBoss : MonoBehaviour
{
    public Transform slamHitBox;
    public GameObject PineapleSpawn;
    public Transform pizaSpawn;
    public GameObject piza;
    public LayerMask player;
    private Vector3 size;
    public Transform HUMAN;
    public bool isfliped = false;
    // Start is called before the first frame update
    void Start()
    {

        size = new Vector3(4f, 0.7f, 1f);

        InvokeRepeating("salami",1f,1f);
        
        //InvokeRepeating("Pineaple", 1f, 2.1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for(int i =1; i<10; i++)
            {
                Invoke("salami", 1f);
            }
        }
        BossFlip();
    }

    void Pineaple()
    {
        Instantiate(PineapleSpawn, pizaSpawn.position, pizaSpawn.rotation);
    }

    void salami()
    {
        float x = Random.Range(-2.5f, -12f);
        Vector3 pos = new Vector3(x, 5.4f, 0f);
        Instantiate(piza,pos, pizaSpawn.rotation);
    }

    public void slam()
    {
        //Debug.Log("1");
        Collider2D[] Hited = Physics2D.OverlapBoxAll(slamHitBox.position, size, 0, player);
        foreach (Collider2D a in Hited)
        {
            Debug.Log("hit ");
        }
    }




    void OnDrawGizmosSelected()
    {
        if (slamHitBox == null)
            return;

        Gizmos.DrawWireCube(slamHitBox.position,size);
    }


    public void BossFlip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > HUMAN.position.x && isfliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isfliped = false;
        }
        else if (transform.position.x < HUMAN.position.x && !isfliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isfliped = true;
        }

    }
    

}
