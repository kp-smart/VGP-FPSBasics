using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");

        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Debug.Log("Coin get!");
        }
    }
}
