using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bulletUpgrade;
    GameObject theBullet;
    bool bulletUpgradeActive = false;
    public float bulletSpeed = 10.0f;
    public float bulletLifeTime = 1.0f;
    public float shootDelay = 0.5f;
    public float reduceShootDelay = 0.25f;
    float timer = 0;
    float reloadtime = 0;
    public int ammoCount = 10;
    public int maxAmmo = 10;
    int absoluteMaxAmmo = 25;
    public int capacityIncrease = 5;
    public int ammoBoxAmmount = 2;
    public bool upgradesCarryOver = true;
    public bool bulletsCarryOver = false;
    bool direction;
    int frame;
    public int gunUpgradeLevel;
    GameObject ammoPickup;
    GameObject ammoFullMessage;
    public Text bulletsText;
    public Button Shoot;

    // Start is called before the first frame update
    void Start()
    {
        bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
        theBullet = bullet1;
        ammoPickup = GameObject.FindGameObjectWithTag("AmmoPickup");
        ammoFullMessage = GameObject.FindGameObjectWithTag("AmmoFull");
    }

    // Update is called once per frame
    void Update()
    {
        reloadtime += Time.deltaTime;
        timer += Time.deltaTime;
        if (reloadtime > 2 && ammoCount < 10)
        {
            ammoCount++;
            bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
            reloadtime = 0;
        }
    }
    public void Fire()
    {
        direction = gameObject.GetComponent<PlatformerMovement>().dir;
        float x = Input.GetAxisRaw("Horizontal");
        if (timer > shootDelay && ammoCount > 0)
        {
            timer = 0;
            GameObject bullet = Instantiate(theBullet, transform.position, Quaternion.identity);
            ammoCount--;
            bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
            if (x > 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }

            if (x < 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            else if (x == 0 && direction == true)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }
            else if (x == 0 && direction == false)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            Destroy(bullet, bulletLifeTime);
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ammo" && ammoCount < 10)
        {
            ammoCount++;
            Destroy(collision.gameObject);
        }
    } */

}
