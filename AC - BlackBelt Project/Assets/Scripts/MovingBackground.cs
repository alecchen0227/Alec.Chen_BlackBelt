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
        x1 = 0;
        x2 = -2340;
        changeVariable = -2340;
    }

    // Update is called once per frame
    void Update()
    {
        // For the starting screen, move the x position of the background using two backgrounds
        background1.GetComponent<RectTransform>().localPosition = new Vector3(x1, background1.GetComponent<RectTransform>().localPosition.y, background1.transform.position.z);
        background2.GetComponent<RectTransform>().localPosition = new Vector3(x2, background2.GetComponent<RectTransform>().localPosition.y, background2.transform.position.z);
        x1 += 1;
        x2 += 1;
        // This number is hit, change the x value of that background to the changeVariable
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
