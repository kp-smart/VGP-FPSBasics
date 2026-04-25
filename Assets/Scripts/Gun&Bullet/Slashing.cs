using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slashing : MonoBehaviour
{
    public AudioPlayer audioPlayer;
    public GameObject EnemyDyingSource;
    public Movement myPlayer;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("can collide");
        /*
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
        */
    }
}
