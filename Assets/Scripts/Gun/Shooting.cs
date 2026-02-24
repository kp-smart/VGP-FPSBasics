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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(DelayLeft <= 0)
            {
                var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation); //spawns new bullet
                bullet.SetActive(true); //make bullet appear
                bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * BulletSpeed; //gives bullet speed, same as new Vector 3 (0, 0, 30)
                DelayLeft = FiringDelay;
            }

            DelayLeft = DelayLeft - Time.deltaTime;

        }
    }
}
