using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    public WeaponManager weaponManager;
    public GameObject closeChest;
    public GameObject openChest;
    // Start is called before the first frame update
    void Start()
    {
        closeChest.SetActive(true);
        openChest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        closedChest();
        openedChest();
    }

    void closedChest()
    {
        if(weaponManager.Timer <= 0)
        {
            closeChest.SetActive(true);
            openChest.SetActive(false);
        }
    }

    void openedChest()
    {
        if (weaponManager.Timer > 0)
        {
            closeChest.SetActive(false);
            openChest.SetActive(true);
        }
    }
}
