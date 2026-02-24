using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Destroy : MonoBehaviour
{
    public float bulletLifespan = 5.0f;

    public Movement myPlayer;

    // Awake is called when the gameObject is called
    void Awake()
    {
        Destroy(gameObject, bulletLifespan);
        //destroys bullet after 5 seconds

        //myPlayer = GameObject.Find("Player").GetComponent<Movement>();
        //drag and drop preferred, but this works as well
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            //destroys obstacle
            Destroy(gameObject);
            //destroys bullet

            myPlayer.numKills++;
        }

    }
}
