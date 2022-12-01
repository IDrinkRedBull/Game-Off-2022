using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaBoss : MonoBehaviour
{
    Animator boss;
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

    bool bossDead;
    public GameObject pizaDead;

    private int idle = Animator.StringToHash("PizzaIdle");
    private int shoot = Animator.StringToHash("PizzaShoot");
    private int dead = Animator.StringToHash("PizzaDead");
    private void Start()
    {
        boss = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        salamiTimer += Time.deltaTime;
        BossFlip();

        if (!bossDead)
        {
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

        if (!bossDead)
        {
            var state = GetState();

            if (state == currentState) return;
            boss.CrossFade(state, 0, 0);
            currentState = state;
        }
        else Invoke("dying", 2);

    }

    private int currentState;
    void Pineaple()
    {
        Instantiate(PineapleSpawn, pizaSpawn.position, pizaSpawn.rotation);
    }
    private int GetState()
    {
        if (gameObject.GetComponent<EnemyScipt>().hp <= 0)
        {
            bossDead = true;
            return dead;
        }

        if (firstPhases) return shoot;
        else return idle;
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
    
    void dying()
    {
        if (pizaDead == null) return;

        pizaDead.SetActive(true);
        gameObject.SetActive(false);

    }

}
