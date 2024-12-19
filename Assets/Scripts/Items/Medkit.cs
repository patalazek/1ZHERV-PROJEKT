using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private int healAmount = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            PlayerObject Player = collision.GetComponent<PlayerObject>();
            if(Player.health + healAmount > Player.maxHealth){
                Player.health = Player.maxHealth;
            } else {
                Player.health += healAmount;
            }
            Destroy(gameObject);
        }
    }
}
