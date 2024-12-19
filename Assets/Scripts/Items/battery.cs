using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    [SerializeField] public int batteryAmount = 2500;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerObject>())
        {
            Destroy(gameObject);
            if(collision.GetComponentInChildren<Flashlight>().battery + batteryAmount > collision.GetComponentInChildren<Flashlight>().maxBattery){
                collision.GetComponentInChildren<Flashlight>().battery = collision.GetComponentInChildren<Flashlight>().maxBattery;
            } else {
                collision.GetComponentInChildren<Flashlight>().battery += batteryAmount;
            }
        }
    }
}
