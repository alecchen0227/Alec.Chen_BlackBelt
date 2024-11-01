using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    Light light;
    public Transform rotate;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotate.rotation;
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.enabled = !light.enabled;
        }
    }
}
