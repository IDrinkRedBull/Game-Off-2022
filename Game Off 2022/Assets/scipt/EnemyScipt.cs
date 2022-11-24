using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScipt : MonoBehaviour
{
    public int hp = 2;

    public float highlight;
    // Update is called once per frame
    void Update()
    {
        highlight -= 0.01f;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }


        if (highlight <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            GetHit(1);
        }
    }
    public void GetHit(int dmg)
    {
        hp -= dmg;
    }

}
