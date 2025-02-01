using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverTransition : MonoBehaviour
{
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // Attached to the gameover background and when any key is clicked, change the scene back to main menu
        if (Input.anyKey && timer >= 1)
            SceneManager.LoadScene(0);
    }
}
