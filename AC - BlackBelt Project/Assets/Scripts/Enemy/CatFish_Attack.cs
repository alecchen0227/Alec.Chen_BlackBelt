using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFish_Attack : MonoBehaviour
{
    public Animator animator;
    private int random;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(PlayerEnemyCollision.timer >= 1 && other.gameObject.CompareTag("Player"))
        {
            random = Random.Range(0, 2); 
            switch (random) // When the enemy touches player, it picks a random attack animation
            {
                case 0:
                    animator.Play("Attack1");
                    break;

                case 1:
                    animator.Play("Attack2");
                    break;
            }
        }
    }
}
