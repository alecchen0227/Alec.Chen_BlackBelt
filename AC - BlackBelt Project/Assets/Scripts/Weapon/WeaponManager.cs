using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public ScriptObject[] gunTypes;
    public GameObject gun;
    public Gun gunNumber;
    public GameObject[] weaponModel;
    public TMP_Text gunnName;
    public TMP_Text lootBoxChecker;
    public GameManager gameManager;
    private KeyCode ChangeWeapon = KeyCode.E;
    private bool checker;
    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // intial Gun Stats
        weaponModel[0].SetActive(false);
        weaponModel[1].SetActive(false);
        weaponModel[2].SetActive(false);
        weaponModel[3].SetActive(false);
        weaponModel[4].SetActive(true);
        weaponModel[5].SetActive(false);
        gunnName.text = gunTypes[4].gunName;
        gunNumber.currentGun = 4;
        gun.GetComponent<Gun>().timeBetweenShooting = gunTypes[4].timeBetweenShooting;
        gun.GetComponent<Gun>().startingSpread = gunTypes[4].startingSpread;
        gun.GetComponent<Gun>().currentSpread = gunTypes[4].currentSpread;
        gun.GetComponent<Gun>().spreadMultiplier = gunTypes[4].spreadMultiplier;
        gun.GetComponent<Gun>().maxSpread = gunTypes[4].maxSpread;
        gun.GetComponent<Gun>().reloadTime = gunTypes[4].reloadTime;
        gun.GetComponent<Gun>().magazineSize = gunTypes[4].magazineSize;
        gun.GetComponent<Gun>().damageValue = gunTypes[4].damageValue;
        gun.GetComponent<Gun>().numberOfBullets = gunTypes[4].numberOfBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if(checker == true && Timer <= 0) // If the 5 second timer is at 0 or less.
        {
            lootBoxChecker.text = "Press [E] to use 100 points for a random gun"; // Project this text
            if (Input.GetKeyDown(ChangeWeapon) && gameManager.scoreNumber >= 100) // if E is pressed and money is >= 100
            {
                // Turn off the guns
                weaponModel[0].SetActive(false); 
                weaponModel[1].SetActive(false);
                weaponModel[2].SetActive(false);
                weaponModel[3].SetActive(false);
                weaponModel[4].SetActive(false);
                weaponModel[5].SetActive(false);
                int option = Random.Range(0, gunTypes.Length);
                while (option == gunNumber.currentGun)
                {
                    option = Random.Range(0, gunTypes.Length); // Make sure option is not the same gun as the current gun
                }
                // Change Gun Stat and Name to the new gun stats
                gunnName.text = gunTypes[option].gunName;
                weaponModel[option].SetActive(true);
                gun.GetComponent<Gun>().timeBetweenShooting = gunTypes[option].timeBetweenShooting;
                gun.GetComponent<Gun>().startingSpread = gunTypes[option].startingSpread;
                gun.GetComponent<Gun>().currentSpread = gunTypes[option].currentSpread;
                gun.GetComponent<Gun>().spreadMultiplier = gunTypes[option].spreadMultiplier;
                gun.GetComponent<Gun>().maxSpread = gunTypes[option].maxSpread;
                gun.GetComponent<Gun>().reloadTime = gunTypes[option].reloadTime;
                gun.GetComponent<Gun>().magazineSize = gunTypes[option].magazineSize;
                gun.GetComponent<Gun>().bulletsLeft = gunTypes[option].magazineSize;
                gun.GetComponent<Gun>().damageValue = gunTypes[option].damageValue;
                gun.GetComponent<Gun>().numberOfBullets = gunTypes[option].numberOfBullets;
                gunNumber.currentGun = option; // Switch current gun to option
                gameManager.scoreNumber -= 100; // Take out score
                Timer += 5;
            }
        }
    }
    /// <summary>
    /// Changes the type of gun you are using
    /// </summary>

    private void OnTriggerStay(Collider other) // When entering the trigger, set checker to true
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            checker = true;
        }
    }

    private void OnTriggerExit(Collider other) // WHen exiting the trigger, set checker to false and remove the text
    {
        lootBoxChecker.text = null;
        checker = false;
    }
}
