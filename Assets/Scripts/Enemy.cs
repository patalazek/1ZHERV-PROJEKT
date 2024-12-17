using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public Transform target;
    public float speed = 1.5f;
    public int health = 100;

    private void Update(){
        // Look
        Look();

        // Move
        Move();

        if(health <= 0){
            Destroy(gameObject);
        }
    }

    private void Move(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void Look(){
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        transform.right = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            // Destroy(collision.gameObject);
            collision.GetComponent<PlayerObject>().health -= 100;
        }
    }
}
