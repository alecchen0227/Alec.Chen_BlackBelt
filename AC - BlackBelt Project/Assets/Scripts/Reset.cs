using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevels() // This method is called when the resetbutton is clicked in the credits scene. It sets all the playerPrefs to 0 basically resetting the levels and then showing a message
    {
        message.SetActive(true);
        PlayerPrefs.SetInt("Level1Finish", 0);
        PlayerPrefs.SetInt("Level2Finish", 0);
        PlayerPrefs.SetInt("Level3Finish", 0);
        PlayerPrefs.SetInt("First", 0);
        PlayerPrefs.SetInt("Second", 0);
        PlayerPrefs.SetInt("Third", 0);
        PlayerPrefs.SetInt("Fourth", 0);
        PlayerPrefs.SetInt("Fifth", 0);
        Invoke("HideMessage", 3);
    }

    public void HideMessage()
    {
        message.SetActive(false);
    }
}
