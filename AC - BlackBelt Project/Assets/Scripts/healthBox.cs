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
        touchingHeart = Object.FindObjectOfType<PlayerEnemyCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(touchingHeart.health < 7)
            {
                Instantiate(noiseMaker, transform.position, Quaternion.identity);
                Destroy(gameObject);
                touchingHeart.health++;
                touchingHeart.hearts[touchingHeart.health].SetActive(true);
            }
        }
    }
}
