using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class Counter : MonoBehaviour
{
    [SerializeField] PlayerObject Player;
    private TMP_Text text;
    
    void Start(){
        text = GetComponentInChildren<TMP_Text>();
    }
    public void SetValue(int value, int MaxValue, string description, int total){
        if(total == -1000){
            text.text = description + value + "/" + MaxValue;
        } else{
            text.text = description + value + "/" + MaxValue + " (" + total + ")";
        }
    }
}
