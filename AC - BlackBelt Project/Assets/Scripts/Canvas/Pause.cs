using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public static bool pauseCondition {get; private set;} = true;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // When the player clicks the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCondition) // Freeze everything in the back and then set pauseCondition to false
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseCondition = false;
                pause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                unPause(); // If escape key is pressed again or the buttons on the pause menu, unpause the game
            }
        }
    }

    public void unPause() // This method unfreezes everything
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCondition = true;
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void returnToMainMenu() // This method is called when the player clicks return to main menu in the pause menu
    {
        SceneManager.LoadScene(0);
        pauseCondition = true;
        Time.timeScale = 1;
    }
}
