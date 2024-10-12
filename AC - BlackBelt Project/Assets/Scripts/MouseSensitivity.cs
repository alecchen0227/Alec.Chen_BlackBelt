using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSensitivity : MonoBehaviour
{
    public Slider slider;
    public TMP_Text sliderValue;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("currentSensitivity", 200);
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue.text = "" + slider.value;
    }

    public void adjustSpeed()
    {
        PlayerPrefs.SetFloat("currentSensitivity", slider.value);
    }
}
