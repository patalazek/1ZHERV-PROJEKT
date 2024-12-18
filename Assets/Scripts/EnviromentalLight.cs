using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnvironmentalLight : MonoBehaviour
{
    Light2D light2D;
    void Start(){
        light2D = GetComponentInChildren<Light2D>();
    }

    void FixedUpdate()
    {
        if(Random.Range(0, 15) == 0){
        Invoke("ToggleLight", Random.Range(8, 15));
        }
    }

    void ToggleLight(){
        if(light2D.intensity == 0.2f)
            { light2D.intensity = 1f;}
        else
            { light2D.intensity = 0.2f;}
    }
}
