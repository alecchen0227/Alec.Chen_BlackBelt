    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotation : MonoBehaviour
{
    public Transform rotate;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = rotate.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // When right click is held or pressed
        {
            gun.GetComponent<Animator>().Play("Gun"); // play the animation which moves the gun to the middle
        }
        if (Input.GetMouseButtonUp(1)) // WHen right click is not held or pressed
        {
            gun.GetComponent<Animator>().Play("New State"); // play the animation which returns the gun to it's original state
        }
    }
}
