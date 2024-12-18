using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlowstickColorSelect : MonoBehaviour
{
    private Sprite CurrentSprite;
    [SerializeField] Sprite[] glowstickSprites;
    void Start()
    {
        int CurrentSpriteNumber = Random.Range(0, 3);
        CurrentSprite = glowstickSprites[CurrentSpriteNumber];
        gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        if(CurrentSpriteNumber == 0)
            gameObject.GetComponentInChildren<Light2D>().color = Color.green;
        else if(CurrentSpriteNumber == 1)
            gameObject.GetComponentInChildren<Light2D>().color = Color.blue;
        else if(CurrentSpriteNumber == 2)
            gameObject.GetComponentInChildren<Light2D>().color = Color.red;
    }
}
