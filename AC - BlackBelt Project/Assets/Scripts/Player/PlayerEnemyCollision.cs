using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEnemyCollision : MonoBehaviour
{
    public GameManager gameManager;
    public float health = 1;
    public static float timer = 0;
    public Scene scene;
    public Image healthbar;
    public Vignette vignette;
    public PostProcessVolume volume;
    public List<int> scoreArray = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0;
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
        if(vignette.intensity > 0)
        {
            vignette.intensity.value -= 0.001f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Upon collision with an enemy, reset the timer to 0, decrease the player helath, and set the alpha to 0.5f and change the colour of the screen based on the alpha
        if (other.gameObject.CompareTag("Enemy"))
        {
            collision(0.125f);
        }

        if (other.gameObject.CompareTag("Biggy"))
        {
            collision(0.25f);
        }
    }

    public void checkScore() // If the scene was endless prior to death, see if any of the values on the highscore can be changed
    {
        if(scene.name == "Endless")
        {
            scoreArray.Add(gameManager.scoreNumber);
            scoreArray.Sort();
            PlayerPrefs.SetInt("Fifth", scoreArray[scoreArray.Count-5]);
            PlayerPrefs.SetInt("Fourth", scoreArray[scoreArray.Count-4]);
            PlayerPrefs.SetInt("Third", scoreArray[scoreArray.Count-3]);
            PlayerPrefs.SetInt("Second", scoreArray[scoreArray.Count-2]);
            PlayerPrefs.SetInt("First", scoreArray[scoreArray.Count-1]);
        }
    }

    public void collision(float subtractHealth)
    {
        if (timer >= 1)
        {
            timer = 0;
            health -= subtractHealth;
            vignette.intensity.value = 0.6f;
        }
    }
}
