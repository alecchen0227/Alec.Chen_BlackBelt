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
        if (Input.GetMouseButtonDown(1))
        {
            gun.GetComponent<Animator>().Play("Gun");
        }
        if (Input.GetMouseButtonUp(1))
        {
            gun.GetComponent<Animator>().Play("New State");
        }
    }
}
