using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class campaignScoreChecker : MonoBehaviour
{
    public GameObject[] levelBox;
    public GameObject[] checker;

    // Start is called before the first frame update
    void Start() 
    {   // Turn all gameObject off first
        levelBox[1].SetActive(false);
        levelBox[2].SetActive(false);
        checker[0].SetActive(false);
        checker[1].SetActive(false);
        checker[2].SetActive(false);
        if(PlayerPrefs.GetInt("Level1Finish") == 1) // Checks to see if this playerPref is one and then allow level 1 to be checked off and level 2 to be opened
        {
            levelBox[1].SetActive(true);
            checker[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level2Finish") == 1) // Checks to see if this playerPref is one and then allow level 2 to be checked off and level 3 to be opened
        {
            levelBox[2].SetActive(true);
            checker[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level3Finish") == 1) // Checks to see if this playerPref is one and then allow level 3 to be checked off
        {
            checker[2].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
