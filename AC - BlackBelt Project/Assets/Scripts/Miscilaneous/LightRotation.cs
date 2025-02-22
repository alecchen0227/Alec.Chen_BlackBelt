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
        light = GetComponent<Light>(); // get the light component
        light.enabled = false; // Turn the light off at start
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotate.rotation; // The light object and the player have the same rotation
        if (Input.GetKeyDown(KeyCode.F)) // When F is clicked, change the light enable state
        {
            light.enabled = !light.enabled;
        }
    }
}
