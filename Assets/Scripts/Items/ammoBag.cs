using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBag : MonoBehaviour
{
    [SerializeField] Gun gun;
    private int ammoAmount = 28;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            gun.currentTotalAmmo += ammoAmount;
            Destroy(gameObject);
        }
    }
}
