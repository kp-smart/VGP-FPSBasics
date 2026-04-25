using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float DelayLeft = 0f;
    public GameObject shootEffect;
    public Animator gunAnimator;
    public float ReloadTime = 3.0f;
    public int BulletsLeft;
    public Boolean isReloading = false;

    public TextMeshProUGUI numBulletsUI;

    public AudioPlayer audioPlayer;

    public string currentWeapon = "Pistol";
    public float BulletSpeed = 30.0f;
    public float StartingDelay = 0.5f;
    public int magSize = 6;
    public GameObject Pistol;
    public bool hasPistol = true;
    public GameObject Shovel;
    public bool hasShovel = true;

    private void Start()
    {
        BulletsLeft = magSize;
    }
    void Update()
    {
        //Switching weapons
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentWeapon != "Shovel" && hasShovel) {
                SwitchToShovel();
            } else if (currentWeapon != "Pistol" && hasPistol) {
                SwitchToPistol();
            }
        }

        //attacking
        if (Input.GetMouseButton(0))
        {
            if (currentWeapon == "Pistol")
            {
                if (BulletsLeft > 0 && isReloading == false)
                {
                    if (DelayLeft <= 0)
                    {
                        audioPlayer.PlayGunFire();
                        shootEffect.GetComponent<ParticleSystem>().Play(); //VFX
                        gunAnimator.SetTrigger("Recoil"); //Play recoil animation
                        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation); //spawns new bullet
                        bullet.SetActive(true); //make bullet visible
                        bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * BulletSpeed; //gives bullet speed
                        DelayLeft = StartingDelay;
                        BulletsLeft -= 1;
                    }

                    DelayLeft = DelayLeft - Time.deltaTime;
                }
            }

            if (currentWeapon == "Shovel")
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        numBulletsUI.text = "Bullets Remaining: " + BulletsLeft + " / " + magSize;
    }

    void Reload()
    {
        audioPlayer.PlayGunReload();
        isReloading = true;
        Invoke("ReloadCompleted", ReloadTime);
    }

    void ReloadCompleted()
    {
        BulletsLeft = magSize;
        isReloading = false;
    }

    void SwitchToPistol()
    {
        currentWeapon = "Pistol";
        Shovel.SetActive(false);
        Pistol.SetActive(true);
        magSize = 6;
        BulletsLeft = magSize;
        BulletSpeed = 30f;
        StartingDelay = 0.5f;
    }

    void SwitchToShovel()
    {
        currentWeapon = "Shovel";
        Pistol.SetActive(false);
        Shovel.SetActive(true);
    }

    /*
     if (WeaponType == "Double")
                {
                    if (DelayLeft <= 0)
                    {
                        Vector3 bullet1position = BulletSpawn.position;
    Vector3 bullet2position = BulletSpawn.position;
    bullet1position.x += 0.5f;
                        bullet2position.x -= 0.5f;
                        var bullet1 = Instantiate(BulletPrefab, bullet1position, BulletSpawn.rotation);
    var bullet2 = Instantiate(BulletPrefab, bullet2position, BulletSpawn.rotation);
    bullet1.SetActive(true);
                        bullet2.SetActive(true);
                        bullet1.GetComponent<Rigidbody>().velocity = Vector3.forward* BulletSpeed;
    bullet2.GetComponent<Rigidbody>().velocity = Vector3.forward* BulletSpeed;
    DelayLeft = FiringDelay;
                    }

DelayLeft = DelayLeft - Time.deltaTime;
                }
    */
}
