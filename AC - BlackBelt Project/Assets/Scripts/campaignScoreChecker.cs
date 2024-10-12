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
    {
        levelBox[1].SetActive(false);
        levelBox[2].SetActive(false);
        checker[0].SetActive(false);
        checker[1].SetActive(false);
        checker[2].SetActive(false);
        if(PlayerPrefs.GetInt("Level1Finish") == 1)
        {
            levelBox[1].SetActive(true);
            checker[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level2Finish") == 1)
        {
            levelBox[2].SetActive(true);
            checker[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level3Finish") == 1)
        {
            checker[2].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
