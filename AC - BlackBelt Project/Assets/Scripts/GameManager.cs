using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject enemies;
    public GameObject[] spawner;
    public GameObject largeEnemy;
    float timer = 0;
    public int waveNumber = 1;
    public float timerChanger;
    public TMP_Text wave;
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
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.GetInt("PreviousLevel", 0);
        PlayerPrefs.GetInt("Level1Finish", 0);
        PlayerPrefs.GetInt("Level2Finish", 0);
        PlayerPrefs.GetInt("Level3Finish", 0);
        if(scene.name == "Endless")
        {
            Invoke("waveDisappear", 3);
        }
        else
        {
            wave.text = "";
        }
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
        moneyChecker.text = "$" + money;
        timer += Time.deltaTime;
        if (timer >= timerChanger)
        {
            creator();
            timer = 0;
        }

        if (scene.name == "Endless")
        {
            if (zombiesKilled == waveNumber * 10)
            {
                waveNumber++;
                wave.text = "Wave " + waveNumber;
                timerChanger -= 0.2f;
                Invoke("waveDisappear", 3);
                if (waveNumber % 5 == 0)
                {
                    for (int i = 0; i < numberOfBiggies; i++)
                    {
                        int spawnerNumber = Random.Range(0, spawner.Length);
                        Instantiate(largeEnemy, spawner[spawnerNumber].transform.position, Quaternion.identity);
                    }
                    numberOfBiggies++;
                }
            }
        }
        else
        {
            if (zombiesKilled == waveNumber * 10)
            {
                waveNumber++;
                timerChanger -= 0.2f;
                if (waveNumber % 5 == 0)
                {
                    for (int i = 0; i < numberOfBiggies; i++)
                    {
                        int spawnerNumber = Random.Range(0, spawner.Length);
                        Instantiate(largeEnemy, spawner[spawnerNumber].transform.position, Quaternion.identity);
                    }
                    numberOfBiggies++;
                }
            }
        }

        if(scene.name == "Level 1" && scoreNumber >= 500)
        {
            PlayerPrefs.SetInt("Level1Finish", 1);
            PlayerPrefs.SetInt("Button", 0);
            PlayerPrefs.SetInt("PreviousLevel", 8);
            SceneManager.LoadScene(12);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (scene.name == "Level 2" && scoreNumber >= 500)
        {
            PlayerPrefs.SetInt("Level2Finish", 1);
            PlayerPrefs.SetInt("Button", 0);
            PlayerPrefs.SetInt("PreviousLevel", (int)SceneTransition.LevelNumbers.Level2);
            SceneManager.LoadScene(12);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (scene.name == "Level 3" && scoreNumber >= 500)
        {
            PlayerPrefs.SetInt("Level3Finish", 1);
            PlayerPrefs.SetInt("Button", 1);
            SceneManager.LoadScene(12);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void creator()
    {
        int spawnerNumber = Random.Range(0, spawner.Length);
        int enemyType = Random.Range(0, 25);
        if(enemyType == 12)
        {
            Instantiate(largeEnemy, spawner[spawnerNumber].transform.position, Quaternion.identity);
        }
        else
        {
             Instantiate(enemies, spawner[spawnerNumber].transform.position, Quaternion.identity);
        }
    }
    public void waveDisappear()
    {
        wave.text = null;
    }
}
