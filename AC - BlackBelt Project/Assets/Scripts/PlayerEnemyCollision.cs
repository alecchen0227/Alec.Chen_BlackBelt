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
    private float alphaTransparency;
    public List<int> scoreArray = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        scoreArray.Add(PlayerPrefs.GetInt("First", 0));
        scoreArray.Add(PlayerPrefs.GetInt("Second", 0));
        scoreArray.Add(PlayerPrefs.GetInt("Third", 0));
        scoreArray.Add(PlayerPrefs.GetInt("Fourth", 0));
        scoreArray.Add(PlayerPrefs.GetInt("Fifth", 0));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // update the timer for player and enemy collision
        healthbar.fillAmount = health; // keep updating the bar based on health
        if (health <= 0) // If the player dies it goes to checkScore method
        {
            checkScore();
            SceneManager.LoadScene(11); // Goes to gameover screen
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(redTint.color.a > 0) // Checks if the alpha is greater than 0, if so, decrease it back to 0 slowly
        {
            alphaTransparency -= 0.001f;
            redTint.color = new Color(redTint.color.r, redTint.color.g, redTint.color.b, alphaTransparency);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Upon collision with an enemy, reset the timer to 0, decrease the player helath, and set the alpha to 0.5f and change the colour of the screen based on the alpha
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (timer >= 1)
            {
                timer = 0;
                health -= 0.125f;
                alphaTransparency = 0.5f;
                redTint.color = new Color(redTint.color.r, redTint.color.g, redTint.color.b, alphaTransparency);
            }
        }

        if (other.gameObject.CompareTag("Biggy"))
        {
            if (timer >= 1)
            {
                timer = 0;
                health -= 0.25f;
                alphaTransparency = 0.5f;
                redTint.color = new Color(redTint.color.r, redTint.color.g, redTint.color.b, alphaTransparency);
            }
        }
    }

    public void checkScore() // If the scene was endless prior to death, see if any of the values on the highscore can be changed
    {
        if(scene.name == "Endless")
        {
            scoreArray.Add(gameManager.scoreNumber);
            scoreArray.Sort();

            PlayerPrefs.SetInt("Fifth", scoreArray[4]);
            PlayerPrefs.SetInt("Fourth", scoreArray[3]);
            PlayerPrefs.SetInt("Third", scoreArray[2]);
            PlayerPrefs.SetInt("Second", scoreArray[1]);
            PlayerPrefs.SetInt("First", scoreArray[0]);
        }
    }
}
