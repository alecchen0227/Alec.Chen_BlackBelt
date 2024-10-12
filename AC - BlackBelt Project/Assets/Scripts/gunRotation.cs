using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotation : MonoBehaviour
{
    public Transform rotate;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = rotate.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
