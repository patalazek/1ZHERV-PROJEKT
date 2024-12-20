using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private GameObject glowstickPrefab;
    [SerializeField] public Bar healthBar;

    [SerializeField] public Counter glowstickCounter;
    private float throwSpeed = 3f;
    public bool alive;
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1f;
    public int health = 100;
    public int maxHealth = 100;
    public int glowstickCount = 10;
    public int glowstickMaxCount = 10;
    public TextMeshProUGUI deadMessage;
    public TextMeshProUGUI infoMessage;

    [SerializeField] InputManager InputManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        alive = true;
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            // Look
            Look();

            // Move
            Move();

            // Check if Alive
            if (health <= 0)
            {
                alive = false;
            }

            // Update Health Bar
            healthBar.SetValue(health);

            // Update Glowsticks counter
            glowstickCounter.SetValue(glowstickCount, glowstickMaxCount, "Glowsticks:", -1000);

        }
    }

    private void Update()
    {
        // Throw
        if (InputManager.Throw)
        {
            ThrowGlowstick();
        }

        if (!alive)
        {
            if (deadMessage != null)
            {
                deadMessage.gameObject.SetActive(true);
                deadMessage.text = "You died...";

                infoMessage.gameObject.SetActive(true);
                infoMessage.text = "Press restart and continue to try again!";

                InputManager.GameOver = true;
            }
        }
    }
    private void Look()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.right = direction;
    }

    private void Move()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * moveSpeed;
    }

    private void ThrowGlowstick()
    {
        if (glowstickCount > 0)
        {
            Vector3 glowstickPos = transform.position;
            glowstickPos.z = -0.9f;
            GameObject glowstick = Instantiate(glowstickPrefab, glowstickPos, transform.rotation * Quaternion.Euler(0, 0, 90));
            glowstickCount--;
        }
    }
}
