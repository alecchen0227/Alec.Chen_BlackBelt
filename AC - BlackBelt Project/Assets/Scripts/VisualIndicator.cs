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

    public void spawnTextRegular() // This method is called in enemyHP. It will position a text in a random position in the canvas for 3 seconds. This happens when an enemy is killed.
    {
        int x = Random.Range(-400, 400);
        int y = Random.Range(-200, 200);
        GameObject visual = Instantiate(smallVisual, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        visual.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);
    }

    public void spawnTextBig() // This method is called in largeEnemyHP. It will position a text in a random position in the canvas for 3 seconds. THis happens when an enemy is killed.
    {
        int x = Random.Range(-400, 400);
        int y = Random.Range(-200, 200);
        GameObject visual = Instantiate(bigVisual, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        visual.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);
    }
}
