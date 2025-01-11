using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    AudioSource source;
    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>(); //Grabs the audiosource from this gameObject
        if (instance != null && instance != this) // When I go back to the main menu, there will be two audio managers. This prevents creating another one.
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject); // Keep the same audioManager gameObject throughout the whole game.
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if(scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3" || scene.name == "Endless") // Pause the music when on these levels
        {
            source.Pause();
        }
        else if(!source.isPlaying) // Otherwise play the music
        {
            source.UnPause();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
