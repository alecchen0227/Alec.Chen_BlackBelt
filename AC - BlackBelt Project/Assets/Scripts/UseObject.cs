using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : MonoBehaviour
{
    public ScriptObject[] scriptobjects;
    // Start is called before the first frame update
    void Start()
    {
       // scriptobjects[0].prefabName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //other.GetComponent<Projectile>().reloadTime = scriptobjects[0].numberOfPrefabsToCreate;
    }
}
