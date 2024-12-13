using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    // bullet
    public GameObject bullet;

    // bullet force
    public float shootForce, upwardForce;

    // Gun stats
    public float timeBetweenShooting, startingSpread, currentSpread, spreadMultiplier, maxSpread, reloadTime;
    public int magazineSize;
    public int damageValue;
    public int numberOfBullets;
    public bool allowButtonHold;

    // Current Gun
    public int currentGun;
    public int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Moving
    float currentHeight;

    // Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;
    // bug fixing
    public bool allowInvoke = true;

    // Sound
    private AudioSource Source;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    // Start is called before the first frame update
    public void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        currentHeight = transform.localPosition.y;
    }
    public void Awake()
    {
        // make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading == false && transform.localRotation.x <= 0)
        {
            if (currentGun == 0 || currentGun == 2 || currentGun == 4)
            {
                transform.Rotate(60 * Time.deltaTime, 0, 0);
            }
            else if (currentGun == 1 || currentGun == 5)
            {
                transform.Rotate(400 * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Rotate(500 * Time.deltaTime, 0, 0);
            }
        }


        transform.localPosition  = new Vector3(transform.localPosition.x, currentHeight + Mathf.Sin(Time.timeSinceLevelLoad*2) * 0.01f, transform.localPosition.z);
        CheckShooting();

        //Set ammo display, if it exists
        if(ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft + " / " + magazineSize);
        }

        if(currentSpread >= startingSpread)
        {
            currentSpread -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Takes a correct input and chooses either shooting or reloading
    /// </summary>
    private void CheckShooting()
    {
        // Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && Pause.pauseCondition) Reload();
        // Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        // shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0 && Pause.pauseCondition)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            shoot(); 
        }
    }

    private void shoot()
    {
        readyToShoot = false;
        transform.Rotate(-20, 0, 0);
        Source.clip = shootSound;
        Source.Play();
        
        // Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Just a ray through the middle of your screen
        RaycastHit hit;

        // chec k if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); // Just a point far away from the player

        // caculate direction from attackpoint to targetpoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        if(currentSpread <= maxSpread)
        {
            currentSpread += spreadMultiplier;
        }

        for(int i = 0; i < numberOfBullets; i++)
        {
            // Calculate spread
            float x = Random.Range(-currentSpread, currentSpread);
            float y = Random.Range(-currentSpread, currentSpread);
            
            // Calculate new direction with spread
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); // Add spread

            //Instantiate bullet/projectile
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);


            // Rotate bullet to shoot direction
            currentBullet.transform.forward = directionWithSpread.normalized;

            // Add forces to bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
            currentBullet.GetComponent<BulletEnemyCollision>().damageValue = damageValue;
        }
        
        // Instantiate muzzle flash, if you have one

        bulletsLeft--;
        bulletsShot++;

        // Invoke resetShot function
        if(allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        transform.Rotate(-45, 0, 0);
        Source.clip = reloadSound;
        Source.Play();
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        transform.Rotate(45, 0, 0);
        bulletsLeft = magazineSize;
        reloading = false;
    }

    
}