using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class glowstick : MonoBehaviour
{
    private int litTime = 10;
    void Start()
    {
        Invoke("LightsOut", litTime);
    }

    void LightsOut(){
        Destroy(gameObject);
    }
}
