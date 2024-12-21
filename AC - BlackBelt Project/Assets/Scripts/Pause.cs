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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCondition)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseCondition = false;
                pause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                unPause();
            }
        }
    }

    public void unPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCondition = true;
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
        pauseCondition = true;
        Time.timeScale = 1;
    }
}
