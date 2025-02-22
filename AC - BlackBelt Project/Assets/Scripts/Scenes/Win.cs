using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Button", 0);
        if(PlayerPrefs.GetInt("Button") == 1) // If it is level 3, the button number is 1 so no next level
        {
            nextLevel.SetActive(false);
        }
        else // Otherwise, make the next Level button appear
        {
            nextLevel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
