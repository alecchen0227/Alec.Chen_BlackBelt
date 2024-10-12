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
        if(PlayerPrefs.GetInt("Button") == 1)
        {
            nextLevel.SetActive(false);
        }
        else
        {
            nextLevel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
