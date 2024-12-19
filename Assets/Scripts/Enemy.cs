using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyObject : MonoBehaviour
{
    public Transform target;
    public float Speed = 1.5f;
    public int health = 100;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        // Move
        Move();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);

            // Rotate towards the movement direction
            Vector2 direction = (Vector2)navMeshAgent.steeringTarget - (Vector2)transform.position;
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            // Destroy(collision.gameObject);
            collision.GetComponent<PlayerObject>().health -= 15;
        }
    }
}