using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasterVolume : MonoBehaviour
{
    private static float Volume;
    public Slider volumeSlider;
    public TMP_Text volumeValue;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 100); // set the volume slider's to the right position
        Volume = volumeSlider.value; // update the number volume based on the slider
        AudioListener.volume = Volume; // Change the overall audio based on the volume variable
    }

    // Update is called once per frame
    void Update()
    {
        volumeValue.text = ""+Mathf.Round(volumeSlider.value*100); // Sets the text of the volume 
    }

    public void adjustVolume(float volume) // THis method is called whenever the slider is touched, it updates the slider's value and the overall volume
    {
        PlayerPrefs.SetFloat("volume", volume);
        AudioListener.volume = volume;

    }
}
