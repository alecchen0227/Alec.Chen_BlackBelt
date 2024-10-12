using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletEnemyCollision : MonoBehaviour
{
    // Referencing GameManager Script
    GameManager gameManager;
    public int damageValue;
    // Start is called before the first frame update
    void Start()
    {
        // Finding an object with this gameManager script
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Biggy"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
