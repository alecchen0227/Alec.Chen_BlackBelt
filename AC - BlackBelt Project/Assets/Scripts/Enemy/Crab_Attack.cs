using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crab_Attack : MonoBehaviour {

    public Animator animator;
    private int random = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnTriggerStay(Collider other)
    {
        if(PlayerEnemyCollision.timer >= 1 && other.gameObject.CompareTag("Player"))
        {
            random = Random.Range(0, 3);
            switch (random) // When the enemy touches my player, it chooses a random attack animation
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
