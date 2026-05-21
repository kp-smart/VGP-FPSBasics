using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Movement myPlayer;

    public AudioPlayer audioPlayer;
    public GameObject EnemyDyingSource;

    //public SelfVariables enemyHealthbar;
    //public HealthBar healthBar;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("testslash");
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

            myPlayer.numKills++;
        }

    }
}
