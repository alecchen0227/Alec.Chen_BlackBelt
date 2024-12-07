using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CrosshairColour : MonoBehaviour
{
    public Image[] crosshair;
    public float redNumber;
    public float greenNumber;
    public float blueNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        redNumber = PlayerPrefs.GetFloat("red");
        greenNumber = PlayerPrefs.GetFloat("green");
        blueNumber = PlayerPrefs.GetFloat("blue");
        crosshair[0].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[1].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[2].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[3].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[4].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[5].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[6].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
        crosshair[7].GetComponent<Image>().color = new Color(redNumber, greenNumber, blueNumber);
    }
}
