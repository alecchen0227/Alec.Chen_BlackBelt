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

    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
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
