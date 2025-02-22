using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSpread : MonoBehaviour
{
    public RectTransform[] crosshairParts;
    public Gun gun;
    private int multiplier = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Changes the position of the four parts of my crosshair depending on the spread of that specific gun
        float currentSpread = gun.currentSpread;
        crosshairParts[0].anchoredPosition = new Vector2(-currentSpread * multiplier, currentSpread * multiplier);
        crosshairParts[1].anchoredPosition = new Vector2(currentSpread * multiplier, currentSpread * multiplier);
        crosshairParts[2].anchoredPosition = new Vector2(-currentSpread * multiplier, -currentSpread * multiplier);
        crosshairParts[3].anchoredPosition = new Vector2(currentSpread * multiplier, -currentSpread * multiplier);
    }
}
