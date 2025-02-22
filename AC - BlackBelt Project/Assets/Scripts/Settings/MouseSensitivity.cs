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
        slider.value = PlayerPrefs.GetFloat("currentSensitivity", 1); // Sets the slider's value based on the playerPref of currrentSensitivity
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue.text = "" + slider.value; // Update the slider text
    }

    public void adjustSpeed() // This method is called whenever the slider is changed, it will update the sentivity based on the value of the slider (200, 3200)
    {
        PlayerPrefs.SetFloat("currentSensitivity", slider.value);
    }
}
