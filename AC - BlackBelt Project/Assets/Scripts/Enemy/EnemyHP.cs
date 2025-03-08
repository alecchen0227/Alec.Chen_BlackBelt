using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHP : MonoBehaviour
{
    GameManager gameManager;
    public float hp;
    public GameObject healthbox;
    public PlayerEnemyCollision checker;
    public ParticleSystem particles;
    public ParticleSystem deathParticles;
    public VisualIndicator visualIndicator;
    // Start is called before the first frame update
    void Start()
    {
        // Finds the gameObjects with these scripts in the hierarchy
        gameManager = Object.FindObjectOfType<GameManager>();
        checker = Object.FindObjectOfType<PlayerEnemyCollision>();
        visualIndicator = Object.FindObjectOfType<VisualIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        // When enemy is killed
        if(hp <= 0)
        {
            int chance = Random.Range(0, 7);
            if(chance == 5 && checker.health < 1)
            {
                // 1 in 8th chance to instantiate a healthbox
                Instantiate(healthbox, transform.position, Quaternion.identity);
            }
            visualIndicator.spawnTextRegular(); // Create a text in a random location on the canvas
            die();
            // update the number in the gameManager
            gameManager.scoreNumber += 10;
            gameManager.zombiesKilled++;
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // subtract the hp from the enemy and create particles upon onTrigger
        if(collision.gameObject.CompareTag("projectile"))
        {
            hp -= collision.GetComponent<BulletEnemyCollision>().damageValue;
            particles.Play();
            // Stop the particles after 0.5 seconds
            Invoke("StopParticles", 0.5f);
        }
    }

    public void die()
    {
        // Create particles and destroy the enemy
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void StopParticles()
    {
        particles.Stop();
    }
}
