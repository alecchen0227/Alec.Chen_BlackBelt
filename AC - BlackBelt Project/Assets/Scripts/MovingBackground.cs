using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    private float x1;
    private float x2;
    private float changeVariable;
    // Start is called before the first frame update
    void Start()
    {
        x1 = background1.transform.position.x;
        x2 = background2.transform.position.x;
        changeVariable = -1650;
    }

    // Update is called once per frame
    void Update()
    {
        background1.transform.position = new Vector3(x1, background1.transform.position.y, background1.transform.position.z);
        background2.transform.position = new Vector3(x2, background2.transform.position.y, background2.transform.position.z);
        x1 += 1;
        x2 += 1;
        if(x1 >= 2340)
        {
            x1 = changeVariable;
        }
        if(x2 >= 2340)
        {
            x2 = changeVariable;
        }
    }
}
