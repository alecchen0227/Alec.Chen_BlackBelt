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

    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            random = Random.Range(0, 2);
            switch (random)
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
