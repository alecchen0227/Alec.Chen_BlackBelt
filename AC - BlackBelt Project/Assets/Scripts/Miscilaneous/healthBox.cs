using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBox : MonoBehaviour
{
    public PlayerEnemyCollision touchingHeart;
    public GameObject noiseMaker;
    // Start is called before the first frame update
    void Start()
    {
        touchingHeart = Object.FindObjectOfType<PlayerEnemyCollision>(); // Takes a reference to the player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // If the healthbox touches the player
        {
            if(touchingHeart.health < 1)
            {
                touchingHeart.health += 0.125f; // Increase the player's hp
            }
            Instantiate(noiseMaker, transform.position, Quaternion.identity); // Create a sound
            Destroy(gameObject); // Destroy the health gameObject
        }
    }
}
