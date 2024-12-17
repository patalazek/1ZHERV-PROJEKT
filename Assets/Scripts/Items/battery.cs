using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            Destroy(gameObject);
            collision.GetComponentInChildren<Flashlight>().battery += 1000;
        }
    }
}
