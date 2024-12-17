using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    private Light2D light;
    public int battery = 10000;
    void Start(){
        light = GetComponent<Light2D>();
    }
    void Update()
    {
        if(InputManager.Flashlight){
            if(battery > 0){
                ToggleFlashlight();
            }
        }

        if(light.intensity == 1){
            Invoke("DrainBattery", 1);
        }
    }

    void ToggleFlashlight(){
        if(light.intensity == 0)
            { light.intensity = 1;}
        else
            { light.intensity = 0;}
    }

    void DrainBattery(){
        if(light.intensity == 1){
            battery -= 1;
            if(battery == 0){
                light.intensity = 0;
            }
        }
    }
}
