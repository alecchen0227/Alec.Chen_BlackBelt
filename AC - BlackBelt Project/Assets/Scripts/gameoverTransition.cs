using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Attached to the gameover background and when any key is clicked, change the scene back to main menu
        if (Input.anyKey)
            SceneManager.LoadScene(0);
    }
}
