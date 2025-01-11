using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc_Attack : MonoBehaviour
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
        if (PlayerEnemyCollision.timer >= 1 && other.gameObject.CompareTag("Player")) // If the enemy touches the enemy, pick a random attack animation
        {
            random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    animator.Play("Attack1");
                    break;

                case 1:
                    animator.Play("Attack2");
                    break;

                case 2:
                    animator.Play("Attack3");
                    break;
            }
        }
    }
}
