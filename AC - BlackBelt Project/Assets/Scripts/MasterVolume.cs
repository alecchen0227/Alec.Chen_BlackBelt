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
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 100);
        Volume = volumeSlider.value;
        AudioListener.volume = Volume;
    }

    // Update is called once per frame
    void Update()
    {
        volumeValue.text = ""+volumeSlider.value;
    }

    public void adjustVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}