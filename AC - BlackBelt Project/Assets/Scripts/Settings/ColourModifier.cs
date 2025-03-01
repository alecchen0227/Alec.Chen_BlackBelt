using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourModifier : MonoBehaviour
{
    public TMP_Text crosshair;
    public TMP_Text redValue;
    public TMP_Text greenValue;
    public TMP_Text blueValue;
    public Slider red;
    public Slider green;
    public Slider blue;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        red.value = PlayerPrefs.GetFloat("red", 1);
        green.value = PlayerPrefs.GetFloat("green", 1);
        blue.value = PlayerPrefs.GetFloat("blue", 1);
        crosshair.GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b);
    }

    // Update is called once per frame
    void Update()
    {   // Changes the value of my RGB based on the value of the slider
        crosshair.GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b);
        redValue.text = "" + red.value;
        greenValue.text = "" + green.value;
        blueValue.text = "" + blue.value;
    }
    // This method is connected to my sliders which changes the colour whenever it is changed.
    public void ChangeColour(int colourChoice)
    {
        if(colourChoice == 0)
        {
            PlayerPrefs.SetFloat("red", red.value);
            color.r = red.value;
        }
        else if(colourChoice == 1)
        {
            PlayerPrefs.SetFloat("green", green.value);
            color.g = green.value;
        }
        else
        {
            PlayerPrefs.SetFloat("blue", blue.value);
            color.b = blue.value;
        }
    }
}
