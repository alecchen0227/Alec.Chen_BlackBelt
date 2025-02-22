using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script plays the source after a healthbox is collected. It will play the sound and then destroy itself after 3 seconds
public class Noise : MonoBehaviour
{
    AudioSource source;
    public AudioClip healthClip;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = healthClip;
        source.Play();
        Invoke("destroy", 3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
