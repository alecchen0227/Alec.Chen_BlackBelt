using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject enemies;
    public GameObject[] spawner;
    public GameObject largeEnemy;
    public GameObject scroll;
    public TMP_Text scrollText;
    float timer = 0;
    public int waveNumber = 1;
    public float timerChanger;
    public int zombiesKilled = 0;
    public int numberOfBiggies = 1;
    public int money = 0;
    public TMP_Text moneyChecker;
    /*
     Increase score when an enemy dies from projectile
    */
    public TMP_Text score;
    public int scoreNumber;
    public Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene(); // Make scene this scene
        PlayerPrefs.GetInt("PreviousLevel", 0);
        PlayerPrefs.GetInt("HighestLevel", 0);
        if(scene.name == "Endless")
        {
            scrollText.text = "Survive as Many Waves as Possible!";
            Invoke("removeScroll", 10);
        }
        else
        {
            scrollText.text = "Gather 500 Points to Win!";
            Invoke("removeScroll", 10);
        }
    }

    void removeScroll()
    {
        scroll.SetActive(false); // removes the scroll in endless mode after 10 seconds
    }
    // Update is called once per frame
    void Update()
    {
        if(scene.name == "Endless")
        {
            score.text = "Score: " + scoreNumber;
        }
        else
        {
            score.text = "Score: " + scoreNumber + "/500";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moneyChecker.text = "$" + money; // Update the amount of money
        timer += Time.deltaTime;
        if (timer >= timerChanger) // After an x number of seconds, go to creator method
        {
            creator();
            timer = 0;
        }

        if (zombiesKilled == waveNumber * 10) // On endless, there are waves, it changes every 10 kills
        {
            waveNumber++;
            timerChanger -= 0.2f; // Decrease the timer that it takes to spawn enemies
            if (waveNumber % 5 == 0) // Create a large enemy every 5 waves. Every 5 waves, the number of large enemies will increase by 10. i.e. 2 large enemies on wave 10
            {
                for (int i = 0; i < numberOfBiggies; i++)
                {
                    int spawnerNumber = Random.Range(0, spawner.Length);
                    Instantiate(largeEnemy, spawner[spawnerNumber].transform.position, Quaternion.identity);
                }
                numberOfBiggies++;
            }
        }
        // When the player beats the level, take player to winning map and make a next level button except for level 3
        // PreviousLevel playerPref takes the value and transitions the player to the next level
        if (scene.name == "Level 1" && scoreNumber >= 500) 
        {
            PlayerPrefs.SetInt("HighestLevel", 2);
            PlayerPrefs.SetInt("Button", 0);
            PlayerPrefs.SetInt("PreviousLevel", 8);
            SceneManager.LoadScene(12);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (scene.name == "Level 2" && scoreNumber >= 500)
        {
            PlayerPrefs.SetInt("HighestLevel", 3);
            PlayerPrefs.SetInt("Button", 0);
            PlayerPrefs.SetInt("PreviousLevel", (int)SceneTransition.LevelNumbers.Level2);
            SceneManager.LoadScene(12);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (scene.name == "Level 3" && scoreNumber >= 500)
        {
            PlayerPrefs.SetInt("HighestLevel", 4);
            PlayerPrefs.SetInt("Button", 1);
            SceneManager.LoadScene(12);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void creator()
    {
        int spawnerNumber = Random.Range(0, spawner.Length); // Picks either spawner 1, 2, 3, or 4
        int enemyType = Random.Range(0, 25); // Spawns an enemy
        if(enemyType == 12)
        {
            Instantiate(largeEnemy, spawner[spawnerNumber].transform.position, Quaternion.identity); // If enemyType is 12, it will spawn a large enemy
        }
        else
        {
             Instantiate(enemies, spawner[spawnerNumber].transform.position, Quaternion.identity); // Otherwise spawn regular enemies
        }
    }
}
