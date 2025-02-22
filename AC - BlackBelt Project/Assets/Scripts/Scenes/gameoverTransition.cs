using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverTransition : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Invoke("returnToMainMenu", 2);
    }

    void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
