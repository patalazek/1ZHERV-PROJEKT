using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public bool alive;
    public int health = 100;
    
    private Vector2 movement;

    private Rigidbody2D rb;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        alive = true;
    }

    private void FixedUpdate(){
        if(alive){
            // Look
            Look();

            // Move
            Move();
            if(health <= 0){
                alive = false;
            }
        }
    }
    private void Look(){
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.right = direction;
    }

    private void Move(){
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * moveSpeed;
    }
}
