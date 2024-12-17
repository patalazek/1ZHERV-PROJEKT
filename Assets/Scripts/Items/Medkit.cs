using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerObject>().health += 50;
        }
    }
}
