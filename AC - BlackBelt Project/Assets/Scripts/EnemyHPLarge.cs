using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHPLarge : MonoBehaviour
{
    GameManager gameManager;
    public int hp;
    public GameObject healthbox;
    public PlayerEnemyCollision checker;
    public ParticleSystem particles;
    public ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        checker = Object.FindObjectOfType<PlayerEnemyCollision>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0)
        {
            int chance = Random.Range(0, 10);
            if (chance == 5 && checker.health < 7)
            {
                Instantiate(healthbox, transform.position, Quaternion.identity);
            }
            die();
            gameManager.scoreNumber += 50;
            gameManager.money += 50;
            gameManager.zombiesKilled++;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("projectile"))
        {
            hp -= collision.GetComponent<BulletEnemyCollision>().damageValue;
            particles.Play();
            Invoke("StopParticles", 0.5f);
        }
    }

    public void die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void StopParticles()
    {
        particles.Stop();
    }
}
