using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("disappear", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void disappear()
    {
        Destroy(gameObject);
    }
}
