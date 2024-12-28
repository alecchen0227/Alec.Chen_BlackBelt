using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject loading;
    public int returnToThisScene;
    public GameObject backButton;
    public enum LevelNumbers {
            Level1 = 8,
            Level2 = 9
    }

    public LevelNumbers level;

    public void Start()
    {
        if(loading != null)
        {
            loading.SetActive(false);
        }
    }

    public void Update()
    {
        if (backButton != null && Input.GetKeyDown(KeyCode.Escape))
        {
            loadLevel(returnToThisScene);
        }
    }

    public void loadLevel(int index)
    {
        if(index == 1)
        {
            loading.SetActive(true);
        }
        SceneManager.LoadScene(index);
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousLevel") + 1);
    }
}
