using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public float life = 3.0f;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Awake()
    {
        //healthBar = GameObject.Find("Player").GetComponent<HealthBar>();
        Destroy(gameObject, life);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            //gunShoot.enemyDestroyed++;
            double updatedHealth = healthBar.healthBarSprite.fillAmount - 0.2;
            healthBar.UpdateHealthBar(updatedHealth);
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }
}
