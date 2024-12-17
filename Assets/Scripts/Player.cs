using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private GameObject glowstickPrefab;
    private float throwSpeed = 3f;
    public bool alive;
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1f;
    public int health = 100;

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

    private void Update(){
        // Throw
            if(InputManager.Throw){
                ThrowGlowstick();
                health += 10;
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

    private void ThrowGlowstick(){
        Vector3 glowstickPos = transform.position;
        glowstickPos.z = -0.9f;
        GameObject glowstick = Instantiate(glowstickPrefab, glowstickPos, transform.rotation * Quaternion.Euler(0, 0, 90));
    }
}
