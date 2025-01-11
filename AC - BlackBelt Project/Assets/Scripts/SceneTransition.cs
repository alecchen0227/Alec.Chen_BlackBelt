using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject loading;
    public int returnToThisScene;
    public GameObject backButton;
    public enum LevelNumbers { // Used for moving to nextLevel
            Level1 = 8,
            Level2 = 9
    }

    public LevelNumbers level;

    public void Start()
    {
        if(loading != null) // If there is no loading gameObject, set it as false
        {
            loading.SetActive(false);
        }
    }

    public void Update()
    {
        if (backButton != null && Input.GetKeyDown(KeyCode.Escape)) // When escape key is clicked and you can go back to another scene, it transitions the player to previous scene
        {
            loadLevel(returnToThisScene);
        }
    }

    public void loadLevel(int index) // This method is called from different buttons transitioning to different scenes. If in the 
    {
        if(index == 1) // When the endless button is clicked, index will be 1 and it will show the loading gameObject
        {
            loading.SetActive(true);
        }
        SceneManager.LoadScene(index); // Load the scene
    }

    public void loadNextLevel() // This method is called in the gameManager when transitioning to the next level using a playerPref and eNums
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousLevel") + 1);
    }
}
