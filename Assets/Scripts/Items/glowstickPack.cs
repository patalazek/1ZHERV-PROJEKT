using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowstickPack : MonoBehaviour
{
    private int packCount = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            PlayerObject Player = collision.GetComponent<PlayerObject>();
            Player.glowstickCount += packCount;
            if(Player.glowstickCount > Player.glowstickMaxCount)
            {
                Player.glowstickCount = Player.glowstickMaxCount;
            }
            Destroy(gameObject);
        }
    }
}
