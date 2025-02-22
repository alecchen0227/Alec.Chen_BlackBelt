using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highscore : MonoBehaviour
{
    public TMP_Text[] ranks;
    // Start is called before the first frame update
    void Start() // When the highscore scene is opened, show the value of the 5 highest scores in endless mode
    {
        ranks[0].text = "#1   " + PlayerPrefs.GetInt("First");
        ranks[1].text = "#2   " + PlayerPrefs.GetInt("Second");
        ranks[2].text = "#3   " + PlayerPrefs.GetInt("Third");
        ranks[3].text = "#4   " + PlayerPrefs.GetInt("Fourth");
        ranks[4].text = "#5   " + PlayerPrefs.GetInt("Fifth");
    }
}
