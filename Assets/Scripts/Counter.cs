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
    public void SetValue(int value, int MaxValue, string description){
        text.text = description + value + "/" + MaxValue;
    }
}
