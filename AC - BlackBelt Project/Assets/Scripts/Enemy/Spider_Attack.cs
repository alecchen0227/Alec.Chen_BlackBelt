using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Attack : MonoBehaviour
{
    public Animator animator;
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
        if (PlayerEnemyCollision.timer >= 1 && other.gameObject.CompareTag("Player")) // WHen the enemy touches the player, it will play an attack animation
        {
            animator.Play("Attack");
        }
    }
}
