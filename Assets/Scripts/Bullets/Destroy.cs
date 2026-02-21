using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float bulletLifespan = 5.0f;

    // Awake is called when the gameObject is called
    void Awake()
    {
        Destroy(gameObject, bulletLifespan);
        //destroys bullet after 5 seconds
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            //destroys obstacle

            Destroy(gameObject);
            //destroys bullet
        }

    }
}
