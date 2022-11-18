using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    Transform player;

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        findEnemy();
        if (target == null)
        {
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, 10 * Time.deltaTime);
        Debug.DrawLine(player.transform.position, target.position, Color.green);
    }

    void findEnemy()
    {
        float disToClosestEnemy = Mathf.Infinity;
        EnemyScipt closestEnemy = null;

        // Find all enemy and put them in a array
        EnemyScipt[] allEnemies = GameObject.FindObjectsOfType<EnemyScipt>();

        // check all enemy and see which one is closer
        foreach (EnemyScipt currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
            if (distanceToEnemy <= disToClosestEnemy)
            {
                // Set the distance to the cloest enemy
                disToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                target = closestEnemy.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
