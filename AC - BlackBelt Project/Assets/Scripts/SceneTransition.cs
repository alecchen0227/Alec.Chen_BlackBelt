using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public enum LevelNumbers {
            Level1 = 8,
            Level2 = 9
    }

    public LevelNumbers level;

    public void loadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousLevel") + 1);
    }
}
