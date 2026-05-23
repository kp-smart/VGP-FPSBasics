using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Shooting : MonoBehaviour
{
    public GameObject Pistol;
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float BulletSpeed = 30.0f;
    public float bulletSpread;
    public int BulletsLeft;
    public int magSize = 6;
    public float StartingDelay = 0.5f;
    public float DelayLeft = 0f;
    public Boolean isReloading = false;
    public float ReloadTime = 3.0f;
    public GameObject shootEffect;
    public Animator gunAnimator;

    public TextMeshProUGUI numBulletsUI;
    public AudioPlayer audioPlayer;

    public string currentWeapon = "Pistol";
    public bool hasPistol = true;
    public bool hasShovel = true;

    public GameObject Shovel;
    public bool canSlash = true;
    public float slashCooldown = 2.0f;
    public Collider ShovelCollider;
    
    private void Start()
    {
        BulletsLeft = magSize;
    }
    void Update()
    {
        //Switching weapons
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentWeapon == "Pistol" && hasShovel)
            {
                SwitchToShovel();
            } 
            else if (currentWeapon == "Shovel" && hasPistol) 
            {
                SwitchToPistol();
            }
        }

        
        if (Input.GetMouseButton(0))
        {
            if (currentWeapon == "Pistol")
            {
                if (BulletsLeft > 0 && isReloading == false)
                {
                    if (DelayLeft <= 0)
                    {
                        audioPlayer.PlayGunFire(); //SFX
                        shootEffect.GetComponent<ParticleSystem>().Play(); //VFX
                        gunAnimator.SetTrigger("Recoil"); //Play recoil animation
                        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation); //spawns new bullet
                        bullet.SetActive(true); //make bullet visible

                        //Vector3 bulletDirection = GetBulletDirection();
                        //bullet.transform.rotation = Quaternion.LookRotation(bulletDirection);
                        bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * BulletSpeed; //gives bullet speed      prev BulletSpawn.forward
                        DelayLeft = StartingDelay;
                        BulletsLeft -= 1;
                    }

                    DelayLeft = DelayLeft - Time.deltaTime;
                }
            }

            if (currentWeapon == "Shovel")
            {
                if (canSlash)
                {
                    Slash();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        numBulletsUI.text = "Bullets Remaining: " + BulletsLeft + " / " + magSize;
    }
    private Vector3 GetBulletDirection()
    {
        float spreadAmount = Mathf.Max(0f, bulletSpread);
        Vector2 randomSpread = UnityEngine.Random.insideUnitCircle * spreadAmount;
        Quaternion spreadRotation = BulletSpawn.rotation * Quaternion.Euler(randomSpread.y, randomSpread.x, 0f);

        return (spreadRotation * Vector3.forward).normalized;
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

    void SwitchToShovel()
    {
        currentWeapon = "Shovel";
        Pistol.SetActive(false);
        Shovel.SetActive(true);
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

    void Slash()
    {
        canSlash = false;
        ShovelCollider.enabled = true;
        Animator anim = Shovel.GetComponent<Animator>();
        anim.SetTrigger("CanSlash");  
        audioPlayer.PlayShovelSlash();
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(slashCooldown);
        ShovelCollider.enabled = false;
        canSlash = true;
    }
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

