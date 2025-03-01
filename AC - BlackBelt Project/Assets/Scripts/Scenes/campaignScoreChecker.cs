using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class campaignScoreChecker : MonoBehaviour
{
    public GameObject[] levelBox;
    public GameObject[] checker;

    // Start is called before the first frame update
    void Start() 
    {   
        if(PlayerPrefs.GetInt("HighestLevel") == 0)
        {
            PlayerPrefs.SetInt("HighestLevel", 1);
        }
        // Turn all gameObject off first
        for(int i = 0; i < levelBox.Length; i++)
        {
            if(i < levelBox.Length)
            {
                levelBox[i].GetComponent<Button>().interactable = false;
                checker[i].SetActive(false);
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("HighestLevel"); i++)
        {
            if(i < levelBox.Length)
            {
                levelBox[i].GetComponent<Button>().interactable = true;
            }
            if (i > 0)
            {
                checker[i - 1].SetActive(true);
            }
        }
    }
}
