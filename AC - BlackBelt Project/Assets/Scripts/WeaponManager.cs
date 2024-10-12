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
        gun.GetComponent<Gun>().timeBetweenShooting = gunTypes[4].timeBetweenShooting;
        gun.GetComponent<Gun>().startingSpread = gunTypes[4].startingSpread;
        gun.GetComponent<Gun>().currentSpread = gunTypes[4].currentSpread;
        gun.GetComponent<Gun>().spreadMultiplier = gunTypes[4].spreadMultiplier;
        gun.GetComponent<Gun>().maxSpread = gunTypes[4].maxSpread;
        gun.GetComponent<Gun>().reloadTime = gunTypes[4].reloadTime;
        gun.GetComponent<Gun>().timeBetweenShots = gunTypes[4].timeBetweenShots;
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
        if(checker == true && Timer <= 0)
        {
            lootBoxChecker.text = "Press [E] to spend $100 for a random gun";
            if (Input.GetKeyDown(ChangeWeapon) && gameManager.money >= 100)
            {
                weaponModel[0].SetActive(false);
                weaponModel[1].SetActive(false);
                weaponModel[2].SetActive(false);
                weaponModel[3].SetActive(false);
                weaponModel[4].SetActive(false);
                weaponModel[5].SetActive(false);
                int option = Random.Range(0, gunTypes.Length);
                while (option == gunNumber.currentGun)
                {
                    option = Random.Range(0, gunTypes.Length);
                }
                // Change Gun Stat and Name 
                gunnName.text = gunTypes[option].gunName;
                weaponModel[option].SetActive(true);
                gun.GetComponent<Gun>().timeBetweenShooting = gunTypes[option].timeBetweenShooting;
                gun.GetComponent<Gun>().startingSpread = gunTypes[option].startingSpread;
                gun.GetComponent<Gun>().currentSpread = gunTypes[option].currentSpread;
                gun.GetComponent<Gun>().spreadMultiplier = gunTypes[option].spreadMultiplier;
                gun.GetComponent<Gun>().maxSpread = gunTypes[option].maxSpread;
                gun.GetComponent<Gun>().reloadTime = gunTypes[option].reloadTime;
                gun.GetComponent<Gun>().timeBetweenShots = gunTypes[option].timeBetweenShots;
                gun.GetComponent<Gun>().magazineSize = gunTypes[option].magazineSize;
                gun.GetComponent<Gun>().bulletsLeft = gunTypes[option].magazineSize;
                gun.GetComponent<Gun>().damageValue = gunTypes[option].damageValue;
                gun.GetComponent<Gun>().numberOfBullets = gunTypes[option].numberOfBullets;
                gunNumber.currentGun = option;
                gameManager.money -= 100;
                Timer += 5;
            }
        }
    }
    /// <summary>
    /// Changes the type of gun you are using
    /// </summary>

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checker = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lootBoxChecker.text = null;
        checker = false;
    }
}
