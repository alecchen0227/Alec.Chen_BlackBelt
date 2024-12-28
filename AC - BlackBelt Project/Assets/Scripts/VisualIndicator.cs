using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualIndicator : MonoBehaviour
{
    public GameObject smallVisual;
    public GameObject bigVisual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnTextRegular()
    {
        int x = Random.Range(-400, 400);
        int y = Random.Range(-200, 200);
        GameObject visual = Instantiate(smallVisual, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        visual.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);
        print("working");
    }

    public void spawnTextBig()
    {
        int x = Random.Range(-400, 400);
        int y = Random.Range(-200, 200);
        GameObject visual = Instantiate(bigVisual, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        visual.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);
        print("working2");
    }
}
