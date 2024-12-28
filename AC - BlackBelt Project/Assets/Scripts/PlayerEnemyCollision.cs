using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEnemyCollision : MonoBehaviour
{
    public GameManager gameManager;
    public float health = 1;
    public static float timer = 0;
    public Scene scene;
    public Image healthbar;
    public Image redTint;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.GetInt("First", 0);
        PlayerPrefs.GetInt("Second", 0);
        PlayerPrefs.GetInt("Third", 0);
        PlayerPrefs.GetInt("Fourth", 0);
        PlayerPrefs.GetInt("Fifth", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(health <= 0)
        {
            checkScore();
            SceneManager.LoadScene(11);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        healthbar.fillAmount = health;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (timer >= 1)
            {
                health -= 0.125f;
                timer = 0;
            }
        }

        if (other.gameObject.CompareTag("Biggy"))
        {
            if (timer >= 1)
            {
                health -= 0.25f;
                redTint.color.a = 1;
                timer = 0;
            }
        }
    }

    public void checkScore()
    {
        if(scene.name == "Endless")
        {
            if (gameManager.scoreNumber >= PlayerPrefs.GetInt("First"))
            {
                PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
                PlayerPrefs.SetInt("Fourth", PlayerPrefs.GetInt("Third"));
                PlayerPrefs.SetInt("Third", PlayerPrefs.GetInt("Second"));
                PlayerPrefs.SetInt("Second", PlayerPrefs.GetInt("First"));
                PlayerPrefs.SetInt("First", gameManager.scoreNumber);
            }
            else if (gameManager.scoreNumber >= PlayerPrefs.GetInt("Second"))
            {
                PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
                PlayerPrefs.SetInt("Fourth", PlayerPrefs.GetInt("Third"));
                PlayerPrefs.SetInt("Third", PlayerPrefs.GetInt("Second"));
                PlayerPrefs.SetInt("Second", gameManager.scoreNumber);
            }
            else if (gameManager.scoreNumber >= PlayerPrefs.GetInt("Third"))
            {
                PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
                PlayerPrefs.SetInt("Fourth", PlayerPrefs.GetInt("Third"));
                PlayerPrefs.SetInt("Third", gameManager.scoreNumber);
            }
            else if (gameManager.scoreNumber >= PlayerPrefs.GetInt("Fourth"))
            {
                PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
                PlayerPrefs.SetInt("Fourth", gameManager.scoreNumber);
            }
            else if (gameManager.scoreNumber >= PlayerPrefs.GetInt("Fifth"))
            {
                PlayerPrefs.SetInt("Fifth", gameManager.scoreNumber);
            }
        }
    }
}
