using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    public Transform transformObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transformObject.position; 
    }
}
