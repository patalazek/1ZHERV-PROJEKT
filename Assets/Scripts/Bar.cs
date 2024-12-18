using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{

    private Slider slider;
    
    void Start(){
        slider = GetComponentInChildren<Slider>();
    }
    public void SetValue(int health){
        slider.value = health;
    }

    public void SetMaxValue(int health){
        slider.maxValue = health;
        slider.value = health;
    }
}
