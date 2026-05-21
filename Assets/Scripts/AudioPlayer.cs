using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource GunSource;
    public AudioSource EnemySource;
    public AudioSource ShovelSource;

    public AudioClip gunFire;
    public AudioClip gunReload;
    public AudioClip enemyDying;
    public AudioClip shovelSlash;

    public void PlayGunFire()
    {
        GunSource.clip = gunFire;
        GunSource.Play();
    }
    public void PlayGunReload()
    {
        GunSource.clip = gunReload;
        GunSource.Play();
    }
    public void PlayEnemyDying()
    {
        EnemySource.clip = enemyDying;
        EnemySource.Play();
    }

    public void PlayShovelSlash()
    {
        //ShovelSource.clip = shovelSlash;
        //ShovelSource.Play();
    }

   
}
