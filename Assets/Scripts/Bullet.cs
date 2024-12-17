using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyObject>())
        {
            // Destroy(collision.gameObject);
            collision.GetComponent<EnemyObject>().health -= 10;
            Destroy(gameObject);
        } else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
