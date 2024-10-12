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
        red.value = PlayerPrefs.GetFloat("red");
        green.value = PlayerPrefs.GetFloat("green");
        blue.value = PlayerPrefs.GetFloat("blue");
        crosshair.GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b);
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b);
        redValue.text = "" + red.value;
        greenValue.text = "" + green.value;
        blueValue.text = "" + blue.value;
    }

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
