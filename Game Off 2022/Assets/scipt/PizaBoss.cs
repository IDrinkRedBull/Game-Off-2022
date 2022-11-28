using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaBoss : MonoBehaviour
{
    public Transform sala1, sala2, sala3;
    public Transform slamHitBox;
    public GameObject PineapleSpawn;
    public Transform pizaSpawn;
    public GameObject piza;
    public LayerMask player;
    public Transform HUMAN;
    public bool isfliped = false;

    public bool firstPhases;
    public bool secondPhases;

    public float salamiTimer;
    public float period;
    float repeatCount = 0;


    // Update is called once per frame
    void Update()
    {
        salamiTimer += Time.deltaTime;
        BossFlip();

        if (Input.GetKeyDown(KeyCode.F))
        {
            salamiTimer = 10;
        }
        if (firstPhases && salamiTimer > 0.7f)
        {
            Invoke("salami", 1);
            salamiTimer = 0;
            repeatCount++;

            if (repeatCount >= 11)
            {
                firstPhases = false;
                secondPhases = true;
                repeatCount = 0;
            }
        }
        else if (secondPhases && salamiTimer > 2)
        {
            Invoke("Pineaple", 1);
            salamiTimer = 0;
            repeatCount++;

            if (repeatCount >= 6)
            {
                secondPhases = false;
                firstPhases = true;
                repeatCount = 0;
                salamiTimer = 0;
            }
        }

    }

    void Pineaple()
    {
        Instantiate(PineapleSpawn, pizaSpawn.position, pizaSpawn.rotation);
    }

    void salami()
    {
        float x = Random.Range(sala1.position.x, sala2.position.x);
        Vector3 pos = new Vector3(x, sala3.position.y, 0f);
        Instantiate(piza, pos, Quaternion.identity);
        Debug.Log("Is running");
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
