using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slashing : MonoBehaviour
{
    public AudioPlayer audioPlayer;
    public GameObject EnemyDyingSource;
    public Movement myPlayer;
    public HealthBar enemyhealthbar;

    private void OnTriggerStay(Collider collision)
    {
        var enemyVar = collision.gameObject.GetComponent<SelfVariables>();
        enemyhealthbar = enemyVar.healthbar;

            
        if (enemyVar != null && enemyVar.healthbar != null) 
        {     
            double updatedHealth = enemyVar.healthbar.healthBarSprite.fillAmount - 0.5f;   
            enemyVar.healthbar.UpdateHealthBar(updatedHealth);
        }

           
        if (collision.gameObject.tag == "Enemy" && enemyVar.healthbar.isDead) 
        {
            EnemyDyingSource.transform.position = collision.gameObject.transform.position;
            audioPlayer.PlayEnemyDying();
            myPlayer.numKills++;
        }
    }
}
