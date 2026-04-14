using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource GunSource;
    public AudioSource EnemySource;

    public AudioClip gunFire;
    public AudioClip gunReload;
    public AudioClip enemyDying;

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

   
}
