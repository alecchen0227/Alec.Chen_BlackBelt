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
        source = gameObject.GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3" || scene.name == "Endless")
        {
            source.Pause();
        }
        else if(!source.isPlaying)
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
