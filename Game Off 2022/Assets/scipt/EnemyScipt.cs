using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScipt : MonoBehaviour
{
    public Slider slider;
    public bool isBoss;
    public int hp = 2;

    public float highlight;
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) Destroy(gameObject);

        if (isBoss)
        {
            slider.maxValue = 30;
            slider.value = hp;
            slider.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet") GetHit(1);
        if ((collision.gameObject.tag == "Cheese")) GetHit(3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet") GetHit(1);
        if ((collision.gameObject.tag == "Cheese")) GetHit(3);
    }
    public void GetHit(int dmg)
    {
        hp -= dmg;
    }

}
