using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float BulletSpeed = 30.0f;
    public float StartingDelay = 0.1f;
    public float DelayLeft = 0f;
    private string WeaponType = "Single";
    public GameObject shootEffect;
    public Animator gunAnimator;
    public float ReloadTime = 3.0f;
    public int StartingBulletNum = 6;
    public int BulletsLeft;
    public Boolean isReloading = false;
    public TextMeshProUGUI numBulletsUI;
    // Update is called once per frame

    private void Start()
    {
        BulletsLeft = StartingBulletNum;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (WeaponType == "Single")
            {
                WeaponType = "Double";
            }
            else
            {
                WeaponType = "Single";
            }
        }

        
        if (Input.GetMouseButton(0))
        {
            if (BulletsLeft > 0 && isReloading == false)
            {
                if (WeaponType == "Single")
                {
                    if (DelayLeft <= 0)
                    {
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
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        numBulletsUI.text = "Bullets Remaining: " + BulletsLeft + " / " + StartingBulletNum;
    }

    void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", ReloadTime);
    }

    void ReloadCompleted()
    {
        BulletsLeft = StartingBulletNum;
        isReloading = false;
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
