using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float bulletLifespan = 5.0f;

    public Movement myPlayer;

    public AudioPlayer audioPlayer;
    public GameObject EnemyDyingSource;

    // Awake is called when the gameObject is called
    void Awake()
    {
        Destroy(gameObject, bulletLifespan); //destroys bullet after 5 seconds

        //myPlayer = GameObject.Find("Player").GetComponent<Movement>();
        //drag and drop preferred, but this works as well
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemyVar = collision.gameObject.GetComponent<SelfVariables>();


        if (enemyVar != null && enemyVar.healthbar != null)
        {
            double updatedHealth = enemyVar.healthbar.healthBarSprite.fillAmount - 0.5f;
            enemyVar.healthbar.UpdateHealthBar(updatedHealth);
        }

        if (collision.gameObject.tag == "Enemy" && enemyVar.healthbar.isDead)
        {
            EnemyDyingSource.transform.position = collision.gameObject.transform.position;
            audioPlayer.PlayEnemyDying();

            //Destroy(collision.gameObject); //destroys enemy

            Destroy(gameObject); //destroys bullet
            

            myPlayer.numKills++;
        }

    }
}
