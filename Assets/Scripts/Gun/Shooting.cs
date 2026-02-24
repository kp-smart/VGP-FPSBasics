using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float BulletSpeed = 30.0f;
    public float FiringDelay = 0.1f;
    public float DelayLeft = 0f;
    private string WeaponType = "Single";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (WeaponType == "Single")
            {
                WeaponType = "Double";
            }
            else
            {
                WeaponType = "Single";
            }

            Debug.Log(WeaponType);
        }


        if (Input.GetMouseButton(0))
        {
            if (WeaponType == "Single")
            {
                if (DelayLeft <= 0)
                {
                    var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation); //spawns new bullet
                    bullet.SetActive(true); //make bullet appear
                    bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * BulletSpeed; //gives bullet speed, same as new Vector 3 (0, 0, 30)
                    DelayLeft = FiringDelay;
                }
                DelayLeft = DelayLeft - Time.deltaTime;
            }
           
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
                    bullet1.GetComponent<Rigidbody>().velocity = Vector3.forward * BulletSpeed;
                    bullet2.GetComponent<Rigidbody>().velocity = Vector3.forward * BulletSpeed;
                    DelayLeft = FiringDelay;
                }
                DelayLeft = DelayLeft - Time.deltaTime;
            }
        }

        
    }
}
